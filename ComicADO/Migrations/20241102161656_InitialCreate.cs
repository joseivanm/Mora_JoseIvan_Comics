﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicADO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Pais = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Autor__F58AE9092334E25C", x => x.AutorID);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    EditorialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Editoria__D54C828EBDED7347", x => x.EditorialID);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NIF = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__958BE6F0A592DBBF", x => x.EmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoLocal",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoLocal", x => new { x.EmpleadoId, x.LocalId });
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    LocalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(9,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Local__499359DB8AB9ECEE", x => x.LocalID);
                });

            migrationBuilder.CreateTable(
                name: "Medio_De_Pago",
                columns: table => new
                {
                    Medio_De_PagoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Nombre_Corto = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medio_De__BBFD2763DAECE456", x => x.Medio_De_PagoID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Operacion",
                columns: table => new
                {
                    Tipo_OperacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tipo_Ope__F75BE529E376A9FC", x => x.Tipo_OperacionID);
                });

            migrationBuilder.CreateTable(
                name: "Comic",
                columns: table => new
                {
                    ComicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    AutorID = table.Column<int>(type: "int", nullable: true),
                    EditorialID = table.Column<int>(type: "int", nullable: true),
                    Precio_Compra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Precio_Venta = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comic__B8F0904EADD10E0E", x => x.ComicID);
                    table.ForeignKey(
                        name: "FK__Comic__AutorID__286302EC",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "AutorID");
                    table.ForeignKey(
                        name: "FK__Comic__Editorial__29572725",
                        column: x => x.EditorialID,
                        principalTable: "Editorial",
                        principalColumn: "EditorialID");
                });

            migrationBuilder.CreateTable(
                name: "Local_Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    LocalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Local_Em__3112D36D047C811E", x => new { x.EmpleadoID, x.LocalID });
                    table.ForeignKey(
                        name: "FK__Local_Emp__Emple__300424B4",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID");
                    table.ForeignKey(
                        name: "FK__Local_Emp__Local__30F848ED",
                        column: x => x.LocalID,
                        principalTable: "Local",
                        principalColumn: "LocalID");
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    OperacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medio_De_PagoID = table.Column<int>(type: "int", nullable: false),
                    Tipo_OperacionID = table.Column<int>(type: "int", nullable: false),
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    LocalID = table.Column<int>(type: "int", nullable: false),
                    Fecha_Operacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Operacio__8A668AF7E68D4AA0", x => x.OperacionID);
                    table.ForeignKey(
                        name: "FK__Operacion__Comic__3D5E1FD2",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID");
                    table.ForeignKey(
                        name: "FK__Operacion__Emple__3F466844",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID");
                    table.ForeignKey(
                        name: "FK__Operacion__Local__3E52440B",
                        column: x => x.LocalID,
                        principalTable: "Local",
                        principalColumn: "LocalID");
                    table.ForeignKey(
                        name: "FK__Operacion__Medio__3B75D760",
                        column: x => x.Medio_De_PagoID,
                        principalTable: "Medio_De_Pago",
                        principalColumn: "Medio_De_PagoID");
                    table.ForeignKey(
                        name: "FK__Operacion__Tipo___3C69FB99",
                        column: x => x.Tipo_OperacionID,
                        principalTable: "Tipo_Operacion",
                        principalColumn: "Tipo_OperacionID");
                });

            migrationBuilder.CreateTable(
                name: "Stock_Comic",
                columns: table => new
                {
                    Stock_ComicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    LocalID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stock_Co__3A77E093F1F1B3DD", x => x.Stock_ComicID);
                    table.ForeignKey(
                        name: "FK__Stock_Com__Comic__34C8D9D1",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID");
                    table.ForeignKey(
                        name: "FK__Stock_Com__Local__33D4B598",
                        column: x => x.LocalID,
                        principalTable: "Local",
                        principalColumn: "LocalID");
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Operacion",
                columns: table => new
                {
                    Detalle_OperacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionID = table.Column<int>(type: "int", nullable: false),
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(7,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Detalle___DA3A53714EA50D72", x => x.Detalle_OperacionID);
                    table.ForeignKey(
                        name: "FK__Detalle_O__Comic__4316F928",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID");
                    table.ForeignKey(
                        name: "FK__Detalle_O__Opera__4222D4EF",
                        column: x => x.OperacionID,
                        principalTable: "Operacion",
                        principalColumn: "OperacionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comic_AutorID",
                table: "Comic",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Comic_EditorialID",
                table: "Comic",
                column: "EditorialID");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Operacion_ComicID",
                table: "Detalle_Operacion",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Operacion_OperacionID",
                table: "Detalle_Operacion",
                column: "OperacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Local_Empleado_LocalID",
                table: "Local_Empleado",
                column: "LocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_ComicID",
                table: "Operacion",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_EmpleadoID",
                table: "Operacion",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_LocalID",
                table: "Operacion",
                column: "LocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Medio_De_PagoID",
                table: "Operacion",
                column: "Medio_De_PagoID");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Tipo_OperacionID",
                table: "Operacion",
                column: "Tipo_OperacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Comic_ComicID",
                table: "Stock_Comic",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Comic_LocalID",
                table: "Stock_Comic",
                column: "LocalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Operacion");

            migrationBuilder.DropTable(
                name: "EmpleadoLocal");

            migrationBuilder.DropTable(
                name: "Local_Empleado");

            migrationBuilder.DropTable(
                name: "Stock_Comic");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Comic");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "Medio_De_Pago");

            migrationBuilder.DropTable(
                name: "Tipo_Operacion");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Editorial");
        }
    }
}
