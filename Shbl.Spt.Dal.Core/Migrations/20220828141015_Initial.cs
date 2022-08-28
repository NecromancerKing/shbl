using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shbl.Spt.Dal.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActivitySession = table.Column<byte>(type: "tinyint", nullable: false),
                    IsTest = table.Column<bool>(type: "bit", nullable: false),
                    ActivityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CfType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CfTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CfType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestOnly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordEntry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PairId = table.Column<int>(type: "int", nullable: true),
                    SoundGroup = table.Column<byte>(type: "tinyint", nullable: false),
                    TestOnly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Word_Word_PairId",
                        column: x => x.PairId,
                        principalTable: "Word",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    AgeGroup = table.Column<byte>(type: "tinyint", nullable: false),
                    ProficiencyLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    CfTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_CfType_CfTypeId",
                        column: x => x.CfTypeId,
                        principalTable: "CfType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CfTypeSpeaker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CfTypeId = table.Column<int>(type: "int", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false),
                    FileName1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CfTypeSpeaker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfTypeSpeaker_CfType_CfTypeId",
                        column: x => x.CfTypeId,
                        principalTable: "CfType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CfTypeSpeaker_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speaker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordSpeaker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSpeaker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordSpeaker_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speaker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordSpeaker_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "Word",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SptUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SptUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SptUser_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SptUserActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SptUserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SptUserActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SptUserActivity_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SptUserActivity_SptUser_SptUserId",
                        column: x => x.SptUserId,
                        principalTable: "SptUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SptUserActivityDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserActivityId = table.Column<int>(type: "int", nullable: false),
                    WordSpeakerId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SptUserActivityDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SptUserActivityDetail_SptUserActivity_UserActivityId",
                        column: x => x.UserActivityId,
                        principalTable: "SptUserActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SptUserActivityDetail_WordSpeaker_WordSpeakerId",
                        column: x => x.WordSpeakerId,
                        principalTable: "WordSpeaker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CfTypeSpeaker_CfTypeId",
                table: "CfTypeSpeaker",
                column: "CfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CfTypeSpeaker_SpeakerId",
                table: "CfTypeSpeaker",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CfTypeId",
                table: "Person",
                column: "CfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SptUser_PersonId",
                table: "SptUser",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SptUserActivity_ActivityId",
                table: "SptUserActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SptUserActivity_SptUserId",
                table: "SptUserActivity",
                column: "SptUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SptUserActivityDetail_UserActivityId",
                table: "SptUserActivityDetail",
                column: "UserActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SptUserActivityDetail_WordSpeakerId",
                table: "SptUserActivityDetail",
                column: "WordSpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Word_PairId",
                table: "Word",
                column: "PairId");

            migrationBuilder.CreateIndex(
                name: "IX_WordSpeaker_SpeakerId",
                table: "WordSpeaker",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_WordSpeaker_WordId",
                table: "WordSpeaker",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CfTypeSpeaker");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "SptUserActivityDetail");

            migrationBuilder.DropTable(
                name: "SptUserActivity");

            migrationBuilder.DropTable(
                name: "WordSpeaker");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "SptUser");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Word");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "CfType");
        }
    }
}
