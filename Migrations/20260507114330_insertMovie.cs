using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema_Booking.Migrations
{
    /// <inheritdoc />
    public partial class insertMovie : Migration
    {
        /// <inheritdoc />
        
            protected override void Up(MigrationBuilder migrationBuilder)
        {
            //-------------------------
            // CATEGORY
            //-------------------------
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
            { 1, "Action" },
            { 2, "Sci-Fi" }
                });

            //-------------------------
            // CINEMA
            //-------------------------
            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Name" },
                values: new object[]
                {
            1, "Cairo Cinema"
                });

            //-------------------------
            // MOVIES
            //-------------------------
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[]
                {
            "Id",
            "Name",
            "Description",
            "Price",
            "Image",
            "SubImages",
            "CategoryId",
            "CinemaId"
                },
                values: new object[,]
                {
            {
                1,
                "Movie 1",
                "Action 1",
                100,
                "img1.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                1,
                1
            },
            {
                2,
                "Movie 2",
                "Sci-Fi 2",
                120,
                "img2.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                2,
                1
            },
            {
                3,
                "Movie 3",
                "Action 3",
                110,
                "img3.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                1,
                1
            },
            {
                4,
                "Movie 4",
                "Sci-Fi 4",
                130,
                "img4.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                2,
                1
            },
            {
                5,
                "Movie 5",
                "Action 5",
                140,
                "img5.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                1,
                1
            },
            {
                6,
                "Movie 6",
                "Sci-Fi 6",
                150,
                "img6.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                2,
                1
            },
            {
                7,
                "Movie 7",
                "Action 7",
                160,
                "img7.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                1,
                1
            },
            {
                8,
                "Movie 8",
                "Sci-Fi 8",
                170,
                "img8.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                2,
                1
            },
            {
                9,
                "Movie 9",
                "Action 9",
                180,
                "img9.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                1,
                1
            },
            {
                10,
                "Movie 10",
                "Sci-Fi 10",
                190,
                "img10.jpg",
                "[\"s1.jpg\",\"s2.jpg\"]",
                2,
                1
            }
                });

            //-------------------------
            // SHOWTIMES
            //-------------------------
            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "StartTime", "MovieId" },
                values: new object[,]
                {
            { 1, new DateTime(2026, 5, 6, 10, 0, 0), 1 },
            { 2, new DateTime(2026, 5, 6, 11, 0, 0), 2 },
            { 3, new DateTime(2026, 5, 6, 12, 0, 0), 3 },
            { 4, new DateTime(2026, 5, 6, 13, 0, 0), 4 },
            { 5, new DateTime(2026, 5, 6, 14, 0, 0), 5 },
            { 6, new DateTime(2026, 5, 6, 15, 0, 0), 6 },
            { 7, new DateTime(2026, 5, 6, 16, 0, 0), 7 },
            { 8, new DateTime(2026, 5, 6, 17, 0, 0), 8 },
            { 9, new DateTime(2026, 5, 6, 18, 0, 0), 9 },
            { 10, new DateTime(2026, 5, 6, 19, 0, 0), 10 }
                });
        }
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    -------------------------
    -- DELETE CHILD FIRST
    -------------------------
    DELETE FROM ShowTimes;

    -------------------------
    -- MOVIE ACTORS (لو موجودة عندك)
    -------------------------
    DELETE FROM MovieActor;

    -------------------------
    -- BOOKING (لو موجودة)
    -------------------------
    DELETE FROM Booking;

    -------------------------
    -- MOVIES
    -------------------------
    DELETE FROM Movie;

    -------------------------
    -- ACTORS
    -------------------------
    DELETE FROM Actor;

    -------------------------
    -- CINEMA
    -------------------------
    DELETE FROM Cinema;

    -------------------------
    -- CATEGORY
    -------------------------
    DELETE FROM Category;
");
        }


    }
}
