CREATE PROCEDURE [dbo].[InsertCategory]
(
	@Name nvarchar(1024),
	@TimeSlotSize int
)
AS
	SET NOCOUNT OFF;
DECLARE @Id uniqueidentifier;
SET @Id = NEWID();
INSERT INTO [Categories] ([Id], [Name], [TimeSlotSize]) VALUES (@Id, @Name, @TimeSlotSize);
	
SELECT * FROM Categories WHERE (Id = @Id)