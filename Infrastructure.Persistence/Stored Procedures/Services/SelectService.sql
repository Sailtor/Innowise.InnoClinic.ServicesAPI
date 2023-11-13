CREATE PROCEDURE [dbo].[SelectService]
(
	@Id uniqueidentifier
)
AS
	SET NOCOUNT ON;
SELECT        Services.*
FROM            Services
WHERE Services.Id = @Id;