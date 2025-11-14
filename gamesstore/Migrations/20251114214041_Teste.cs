using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamesstore.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categories (Name) VALUES ('Ação')");
            migrationBuilder.Sql("INSERT INTO categories (Name) VALUES ('RPG')");
            migrationBuilder.Sql("INSERT INTO categories (Name) VALUES ('Esportes')");

            // Games Categoria 1 - Ação
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('CyberStrike', 59.90, NOW(), '2020-05-10', 1)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Urban Warfare', 79.90, NOW(), '2021-11-20', 1)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Shadow Ops', 49.99, NOW(), '2019-02-15', 1)");

            // Games Categoria 2 - RPG
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Legends of Avaria', 129.90, NOW(), '2022-03-01', 2)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('ChronoSaga', 89.90, NOW(), '2020-08-18', 2)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Mystic Realms', 99.90, NOW(), '2021-12-05', 2)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Fallen Kingdom', 149.90, NOW(), '2018-10-11', 2)");

            // Games Categoria 3 - Esportes
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Soccer Pro 22', 59.90, NOW(), '2022-01-05', 3)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Ultimate Basketball', 69.90, NOW(), '2021-09-14', 3)");
            migrationBuilder.Sql("INSERT INTO games (Name, Price, Created_At, PublicationDate, CategoryId) VALUES ('Tennis Star', 39.99, NOW(), '2019-04-21', 3)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE categories");
            migrationBuilder.Sql("DROP TABLE games");
        }
    }
}
