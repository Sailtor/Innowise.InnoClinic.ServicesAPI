ALTER PROCEDURE [dbo].[InsertService]
(
	@Name nvarchar(1024),
	@Price decimal(10, 2),
	@IsActive bit,
	@CategoryId uniqueidentifier,
	@SpecializationId uniqueidentifier
)
AS
	SET NOCOUNT OFF;
DECLARE @Id uniqueidentifier;
SET @Id = NEWID();
INSERT INTO [Services] ([Id], [Name], [Price], [IsActive], [CategoryId], [SpecializationId]) VALUES (@Id, @Name, @Price, @IsActive, @CategoryId, @SpecializationId);
	
SELECT * FROM Services WHERE (Id = @Id)