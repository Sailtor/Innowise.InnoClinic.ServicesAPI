ALTER PROCEDURE [dbo].[DeleteService]
(
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
DELETE FROM [Services] WHERE [Id] = @Original_Id