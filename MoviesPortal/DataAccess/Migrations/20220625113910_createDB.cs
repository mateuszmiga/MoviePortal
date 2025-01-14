﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreativePersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhotographyPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreativePersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<int>(name: "Release Date", type: "int", maxLength: 2022, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false, defaultValue: "Nie dodano jeszcze żadnego opisu."),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForKids = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: "Nie dodano jeszcze żadnego opisu."),
                    Start_Year = table.Column<int>(type: "int", nullable: false),
                    End_Year = table.Column<int>(type: "int", nullable: false),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbRatio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteApiMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteApiMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteApiMovies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMovies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_CreativeP_Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_CreativeP_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_CreativeP_Movie_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_CreativeP_Movie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_CreativeP_Movie_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries_CreativeP_Role",
                columns: table => new
                {
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries_CreativeP_Role", x => new { x.TvSeriesId, x.CreativePersonId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativeP_Role_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativeP_Role_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativeP_Role_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries_Genre",
                columns: table => new
                {
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries_Genre", x => new { x.GenreId, x.TvSeriesId });
                    table.ForeignKey(
                        name: "FK_TvSeries_Genre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_Genre_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteTvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteTvSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteTvSeries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteTvSeries_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CreativePersons",
                columns: new[] { "Id", "DateOfBirth", "Name", "PhotographyPath", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1946, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sylvester", "https://i.pinimg.com/originals/be/8f/3d/be8f3dfb132eb1b867379235d75a37b1.jpg", "Stallone" },
                    { 2, new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "https://i.pinimg.com/originals/9d/73/d6/9d73d68e972ef3fd416f38c780e901ff.jpg", "Hardy" },
                    { 3, new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "https://i.pinimg.com/originals/13/62/b3/1362b30b97ed513559b4f28a5a3823f2.png", "Hemsworth" },
                    { 4, new DateTime(1976, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cillian", "https://i.pinimg.com/originals/cc/9a/3c/cc9a3cb9e0cd36b322a4491875c16be0.png", "Murphy" },
                    { 5, new DateTime(1975, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taika", "https://i.pinimg.com/originals/74/e4/a5/74e4a59cb0e2a110166fd2eef714ad37.jpg", "Waititi" },
                    { 6, new DateTime(1931, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ted", "https://tce-live2.s3.amazonaws.com/media/media/74b70c1f-c4c4-4b77-9c6f-114cb1d62fdb.jpg", "Kotcheff" },
                    { 7, new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher", "https://i.pinimg.com/736x/c7/c4/84/c7c484a0a51dd210405148c1f933ab54.jpg", "Nolan" },
                    { 8, new DateTime(1969, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cate", "https://i.pinimg.com/originals/d5/23/75/d52375bb559b121f8221877db8b653a8.jpg", "Blanchett" },
                    { 9, new DateTime(1981, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "https://i.redd.it/r9ytchitgnu01.jpg", "Hiddleston" },
                    { 10, new DateTime(1972, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Idris", "https://static.stereogum.com/uploads/2014/09/Idris-Elba.jpg", "Elba" },
                    { 11, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "https://i.pinimg.com/originals/26/ec/2c/26ec2c71b16085720e0f21f22f074999.jpg", "Downey Jr." },
                    { 12, new DateTime(1971, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe", "https://m.media-amazon.com/images/M/MV5BMTc2NzY1NTY5OF5BMl5BanBnXkFtZTgwNjY3ODczNjM@._V1_.jpg", "Russo" },
                    { 13, new DateTime(1970, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony", "https://m.media-amazon.com/images/M/MV5BMTc2NjM5MTM0Ml5BMl5BanBnXkFtZTgwMTY3ODczNjM@._V1_.jpg", "Russo" },
                    { 14, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett", "https://i.pinimg.com/originals/29/f7/b2/29f7b250f36d1758a7015e062c39b180.jpg", "Johansson" },
                    { 15, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "https://images.mubicdn.net/images/cast_member/32256/cache-2145-1600710858/image-w856.jpg?size=800x", "Evans" },
                    { 16, new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "https://cdn.lifestyleasia.com/wp-content/uploads/sites/7/2022/01/19151605/125891247_439627203697586_8066488800487655769_n.jpg", "Holland" },
                    { 17, new DateTime(1976, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benedict", "https://images.prismic.io/netflix-queue/8e7ebecd-0a79-4517-93e5-c2828603c6fb_SH21091+NFX+09B_01+IV+RGB.jpg?auto=compress,format&rect=33,0,1013,1350&w=2000&h=2666", "Cumberbatch" },
                    { 18, new DateTime(1971, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", "https://pbs.twimg.com/media/CIpuOJoUYAA_U1e.jpg", "Bettany" },
                    { 19, new DateTime(1989, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elizabeth", "https://m.media-amazon.com/images/M/MV5BMTZmYjFmNzItMDk4YS00NWE0LThkZmMtMmRkYzFmODVhOGU1XkEyXkFqcGdeQXVyMTU3NTQyMTg@._V1_.jpg", "Olsen" },
                    { 20, new DateTime(1969, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spike", "https://cdn.gracza.pl/galeria/mdb/o/116997531.jpg", "Jonze" },
                    { 21, new DateTime(1974, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joaquin", "https://www.interviewmagazine.com/wp-content/uploads/2015/03/img-star---joaquin-phoenix_152859450894-814x1000.jpg", "Phoenix" },
                    { 22, new DateTime(1974, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amy", "https://i.pinimg.com/originals/8e/09/9b/8e099b26d870e3577e730a9c61e0d355.jpg", "Adams" },
                    { 23, new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian", "https://i.pinimg.com/originals/47/87/fe/4787fe17d62edd2901c0c9b9056a9637.jpg", "Bale" },
                    { 24, new DateTime(1979, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heath", "https://i.pinimg.com/originals/aa/d2/0c/aad20c5c81fba355f879cec1f18f1bce.jpg", "Ledger" },
                    { 25, new DateTime(1969, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthew", "https://i.pinimg.com/originals/e9/7e/f2/e97ef25eb772ba0b04bc9ee6826d1552.jpg", "McConaughey" },
                    { 26, new DateTime(1982, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anne", "https://i.pinimg.com/originals/17/4e/2c/174e2ce83ea42b6fd971a773cbd5c45d.jpg", "Hathaway" },
                    { 27, new DateTime(1977, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jessica", "https://c4.wallpaperflare.com/wallpaper/728/39/584/women-actress-jessica-chastain-white-coat-wallpaper-preview.jpg", "Chastain" },
                    { 28, new DateTime(1942, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harrison", "https://i.pinimg.com/564x/4d/56/69/4d56692bc2b42418dc78693123dc2a31.jpg", "Ford" },
                    { 29, new DateTime(1951, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "https://i.pinimg.com/originals/0e/11/75/0e117523130725aae5a4b6e49a7d8787.png", "Hamill" },
                    { 30, new DateTime(1956, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carrie", "https://i.pinimg.com/originals/b5/db/f8/b5dbf8637c0f5787d26916cc04097d09.jpg", "Fisher" },
                    { 31, new DateTime(1914, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alec", "https://i.pinimg.com/736x/5c/00/a3/5c00a3d0575ebc6bc6c99c41896d3f37.jpg", "Guinness" },
                    { 32, new DateTime(1931, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F20%2F2022%2F01%2F14%2Fjames-earl-jones-21-2000.jpg", "Earl Jones" },
                    { 33, new DateTime(1944, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", "https://i.pinimg.com/originals/4a/a2/8d/4aa28ddad9d7b00ef950ac24a94dca1a.jpg", "Lucas" },
                    { 34, new DateTime(1923, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irvin", "https://upload.wikimedia.org/wikipedia/en/f/f7/Irvin_Kershner.jpg", "Kershner" },
                    { 35, new DateTime(1937, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richard", "https://m.media-amazon.com/images/M/MV5BMjgwY2ZkYjEtNzgxZi00ZDIyLWJhZWItZjg1NGQ4OWE5ZTZhXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_.jpg", "Marquand" },
                    { 36, new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven", "https://i.pinimg.com/736x/e2/5a/5c/e25a5c78c5077d6e78793fc720eb78cb.jpg", "Spielberg" },
                    { 37, new DateTime(1951, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karen", "https://i.pinimg.com/originals/22/54/7a/22547ac8ae5f59ad0d5fa156127781b4.jpg", "Allen" },
                    { 38, new DateTime(1944, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "https://www.flowee.cz/images/.thumbnails/images/misa_2020/unor_2020/gimli_box-0467378879.500x546cg.jpg", "Rhys-Davies" },
                    { 39, new DateTime(1930, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sean", "https://i.pinimg.com/originals/0e/01/c8/0e01c867c9a1fa680c741f32d1f8878a.jpg", "Connery" },
                    { 40, new DateTime(1962, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "https://i.pinimg.com/originals/ff/e7/09/ffe709086a975b0f38338fe63182a299.png", "Fincher" },
                    { 41, new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brad", "https://bi.im-g.pl/im/cd/52/18/z25503949IH,Brad-Pitt-w-New-York-Times.jpg", "Pitt" },
                    { 42, new DateTime(1969, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edward", "https://www.interviewmagazine.com/wp-content/uploads/2014/10/img-edward-norton_233002559555.jpg", "Norton" }
                });

            migrationBuilder.InsertData(
                table: "CreativePersons",
                columns: new[] { "Id", "DateOfBirth", "Name", "PhotographyPath", "Surname" },
                values: new object[,]
                {
                    { 43, new DateTime(1959, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", "https://i.pinimg.com/originals/a7/32/c0/a732c0f7d2f7c1d60e07b9794811f3e4.jpg", "Spacey" },
                    { 44, new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morgan", "https://i.pinimg.com/564x/9f/76/e8/9f76e87c8d4812916c7aec060a88c469--supporting-actor-morgan-freeman.jpg", "Freeman" },
                    { 45, new DateTime(1983, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jesse", "https://www4.pictures.zimbio.com/gi/Vivarium+Photocall+vnyP7s1-p9zx.jpg", "Eisenberg" },
                    { 46, new DateTime(1983, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew", "https://data.whicdn.com/images/4749775/original.jpg", "Garfield" },
                    { 47, new DateTime(1980, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jake", "https://i.pinimg.com/originals/00/be/20/00be20ddd9db763008a37e6c54e7a801.jpg", "Gyllenhaal" },
                    { 48, new DateTime(1967, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "https://i.pinimg.com/550x/e0/3b/17/e03b17c2cbb0f2ad648db40ca5eba9dd.jpg", "Ruffalo" },
                    { 49, new DateTime(1959, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sam", "https://cdn.gracza.pl/galeria/mdb/o/542286000.jpg", "Raimi" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "action" },
                    { 2, "adventure" },
                    { 3, "animated" },
                    { 4, "comedy" },
                    { 5, "drama" },
                    { 6, "fantasy" },
                    { 7, "historical" },
                    { 8, "horror" },
                    { 9, "sciFi" },
                    { 10, "thriller" },
                    { 11, "western" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "BackgroundPoster", "Description", "ImdbRatio", "IsForKids", "PosterPath", "Release Date", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "https://c4.wallpaperflare.com/wallpaper/1012/513/237/action-adventure-drama-film-wallpaper-preview.jpg", "A veteran Green Beret is forced by a cruel Sheriff and his deputies to flee into the mountains and wage an escalating one-man war against his pursuers.", "7.7", false, "https://image.tmdb.org/t/p/original/a9sa6ERZCpplbPEO7OMWE763CLD.jpg", 1982, "Rambo: First Blood", "https://www.youtube.com/watch?v=IAqLKlxY3Eo" },
                    { 2, "https://image.tmdb.org/t/p/original//6G2fLCVm9fiLyHvBrccq6GSe2ih.jpg", "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.", "7.9", true, "https://image.tmdb.org/t/p/original/rzRwTcFvttcN1ZpX2xv4j3tSdJu.jpg", 2017, "Thor: Ragnarok", "https://www.youtube.com/watch?v=ue80QwXMRHg" },
                    { 3, "https://wallpaperaccess.com/full/3528110.jpg", "Allied soldiers from Belgium, the British Commonwealth and Empire, and France are surrounded by the German Army and evacuated during a fierce battle in World War II.", "7.8", false, "https://image.tmdb.org/t/p/original/ebSnODDg9lbsMIaWg2uAbjn7TO5.jpg", 2017, "Dunkirk", "https://www.youtube.com/watch?v=F-eMt3SrfFU" },
                    { 4, "https://blog.hdwallsource.com/wp-content/uploads/2018/05/avengers-infinity-war-thanos-wallpaper-63589-65679-hd-wallpapers.jpg", "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", "8.4", true, "https://image.tmdb.org/t/p/original/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg", 2018, "Avengers: Infinity War", "https://www.youtube.com/watch?v=6ZfuNTqbHE8" },
                    { 5, "https://images7.alphacoders.com/100/1004126.png", "Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.", "7.8", true, "https://image.tmdb.org/t/p/original/rAGiXaUfPzY7CDEyNKUofk3Kw2e.jpg", 2016, "Captain America: Civil War", "https://www.youtube.com/watch?v=dKrVegVI0Us" },
                    { 6, "https://images2.alphacoders.com/523/thumb-1920-523274.jpg", "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", "8.6", true, "https://image.tmdb.org/t/p/original/6FfCtAuVAW8XJjZ7eWeLibRLWTw.jpg", 1977, "Star Wars: Episode IV - New Hope", "https://www.youtube.com/watch?v=vZ734NWnAHA" },
                    { 7, "https://wallpaperaccess.com/full/1602841.jpg", "After the Rebels are brutally overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.", "8.7", true, "https://image.tmdb.org/t/p/original/2l05cFWJacyIsTpsqSgH0wQXe4V.jpg", 1980, "Star Wars: Episode V - The Empire Strikes Back", "https://www.youtube.com/watch?v=JNwNXF9Y6kY" },
                    { 8, "https://images5.alphacoders.com/339/thumb-1920-339210.jpg", "After a daring mission to rescue Han Solo from Jabba the Hutt, the Rebels dispatch to Endor to destroy the second Death Star. Meanwhile, Luke struggles to help Darth Vader back from the dark side without falling into the Emperor's trap.", "8.3", true, "https://image.tmdb.org/t/p/original/1kAbMLKVJz7LGjs8nnp259tffry.jpg", 1983, "Star Wars: Episode VI - Return of the Jedi", "https://www.youtube.com/watch?v=5UfA_aKBGMc" },
                    { 9, "https://images2.alphacoders.com/865/thumb-1920-86520.jpg", "In 1936, archaeologist and adventurer Indiana Jones is hired by the U.S. government to find the Ark of the Covenant before Adolf Hitler's Nazis can obtain its awesome powers.", "8.4", true, "https://image.tmdb.org/t/p/original/ceG9VzoRAVGwivFU403Wc3AHRys.jpg", 1981, "Raiders of the Lost Ark", "https://www.youtube.com/watch?v=0xQSIdSRlAk" },
                    { 10, "https://wallpapercave.com/wp/wp4119239.jpg", "In 1938, after his father Professor Henry Jones, Sr. goes missing while pursuing the Holy Grail, Professor Henry 'Indiana' Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.", "8.2", true, "https://image.tmdb.org/t/p/original/sizg1AU8f8JDZX4QIgE4pjUMBvx.jpg", 1989, "Indiana Jones and the Last Crusade", "https://www.youtube.com/watch?v=DKg36LBVgfg" },
                    { 11, "https://images5.alphacoders.com/585/thumb-1920-585645.png", "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", "8.6", true, "https://image.tmdb.org/t/p/original/mS4EvhsrT0SQZOlWrQEzWI5KiUa.jpg", 2014, "Interstellar", "https://www.youtube.com/watch?v=zSWdZVtXT7E" },
                    { 12, "https://images.hdqwalls.com/wallpapers/the-dark-knight-aftermath-4k-yk.jpg", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "9.0", false, "https://image.tmdb.org/t/p/original/vGYJRor3pCyjbaCpJKC39MpJhIT.jpg", 2008, "The Dark Knight", "https://www.youtube.com/watch?v=EXeTwQWrcwY" },
                    { 13, "https://images4.alphacoders.com/645/thumb-1920-645704.jpeg", "In a near future, a lonely writer develops an unlikely relationship with an operating system designed to meet his every need.", "8.0", false, "https://image.tmdb.org/t/p/original/yk4J4aewWYNiBhD49WD7UaBBn37.jpg", 2013, "Her", "https://www.youtube.com/watch?v=ne6p6MfLBxc" },
                    { 14, "https://images.alphacoders.com/204/thumb-1920-204781.jpg", "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "8.8", false, "https://image.tmdb.org/t/p/original/a26cQPRhJPX6GbWfQbvZdrrp9j9.jpg", 1999, "Fight Club", "https://www.youtube.com/watch?v=O1nDozs-LxI" },
                    { 15, "https://c4.wallpaperflare.com/wallpaper/580/168/4/movie-se7en-brad-pitt-wallpaper-preview.jpg", "Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.", "8.6", false, "https://image.tmdb.org/t/p/original/sj8dIprCrqeVdikCsWODyjDjhST.jpg", 1995, "Se7en", "https://www.youtube.com/watch?v=znmZoVkCjpI" },
                    { 16, "https://www.axn.pl/sites/pl.fern.axn/files/ct_movie_f_primary_image/socialnetwork.jpg", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "7.8", false, "https://image.tmdb.org/t/p/original/jXbqfVHmvCikyTw2Lf5OhKyt9Ym.jpg", 2010, "The Social Network", "https://www.youtube.com/watch?v=lB95KLmpLR4" },
                    { 17, "https://www.highonfilms.com/wp-content/uploads/2017/10/zodiac-downey-gyllenhaal.jpg", "Between 1968 and 1983, a San Francisco cartoonist becomes an amateur detective obsessed with tracking down the Zodiac Killer, an unidentified individual who terrorizes Northern California with a killing spree.", "7.7", false, "https://image.tmdb.org/t/p/original/kqERBMBQ5L45VmtDiuWmZiAhgzg.jpg", 2007, "Zodiac", "https://www.youtube.com/watch?v=yNncHPl1UXg" },
                    { 18, "https://images.squarespace-cdn.com/content/v1/51b3dc8ee4b051b96ceb10de/911c7616-5036-4b64-9039-77ce53af8f52/limited-edition-poster-art-for-doctor-strange-in-the-multiverse-of-madness-from-artist-matt-ferguson.jpg", "Dr. Stephen Strange casts a forbidden spell that opens the doorway to the multiverse, including alternate versions of himself, whose threat to humanity is too great for the combined forces of Strange, Wong, and Wanda Maximoff.", "7.6", true, "https://image.tmdb.org/t/p/original/A7CzMZBitf00BAtb1kJa50pWPgV.jpg", 2022, "Doctor Strange in the Multiverse of Madness", "https://www.youtube.com/watch?v=aWzlQ2N6qqg" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Actor" },
                    { 2, "Director" }
                });

            migrationBuilder.InsertData(
                table: "Movie_Genre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 10, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 2 },
                    { 5, 4, 2 },
                    { 6, 1, 3 },
                    { 7, 5, 3 },
                    { 8, 7, 3 },
                    { 9, 1, 4 },
                    { 10, 2, 4 },
                    { 11, 4, 4 },
                    { 12, 1, 5 },
                    { 13, 2, 5 },
                    { 14, 4, 5 },
                    { 15, 1, 6 },
                    { 16, 2, 6 },
                    { 17, 6, 6 },
                    { 18, 7, 6 },
                    { 19, 1, 7 },
                    { 20, 2, 7 },
                    { 21, 6, 7 },
                    { 22, 9, 7 },
                    { 23, 1, 8 },
                    { 24, 2, 8 },
                    { 25, 6, 8 },
                    { 26, 9, 8 },
                    { 27, 1, 9 },
                    { 28, 2, 9 },
                    { 29, 6, 9 },
                    { 30, 1, 10 },
                    { 31, 2, 10 },
                    { 32, 6, 10 },
                    { 33, 2, 11 },
                    { 34, 5, 11 },
                    { 35, 9, 11 },
                    { 36, 1, 12 },
                    { 37, 5, 12 },
                    { 38, 5, 13 },
                    { 39, 9, 13 },
                    { 40, 5, 14 },
                    { 41, 10, 14 },
                    { 42, 5, 15 }
                });

            migrationBuilder.InsertData(
                table: "Movie_Genre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 43, 10, 15 },
                    { 44, 5, 16 },
                    { 45, 10, 16 },
                    { 46, 5, 17 },
                    { 47, 10, 17 },
                    { 48, 1, 18 },
                    { 50, 2, 18 },
                    { 51, 8, 18 }
                });

            migrationBuilder.InsertData(
                table: "Role_CreativeP_Movie",
                columns: new[] { "Id", "CreativePersonId", "MovieId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 6, 1, 2 },
                    { 3, 3, 2, 1 },
                    { 4, 9, 2, 1 },
                    { 5, 8, 2, 1 },
                    { 6, 10, 2, 1 },
                    { 7, 5, 2, 1 },
                    { 8, 5, 2, 2 },
                    { 9, 2, 3, 1 },
                    { 10, 4, 3, 1 },
                    { 11, 7, 3, 2 },
                    { 12, 3, 4, 1 },
                    { 13, 9, 4, 1 },
                    { 14, 10, 4, 1 },
                    { 15, 11, 4, 1 },
                    { 16, 14, 4, 1 },
                    { 17, 15, 4, 1 },
                    { 18, 16, 4, 1 },
                    { 19, 17, 4, 1 },
                    { 20, 18, 4, 1 },
                    { 21, 19, 4, 1 },
                    { 22, 13, 4, 2 },
                    { 23, 12, 4, 2 },
                    { 24, 11, 5, 1 },
                    { 25, 14, 5, 1 },
                    { 26, 15, 5, 1 },
                    { 27, 16, 5, 1 },
                    { 28, 18, 5, 1 },
                    { 29, 19, 5, 1 },
                    { 30, 12, 5, 2 },
                    { 31, 13, 5, 2 },
                    { 32, 28, 6, 1 },
                    { 33, 29, 6, 1 },
                    { 34, 30, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Role_CreativeP_Movie",
                columns: new[] { "Id", "CreativePersonId", "MovieId", "RoleId" },
                values: new object[,]
                {
                    { 35, 31, 6, 1 },
                    { 36, 32, 6, 1 },
                    { 37, 33, 6, 2 },
                    { 38, 28, 7, 1 },
                    { 39, 29, 7, 1 },
                    { 40, 30, 7, 1 },
                    { 41, 31, 7, 1 },
                    { 42, 32, 7, 1 },
                    { 43, 34, 7, 2 },
                    { 44, 28, 8, 1 },
                    { 45, 29, 8, 1 },
                    { 46, 30, 8, 1 },
                    { 47, 31, 8, 1 },
                    { 48, 32, 8, 1 },
                    { 49, 35, 8, 2 },
                    { 50, 28, 9, 1 },
                    { 51, 37, 9, 1 },
                    { 52, 38, 9, 1 },
                    { 53, 36, 9, 2 },
                    { 54, 28, 10, 1 },
                    { 55, 38, 10, 1 },
                    { 56, 39, 10, 1 },
                    { 57, 36, 10, 2 },
                    { 58, 25, 11, 1 },
                    { 59, 26, 11, 1 },
                    { 60, 27, 11, 1 },
                    { 61, 7, 11, 2 },
                    { 62, 4, 12, 1 },
                    { 63, 23, 12, 1 },
                    { 64, 24, 12, 1 },
                    { 65, 7, 12, 2 },
                    { 66, 14, 13, 1 },
                    { 67, 21, 13, 1 },
                    { 68, 22, 13, 1 },
                    { 69, 20, 13, 2 },
                    { 70, 41, 14, 1 },
                    { 71, 42, 14, 1 },
                    { 72, 40, 14, 2 },
                    { 73, 44, 15, 1 },
                    { 74, 43, 15, 1 },
                    { 75, 41, 15, 1 },
                    { 76, 40, 15, 2 }
                });

            migrationBuilder.InsertData(
                table: "Role_CreativeP_Movie",
                columns: new[] { "Id", "CreativePersonId", "MovieId", "RoleId" },
                values: new object[,]
                {
                    { 77, 45, 16, 1 },
                    { 78, 46, 16, 1 },
                    { 79, 40, 16, 2 },
                    { 80, 48, 17, 1 },
                    { 81, 11, 17, 1 },
                    { 82, 47, 17, 1 },
                    { 83, 40, 17, 2 },
                    { 84, 17, 18, 1 },
                    { 85, 19, 18, 1 },
                    { 86, 49, 18, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genre_GenreId",
                table: "Movie_Genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genre_MovieId",
                table: "Movie_Genre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_CreativePersonId",
                table: "Role_CreativeP_Movie",
                column: "CreativePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_MovieId",
                table: "Role_CreativeP_Movie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_RoleId",
                table: "Role_CreativeP_Movie",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvSeriesId",
                table: "Seasons",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_CreativeP_Role_CreativePersonId",
                table: "TvSeries_CreativeP_Role",
                column: "CreativePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_CreativeP_Role_RoleId",
                table: "TvSeries_CreativeP_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_Genre_TvSeriesId",
                table: "TvSeries_Genre",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteApiMovies_UserId",
                table: "UserFavoriteApiMovies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMovies_MovieId",
                table: "UserFavoriteMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMovies_UserId",
                table: "UserFavoriteMovies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteTvSeries_TvSeriesId",
                table: "UserFavoriteTvSeries",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteTvSeries_UserId",
                table: "UserFavoriteTvSeries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Movie_Genre");

            migrationBuilder.DropTable(
                name: "Role_CreativeP_Movie");

            migrationBuilder.DropTable(
                name: "TvSeries_CreativeP_Role");

            migrationBuilder.DropTable(
                name: "TvSeries_Genre");

            migrationBuilder.DropTable(
                name: "UserFavoriteApiMovies");

            migrationBuilder.DropTable(
                name: "UserFavoriteMovies");

            migrationBuilder.DropTable(
                name: "UserFavoriteTvSeries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "CreativePersons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TvSeries");
        }
    }
}
