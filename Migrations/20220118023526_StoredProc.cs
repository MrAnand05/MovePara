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
    SET NOCOUNT ON;
    Delete from ParaLeft
    Delete from ParaRight
    insert into ParaLeft Select ParaId from Para
END";

            migrationBuilder.Sql(Proc_Initilize);
            var Proc_Move = @"
CREATE PROCEDURE [dbo].[Proc_Move] @ParaId  nvarchar(10)
AS
BEGIN
	if EXISTS (Select 1 from paraLeft where ParaId = @ParaId)
	BEGIN
		insert into paraRight values (@ParaId)
		delete from paraLeft where ParaId = @ParaId
	END
	ELSE
	BEGIN
		Insert into paraLeft values (@ParaId)
		delete from paraRight where ParaId = @ParaId
	END
END";

            migrationBuilder.Sql(Proc_Move);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
