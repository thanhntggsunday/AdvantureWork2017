using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvantureWork.Model.Migrations
{
    public partial class AddTableUser_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdventureWorksDWBuildVersion",
                columns: table => new
                {
                    DBVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VersionDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseLog",
                columns: table => new
                {
                    DatabaseLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatabaseUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Event = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Schema = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Object = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TSQL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XmlEvent = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseLog_DatabaseLogID", x => x.DatabaseLogID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DimAccount",
                columns: table => new
                {
                    AccountKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentAccountKey = table.Column<int>(type: "int", nullable: true),
                    AccountCodeAlternateKey = table.Column<int>(type: "int", nullable: true),
                    ParentAccountCodeAlternateKey = table.Column<int>(type: "int", nullable: true),
                    AccountDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomMembers = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ValueType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomMemberOptions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimAccount", x => x.AccountKey);
                    table.ForeignKey(
                        name: "FK_DimAccount_DimAccount",
                        column: x => x.ParentAccountKey,
                        principalTable: "DimAccount",
                        principalColumn: "AccountKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimCurrency",
                columns: table => new
                {
                    CurrencyKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyAlternateKey = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCurrency_CurrencyKey", x => x.CurrencyKey);
                });

            migrationBuilder.CreateTable(
                name: "DimDate",
                columns: table => new
                {
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    FullDateAlternateKey = table.Column<DateTime>(type: "date", nullable: false),
                    DayNumberOfWeek = table.Column<byte>(type: "tinyint", nullable: false),
                    EnglishDayNameOfWeek = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpanishDayNameOfWeek = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FrenchDayNameOfWeek = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DayNumberOfMonth = table.Column<byte>(type: "tinyint", nullable: false),
                    DayNumberOfYear = table.Column<short>(type: "smallint", nullable: false),
                    WeekNumberOfYear = table.Column<byte>(type: "tinyint", nullable: false),
                    EnglishMonthName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpanishMonthName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FrenchMonthName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MonthNumberOfYear = table.Column<byte>(type: "tinyint", nullable: false),
                    CalendarQuarter = table.Column<byte>(type: "tinyint", nullable: false),
                    CalendarYear = table.Column<short>(type: "smallint", nullable: false),
                    CalendarSemester = table.Column<byte>(type: "tinyint", nullable: false),
                    FiscalQuarter = table.Column<byte>(type: "tinyint", nullable: false),
                    FiscalYear = table.Column<short>(type: "smallint", nullable: false),
                    FiscalSemester = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDate_DateKey", x => x.DateKey);
                });

            migrationBuilder.CreateTable(
                name: "DimDepartmentGroup",
                columns: table => new
                {
                    DepartmentGroupKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentDepartmentGroupKey = table.Column<int>(type: "int", nullable: true),
                    DepartmentGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDepartmentGroup", x => x.DepartmentGroupKey);
                    table.ForeignKey(
                        name: "FK_DimDepartmentGroup_DimDepartmentGroup",
                        column: x => x.ParentDepartmentGroupKey,
                        principalTable: "DimDepartmentGroup",
                        principalColumn: "DepartmentGroupKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimProductCategory",
                columns: table => new
                {
                    ProductCategoryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryAlternateKey = table.Column<int>(type: "int", nullable: true),
                    EnglishProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpanishProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrenchProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProductCategory_ProductCategoryKey", x => x.ProductCategoryKey);
                });

            migrationBuilder.CreateTable(
                name: "DimPromotion",
                columns: table => new
                {
                    PromotionKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionAlternateKey = table.Column<int>(type: "int", nullable: true),
                    EnglishPromotionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpanishPromotionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FrenchPromotionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiscountPct = table.Column<double>(type: "float", nullable: true),
                    EnglishPromotionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpanishPromotionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FrenchPromotionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnglishPromotionCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpanishPromotionCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FrenchPromotionCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MinQty = table.Column<int>(type: "int", nullable: true),
                    MaxQty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimPromotion_PromotionKey", x => x.PromotionKey);
                });

            migrationBuilder.CreateTable(
                name: "DimSalesReason",
                columns: table => new
                {
                    SalesReasonKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReasonAlternateKey = table.Column<int>(type: "int", nullable: false),
                    SalesReasonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesReasonReasonType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSalesReason_SalesReasonKey", x => x.SalesReasonKey);
                });

            migrationBuilder.CreateTable(
                name: "DimSalesTerritory",
                columns: table => new
                {
                    SalesTerritoryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesTerritoryAlternateKey = table.Column<int>(type: "int", nullable: true),
                    SalesTerritoryRegion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesTerritoryCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesTerritoryGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesTerritoryImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSalesTerritory_SalesTerritoryKey", x => x.SalesTerritoryKey);
                });

            migrationBuilder.CreateTable(
                name: "DimScenario",
                columns: table => new
                {
                    ScenarioKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScenarioName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimScenario", x => x.ScenarioKey);
                });

            migrationBuilder.CreateTable(
                name: "FactAdditionalInternationalProductDescription",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "int", nullable: false),
                    CultureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactAdditionalInternationalProductDescription_ProductKey_CultureName", x => new { x.ProductKey, x.CultureName });
                });

            migrationBuilder.CreateTable(
                name: "NewFactCurrencyRate",
                columns: table => new
                {
                    AverageRate = table.Column<float>(type: "real", nullable: true),
                    CurrencyID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CurrencyDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndOfDayRate = table.Column<float>(type: "real", nullable: true),
                    CurrencyKey = table.Column<int>(type: "int", nullable: true),
                    DateKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProspectiveBuyer",
                columns: table => new
                {
                    ProspectiveBuyerKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProspectAlternateKey = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "money", nullable: true),
                    TotalChildren = table.Column<byte>(type: "tinyint", nullable: true),
                    NumberChildrenAtHome = table.Column<byte>(type: "tinyint", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HouseOwnerFlag = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    NumberCarsOwned = table.Column<byte>(type: "tinyint", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Salutation = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Unknown = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectiveBuyer_ProspectiveBuyerKey", x => x.ProspectiveBuyerKey);
                });

            migrationBuilder.CreateTable(
                name: "DimOrganization",
                columns: table => new
                {
                    OrganizationKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentOrganizationKey = table.Column<int>(type: "int", nullable: true),
                    PercentageOfOwnership = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimOrganization", x => x.OrganizationKey);
                    table.ForeignKey(
                        name: "FK_DimOrganization_DimCurrency",
                        column: x => x.CurrencyKey,
                        principalTable: "DimCurrency",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DimOrganization_DimOrganization",
                        column: x => x.ParentOrganizationKey,
                        principalTable: "DimOrganization",
                        principalColumn: "OrganizationKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactCallCenter",
                columns: table => new
                {
                    FactCallCenterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    WageType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LevelOneOperators = table.Column<short>(type: "smallint", nullable: false),
                    LevelTwoOperators = table.Column<short>(type: "smallint", nullable: false),
                    TotalOperators = table.Column<short>(type: "smallint", nullable: false),
                    Calls = table.Column<int>(type: "int", nullable: false),
                    AutomaticResponses = table.Column<int>(type: "int", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false),
                    IssuesRaised = table.Column<short>(type: "smallint", nullable: false),
                    AverageTimePerIssue = table.Column<short>(type: "smallint", nullable: false),
                    ServiceGrade = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactCallCenter", x => x.FactCallCenterID);
                    table.ForeignKey(
                        name: "FK_FactCallCenter_DimDate",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactCurrencyRate",
                columns: table => new
                {
                    CurrencyKey = table.Column<int>(type: "int", nullable: false),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    AverageRate = table.Column<double>(type: "float", nullable: false),
                    EndOfDayRate = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactCurrencyRate_CurrencyKey_DateKey", x => new { x.CurrencyKey, x.DateKey });
                    table.ForeignKey(
                        name: "FK_FactCurrencyRate_DimCurrency",
                        column: x => x.CurrencyKey,
                        principalTable: "DimCurrency",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactCurrencyRate_DimDate",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimProductSubcategory",
                columns: table => new
                {
                    ProductSubcategoryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSubcategoryAlternateKey = table.Column<int>(type: "int", nullable: true),
                    EnglishProductSubcategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpanishProductSubcategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrenchProductSubcategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductCategoryKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProductSubcategory_ProductSubcategoryKey", x => x.ProductSubcategoryKey);
                    table.ForeignKey(
                        name: "FK_DimProductSubcategory_DimProductCategory",
                        column: x => x.ProductCategoryKey,
                        principalTable: "DimProductCategory",
                        principalColumn: "ProductCategoryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimEmployee",
                columns: table => new
                {
                    EmployeeKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentEmployeeKey = table.Column<int>(type: "int", nullable: true),
                    EmployeeNationalIDAlternateKey = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ParentEmployeeNationalIDAlternateKey = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SalesTerritoryKey = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameStyle = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    LoginID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SalariedFlag = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    PayFrequency = table.Column<byte>(type: "tinyint", nullable: true),
                    BaseRate = table.Column<decimal>(type: "money", nullable: true),
                    VacationHours = table.Column<short>(type: "smallint", nullable: true),
                    SickLeaveHours = table.Column<short>(type: "smallint", nullable: true),
                    CurrentFlag = table.Column<bool>(type: "bit", nullable: false),
                    SalesPersonFlag = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimEmployee_EmployeeKey", x => x.EmployeeKey);
                    table.ForeignKey(
                        name: "FK_DimEmployee_DimEmployee",
                        column: x => x.ParentEmployeeKey,
                        principalTable: "DimEmployee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DimEmployee_DimSalesTerritory",
                        column: x => x.SalesTerritoryKey,
                        principalTable: "DimSalesTerritory",
                        principalColumn: "SalesTerritoryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimGeography",
                columns: table => new
                {
                    GeographyKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    StateProvinceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    EnglishCountryRegionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpanishCountryRegionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FrenchCountryRegionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SalesTerritoryKey = table.Column<int>(type: "int", nullable: true),
                    IpAddressLocator = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimGeography_GeographyKey", x => x.GeographyKey);
                    table.ForeignKey(
                        name: "FK_DimGeography_DimSalesTerritory",
                        column: x => x.SalesTerritoryKey,
                        principalTable: "DimSalesTerritory",
                        principalColumn: "SalesTerritoryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactFinance",
                columns: table => new
                {
                    FinanceKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    OrganizationKey = table.Column<int>(type: "int", nullable: false),
                    DepartmentGroupKey = table.Column<int>(type: "int", nullable: false),
                    ScenarioKey = table.Column<int>(type: "int", nullable: false),
                    AccountKey = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FactFinance_DimAccount",
                        column: x => x.AccountKey,
                        principalTable: "DimAccount",
                        principalColumn: "AccountKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactFinance_DimDate",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactFinance_DimDepartmentGroup",
                        column: x => x.DepartmentGroupKey,
                        principalTable: "DimDepartmentGroup",
                        principalColumn: "DepartmentGroupKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactFinance_DimOrganization",
                        column: x => x.OrganizationKey,
                        principalTable: "DimOrganization",
                        principalColumn: "OrganizationKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactFinance_DimScenario",
                        column: x => x.ScenarioKey,
                        principalTable: "DimScenario",
                        principalColumn: "ScenarioKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimProduct",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductAlternateKey = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ProductSubcategoryKey = table.Column<int>(type: "int", nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
                    EnglishProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpanishProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrenchProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StandardCost = table.Column<decimal>(type: "money", nullable: true),
                    FinishedGoodsFlag = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SafetyStockLevel = table.Column<short>(type: "smallint", nullable: true),
                    ReorderPoint = table.Column<short>(type: "smallint", nullable: true),
                    ListPrice = table.Column<decimal>(type: "money", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SizeRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    DaysToManufacture = table.Column<int>(type: "int", nullable: true),
                    ProductLine = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: true),
                    DealerPrice = table.Column<decimal>(type: "money", nullable: true),
                    Class = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: true),
                    Style = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LargePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EnglishDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    FrenchDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ChineseDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ArabicDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    HebrewDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ThaiDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GermanDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    JapaneseDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TurkishDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProduct_ProductKey", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_DimProduct_DimProductSubcategory",
                        column: x => x.ProductSubcategoryKey,
                        principalTable: "DimProductSubcategory",
                        principalColumn: "ProductSubcategoryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactSalesQuota",
                columns: table => new
                {
                    SalesQuotaKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeKey = table.Column<int>(type: "int", nullable: false),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    CalendarYear = table.Column<short>(type: "smallint", nullable: false),
                    CalendarQuarter = table.Column<byte>(type: "tinyint", nullable: false),
                    SalesAmountQuota = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactSalesQuota_SalesQuotaKey", x => x.SalesQuotaKey);
                    table.ForeignKey(
                        name: "FK_FactSalesQuota_DimDate",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactSalesQuota_DimEmployee",
                        column: x => x.EmployeeKey,
                        principalTable: "DimEmployee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimCustomer",
                columns: table => new
                {
                    CustomerKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeographyKey = table.Column<int>(type: "int", nullable: true),
                    CustomerAlternateKey = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameStyle = table.Column<bool>(type: "bit", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "money", nullable: true),
                    TotalChildren = table.Column<byte>(type: "tinyint", nullable: true),
                    NumberChildrenAtHome = table.Column<byte>(type: "tinyint", nullable: true),
                    EnglishEducation = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SpanishEducation = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FrenchEducation = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EnglishOccupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpanishOccupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FrenchOccupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HouseOwnerFlag = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    NumberCarsOwned = table.Column<byte>(type: "tinyint", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateFirstPurchase = table.Column<DateTime>(type: "date", nullable: true),
                    CommuteDistance = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCustomer_CustomerKey", x => x.CustomerKey);
                    table.ForeignKey(
                        name: "FK_DimCustomer_DimGeography",
                        column: x => x.GeographyKey,
                        principalTable: "DimGeography",
                        principalColumn: "GeographyKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimReseller",
                columns: table => new
                {
                    ResellerKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeographyKey = table.Column<int>(type: "int", nullable: true),
                    ResellerAlternateKey = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BusinessType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ResellerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberEmployees = table.Column<int>(type: "int", nullable: true),
                    OrderFrequency = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    OrderMonth = table.Column<byte>(type: "tinyint", nullable: true),
                    FirstOrderYear = table.Column<int>(type: "int", nullable: true),
                    LastOrderYear = table.Column<int>(type: "int", nullable: true),
                    ProductLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AnnualSales = table.Column<decimal>(type: "money", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinPaymentType = table.Column<byte>(type: "tinyint", nullable: true),
                    MinPaymentAmount = table.Column<decimal>(type: "money", nullable: true),
                    AnnualRevenue = table.Column<decimal>(type: "money", nullable: true),
                    YearOpened = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimReseller_ResellerKey", x => x.ResellerKey);
                    table.ForeignKey(
                        name: "FK_DimReseller_DimGeography",
                        column: x => x.GeographyKey,
                        principalTable: "DimGeography",
                        principalColumn: "GeographyKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactProductInventory",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "int", nullable: false),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "date", nullable: false),
                    UnitCost = table.Column<decimal>(type: "money", nullable: false),
                    UnitsIn = table.Column<int>(type: "int", nullable: false),
                    UnitsOut = table.Column<int>(type: "int", nullable: false),
                    UnitsBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactProductInventory", x => new { x.ProductKey, x.DateKey });
                    table.ForeignKey(
                        name: "FK_FactProductInventory_DimDate",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactProductInventory_DimProduct",
                        column: x => x.ProductKey,
                        principalTable: "DimProduct",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactInternetSales",
                columns: table => new
                {
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SalesOrderLineNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductKey = table.Column<int>(type: "int", nullable: false),
                    OrderDateKey = table.Column<int>(type: "int", nullable: false),
                    DueDateKey = table.Column<int>(type: "int", nullable: false),
                    ShipDateKey = table.Column<int>(type: "int", nullable: false),
                    CustomerKey = table.Column<int>(type: "int", nullable: false),
                    PromotionKey = table.Column<int>(type: "int", nullable: false),
                    CurrencyKey = table.Column<int>(type: "int", nullable: false),
                    SalesTerritoryKey = table.Column<int>(type: "int", nullable: false),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderQuantity = table.Column<short>(type: "smallint", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    ExtendedAmount = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscountPct = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    ProductStandardCost = table.Column<decimal>(type: "money", nullable: false),
                    TotalProductCost = table.Column<decimal>(type: "money", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "money", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false),
                    Freight = table.Column<decimal>(type: "money", nullable: false),
                    CarrierTrackingNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CustomerPONumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactInternetSales_SalesOrderNumber_SalesOrderLineNumber", x => new { x.SalesOrderNumber, x.SalesOrderLineNumber });
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimCurrency",
                        column: x => x.CurrencyKey,
                        principalTable: "DimCurrency",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimCustomer",
                        column: x => x.CustomerKey,
                        principalTable: "DimCustomer",
                        principalColumn: "CustomerKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimDate",
                        column: x => x.OrderDateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimDate1",
                        column: x => x.DueDateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimDate2",
                        column: x => x.ShipDateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimProduct",
                        column: x => x.ProductKey,
                        principalTable: "DimProduct",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimPromotion",
                        column: x => x.PromotionKey,
                        principalTable: "DimPromotion",
                        principalColumn: "PromotionKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimSalesTerritory",
                        column: x => x.SalesTerritoryKey,
                        principalTable: "DimSalesTerritory",
                        principalColumn: "SalesTerritoryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactSurveyResponse",
                columns: table => new
                {
                    SurveyResponseKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    CustomerKey = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryKey = table.Column<int>(type: "int", nullable: false),
                    EnglishProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductSubcategoryKey = table.Column<int>(type: "int", nullable: false),
                    EnglishProductSubcategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactSurveyResponse_SurveyResponseKey", x => x.SurveyResponseKey);
                    table.ForeignKey(
                        name: "FK_FactSurveyResponse_CustomerKey",
                        column: x => x.CustomerKey,
                        principalTable: "DimCustomer",
                        principalColumn: "CustomerKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactSurveyResponse_DateKey",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactResellerSales",
                columns: table => new
                {
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SalesOrderLineNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductKey = table.Column<int>(type: "int", nullable: false),
                    OrderDateKey = table.Column<int>(type: "int", nullable: false),
                    DueDateKey = table.Column<int>(type: "int", nullable: false),
                    ShipDateKey = table.Column<int>(type: "int", nullable: false),
                    ResellerKey = table.Column<int>(type: "int", nullable: false),
                    EmployeeKey = table.Column<int>(type: "int", nullable: false),
                    PromotionKey = table.Column<int>(type: "int", nullable: false),
                    CurrencyKey = table.Column<int>(type: "int", nullable: false),
                    SalesTerritoryKey = table.Column<int>(type: "int", nullable: false),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: true),
                    OrderQuantity = table.Column<short>(type: "smallint", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: true),
                    ExtendedAmount = table.Column<decimal>(type: "money", nullable: true),
                    UnitPriceDiscountPct = table.Column<double>(type: "float", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: true),
                    ProductStandardCost = table.Column<decimal>(type: "money", nullable: true),
                    TotalProductCost = table.Column<decimal>(type: "money", nullable: true),
                    SalesAmount = table.Column<decimal>(type: "money", nullable: true),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: true),
                    Freight = table.Column<decimal>(type: "money", nullable: true),
                    CarrierTrackingNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CustomerPONumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactResellerSales_SalesOrderNumber_SalesOrderLineNumber", x => new { x.SalesOrderNumber, x.SalesOrderLineNumber });
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimCurrency",
                        column: x => x.CurrencyKey,
                        principalTable: "DimCurrency",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimDate",
                        column: x => x.OrderDateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimDate1",
                        column: x => x.DueDateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimDate2",
                        column: x => x.ShipDateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimEmployee",
                        column: x => x.EmployeeKey,
                        principalTable: "DimEmployee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimProduct",
                        column: x => x.ProductKey,
                        principalTable: "DimProduct",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimPromotion",
                        column: x => x.PromotionKey,
                        principalTable: "DimPromotion",
                        principalColumn: "PromotionKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimReseller",
                        column: x => x.ResellerKey,
                        principalTable: "DimReseller",
                        principalColumn: "ResellerKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimSalesTerritory",
                        column: x => x.SalesTerritoryKey,
                        principalTable: "DimSalesTerritory",
                        principalColumn: "SalesTerritoryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactInternetSalesReason",
                columns: table => new
                {
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SalesOrderLineNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    SalesReasonKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactInternetSalesReason_SalesOrderNumber_SalesOrderLineNumber_SalesReasonKey", x => new { x.SalesOrderNumber, x.SalesOrderLineNumber, x.SalesReasonKey });
                    table.ForeignKey(
                        name: "FK_FactInternetSalesReason_DimSalesReason",
                        column: x => x.SalesReasonKey,
                        principalTable: "DimSalesReason",
                        principalColumn: "SalesReasonKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactInternetSalesReason_FactInternetSales",
                        columns: x => new { x.SalesOrderNumber, x.SalesOrderLineNumber },
                        principalTable: "FactInternetSales",
                        principalColumns: new[] { "SalesOrderNumber", "SalesOrderLineNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DimAccount_ParentAccountKey",
                table: "DimAccount",
                column: "ParentAccountKey");

            migrationBuilder.CreateIndex(
                name: "AK_DimCurrency_CurrencyAlternateKey",
                table: "DimCurrency",
                column: "CurrencyAlternateKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimCustomer_CustomerAlternateKey",
                table: "DimCustomer",
                column: "CustomerAlternateKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimCustomer_GeographyKey",
                table: "DimCustomer",
                column: "GeographyKey");

            migrationBuilder.CreateIndex(
                name: "AK_DimDate_FullDateAlternateKey",
                table: "DimDate",
                column: "FullDateAlternateKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimDepartmentGroup_ParentDepartmentGroupKey",
                table: "DimDepartmentGroup",
                column: "ParentDepartmentGroupKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimEmployee_ParentEmployeeKey",
                table: "DimEmployee",
                column: "ParentEmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimEmployee_SalesTerritoryKey",
                table: "DimEmployee",
                column: "SalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimGeography_SalesTerritoryKey",
                table: "DimGeography",
                column: "SalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimOrganization_CurrencyKey",
                table: "DimOrganization",
                column: "CurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimOrganization_ParentOrganizationKey",
                table: "DimOrganization",
                column: "ParentOrganizationKey");

            migrationBuilder.CreateIndex(
                name: "AK_DimProduct_ProductAlternateKey_StartDate",
                table: "DimProduct",
                columns: new[] { "ProductAlternateKey", "StartDate" },
                unique: true,
                filter: "[ProductAlternateKey] IS NOT NULL AND [StartDate] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DimProduct_ProductSubcategoryKey",
                table: "DimProduct",
                column: "ProductSubcategoryKey");

            migrationBuilder.CreateIndex(
                name: "AK_DimProductCategory_ProductCategoryAlternateKey",
                table: "DimProductCategory",
                column: "ProductCategoryAlternateKey",
                unique: true,
                filter: "[ProductCategoryAlternateKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_DimProductSubcategory_ProductSubcategoryAlternateKey",
                table: "DimProductSubcategory",
                column: "ProductSubcategoryAlternateKey",
                unique: true,
                filter: "[ProductSubcategoryAlternateKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DimProductSubcategory_ProductCategoryKey",
                table: "DimProductSubcategory",
                column: "ProductCategoryKey");

            migrationBuilder.CreateIndex(
                name: "AK_DimPromotion_PromotionAlternateKey",
                table: "DimPromotion",
                column: "PromotionAlternateKey",
                unique: true,
                filter: "[PromotionAlternateKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_DimReseller_ResellerAlternateKey",
                table: "DimReseller",
                column: "ResellerAlternateKey",
                unique: true,
                filter: "[ResellerAlternateKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DimReseller_GeographyKey",
                table: "DimReseller",
                column: "GeographyKey");

            migrationBuilder.CreateIndex(
                name: "AK_DimSalesTerritory_SalesTerritoryAlternateKey",
                table: "DimSalesTerritory",
                column: "SalesTerritoryAlternateKey",
                unique: true,
                filter: "[SalesTerritoryAlternateKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_FactCallCenter_DateKey_Shift",
                table: "FactCallCenter",
                columns: new[] { "DateKey", "Shift" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactCurrencyRate_DateKey",
                table: "FactCurrencyRate",
                column: "DateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinance_AccountKey",
                table: "FactFinance",
                column: "AccountKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinance_DateKey",
                table: "FactFinance",
                column: "DateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinance_DepartmentGroupKey",
                table: "FactFinance",
                column: "DepartmentGroupKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinance_OrganizationKey",
                table: "FactFinance",
                column: "OrganizationKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinance_ScenarioKey",
                table: "FactFinance",
                column: "ScenarioKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_CurrencyKey",
                table: "FactInternetSales",
                column: "CurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_CustomerKey",
                table: "FactInternetSales",
                column: "CustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_DueDateKey",
                table: "FactInternetSales",
                column: "DueDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_OrderDateKey",
                table: "FactInternetSales",
                column: "OrderDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_ProductKey",
                table: "FactInternetSales",
                column: "ProductKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_PromotionKey",
                table: "FactInternetSales",
                column: "PromotionKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_SalesTerritoryKey",
                table: "FactInternetSales",
                column: "SalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_ShipDateKey",
                table: "FactInternetSales",
                column: "ShipDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSalesReason_SalesReasonKey",
                table: "FactInternetSalesReason",
                column: "SalesReasonKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactProductInventory_DateKey",
                table: "FactProductInventory",
                column: "DateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_CurrencyKey",
                table: "FactResellerSales",
                column: "CurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_DueDateKey",
                table: "FactResellerSales",
                column: "DueDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_EmployeeKey",
                table: "FactResellerSales",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_OrderDateKey",
                table: "FactResellerSales",
                column: "OrderDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_ProductKey",
                table: "FactResellerSales",
                column: "ProductKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_PromotionKey",
                table: "FactResellerSales",
                column: "PromotionKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_ResellerKey",
                table: "FactResellerSales",
                column: "ResellerKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_SalesTerritoryKey",
                table: "FactResellerSales",
                column: "SalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_ShipDateKey",
                table: "FactResellerSales",
                column: "ShipDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSalesQuota_DateKey",
                table: "FactSalesQuota",
                column: "DateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSalesQuota_EmployeeKey",
                table: "FactSalesQuota",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSurveyResponse_CustomerKey",
                table: "FactSurveyResponse",
                column: "CustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSurveyResponse_DateKey",
                table: "FactSurveyResponse",
                column: "DateKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventureWorksDWBuildVersion");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "DatabaseLog");

            migrationBuilder.DropTable(
                name: "FactAdditionalInternationalProductDescription");

            migrationBuilder.DropTable(
                name: "FactCallCenter");

            migrationBuilder.DropTable(
                name: "FactCurrencyRate");

            migrationBuilder.DropTable(
                name: "FactFinance");

            migrationBuilder.DropTable(
                name: "FactInternetSalesReason");

            migrationBuilder.DropTable(
                name: "FactProductInventory");

            migrationBuilder.DropTable(
                name: "FactResellerSales");

            migrationBuilder.DropTable(
                name: "FactSalesQuota");

            migrationBuilder.DropTable(
                name: "FactSurveyResponse");

            migrationBuilder.DropTable(
                name: "NewFactCurrencyRate");

            migrationBuilder.DropTable(
                name: "ProspectiveBuyer");

            migrationBuilder.DropTable(
                name: "DimAccount");

            migrationBuilder.DropTable(
                name: "DimDepartmentGroup");

            migrationBuilder.DropTable(
                name: "DimOrganization");

            migrationBuilder.DropTable(
                name: "DimScenario");

            migrationBuilder.DropTable(
                name: "DimSalesReason");

            migrationBuilder.DropTable(
                name: "FactInternetSales");

            migrationBuilder.DropTable(
                name: "DimReseller");

            migrationBuilder.DropTable(
                name: "DimEmployee");

            migrationBuilder.DropTable(
                name: "DimCurrency");

            migrationBuilder.DropTable(
                name: "DimCustomer");

            migrationBuilder.DropTable(
                name: "DimDate");

            migrationBuilder.DropTable(
                name: "DimProduct");

            migrationBuilder.DropTable(
                name: "DimPromotion");

            migrationBuilder.DropTable(
                name: "DimGeography");

            migrationBuilder.DropTable(
                name: "DimProductSubcategory");

            migrationBuilder.DropTable(
                name: "DimSalesTerritory");

            migrationBuilder.DropTable(
                name: "DimProductCategory");
        }
    }
}
