CREATE PROCEDURE [dbo].[UpdateCategory]
(
	@Name nvarchar(1024),
	@TimeSlotSize int,
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
UPDATE [Categories] SET [Name] = @Name, [TimeSlotSize] = @TimeSlotSize WHERE ([Id] = @Original_Id);