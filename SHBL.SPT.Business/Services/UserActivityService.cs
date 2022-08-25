using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Dto;
using SHBL.SPT.Model.General;
using SHBL.SPT.Model.Word;

namespace SHBL.SPT.Business.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly SptContext _context;

        public UserActivityService()
        {
            _context = new SptContext();
        }

        public async Task<List<SptUserActivityDetail>> GetUserActivityDetailAsync(string username, byte activityId, byte session)
        {
            var user = await _context.SptUsers.Include(u => u.SptUserActivities)
                .SingleAsync(u => u.Username == username);

            var activity = await _context.Activities.SingleAsync(t => t.Id == activityId && t.ActivitySession == session);

            return user.SptUserActivities.Single(t => t.ActivityId == activity.Id).SptUserActivityDetails.ToList();
        }

        public async Task<SptUserActivity> GetLatestUserActivityAsync(string username)
        {
            var user = await _context.SptUsers.Include(u => u.SptUserActivities)
                .SingleAsync(u => u.Username == username);

            return user.SptUserActivities.Where(a => a.FinishDate != null).OrderByDescending(a => a.FinishDate)
                .FirstOrDefault();
        }

        public async Task AddActivityAsync(string username, byte activityId)
        {
            var user = await _context.SptUsers.SingleAsync(u => u.Username == username);
            var activity = await _context.Activities.FindAsync(activityId);
            if (activity == null) throw new NullReferenceException();

            var userActivity = new SptUserActivity
            {
                SptUser = user,
                Activity = activity,
                StartDate = DateTime.Now
            };

            var wordSpeakers = _context.WordSpeakers.AsQueryable();
            if (activity.IsTest)
            {
                wordSpeakers = wordSpeakers
                    .Where(t => t.Word.TestOnly && t.Speaker.TestOnly == false)
                    .Union(wordSpeakers.Where(t => t.Word.TestOnly == false)).OrderBy(t => Guid.NewGuid());
            }
            else
                wordSpeakers = wordSpeakers.Where(t => t.Speaker.TestOnly == false && t.Word.TestOnly == false)
                    .OrderBy(t => Guid.NewGuid());

            foreach (var ws in wordSpeakers)
            {
                userActivity.SptUserActivityDetails.Add(new SptUserActivityDetail
                {
                    SptUserActivity = userActivity,
                    WordSpeaker = ws
                });
            }

            _context.SptUserActivities.Add(userActivity);
            await _context.SaveChangesAsync();
        }

        public async Task<UpdateQuestionDto> UpdateQuestionAsync(int questionId, string chosenWord)
        {
            try
            {
                var dto = new UpdateQuestionDto();
                var question = await _context.SptUserActivityDetails.FindAsync(questionId);
                if (question == null) throw new NullReferenceException();

                if (question.WordSpeaker.Word.WordEntry == chosenWord)
                {
                    question.Result = true;
                    dto.Result = true;
                    dto.FileNameOne = null;
                    dto.FileNameTwo = null;
                    dto.CfFileNameOne = null;
                    dto.CfFileNameTwo = null;
                }
                else
                {
                    dto.Result = false;
                    question.Result = false;
                    dto.FileNameOne = question.WordSpeaker.FileName;
                    dto.FileNameTwo = (await _context.WordSpeakers.Where(ws =>
                            ws.Word.Id == question.WordSpeaker.Word.Pair.Id &&
                            ws.Speaker.Id == question.WordSpeaker.Speaker.Id)
                        .SingleAsync()).FileName;

                    var speaker = question.WordSpeaker.Speaker;
                    var speakerMtoF = speaker.SpeakerName.Replace("M", "F");
                    var speakerFtoM = speaker.SpeakerName.Replace("F", "M");
                    if (speaker.SpeakerName.Contains("M"))
                        speaker = await _context.Speakers.Where(t => t.SpeakerName == speakerMtoF).SingleAsync();
                    else
                        speaker = await _context.Speakers.Where(t => t.SpeakerName == speakerFtoM).SingleAsync();

                    var cFTypeSpeaker = await _context.CFTypeSpeakers.Where(t =>
                            t.Speaker.Id == speaker.Id && t.CFType.Id == question.SptUserActivity.SptUser.Person.CFType.Id)
                        .FirstOrDefaultAsync();
                    dto.CfFileNameOne = cFTypeSpeaker?.FileName1;
                    dto.CfFileNameTwo = cFTypeSpeaker?.FileName2;
                }

                _context.Entry(question).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                if ((await _context.SptUserActivityDetails.CountAsync(t => t.UserActivityId == question.UserActivityId && t.Result == null)) == 0)
                {
                    var userActivity = await _context.SptUserActivities.FirstAsync(t => t.Id == question.UserActivityId);
                    userActivity.FinishDate = DateTime.Now;
                    _context.Entry(userActivity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                return dto;
            }
            catch (Exception ex)
            {
                var log = new EventLog
                {
                    EventType = "Error",
                    Source = ex.Source,
                    MessageOne = ex.Message,
                    MessageTwo = ex.InnerException?.Message,
                    MessageThree = ex.InnerException?.InnerException?.Message,
                    StackTrace = ex.StackTrace
                };

                _context.EventLogs.Add(log);
                await _context.SaveChangesAsync();
                throw;
            }
        }

        public async Task<ClientInfoDto> GetClientInfoAsync(string username)
        {
            var dto = new ClientInfoDto();
            var user = await _context.SptUsers.SingleAsync(u => u.Username == username);
            dto.IsAdmin = user.IsAdmin;

            var cf = user.Person.CFType;

            Activity activity;
            var userActivities = user.SptUserActivities;

            if (userActivities.Any())
            {
                var unfinished = userActivities.Where(t => t.FinishDate == null).ToList();
                if (unfinished.Any())
                {
                    var current = unfinished.Single();
                    activity = current.Activity;
                    int? qid = current.SptUserActivityDetails.Where(t => t.Result == null).OrderBy(t => t.Id).First().Id;
                    FillDto(dto, activity, cf, qid);
                }
                else
                {
                    var lastFinished = userActivities.OrderByDescending(t => t.FinishDate).First();
                    //if (lastFinished.FinishDate.Value.AddDays(1) < DateTime.Now)
                    //    activity = await _context.Activities.FirstOrDefaultAsync(t => t.ActivityOrder == lastFinished.Activity.ActivityOrder + 1);
                    //else
                    //    activity = null;

                    activity = await _context.Activities.FirstOrDefaultAsync(t => t.ActivityOrder == lastFinished.Activity.ActivityOrder + 1);


                    FillDto(dto, activity, cf, null);
                }
            }
            else
            {
                activity = await _context.Activities.SingleAsync(t => t.ActivityOrder == 1);
                FillDto(dto, activity, cf, null);
            }

            return dto;
        }

        public async Task<List<IndicatorDto>> GetIndicatorsAsync(string username)
        {
            var user = await _context.SptUsers.SingleAsync(u => u.Username == username);
            var userActivities = user.SptUserActivities;

            var activities = _context.Activities.OrderBy(t => t.ActivityOrder).ToList();
            var last = userActivities.OrderByDescending(o => o.Activity.ActivityOrder).FirstOrDefault();
            var actRoute = string.Empty;
            var indicators = new List<IndicatorDto>();
            activities.ForEach(t =>
            {
                switch (t.ActivityName)
                {
                    case "PreTest":
                        actRoute = "app.activity.pretest";
                        break;
                    case "Training":
                        actRoute = "app.activity.training";
                        break;
                    case "PostTest":
                        actRoute = "app.activity.posttest";
                        break;
                }
                var indicator = new IndicatorDto { Route = actRoute, Title = t.ActivityTitle };
                if (userActivities.Any(p => p.Activity.Id == t.Id && p.FinishDate != null))
                {
                    indicator.Style = "completed";
                    indicator.IsActive = false;
                }
                else if (userActivities.Any(p => p.Activity.Id == t.Id && p.FinishDate == null))
                {
                    indicator.Style = "active";
                    indicator.IsActive = true;
                }
                else
                {
                    if (last != null)
                        indicator.IsActive = last.FinishDate != null &&
                                             last.Activity.ActivityOrder == t.ActivityOrder - 1;
                    else
                        indicator.IsActive = t.ActivityOrder == 1;

                    indicator.Style = string.Empty;
                }
                indicators.Add(indicator);
            });

            return indicators;
        }

        private static void FillDto(ClientInfoDto dto, Activity activity, CFType cFType, int? qId)
        {
            dto.CfTypeId = cFType.Id;
            dto.CfTypeName = cFType.CFTypeName;
            if (activity == null)
            {
                dto.ActivityId = null;
                dto.ActivityName = null;
                dto.Session = null;
                dto.QuestionId = null;
                dto.IsTest = null;
                dto.ActivityTitle = null;
                dto.ActivityDesc = null;
            }
            else
            {
                dto.ActivityId = activity.Id;
                dto.ActivityName = activity.ActivityName;
                dto.Session = activity.ActivitySession;
                dto.QuestionId = qId;
                dto.IsTest = activity.IsTest;
                dto.ActivityTitle = activity.ActivityTitle;
                dto.ActivityDesc = activity.ActivityDesc;
            }
        }
    }
}