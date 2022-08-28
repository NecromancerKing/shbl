﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.Model.Word;

namespace SHBL.SPT.Business.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly SptContext _context;

        public SeedDataService()
        {
            _context = new SptContext();
        }
        public async Task SeedAsync()
        {
            // add speakers
            var speakers = new List<Speaker>
            {
                new Speaker { SpeakerName = "M1", TestOnly = false },
                new Speaker { SpeakerName = "F1", TestOnly = false },
                new Speaker { SpeakerName = "M2", TestOnly = true },
                new Speaker { SpeakerName = "F2", TestOnly = true }
            };
            _context.Speakers.AddRange(speakers);
            await _context.SaveChangesAsync();

            // add CFType
            var cFTypes = new List<CFType>
            {
                new CFType { CFTypeName = "Target" },
                new CFType { CFTypeName = "NonTarget" },
                new CFType { CFTypeName = "Combination" }
            };
            _context.CFTypes.AddRange(cFTypes);
            await _context.SaveChangesAsync();

            // add CFTypeSpeakers
            var cFTypeSpeakers = new List<CFTypeSpeaker>();
            var trainingSpeakers = _context.Speakers.Where(t => t.TestOnly == false).ToList();
            var singleCf = _context.CFTypes.ToList().Take(2).ToList();
            var combinedCf = _context.CFTypes.ToList().Last();

            singleCf.ForEach(t => trainingSpeakers.ForEach(p => cFTypeSpeakers.Add(new CFTypeSpeaker { CFType = t, Speaker = p, FileName1 = t.CFTypeName + p.SpeakerName + ".mp3" })));
            trainingSpeakers.ForEach(p => cFTypeSpeakers.Add(new CFTypeSpeaker { CFType = combinedCf, Speaker = p, FileName1 = combinedCf.CFTypeName + p.SpeakerName + "P1.mp3", FileName2 = combinedCf.CFTypeName + p.SpeakerName + "P2.mp3" }));
            _context.CFTypeSpeakers.AddRange(cFTypeSpeakers);
            await _context.SaveChangesAsync();

            // add user and pesrson
            var users = new List<SptUser>
            {
                new SptUser
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
                        CFType = await _context.CFTypes.FindAsync(1)
                    }
                },
                new SptUser
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
                        CFType = await _context.CFTypes.FindAsync(2)
                    }
                }
            };

            _context.SptUsers.AddRange(users);
            await _context.SaveChangesAsync();

            // add activities
            var activities = new List<Activity>
            {
                new Activity { ActivityOrder = 1, ActivityName = "PreTest", ActivitySession = 1, IsTest = true, ActivityTitle = "Pretest", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can only play once before pressing the answer." },
                new Activity { ActivityOrder = 2, ActivityName = "Training", ActivitySession = 1, IsTest = false, ActivityTitle = "Training  - Session 1", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." },
                new Activity { ActivityOrder = 3, ActivityName = "Training", ActivitySession = 2, IsTest = false, ActivityTitle = "Training  - Session 2", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." },
                new Activity { ActivityOrder = 4, ActivityName = "Training", ActivitySession = 3, IsTest = false, ActivityTitle = "Training  - Session 3", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." },
                new Activity { ActivityOrder = 5, ActivityName = "Training", ActivitySession = 4, IsTest = false, ActivityTitle = "Training  - Session 4", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." },
                new Activity { ActivityOrder = 6, ActivityName = "Training", ActivitySession = 5, IsTest = false, ActivityTitle = "Training  - Session 5", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." },
                new Activity { ActivityOrder = 7, ActivityName = "Training", ActivitySession = 6, IsTest = false, ActivityTitle = "Training  - Session 6", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can play as many times as you need before pressing the answer.<br/>If you pick the wrong answer, you will be presented with an auditory feedback." },
                new Activity { ActivityOrder = 8, ActivityName = "PostTest", ActivitySession = 1, IsTest = true, ActivityTitle = "Posttest", ActivityDesc = "You may Press the play button to hear the pronunciation of a word<br/>then choose the correct written form between the options below.<br/>You can only play once before pressing the answer." }
            };

            _context.Activities.AddRange(activities);
            await _context.SaveChangesAsync();

            // add Words and WordSpeakers

            // Set 1, familiar
            await AddWordPair("Bet", "Bert", Word.SoundGroupEnum.Set1, false);
            await AddWordPair("Bed", "bird", Word.SoundGroupEnum.Set1, false);
            await AddWordPair("Ten", "Turn", Word.SoundGroupEnum.Set1, false);
            await AddWordPair("Hell", "Hurl", Word.SoundGroupEnum.Set1, false);
            await AddWordPair("Nest", "Nursed", Word.SoundGroupEnum.Set1, false);
            await AddWordPair("Bled", "Blurred", Word.SoundGroupEnum.Set1, false);
            await AddWordPair("Best", "Burst", Word.SoundGroupEnum.Set1, false);
            // set 1, unfamiliar
            await AddWordPair("Well", "Whirl", Word.SoundGroupEnum.Set1, true);
            await AddWordPair("End", "Earned", Word.SoundGroupEnum.Set1, true);
            await AddWordPair("Spend", "Spurned", Word.SoundGroupEnum.Set1, true);


            // Set 2, familiar
            await AddWordPair("Ship", "Sheep", Word.SoundGroupEnum.Set2, false);
            await AddWordPair("Fit", "Feet", Word.SoundGroupEnum.Set2, false);
            await AddWordPair("Bit", "Beat", Word.SoundGroupEnum.Set2, false);
            await AddWordPair("Rich", "Reach", Word.SoundGroupEnum.Set2, false);
            await AddWordPair("Itch", "Each", Word.SoundGroupEnum.Set2, false);
            await AddWordPair("Chick", "Cheek", Word.SoundGroupEnum.Set2, false);
            await AddWordPair("Dip", "Deep", Word.SoundGroupEnum.Set2, false);
            // set 2, unfamiliar
            await AddWordPair("Fizz", "Fees", Word.SoundGroupEnum.Set2, true);
            await AddWordPair("Hip", "Heap", Word.SoundGroupEnum.Set2, true);
            await AddWordPair("Pill", "Peel", Word.SoundGroupEnum.Set2, true);


            // Set 3, familiar
            await AddWordPair("Pull", "Pool", Word.SoundGroupEnum.Set3, false);
            await AddWordPair("Wood", "Would", Word.SoundGroupEnum.Set3, false);
            await AddWordPair("Soot", "Suit", Word.SoundGroupEnum.Set3, false);
            await AddWordPair("Pulls", "Pools", Word.SoundGroupEnum.Set3, false);
            await AddWordPair("Food", "Foot", Word.SoundGroupEnum.Set3, false);
            await AddWordPair("Kook", "Cook", Word.SoundGroupEnum.Set3, false);
            await AddWordPair("Luke", "Look", Word.SoundGroupEnum.Set3, false);
            // set 3, unfamiliar
            await AddWordPair("Boole", "Bull", Word.SoundGroupEnum.Set3, true);
            await AddWordPair("Stewed", "Stood", Word.SoundGroupEnum.Set3, true);
            await AddWordPair("Gooed", "Good", Word.SoundGroupEnum.Set3, true);


            // Set 4, familiar
            await AddWordPair("O", "Or", Word.SoundGroupEnum.Set4, false);
            await AddWordPair("Code", "Cord", Word.SoundGroupEnum.Set4, false);
            await AddWordPair("Doze", "Doors", Word.SoundGroupEnum.Set4, false);
            await AddWordPair("Foam", "Form", Word.SoundGroupEnum.Set4, false);
            await AddWordPair("Goal", "Gall", Word.SoundGroupEnum.Set4, false);
            await AddWordPair("Load", "Lord", Word.SoundGroupEnum.Set4, false);
            await AddWordPair("Moan", "Mourn", Word.SoundGroupEnum.Set4, false);
            // set 4, unfamiliar
            await AddWordPair("Motor", "Mortar", Word.SoundGroupEnum.Set4, true);
            await AddWordPair("Mow", "More", Word.SoundGroupEnum.Set4, true);
            await AddWordPair("Oat", "Ought", Word.SoundGroupEnum.Set4, true);
        }

        private async Task AddWordPair(string w1, string w2, Word.SoundGroupEnum grp, bool testOnly)
        {
            var speakers = _context.Speakers.ToList();

            var word1 = new Word { WordEntry = w1, SoundGroup = grp, TestOnly = testOnly };
            var word2 = new Word { WordEntry = w2, SoundGroup = grp, TestOnly = testOnly };

            speakers.ForEach(t => word1.WordSpeakers.Add(new WordSpeaker { Speaker = t, FileName = w1 + "." + t.SpeakerName + ".mp3" }));
            speakers.ForEach(t => word2.WordSpeakers.Add(new WordSpeaker { Speaker = t, FileName = w2 + "." + t.SpeakerName + ".mp3" }));

            _context.Words.Add(word1);
            _context.Words.Add(word2);
            await _context.SaveChangesAsync();

            word1.Pair = word2;
            word2.Pair = word1;
            _context.Entry(word1).State = EntityState.Modified;
            _context.Entry(word2).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}