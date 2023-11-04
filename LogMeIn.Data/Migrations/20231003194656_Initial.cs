using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogMeIn.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
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
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Breeders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Draft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    North = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    South = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
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
                name: "Cat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    TitleBeforeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAfterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PedigreeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Neutered = table.Column<bool>(type: "bit", nullable: true),
                    BreederId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FatherId = table.Column<int>(type: "int", nullable: true),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    IsSameAsExhibitor = table.Column<bool>(type: "bit", nullable: true),
                    IsHomeCat = table.Column<bool>(type: "bit", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Breeders_BreederId",
                        column: x => x.BreederId,
                        principalTable: "Breeders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_Cat_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Cat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cat_Cat_MotherId",
                        column: x => x.MotherId,
                        principalTable: "Cat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Locations_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibitions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exhibitions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnumFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnumFees_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeeEntranceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    MinCount = table.Column<int>(type: "int", nullable: false),
                    MaxCount = table.Column<int>(type: "int", nullable: false),
                    PriceKc = table.Column<double>(type: "float", nullable: false),
                    PriceEur = table.Column<double>(type: "float", nullable: false),
                    MinNumberOfCats = table.Column<int>(type: "int", nullable: false),
                    MaxNumberOfCats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeEntranceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeEntranceDetails_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DefaultBought = table.Column<bool>(type: "bit", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    JavascriptId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibiterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    Draft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_AspNetUsers_ExhibiterId",
                        column: x => x.ExhibiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnumRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    PriceKc = table.Column<double>(type: "float", nullable: false),
                    PriceEur = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnumRecords_EnumFees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "EnumFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManyToManyFeeEntrance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyToManyFeeEntrance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManyToManyFeeEntrance_FeeEntranceDetails_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "FeeEntranceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    MinCount = table.Column<int>(type: "int", nullable: false),
                    MaxCount = table.Column<int>(type: "int", nullable: false),
                    PriceKc = table.Column<double>(type: "float", nullable: false),
                    PriceEur = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeDetails_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CatOrder = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    PersonRegistrationId = table.Column<int>(type: "int", nullable: false),
                    LastStep = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatRegistrations_Cat_CatId",
                        column: x => x.CatId,
                        principalTable: "Cat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatRegistrations_PersonRegistrations_PersonRegistrationId",
                        column: x => x.PersonRegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnumStoredFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    bought = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumStoredFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnumStoredFees_EnumFees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "EnumFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnumStoredFees_PersonRegistrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Submitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonRegistrationId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_PersonRegistrations_PersonRegistrationId",
                        column: x => x.PersonRegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    bought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFees_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFees_PersonRegistrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CatFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    bought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatFees_CatRegistrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "CatRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatFees_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatManyToManyMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatManyToManyMappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatManyToManyMappers_CatRegistrations_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "CatRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Day<CatRegistration>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visited = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day<CatRegistration>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day<CatRegistration>_CatRegistrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "CatRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoredFees<Day<CatRegistration>, Fee, bool>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    bought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredFees<Day<CatRegistration>, Fee, bool>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoredFees<Day<CatRegistration>, Fee, bool>_Day<CatRegistration>_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Day<CatRegistration>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoredFees<Day<CatRegistration>, Fee, bool>_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "North", "South" },
                values: new object[] { 1, "Palackého třída 126", "49.240069", "16.591739" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Email", "Ico", "Name", "PlaceId", "TelNumber", "Website" },
                values: new object[] { 1, "KockyBrno@gmail.com", "03841979", "Kočky Brno", 1, "420 604 954 118", "https://www.kockybrno.cz/" });

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "Id", "Description", "EndDate", "LocationId", "Name", "OrganizationId", "RegistrationEnd", "StartDate", "Url" },
                values: new object[] { 1, "", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "XV. a XVI. Mezinárodní kočičí výstava", 1, new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "https://www.schk.cz/files/ko-kyBrno2023.pdf" });

            migrationBuilder.InsertData(
                table: "EnumFees",
                columns: new[] { "Id", "ExhibitionId", "Name", "Type" },
                values: new object[] { 4, 1, "Propagace vystavovatele", 2 });

            migrationBuilder.InsertData(
                table: "FeeEntranceDetails",
                columns: new[] { "Id", "ExhibitionId", "MaxCount", "MaxNumberOfCats", "MinCount", "MinNumberOfCats", "PriceEur", "PriceKc" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 1, 30.0, 700.0 },
                    { 2, 1, 2, 1, 2, 1, 50.0, 1200.0 },
                    { 3, 1, 2, 2147483647, 1, 1, 0.0, 0.0 },
                    { 4, 1, 1, 2147483647, 1, 1, 25.0, 600.0 },
                    { 5, 1, 2, 2147483647, 2, 1, 40.0, 1000.0 },
                    { 6, 1, 1, 2147483647, 1, 1, 35.0, 800.0 },
                    { 7, 1, 2, 2147483647, 2, 1, 60.0, 1400.0 },
                    { 8, 1, 1, 2147483647, 1, 1, 60.0, 400.0 },
                    { 9, 1, 2, 2147483647, 2, 1, 60.0, 700.0 },
                    { 10, 1, 1, 2147483647, 1, 3, 50.0, 600.0 },
                    { 11, 1, 2, 2147483647, 2, 3, 50.0, 900.0 }
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "DefaultBought", "ExhibitionId", "JavascriptId", "Name", "Order", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, "sturdyFee", "Mám sturdy klec větší než 60x60", 1, 1 },
                    { 2, true, 1, "ownCage", "Mám vlastní klec", 0, 1 },
                    { 3, true, 1, "doubleCage", "Dvojitá klec", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "EnumRecords",
                columns: new[] { "Id", "Default", "FeeId", "Name", "PriceEur", "PriceKc" },
                values: new object[,]
                {
                    { 5, false, 4, "Propagace na celou A4", 0.0, 500.0 },
                    { 6, true, 4, "Žádná propagace", 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "FeeDetails",
                columns: new[] { "Id", "FeeId", "MaxCount", "MinCount", "PriceEur", "PriceKc" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 4.0, 300.0 },
                    { 2, 2, 1, 1, 0.0, 0.0 },
                    { 3, 3, 1, 1, 4.0, 300.0 },
                    { 4, 3, 2, 2, 4.0, 600.0 }
                });

            migrationBuilder.InsertData(
                table: "ManyToManyFeeEntrance",
                columns: new[] { "Id", "AttributeId", "GroupId" },
                values: new object[,]
                {
                    { 1, 1, "1" },
                    { 2, 1, "3" },
                    { 3, 1, "5" },
                    { 4, 1, "7" },
                    { 5, 1, "9" },
                    { 6, 1, "2" },
                    { 7, 1, "4" },
                    { 8, 1, "6" },
                    { 9, 1, "8" },
                    { 10, 1, "10" },
                    { 11, 1, "11" },
                    { 12, 1, "12" },
                    { 13, 2, "1" },
                    { 14, 2, "3" },
                    { 15, 2, "5" },
                    { 16, 2, "7" },
                    { 17, 2, "9" },
                    { 18, 2, "2" },
                    { 19, 2, "4" },
                    { 20, 2, "6" },
                    { 21, 2, "8" },
                    { 22, 2, "10" },
                    { 23, 2, "11" },
                    { 24, 2, "12" },
                    { 25, 3, "13a" },
                    { 26, 3, "13b" },
                    { 27, 3, "13c" },
                    { 28, 4, "14" },
                    { 29, 4, "15" },
                    { 30, 5, "14" },
                    { 31, 5, "15" },
                    { 32, 6, "16" },
                    { 33, 7, "16" },
                    { 34, 8, "17" },
                    { 35, 9, "17" },
                    { 36, 10, "0" },
                    { 37, 10, "1" },
                    { 38, 10, "2" },
                    { 39, 10, "3" },
                    { 40, 10, "4" },
                    { 41, 10, "5" },
                    { 42, 10, "6" },
                    { 43, 10, "7" },
                    { 44, 10, "8" },
                    { 45, 10, "9" },
                    { 46, 10, "10" },
                    { 47, 10, "11" },
                    { 48, 10, "12" },
                    { 49, 10, "13a" },
                    { 50, 10, "13b" },
                    { 51, 10, "13c" },
                    { 52, 10, "14" },
                    { 53, 10, "15" },
                    { 54, 10, "16" },
                    { 55, 10, "17" },
                    { 56, 11, "0" },
                    { 57, 11, "1" },
                    { 58, 11, "2" },
                    { 59, 11, "3" },
                    { 60, 11, "4" },
                    { 61, 11, "5" },
                    { 62, 11, "6" },
                    { 63, 11, "7" },
                    { 64, 11, "8" },
                    { 65, 11, "9" },
                    { 66, 11, "10" },
                    { 67, 11, "11" },
                    { 68, 11, "12" },
                    { 69, 11, "13a" },
                    { 70, 11, "13b" },
                    { 71, 11, "13c" },
                    { 72, 11, "14" },
                    { 73, 11, "15" },
                    { 74, 11, "16" },
                    { 75, 11, "17" }
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
                name: "IX_Cat_BreederId",
                table: "Cat",
                column: "BreederId",
                unique: true,
                filter: "[BreederId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_FatherId",
                table: "Cat",
                column: "FatherId",
                unique: true,
                filter: "[FatherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_MotherId",
                table: "Cat",
                column: "MotherId",
                unique: true,
                filter: "[MotherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CatFees_FeeId",
                table: "CatFees",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatFees_RegistrationId",
                table: "CatFees",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_CatManyToManyMappers_AttributeId",
                table: "CatManyToManyMappers",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatRegistrations_CatId",
                table: "CatRegistrations",
                column: "CatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatRegistrations_PersonRegistrationId",
                table: "CatRegistrations",
                column: "PersonRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Day<CatRegistration>_RegistrationId",
                table: "Day<CatRegistration>",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumFees_ExhibitionId",
                table: "EnumFees",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumRecords_FeeId",
                table: "EnumRecords",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumStoredFees_FeeId",
                table: "EnumStoredFees",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumStoredFees_RegistrationId",
                table: "EnumStoredFees",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_LocationId",
                table: "Exhibitions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_OrganizationId",
                table: "Exhibitions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeDetails_FeeId",
                table: "FeeDetails",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeEntranceDetails_ExhibitionId",
                table: "FeeEntranceDetails",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_ExhibitionId",
                table: "Fees",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ManyToManyFeeEntrance_AttributeId",
                table: "ManyToManyFeeEntrance",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonRegistrationId",
                table: "Orders",
                column: "PersonRegistrationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PlaceId",
                table: "Organizations",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFees_FeeId",
                table: "PersonFees",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFees_RegistrationId",
                table: "PersonFees",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_ExhibiterId",
                table: "PersonRegistrations",
                column: "ExhibiterId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_ExhibitionId",
                table: "PersonRegistrations",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredFees<Day<CatRegistration>, Fee, bool>_FeeId",
                table: "StoredFees<Day<CatRegistration>, Fee, bool>",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredFees<Day<CatRegistration>, Fee, bool>_RegistrationId",
                table: "StoredFees<Day<CatRegistration>, Fee, bool>",
                column: "RegistrationId");
        }

        /// <inheritdoc />
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
                name: "CatFees");

            migrationBuilder.DropTable(
                name: "CatManyToManyMappers");

            migrationBuilder.DropTable(
                name: "EnumRecords");

            migrationBuilder.DropTable(
                name: "EnumStoredFees");

            migrationBuilder.DropTable(
                name: "FeeDetails");

            migrationBuilder.DropTable(
                name: "ManyToManyFeeEntrance");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PersonFees");

            migrationBuilder.DropTable(
                name: "StoredFees<Day<CatRegistration>, Fee, bool>");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EnumFees");

            migrationBuilder.DropTable(
                name: "FeeEntranceDetails");

            migrationBuilder.DropTable(
                name: "Day<CatRegistration>");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "CatRegistrations");

            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "PersonRegistrations");

            migrationBuilder.DropTable(
                name: "Breeders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
