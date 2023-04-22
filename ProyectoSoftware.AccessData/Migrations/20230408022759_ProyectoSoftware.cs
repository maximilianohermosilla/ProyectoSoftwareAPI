using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoSoftware.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class ProyectoSoftware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "https://drive.google.com/file/d/1dP5O3M5hkZ_HkBuGnPqDIF7cc6omspoy/view", "Jamón y Queso", "Empanada Jamón y Queso", 250, "Extender la masa para empanadas. Rellenar con trozos de jamón y queso rallado. Luego cerrar la masa sobre el relleno y sellar los bordes con los dedos. Por último, colocarf las empanadas en el horno durante 15 o 20 minutos a 180°", 1 },
                    { 2, "https://drive.google.com/file/d/1HAsix1qgpinQNCYRTVMkupXSUO7h4Gd-/view", "Carne, cebolla, morrón, huevo, salsa de tomate", "Empanada Carne", 250, "Saltear cebolla y morrón en una sartén con aceite. Incorpororar carne picada, huevo cocido y salsa de tomate. Rellenar la masa con la preparación. Cerrar y sellar los bordes con los dedos. Colocar las empanadas en el horno durante 15 o 20 minutos a 180°", 1 },
                    { 3, "https://drive.google.com/file/d/1nXQuQ8YGwwcYlPZgyxTAdbbvqRYInXX2/view", "Pollo, cebolla, morrón, huevo", "Empanada Pollo", 250, "Saltear cebolla y morrón en una sartén con aceite. Incorpororar pollo trozado, huevo cocido y salsa de tomate. Rellenar la masa con la preparación. Cerrar y sellar los bordes con los dedos. Colocar las empanadas en el horno durante 15 minutos a 180°", 1 },
                    { 4, "https://drive.google.com/file/d/1-bqg5N6evDjhE94SnDSyIx2mwS7wBUyn/view", "Papa, sal", "Papas fritas", 800, "Cortar las papas en bastones. Precalentar una sartén con aceite y sumergir los bastones de papa hasta dorar", 2 },
                    { 5, "https://drive.google.com/file/d/1wKPc99Dk9pRwdnB7Hez5l7yQhP-3Vcpf/view", "Papa, sal, Queso cheddar", "Papas fritas con cheddar", 950, "Cortar las papas en bastones. Precalentar una sartén con aceite y sumergir los bastones de papa hasta dorar. Mezcñar las papas con queso cheddar", 2 },
                    { 6, "https://drive.google.com/file/d/1Jc4rZ65jBg8BEabxlbUshoaUYbf-qHRu/view", "Muzzarella, pan rallado", "Bastones de muzzarella", 850, "Cortar trozos de queso muzzarella. Marinar y rebozar con pan rallado. Precalentar una sartén con aceite y sumergir los bastones hasta dorar", 2 },
                    { 7, "https://drive.google.com/file/d/1bKbmpUGxozKYJOMnuXdRdpXom_Le13zI/view", "Harina, Jamón y Queso", "Sorrentinos", 1100, "Se cocinan de 5 a 6 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección ", 3 },
                    { 8, "https://drive.google.com/file/d/1j0NjEwgzN2yf2cKwhEAFHXm5Ys37er2M/view", "Harina, espinaca, ricota", "Ravioles", 1000, "Se cocinan de 5 a 6 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección", 3 },
                    { 9, "https://drive.google.com/file/d/1y4NG5yqIR8D_WitrKMBqM6EWdx6H4p0a/view", "Papa, harina, manteca", "Ñoquis", 1050, "Se cocinan de 3 a 4 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección", 3 },
                    { 10, "https://drive.google.com/file/d/1mjjIjiRTI_WU9fzdJO3KDNKHywHCB8-o/view", "Asado, vacío, chorizo, morcilla, riñon, molleja, entraña", "Parrillada para 2", 3200, "Carne salada y desgrasada previo a la cocción. Fuego encendido en base a leña y carbón. Cocción en tiempo adecuado para cada corte", 4 },
                    { 11, "https://drive.google.com/file/d/1G6D0pSscTwnvLyFpkt3UN7JfvIjwHFzt/view", "Matambre de cerdo, salsa de tomate, cebolla, morrón, jamón, muzzarella", "Matambre a la pizza", 2100, "Matambre de cerdo tiernizado previo a su cocción en la parrilla. Salsa preparada con cebolla y morrón salteados en pure de tomate. El matambre se sella en la parrilla de un lado, luego se da vuelta y se agregan la salsa y el queso", 4 },
                    { 12, "https://drive.google.com/file/d/1r2UJsC7elU9ypSs6qtGz1gJ2KhrvJXwI/view", "Harina, aceite, levadura, salsa de tomate, muzzarella", "Pizza Muzzarella", 1300, "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones que serán estiradas para formar cada pizza. Se agrega salsa de tomate y muzzarella y se cocina en el horno", 5 },
                    { 13, "https://drive.google.com/file/d/1fLWpcDgcvOvuedhjH8xdcYgNN_sd9rB1/view", "Harina, aceite, levadura, salsa de tomate, muzzarella, jamón, morrón", "Pizza Especial", 1500, "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones que serán estiradas para formar cada pizza. Se agrega salsa de tomate, muzzarella, jamón y morrones y se cocina en el horno", 5 },
                    { 14, "https://drive.google.com/file/d/1b8T3HsvPM0WNJ-N8k9J7I08yMXRGSiSS/view", "Harina, aceite, levadura, salsa de tomate, muzzarella, tomate, orégano, ajo", "Pizza Napolitana", 1500, "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones para formar cada pizza. Se agrega salsa de tomate, muzzarella, ajo tomate y orégano y se cocina en el horno", 5 },
                    { 15, "https://drive.google.com/file/d/1uM26gOQHspyEWeS5KXlE6Ab4weCXybnU/view", "Milanesa de ternera con perejil y ajo, pan", "Sandwich Milanesa Simple", 1000, "La carne es marinada con huevos, perejil, ajo al menos 30 minutos. Es rebozada con pan rallado y se introduce en una sartén con aceite a 180°", 6 },
                    { 16, "https://drive.google.com/file/d/1pVdf0j3VRW43ApQiM3hGBxm_w6EFpvbA/view", "Milanesa de ternera con perejil y ajo, pan, lechuga, tomate, huevo, jamón, queso", "Sandwich Milanesa Completo", 1300, "La carne es marinada con huevos, perejil, ajo al menos 30 minutos. Es rebozada con pan rallado y se introduce en una sartén con aceite a 180°. En el sandwicg se agrega lechuga, tomate, jamón, queso y un huevo frito", 6 },
                    { 17, "https://drive.google.com/file/d/16bcH3whOAZVZyGWa2Ju3Egw4TtidwvB4/view", "Hamburguesa carne, ajo, perejil, huevo, leche, pan", "Hamburguesa Simple", 750, "Se introduce la carne picada en un bol con ajo ý perejil picados, huevos, sal, pimienta y un poco de leche. Se agrega pan rallado y se mezcla. Luego se separan porciones para dar forma a cada hamburguesa que será cocinada en una plancha", 6 },
                    { 18, "https://drive.google.com/file/d/1WrjYHDq8v6BDs6eVcxXfDLgeVtoU0pKF/view", "Hamburguesa carne, lechuga, tomate, jamón, queso, huevo", "Hamburguesa Completa", 1000, "Se introduce la carne picada en un bol con ajo ý perejil, huevos, sal, pimienta y leche. Se agrega pan rallado y se mezcla. Se separan porciones para dar forma a cada hamburguesa. Al sandwich se agrega lechuga, tomate, jamón, queso y huevo", 6 },
                    { 19, "https://drive.google.com/file/d/1J906WVvVzkdbkGVIBGactSueFypvf8ss/view", "Lechuga, tomate, cebolla", "Ensalada Simple", 600, "Se corta la lechuga, el tomate y la cebolla y se mezclan los cortes en un bol. ", 7 },
                    { 20, "https://drive.google.com/file/d/1Mcozjvh0SWZweQygiQrzOrZrT9YVjOLZ/view", "Papa, zanahoria, arvejas, huevo, mayonesa", "Ensalada Rusa", 700, "Las papas, la zanahoria y los huevos son hervidos previamente. La papa, los huevos y la zanahoria son cortadas en pequeñas porciones y se agregan arvejas y mayonesa para mezclar todo posteriormente", 7 },
                    { 21, "https://drive.google.com/file/d/1hMYDum13KkHld5PMHp3jSTM9Oh_ExSOD/view", "No aplica", "Gaseosa", 500, "Ninguna", 8 },
                    { 22, "https://drive.google.com/file/d/1JslDFLsGxkWspmjjdnRlvAiHgXlJtOKI/view", "No aplica", "Agua saborizada", 450, "Ninguna", 8 },
                    { 23, "https://drive.google.com/file/d/1LGTebh1vaG4CmJTFyJ3iz0Sfc6JGd_U2/view", "No aplica", "Agua mineral sin gas", 300, "Ninguna", 8 },
                    { 24, "https://drive.google.com/file/d/1dwOplkCITA5xznlHXLVe-46OVOLI_Zvr/view", "No aplica", "Agua mineral con gas", 300, "Ninguna", 8 },
                    { 25, "https://drive.google.com/file/d/1DGF9Z8OB95lkedMSXb7qAuJyWVU0DvmP/view", "Lúpulo, cebada, malta", "Cerveza IPA", 750, "Ninguna", 9 },
                    { 26, "https://drive.google.com/file/d/1ud32oxsTAjsVbfcny0G9gwQc_8Mmsn_1/view", "Lúpulo, cebada, malta, caramelo", "Cerveza Scotish", 700, "Ninguna", 9 },
                    { 27, "https://drive.google.com/file/d/17oe10vyvebzJUNPchjug88NWI85WRwJ3/view", "Lúpulo, cebada, malta, cacao", "Cerveza Stout", 750, "Ninguna", 9 },
                    { 28, "https://drive.google.com/file/d/1qY-UUAqzQVBkPJ2o_ip_Wrx3MRFWVoQQ/view", "Leche, huevo, azúcar", "Flan", 500, "Se baten huevos con azúcar hasta disolver. Se calienta leche hasta el punto de hervor, se agrega la mezcla y se revuelve. En otro recipiente se prepara caramelo con azúcar y agua. El caramelo y la mezcla se cocinan a 170° en el horno a baño maría", 10 },
                    { 29, "https://drive.google.com/file/d/15y_y2dY8brhQDwS8fMmK-5NXABSVMBc8/view", "Helado de chocolate, dulce de leche, vainilla", "Helado", 600, "No aplica", 10 },
                    { 30, "https://drive.google.com/file/d/1E9j4LTrFyFVluEj0h72jHXZT5MSzrWOs/view", "Manzana, Naranja, Banana, Ananá, Durazno, Cereza", "Ensalada de frutas", 400, "Se quita la cascara de todas las frutas a excepción de la cereza. Luego se realizan cortes pequeños que serán mezclados en un bol con jugo de frutas", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
