using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InlamningNet.Migrations
{
    /// <inheritdoc />
    public partial class new_courseSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ActiveStatus",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdvertisingUpdatesSubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDailyNewsletterSubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEventUpdatesSubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPodcastsSubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStartUpsWeeklySubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWeekInReviewSubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Likebutton",
                table: "Courses",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdvertisingUpdatesSubscribed",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsDailyNewsletterSubscribed",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsEventUpdatesSubscribed",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsPodcastsSubscribed",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsStartUpsWeeklySubscribed",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsWeekInReviewSubscribed",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Likebutton",
                table: "Courses");

            migrationBuilder.AlterColumn<bool>(
                name: "ActiveStatus",
                table: "Subscriptions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
