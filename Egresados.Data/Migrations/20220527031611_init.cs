using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Egresados.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BolsaTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VacanteNombre = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolsaTrabajo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroEducativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroEducativo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LugarEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarEvento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: true),
                    FacultadId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerfilId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CentroId = table.Column<int>(type: "int", nullable: true),
                    CentroEducativoId = table.Column<int>(type: "int", nullable: true),
                    PerfilId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facultad_CentroEducativo_CentroEducativoId",
                        column: x => x.CentroEducativoId,
                        principalTable: "CentroEducativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facultad_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerfilId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincia_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraEvento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Sala = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LugarEventoId = table.Column<int>(type: "int", nullable: true),
                    FacultadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_LugarEvento_LugarEventoId",
                        column: x => x.LugarEventoId,
                        principalTable: "LugarEvento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CentroEducativo",
                columns: new[] { "Id", "Codigo", "FechaAlta", "FechaModificacion", "Nombre" },
                values: new object[] { 1, "CRA", new DateTime(2022, 5, 26, 22, 16, 10, 606, DateTimeKind.Local).AddTicks(1406), null, "Centro Regional de Azuero" });

            migrationBuilder.InsertData(
                table: "Facultad",
                columns: new[] { "Id", "CentroEducativoId", "CentroId", "Codigo", "FechaAlta", "FechaModificacion", "Nombre", "PerfilId" },
                values: new object[,]
                {
                    { 1, null, 1, "FISC", new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(9199), null, "Sistemas", null },
                    { 2, null, 1, "FIC", new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(9905), null, "Civil", null }
                });

            migrationBuilder.InsertData(
                table: "LugarEvento",
                columns: new[] { "Id", "Codigo", "FechaAlta", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "HTAzuero", new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(2198), null, "Hotel Azuero" },
                    { 2, "CRA", new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(2598), null, "UTP Azuero" }
                });

            migrationBuilder.InsertData(
                table: "Provincia",
                columns: new[] { "Id", "Codigo", "FechaAlta", "FechaModificacion", "Nombre", "PerfilId" },
                values: new object[,]
                {
                    { 1, "06", new DateTime(2022, 5, 26, 22, 16, 10, 602, DateTimeKind.Local).AddTicks(2907), null, "Herrera", null },
                    { 2, "07", new DateTime(2022, 5, 26, 22, 16, 10, 604, DateTimeKind.Local).AddTicks(896), null, "Los Santos", null }
                });

            migrationBuilder.InsertData(
                table: "Evento",
                columns: new[] { "Id", "Costo", "Descripcion", "FacultadId", "FechaAlta", "FechaBaja", "FechaEvento", "FechaModificacion", "HoraEvento", "LugarEventoId", "Nombre", "Sala" },
                values: new object[] { 1, 10.4m, "evento de prueba", 1, new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(5997), null, new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(6514), null, new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(5383), 1, "Evento 1", "1" });

            migrationBuilder.InsertData(
                table: "Evento",
                columns: new[] { "Id", "Costo", "Descripcion", "FacultadId", "FechaAlta", "FechaBaja", "FechaEvento", "FechaModificacion", "HoraEvento", "LugarEventoId", "Nombre", "Sala" },
                values: new object[] { 2, 10.4m, "evento de prueba", 1, new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(7655), null, new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(7656), null, new DateTime(2022, 5, 26, 22, 16, 10, 605, DateTimeKind.Local).AddTicks(7648), 1, "Evento 2", "2" });

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
                name: "IX_AspNetUsers_PerfilId",
                table: "AspNetUsers",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_FacultadId",
                table: "Evento",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_LugarEventoId",
                table: "Evento",
                column: "LugarEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facultad_CentroEducativoId",
                table: "Facultad",
                column: "CentroEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facultad_PerfilId",
                table: "Facultad",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PerfilId",
                table: "Provincia",
                column: "PerfilId");
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
                name: "BolsaTrabajo");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "LugarEvento");

            migrationBuilder.DropTable(
                name: "CentroEducativo");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
