using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_manager.Migrations
{
    /// <inheritdoc />
    public partial class AddGioHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaBan = table.Column<float>(type: "real", nullable: false),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHang_TaiKhoan_IdTaiKhoan",
                        column: x => x.IdTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdSanPham",
                table: "GioHang",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdTaiKhoan",
                table: "GioHang",
                column: "IdTaiKhoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHang");
        }
    }
}
