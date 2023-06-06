using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimApi.Data.Migrations
{
    public partial class ViewReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE VIEW dbo.\"vTransactionReport\" AS " +
                                 $"SELECT " +
                                 $"tr.\"Id\", tr.\"AccountId\", tr.\"Amount\", tr.\"Direction\", " +
                                 $"tr.\"TransactionDate\", tr.\"Description\", " +
                                 $"\r\ntr.\"ReferenceNumber\", tr.\"TransactionCode\", " +
                                 $"ac.\"Name\" AS \"AccountName\", ac.\"AccountNumber\", " +
                                 $"ac.\"CustomerId\", cu.\"CustomerNumber\", cu.\"FirstName\", " +
                                 $"cu.\"LastName\", " +
                                 $"tr.\"CreatedAt\", tr.\"UpdatedAt\", tr.\"CreatedBy\", tr.\"UpdatedBy\" " +
                                 $"FROM dbo.\"Transaction\" tr " +
                                 $"INNER JOIN dbo.\"Account\" ac ON ac.\"Id\" = tr.\"AccountId\" " +
                                 $"INNER JOIN dbo.\"Customer\" cu ON cu.\"Id\" = ac.\"CustomerId\"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view dbo.\"vTransactionReport\"");
        }
    }
}
