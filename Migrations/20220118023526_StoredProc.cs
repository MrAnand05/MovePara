using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovePara.Migrations
{
    public partial class StoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var Proc_Initilize = @"
CREATE PROCEDURE [dbo].[Proc_Initilize]    
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			TRUNCATE TABLE paraLeft
			TRUNCATE TABLE paraRight 
			INSERT INTO ParaLeft SELECT ParaId FROM Para
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION; 
		RAISERROR ('Error while inserting or deleting record.',16,1)
		RETURN
	END CATCH
END ";

            migrationBuilder.Sql(Proc_Initilize);
            var Proc_Move = @"
CREATE PROCEDURE [dbo].[Proc_Move] @ParaId  nvarchar(10), @Side  nvarchar(20)
AS
BEGIN
	DECLARE @ErrorMessage NVARCHAR(1000)
	if (@Side = 'Right')
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO paraRight VALUES (@ParaId)
			DELETE FROM paraLeft WHERE ParaId = @ParaId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION; 
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR (@ErrorMessage ,16,1)
		RETURN
	END CATCH
	
	IF(@Side = 'Left')
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO paraLeft VALUES (@ParaId)
			DELETE FROM paraRight WHERE ParaId = @ParaId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION; 
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR (@ErrorMessage ,16,1)
		RETURN
	END CATCH
END";

            migrationBuilder.Sql(Proc_Move);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
