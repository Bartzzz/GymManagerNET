using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagerNET.Data.Migrations
{
    public partial class furtherMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_TrainerId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBooking_Activity_ActivityId",
                table: "RoomBooking");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TrainerId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBooking",
                table: "RoomBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessRoom",
                table: "FitnessRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "RoomBooking",
                newName: "RoomBookings");

            migrationBuilder.RenameTable(
                name: "FitnessRoom",
                newName: "FitnessRooms");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBooking_ActivityId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookings",
                table: "RoomBookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessRooms",
                table: "FitnessRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Activities_ActivityId",
                table: "RoomBookings",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_FitnessRooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "FitnessRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Activities_ActivityId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_FitnessRooms_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookings",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessRooms",
                table: "FitnessRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "RoomBookings",
                newName: "RoomBooking");

            migrationBuilder.RenameTable(
                name: "FitnessRooms",
                newName: "FitnessRoom");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_ActivityId",
                table: "RoomBooking",
                newName: "IX_RoomBooking_ActivityId");

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBooking",
                table: "RoomBooking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessRoom",
                table: "FitnessRoom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TrainerId",
                table: "Clients",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_TrainerId",
                table: "Clients",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBooking_Activity_ActivityId",
                table: "RoomBooking",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
