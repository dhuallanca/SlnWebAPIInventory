using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Users",
                columns: ["Name", "Password", "Email", "FirstName", "LastName", "IsActive", "CreatedBy", "Created"],
                values: new object[,]
                {
                    { "SuperAdmin", "123", "dennishuallanca@gmail.com", "Dennis", "Huallanca Zavaleta", true, "Seed", DateTime.Now },
                });

            migrationBuilder.InsertData("Roles",
            columns: ["Name", "Description", "IsActive"],
            values: new object[,]
            {
               { "SuperAdmin", "Super Administrator", true },
            });

            migrationBuilder.InsertData("Permissions",
            columns: ["Name", "Description", "IsActive"],
            values: new object[,]
            {
                 { "Users", "Handle Users", true },
                 { "Roles", "Handle Roles", true },
                 { "UserRoles", "Add Roles to Users", true },
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
