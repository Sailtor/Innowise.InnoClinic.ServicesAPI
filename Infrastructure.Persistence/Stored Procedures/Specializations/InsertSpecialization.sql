ALTER PROCEDURE [dbo].[InsertSpecialization]
(
	@Name nvarchar(1024),
	@IsActive bit
)
AS
	SET NOCOUNT OFF;
DECLARE @Id uniqueidentifier;
SET @Id = NEWID();
INSERT INTO [Specializations] ([Id], [Name], [IsActive]) VALUES (@Id, @Name, @IsActive);
	
SELECT * FROM Specializations WHERE (Id = @Id)