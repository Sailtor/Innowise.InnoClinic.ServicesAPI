CREATE PROCEDURE [dbo].[SelectCategory]
(
	@Id uniqueidentifier
)
AS
	SET NOCOUNT ON;
SELECT        Categories.*
FROM            Categories
WHERE Categories.Id = @Id;