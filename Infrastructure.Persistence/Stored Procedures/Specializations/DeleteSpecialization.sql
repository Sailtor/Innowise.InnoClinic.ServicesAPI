ALTER PROCEDURE [dbo].[DeleteSpecialization]
(
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
DELETE FROM [Specializations] WHERE [Id] = @Original_Id