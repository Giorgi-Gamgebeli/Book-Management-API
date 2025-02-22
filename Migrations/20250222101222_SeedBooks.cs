using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookViews = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "BookViews", "IsDeleted", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Shota Rustaveli", 500, false, 1189, "The Knight in the Panther's Skin" },
                    { 2, "Chabua Amirejibi", 300, true, 1975, "Data Tutashkhia" },
                    { 3, "Vazha-Pshavela", 250, false, 1890, "The First Step" },
                    { 4, "Nodar Dumbadze", 400, false, 1960, "Me, Grandma, Iliko and Ilarioni" },
                    { 5, "David Kldiashvili", 180, false, 1964, "The Father of Soldiers" },
                    { 6, "Konstantine Gamsakhurdia", 350, true, 1939, "The Right Hand of the Grand Master" },
                    { 7, "David Guramishvili", 200, false, 1787, "Davitiani" },
                    { 8, "Alexander Kazbegi", 275, false, 1881, "Spring in Kartli" },
                    { 9, "Ilia Chavchavadze", 320, true, 1890, "The Wine-Cellar" },
                    { 10, "Otar Chiladze", 290, false, 1962, "The Conductor" },
                    { 11, "Zviad Kharadze", 290, false, 1985, "The Dream of the Mountain" },
                    { 12, "Temur Aghiashvili", 350, true, 1950, "The Homeland of the Brave" },
                    { 13, "Otar Chiladze", 300, false, 1925, "Echoes of the Mountains" },
                    { 14, "Sandro Shanshiashvili", 410, false, 1934, "Whispers of the Past" },
                    { 15, "Akvani Lomaia", 370, true, 1870, "The Last Song of the Wind" },
                    { 16, "Levan Lomidze", 420, false, 1960, "Journey Through the Forgotten Lands" },
                    { 17, "Giorgi Kharshiladze", 260, false, 1950, "A Mother's Love" },
                    { 18, "Giorgi Nikoladze", 300, true, 1920, "Through the Eyes of the Brave" },
                    { 19, "Niko Gvetadze", 250, false, 1945, "The Silent River" },
                    { 20, "Soslan Geleishvili", 330, true, 1910, "Winds of Destiny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
