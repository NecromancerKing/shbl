BEGIN TRY
BEGIN TRANSACTION 

SET IDENTITY_INSERT [dbo].[Word] ON 
INSERT INTO [dbo].[Word] ([Id], [WordEntry]) VALUES (1, 'Both')
INSERT INTO [dbo].[Word] ([Id], [WordEntry]) VALUES (2, 'Boat')
INSERT INTO [dbo].[Word] ([Id], [WordEntry]) VALUES (3, 'Fowl')
INSERT INTO [dbo].[Word] ([Id], [WordEntry]) VALUES (4, 'Fool')
SET IDENTITY_INSERT [dbo].[Word] OFF 


SET IDENTITY_INSERT [dbo].[Speaker] ON 
INSERT INTO [dbo].[Speaker] ([Id], [SpeakerName]) VALUES (1, 'M1')
INSERT INTO [dbo].[Speaker] ([Id], [SpeakerName]) VALUES (2, 'F1')
INSERT INTO [dbo].[Speaker] ([Id], [SpeakerName]) VALUES (3, 'M2')
INSERT INTO [dbo].[Speaker] ([Id], [SpeakerName]) VALUES (4, 'F2')
INSERT INTO [dbo].[Speaker] ([Id], [SpeakerName]) VALUES (5, 'M3')
INSERT INTO [dbo].[Speaker] ([Id], [SpeakerName]) VALUES (6, 'F3')
SET IDENTITY_INSERT [dbo].[Speaker] OFF 


SET IDENTITY_INSERT [dbo].[WordSpeaker] ON 
INSERT [dbo].[WordSpeaker] ([Id], [WordId], [SpeakerId], [FileName], [TestOnly]) VALUES (1, 1, 1, N'1M1.mp3', 0)
INSERT [dbo].[WordSpeaker] ([Id], [WordId], [SpeakerId], [FileName], [TestOnly]) VALUES (2, 1, 2, N'1F1.mp3', 0)
SET IDENTITY_INSERT [dbo].[WordSpeaker] OFF



SET IDENTITY_INSERT [dbo].[Activity] ON 
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (1, 1, N'PreTest', 1, 1)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (2, 2, N'Training', 1, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (3, 3, N'Training', 2, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (4, 4, N'Training', 3, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (5, 5, N'Training', 4, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (6, 6, N'Training', 5, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (7, 7, N'Training', 6, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (8, 8, N'Training', 7, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (9, 9, N'Training', 8, 0)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (10, 10, N'ImmediatePostTest', 1, 1)
INSERT [dbo].[Activity] ([Id], [ActivityOrder], [ActivityName], [ActivitySession], [IsTest]) VALUES (11, 11, N'DelayedPostTest', 1, 1)
SET IDENTITY_INSERT [dbo].[Activity] OFF

COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
