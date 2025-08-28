using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ArabianCo.EntityFrameworkCore;

namespace ArabianCo.Migrations
{
    [DbContext(typeof(ArabianCoDbContext))]
    [Migration("20240101000000_Initial")]
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
