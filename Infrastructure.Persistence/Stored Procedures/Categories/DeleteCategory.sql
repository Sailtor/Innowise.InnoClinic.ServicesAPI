CREATE PROCEDURE [dbo].[DeleteCategory]
(
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
DELETE FROM [Categories] WHERE ([Id] = @Original_Id)