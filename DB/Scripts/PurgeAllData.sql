BEGIN TRANSACTION

DELETE FROM [dbo].[SptUserActivityDetail]
DBCC CHECKIDENT ('[dbo].[SptUserActivityDetail]', RESEED, 0);
GO

DELETE FROM [dbo].[SptUserActivity]
DBCC CHECKIDENT ('[dbo].[SptUserActivity]', RESEED, 0);
GO

DELETE FROM [dbo].[Activity]
DBCC CHECKIDENT ('[dbo].[Activity]', RESEED, 0);
GO

DELETE FROM [dbo].[WordSpeaker]
DBCC CHECKIDENT ('[dbo].[WordSpeaker]', RESEED, 0);
GO

DELETE FROM [dbo].[CFTypeSpeaker]
DBCC CHECKIDENT ('[dbo].[CFTypeSpeaker]', RESEED, 0);
GO

DELETE FROM [dbo].[Word]
DBCC CHECKIDENT ('[dbo].[Word]', RESEED, 0);
GO

DELETE FROM [dbo].[SptUser]
DBCC CHECKIDENT ('[dbo].[SptUser]', RESEED, 0);
GO

DELETE FROM [dbo].[Person]
DBCC CHECKIDENT ('[dbo].[Person]', RESEED, 0);
GO

DELETE FROM [dbo].[CFType]
DBCC CHECKIDENT ('[dbo].[CFType]', RESEED, 0);
GO

DELETE FROM [dbo].[Speaker]
DBCC CHECKIDENT ('[dbo].[Speaker]', RESEED, 0);
GO

COMMIT TRANSACTION
