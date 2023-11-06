ALTER PROCEDURE [dbo].[UpdateSpecialization]
(
	@Name nvarchar(1024),
	@IsActive bit,
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
UPDATE [Specializations] SET [Name] = @Name, [IsActive] = @IsActive WHERE [Id] = @Original_Id;