using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.General;
using SHBL.SPT.Model.Word;
using SHBL.SPT.UI.Model.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class UpdateQuestionService : RequestServiceBase<UpdateQuestionRequest, UpdateQuestionResponse>
    {
        public override UpdateQuestionResponse ProcessRequest(UpdateQuestionRequest request)
        {
            UpdateQuestionResponse response = new UpdateQuestionResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    var question = uow.UserActivityDetailRepository.FindById(request.QuestionId);
                    if (question.WordSpeaker.Word.WordEntry == request.ChosenWord)
                    {
                        question.Result = true;
                        response.Result = true;
                        response.FileNameOne = null;
                        response.FileNameTwo = null;
                        response.CFFileNameOne = null;
                        response.CFFileNameTwo = null;
                    }
                    else
                    {
                        response.Result = false;
                        question.Result = false;

                        response.FileNameOne = question.WordSpeaker.FileName;
                        response.FileNameTwo = uow.WordSpeakerRepository.FindBy(t => t.Word.Id == question.WordSpeaker.Word.Pair.Id && t.Speaker.Id == question.WordSpeaker.Speaker.Id).Single().FileName;

                        var speaker = question.WordSpeaker.Speaker;
                        if (speaker.SpeakerName.Contains("M"))
                        {
                            speaker = uow.SpeakerRepository.FindBy(t => t.SpeakerName == speaker.SpeakerName.Replace("M", "F")).Single();
                        }
                        else
                        {
                            speaker = uow.SpeakerRepository.FindBy(t => t.SpeakerName == speaker.SpeakerName.Replace("F", "M")).Single();
                        }

                        var cFTypeSpeaker = uow.CFTypeSpeakerRepository.FindBy(t => t.Speaker.Id == speaker.Id && t.CFType.Id == question.SptUserActivity.SptUser.Person.CFType.Id).FirstOrDefault();
                        response.CFFileNameOne = cFTypeSpeaker != null ? cFTypeSpeaker.FileName1 : null;
                        response.CFFileNameTwo = cFTypeSpeaker != null ? cFTypeSpeaker.FileName2 : null;
                    }

                    uow.UserActivityDetailRepository.Edit(question);
                    uow.Save();

                    if (uow.UserActivityDetailRepository.FindBy(t => t.UserActivityId == question.UserActivityId && t.Result == null).Count() == 0)
                    {
                        var userActivity = uow.UserActivityRepository.FindBy(t => t.Id == question.UserActivityId).First();
                        userActivity.FinishDate = DateTime.Now;
                        uow.UserActivityRepository.Edit(userActivity);
                        uow.Save();
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                using (SptUnitOfWork cLog = new SptUnitOfWork())
                {
                    EventLog log = new EventLog
                    {
                        EventType = "Error",
                        Source = ex.Source,
                        MessageOne = ex.Message,
                        MessageTwo = ex.InnerException == null ? null : ex.InnerException.Message,
                        MessageThree = ex.InnerException == null ? null : ex.InnerException.InnerException == null ? null : ex.InnerException.InnerException.Message,
                        StackTrace = ex.StackTrace
                    };

                    cLog.EventLogRepository.Add(log);
                    cLog.Save();
                }
                throw;
            }
        }
    }
}