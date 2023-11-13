ALTER PROCEDURE [dbo].[UpdateService]
(
	@Name nvarchar(1024),
	@Price decimal(10, 2),
	@IsActive bit,
	@CategoryId uniqueidentifier,
	@SpecializationId uniqueidentifier,
	@Original_Id uniqueidentifier
)
AS
	SET NOCOUNT OFF;
UPDATE [Services] SET [Name] = @Name, [Price] = @Price, [IsActive] = @IsActive, [CategoryId] = @CategoryId, [SpecializationId] = @SpecializationId WHERE [Id] = @Original_Id;