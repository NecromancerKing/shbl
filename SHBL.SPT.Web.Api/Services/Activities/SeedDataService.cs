using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.Model.Word;
using SHBL.SPT.UI.Model.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class SeedDataService : RequestServiceBase<SeedDataResponse>
    {
        public override SeedDataResponse ProcessRequest()
        {
            var uow = new SptUnitOfWork();
            SeedDataResponse response = new SeedDataResponse();
            try
            {
                // add speakers
                var speakers = new List<Speaker>();
                speakers.Add(new Speaker { SpeakerName = "M1", TestOnly = false });
                speakers.Add(new Speaker { SpeakerName = "F1", TestOnly = false });
                speakers.Add(new Speaker { SpeakerName = "M2", TestOnly = true });
                speakers.Add(new Speaker { SpeakerName = "F2", TestOnly = true });
                uow.SpeakerRepository.AddRange(speakers);
                uow.Save();

                // add CFType
                var cFTypes = new List<CFType>();
                cFTypes.Add(new CFType { CFTypeName = "Target" });
                cFTypes.Add(new CFType { CFTypeName = "NonTarget" });
                cFTypes.Add(new CFType { CFTypeName = "Combination" });
                uow.CFTypeRepository.AddRange(cFTypes);
                uow.Save();

                // add CFTypeSpeakers
                var cFTypeSpeakers = new List<CFTypeSpeaker>();
                var trainingSpeakers = uow.SpeakerRepository.FindBy(t => t.TestOnly == false).ToList();
                var singleCF = uow.CFTypeRepository.GetAll().ToList().Take(2).ToList();
                var combinedCF = uow.CFTypeRepository.GetAll().ToList().Last();

                singleCF.ForEach(t => trainingSpeakers.ForEach(p => cFTypeSpeakers.Add(new CFTypeSpeaker { CFType = t, Speaker = p, FileName1 = t.CFTypeName + p.SpeakerName + ".mp3" })));
                trainingSpeakers.ForEach(p => cFTypeSpeakers.Add(new CFTypeSpeaker { CFType = combinedCF, Speaker = p, FileName1 = combinedCF.CFTypeName + p.SpeakerName + "P1.mp3", FileName2 = combinedCF.CFTypeName + p.SpeakerName + "P2.mp3" }));
                uow.CFTypeSpeakerRepository.AddRange(cFTypeSpeakers);
                uow.Save();

                // add user and pesrson
                var users = new List<SptUser>();
                users.Add(new SptUser
                {
                    Username = "shilanshebli@yahoo.com",
                    Password = "111111",
                    IsAdmin = true,
                    Person = new Person
                    {
                        FirstName = "Shilan",
                        LastName = "Shebli",
                        Gender = "F",
                        AgeGroup = Person.AgeGroupEnum.GrpAbove15,
                        ProficiencyLevel = Person.ProficiencyLevelEnum.Beginner,
                        CFType = uow.CFTypeRepository.FindById(1)
                    }
                });

                users.Add(new SptUser
                {
                    Username = "rostami.siavash@gmail.com",
                    Password = "111111",
                    IsAdmin = true,
                    Person = new Person
                    {
                        FirstName = "Siavash",
                        LastName = "Rostami",
                        Gender = "M",
                        AgeGroup = Person.AgeGroupEnum.GrpAbove15,
                        ProficiencyLevel = Person.ProficiencyLevelEnum.Beginner,
                        CFType = uow.CFTypeRepository.FindById(2)
                    }
                });

                uow.UserRepository.AddRange(users);
                uow.Save();

                // add activities
                var activities = new List<Activity>();
                activities.Add(new Activity { ActivityOrder = 1, ActivityName = "PreTest", ActivitySession = 1, IsTest = true, ActivityTitle = "Pretest", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can only play once before pressing the answer." });
                activities.Add(new Activity { ActivityOrder = 2, ActivityName = "Training", ActivitySession = 1, IsTest = false, ActivityTitle = "Training  - Session 1", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." });
                activities.Add(new Activity { ActivityOrder = 3, ActivityName = "Training", ActivitySession = 2, IsTest = false, ActivityTitle = "Training  - Session 2", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." });
                activities.Add(new Activity { ActivityOrder = 4, ActivityName = "Training", ActivitySession = 3, IsTest = false, ActivityTitle = "Training  - Session 3", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." });
                activities.Add(new Activity { ActivityOrder = 5, ActivityName = "Training", ActivitySession = 4, IsTest = false, ActivityTitle = "Training  - Session 4", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." });
                activities.Add(new Activity { ActivityOrder = 6, ActivityName = "Training", ActivitySession = 5, IsTest = false, ActivityTitle = "Training  - Session 5", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." });
                activities.Add(new Activity { ActivityOrder = 7, ActivityName = "Training", ActivitySession = 6, IsTest = false, ActivityTitle = "Training  - Session 6", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." });
                activities.Add(new Activity { ActivityOrder = 8, ActivityName = "PostTest", ActivitySession = 1, IsTest = true, ActivityTitle = "Posttest", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can only play once before pressing the answer." });
                uow.ActivityRepository.AddRange(activities);
                uow.Save();

                // add Words and WordSpeakers

                // Set 1, familiar
                AddWordPair(uow, "Bet", "Bert", Word.SoundGroupEnum.Set1, false);
                AddWordPair(uow, "Bed", "bird", Word.SoundGroupEnum.Set1, false);
                AddWordPair(uow, "Ten", "Turn", Word.SoundGroupEnum.Set1, false);
                AddWordPair(uow, "Hell", "Hurl", Word.SoundGroupEnum.Set1, false);
                AddWordPair(uow, "Nest", "Nursed", Word.SoundGroupEnum.Set1, false);
                AddWordPair(uow, "Bled", "Blurred", Word.SoundGroupEnum.Set1, false);
                AddWordPair(uow, "Best", "Burst", Word.SoundGroupEnum.Set1, false);
                // set 1, unfamiliar
                AddWordPair(uow, "Well", "Whirl", Word.SoundGroupEnum.Set1, true);
                AddWordPair(uow, "End", "Earned", Word.SoundGroupEnum.Set1, true);
                AddWordPair(uow, "Spend", "Spurned", Word.SoundGroupEnum.Set1, true);


                // Set 2, familiar
                AddWordPair(uow, "Ship", "Sheep", Word.SoundGroupEnum.Set2, false);
                AddWordPair(uow, "Fit", "Feet", Word.SoundGroupEnum.Set2, false);
                AddWordPair(uow, "Bit", "Beat", Word.SoundGroupEnum.Set2, false);
                AddWordPair(uow, "Rich", "Reach", Word.SoundGroupEnum.Set2, false);
                AddWordPair(uow, "Itch", "Each", Word.SoundGroupEnum.Set2, false);
                AddWordPair(uow, "Chick", "Cheek", Word.SoundGroupEnum.Set2, false);
                AddWordPair(uow, "Dip", "Deep", Word.SoundGroupEnum.Set2, false);
                // set 2, unfamiliar
                AddWordPair(uow, "Fizz", "Fees", Word.SoundGroupEnum.Set2, true);
                AddWordPair(uow, "Hip", "Heap", Word.SoundGroupEnum.Set2, true);
                AddWordPair(uow, "Pill", "Peel", Word.SoundGroupEnum.Set2, true);


                // Set 3, familiar
                AddWordPair(uow, "Pull", "Pool", Word.SoundGroupEnum.Set3, false);
                AddWordPair(uow, "Wood", "Would", Word.SoundGroupEnum.Set3, false);
                AddWordPair(uow, "Soot", "Suit", Word.SoundGroupEnum.Set3, false);
                AddWordPair(uow, "Pulls", "Pools", Word.SoundGroupEnum.Set3, false);
                AddWordPair(uow, "Food", "Foot", Word.SoundGroupEnum.Set3, false);
                AddWordPair(uow, "Kook", "Cook", Word.SoundGroupEnum.Set3, false);
                AddWordPair(uow, "Luke", "Look", Word.SoundGroupEnum.Set3, false);
                // set 3, unfamiliar
                AddWordPair(uow, "Boole", "Bull", Word.SoundGroupEnum.Set3, true);
                AddWordPair(uow, "Stewed", "Stood", Word.SoundGroupEnum.Set3, true);
                AddWordPair(uow, "Gooed", "Good", Word.SoundGroupEnum.Set3, true);


                // Set 4, familiar
                AddWordPair(uow, "O", "Or", Word.SoundGroupEnum.Set4, false);
                AddWordPair(uow, "Code", "Cord", Word.SoundGroupEnum.Set4, false);
                AddWordPair(uow, "Doze", "Doors", Word.SoundGroupEnum.Set4, false);
                AddWordPair(uow, "Foam", "Form", Word.SoundGroupEnum.Set4, false);
                AddWordPair(uow, "Goal", "Gall", Word.SoundGroupEnum.Set4, false);
                AddWordPair(uow, "Load", "Lord", Word.SoundGroupEnum.Set4, false);
                AddWordPair(uow, "Moan", "Mourn", Word.SoundGroupEnum.Set4, false);
                // set 4, unfamiliar
                AddWordPair(uow, "Motor", "Mortar", Word.SoundGroupEnum.Set4, true);
                AddWordPair(uow, "Mow", "More", Word.SoundGroupEnum.Set4, true);
                AddWordPair(uow, "Oat", "Ought", Word.SoundGroupEnum.Set4, true);

                uow.Dispose();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void AddWordPair(SptUnitOfWork uw, string w1, string w2, Word.SoundGroupEnum grp, bool testOnly)
        {
            var speakers = uw.SpeakerRepository.GetAll().ToList();

            var word1 = new Word { WordEntry = w1, SoundGroup = grp, TestOnly = testOnly };
            var word2 = new Word { WordEntry = w2, SoundGroup = grp, TestOnly = testOnly };

            speakers.ForEach(t => word1.WordSpeakers.Add(new WordSpeaker { Speaker = t, FileName = w1 + "." + t.SpeakerName + ".mp3" }));
            speakers.ForEach(t => word2.WordSpeakers.Add(new WordSpeaker { Speaker = t, FileName = w2 + "." + t.SpeakerName + ".mp3" }));

            uw.WordRepository.Add(word1);
            uw.WordRepository.Add(word2);
            uw.Save();

            word1.Pair = word2;
            word2.Pair = word1;
            uw.WordRepository.Edit(word1);
            uw.WordRepository.Edit(word2);
            uw.Save();
        }
    }
}