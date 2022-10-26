using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Database.Migrations
{
    public partial class StoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var getOverallSuccessRatesSP = @"CREATE PROCEDURE GetOverallSuccessRates
                                                AS
                                                BEGIN
                                                DROP TABLE IF EXISTS #T1
                                                DROP TABLE IF EXISTS #T2

                                                SELECT COUNT(*) AS TotalNumberOfStudents 
                                                INTO #T1
                                                FROM Students

                                                SELECT COUNT(*) AS PassingNumberOfStudents 
                                                INTO #T2
                                                FROM Students
                                                WHERE StudentStatusId = 2

                                                SELECT ROUND(CAST(ISNULL(PassingNumberOfStudents, 0 ) AS FLOAT) 
	                                                   / (CAST(ISNULL(TotalNumberOfStudents, 0 ) AS FLOAT)) 
	                                                   * CAST(100 AS FLOAT), 2) 
	                                                   as OverallSuccessRate 
                                                FROM #T1, #T2
                                                END
                                                GO";

            var getSelectionsSuccessRatesSP = @"CREATE PROCEDURE GetSelectionsSuccessRates
                                                AS
                                                BEGIN
                                                DROP TABLE IF EXISTS  #T1
                                                DROP TABLE IF EXISTS  #T2
                                                DROP TABLE IF EXISTS  #T3

                                                SELECT Selections.Name AS SelectionName, 
	                                                   Programs.Name AS ProgramName,
	                                                   StudentStatuses.Name AS StudentStatus
                                                INTO   #T1
                                                FROM   Selections
                                                JOIN   Programs 
                                                ON     Selections.ProgramId = Programs.Id
                                                JOIN   Students
                                                ON     Selections.Id = Students.SelectionId
                                                JOIN   StudentStatuses
                                                ON     Students.StudentStatusId = StudentStatuses.Id

                                                SELECT SelectionName, COUNT(SelectionName) AS PassingNumberOfStudents
                                                INTO   #T2
                                                FROM   #T1
                                                WHERE  StudentStatus = 'Success' 
                                                GROUP 
                                                BY     SelectionName

                                                SELECT SelectionName, COUNT(SelectionName) AS FailingNumberOfStudents
                                                INTO   #T3
                                                FROM   #T1
                                                WHERE  StudentStatus != 'Success' 
                                                GROUP 
                                                BY     SelectionName

                                                SELECT #T1.SelectionName, 
	                                                   ProgramName,
	                                                   ROUND(CAST(ISNULL(PassingNumberOfStudents, 0 ) AS FLOAT) 
	                                                   / (CAST(ISNULL(PassingNumberOfStudents, 0 ) AS FLOAT) 
	                                                   + CAST(ISNULL(FailingNumberOfStudents, 0 ) AS FLOAT)) 
	                                                   * CAST(100 AS FLOAT), 2) 
	                                                   as SelectionSuccessRate
                                                FROM   #T1 
                                                FULL 
                                                JOIN   #T2 
                                                ON     #T1.SelectionName = #T2.SelectionName 
                                                FULL 
                                                JOIN   #T3
                                                ON     #T1.SelectionName = #T3.SelectionName
                                                GROUP 
                                                BY     ProgramName,
	                                                   #T1.SelectionName, 
	                                                   PassingNumberOfStudents, 
	                                                   FailingNumberOfStudents
                                                END
                                                GO";

            migrationBuilder.Sql(getSelectionsSuccessRatesSP);
            migrationBuilder.Sql(getOverallSuccessRatesSP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
