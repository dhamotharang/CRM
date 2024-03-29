﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Models.Migrations
{
    public partial class ModifyFieldWaiveQC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiveQC_Unit_UnitID",
                schema: "PRJ",
                table: "WaiveQC");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitID",
                schema: "PRJ",
                table: "WaiveQC",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_WaiveQC_Unit_UnitID",
                schema: "PRJ",
                table: "WaiveQC",
                column: "UnitID",
                principalSchema: "PRJ",
                principalTable: "Unit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiveQC_Unit_UnitID",
                schema: "PRJ",
                table: "WaiveQC");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitID",
                schema: "PRJ",
                table: "WaiveQC",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiveQC_Unit_UnitID",
                schema: "PRJ",
                table: "WaiveQC",
                column: "UnitID",
                principalSchema: "PRJ",
                principalTable: "Unit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
