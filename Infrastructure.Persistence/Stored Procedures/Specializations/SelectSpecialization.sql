ALTER PROCEDURE [dbo].[SelectSpecialization]
(
	@Id uniqueidentifier
)
AS
	SET NOCOUNT ON;
SELECT        Specializations.*
FROM            Specializations
WHERE Specializations.Id = @Id;