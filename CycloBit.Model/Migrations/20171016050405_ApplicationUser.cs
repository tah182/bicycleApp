using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CycloBit.Model.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "CycloBit",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                schema: "CycloBit",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoUrl",
                schema: "CycloBit",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "CycloBit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndCoordinates_Lat = table.Column<double>(type: "float", nullable: false),
                    EndCoordinates_Lng = table.Column<double>(type: "float", nullable: false),
                    StartCoordinates_Lat = table.Column<double>(type: "float", nullable: false),
                    StartCoordinates_Lng = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "CycloBit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Coordinate_Lat = table.Column<double>(type: "float", nullable: false),
                    Coordinate_Lng = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDetail",
                schema: "CycloBit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeightCm = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeightKg = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalDetail_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalSchema: "CycloBit",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Segment",
                schema: "CycloBit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<long>(type: "bigint", nullable: false),
                    EncodedRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegmentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SegmentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityHealth_Distance = table.Column<float>(type: "real", nullable: false),
                    ActivityHealth_HeartBpm = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segment_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "CycloBit",
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "CycloBit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "CycloBit",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "CycloBit",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_AddressId",
                schema: "CycloBit",
                table: "Location",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ApplicationUserId",
                schema: "CycloBit",
                table: "Location",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDetail_IdentityUserId",
                schema: "CycloBit",
                table: "MedicalDetail",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_ActivityId",
                schema: "CycloBit",
                table: "Segment",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location",
                schema: "CycloBit");

            migrationBuilder.DropTable(
                name: "MedicalDetail",
                schema: "CycloBit");

            migrationBuilder.DropTable(
                name: "Segment",
                schema: "CycloBit");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "CycloBit");

            migrationBuilder.DropTable(
                name: "Activity",
                schema: "CycloBit");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "CycloBit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "CycloBit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoUrl",
                schema: "CycloBit",
                table: "AspNetUsers");
        }
    }
}
