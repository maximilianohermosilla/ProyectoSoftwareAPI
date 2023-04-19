﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSoftware.AccessData;

#nullable disable

namespace ProyectoSoftware.AccessData.Migrations
{
    [DbContext(typeof(ProyectoSoftwareContext))]
    [Migration("20230419223149_ProyectoSoftwareAPI")]
    partial class ProyectoSoftwareAPI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.Comanda", b =>
                {
                    b.Property<Guid>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<int>("FormaEntregaId")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotal")
                        .HasColumnType("int");

                    b.HasKey("ComandaId");

                    b.HasIndex("FormaEntregaId");

                    b.ToTable("Comanda", (string)null);
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.ComandaMercaderia", b =>
                {
                    b.Property<int>("ComandaMercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComandaMercaderiaId"));

                    b.Property<Guid>("ComandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MercaderiaId")
                        .HasColumnType("int");

                    b.HasKey("ComandaMercaderiaId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("MercaderiaId");

                    b.ToTable("ComandaMercaderia", (string)null);
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.FormaEntrega", b =>
                {
                    b.Property<int>("FormaEntregaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormaEntregaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FormaEntregaId");

                    b.ToTable("FormaEntrega", (string)null);

                    b.HasData(
                        new
                        {
                            FormaEntregaId = 1,
                            Descripcion = "Salon"
                        },
                        new
                        {
                            FormaEntregaId = 2,
                            Descripcion = "Delivery"
                        },
                        new
                        {
                            FormaEntregaId = 3,
                            Descripcion = "Pedidos Ya"
                        });
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.Mercaderia", b =>
                {
                    b.Property<int>("MercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MercaderiaId"));

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ingredientes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Preparacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TipoMercaderiaId")
                        .HasColumnType("int");

                    b.HasKey("MercaderiaId");

                    b.HasIndex("TipoMercaderiaId");

                    b.ToTable("Mercaderia", (string)null);

                    b.HasData(
                        new
                        {
                            MercaderiaId = 1,
                            Imagen = "https://drive.google.com/file/d/1dP5O3M5hkZ_HkBuGnPqDIF7cc6omspoy/view",
                            Ingredientes = "Jamón y Queso",
                            Nombre = "Empanada Jamón y Queso",
                            Precio = 250,
                            Preparacion = "Extender la masa para empanadas. Rellenar con trozos de jamón y queso rallado. Luego cerrar la masa sobre el relleno y sellar los bordes con los dedos. Por último, colocarf las empanadas en el horno durante 15 o 20 minutos a 180°",
                            TipoMercaderiaId = 1
                        },
                        new
                        {
                            MercaderiaId = 2,
                            Imagen = "https://drive.google.com/file/d/1HAsix1qgpinQNCYRTVMkupXSUO7h4Gd-/view",
                            Ingredientes = "Carne, cebolla, morrón, huevo, salsa de tomate",
                            Nombre = "Empanada Carne",
                            Precio = 250,
                            Preparacion = "Saltear cebolla y morrón en una sartén con aceite. Incorpororar carne picada, huevo cocido y salsa de tomate. Rellenar la masa con la preparación. Cerrar y sellar los bordes con los dedos. Colocar las empanadas en el horno durante 15 o 20 minutos a 180°",
                            TipoMercaderiaId = 1
                        },
                        new
                        {
                            MercaderiaId = 3,
                            Imagen = "https://drive.google.com/file/d/1nXQuQ8YGwwcYlPZgyxTAdbbvqRYInXX2/view",
                            Ingredientes = "Pollo, cebolla, morrón, huevo",
                            Nombre = "Empanada Pollo",
                            Precio = 250,
                            Preparacion = "Saltear cebolla y morrón en una sartén con aceite. Incorpororar pollo trozado, huevo cocido y salsa de tomate. Rellenar la masa con la preparación. Cerrar y sellar los bordes con los dedos. Colocar las empanadas en el horno durante 15 minutos a 180°",
                            TipoMercaderiaId = 1
                        },
                        new
                        {
                            MercaderiaId = 4,
                            Imagen = "https://drive.google.com/file/d/1-bqg5N6evDjhE94SnDSyIx2mwS7wBUyn/view",
                            Ingredientes = "Papa, sal",
                            Nombre = "Papas fritas",
                            Precio = 800,
                            Preparacion = "Cortar las papas en bastones. Precalentar una sartén con aceite y sumergir los bastones de papa hasta dorar",
                            TipoMercaderiaId = 2
                        },
                        new
                        {
                            MercaderiaId = 5,
                            Imagen = "https://drive.google.com/file/d/1wKPc99Dk9pRwdnB7Hez5l7yQhP-3Vcpf/view",
                            Ingredientes = "Papa, sal, Queso cheddar",
                            Nombre = "Papas fritas con cheddar",
                            Precio = 950,
                            Preparacion = "Cortar las papas en bastones. Precalentar una sartén con aceite y sumergir los bastones de papa hasta dorar. Mezcñar las papas con queso cheddar",
                            TipoMercaderiaId = 2
                        },
                        new
                        {
                            MercaderiaId = 6,
                            Imagen = "https://drive.google.com/file/d/1Jc4rZ65jBg8BEabxlbUshoaUYbf-qHRu/view",
                            Ingredientes = "Muzzarella, pan rallado",
                            Nombre = "Bastones de muzzarella",
                            Precio = 850,
                            Preparacion = "Cortar trozos de queso muzzarella. Marinar y rebozar con pan rallado. Precalentar una sartén con aceite y sumergir los bastones hasta dorar",
                            TipoMercaderiaId = 2
                        },
                        new
                        {
                            MercaderiaId = 7,
                            Imagen = "https://drive.google.com/file/d/1bKbmpUGxozKYJOMnuXdRdpXom_Le13zI/view",
                            Ingredientes = "Harina, Jamón y Queso",
                            Nombre = "Sorrentinos",
                            Precio = 1100,
                            Preparacion = "Se cocinan de 5 a 6 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección ",
                            TipoMercaderiaId = 3
                        },
                        new
                        {
                            MercaderiaId = 8,
                            Imagen = "https://drive.google.com/file/d/1j0NjEwgzN2yf2cKwhEAFHXm5Ys37er2M/view",
                            Ingredientes = "Harina, espinaca, ricota",
                            Nombre = "Ravioles",
                            Precio = 1000,
                            Preparacion = "Se cocinan de 5 a 6 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección",
                            TipoMercaderiaId = 3
                        },
                        new
                        {
                            MercaderiaId = 9,
                            Imagen = "https://drive.google.com/file/d/1y4NG5yqIR8D_WitrKMBqM6EWdx6H4p0a/view",
                            Ingredientes = "Papa, harina, manteca",
                            Nombre = "Ñoquis",
                            Precio = 1050,
                            Preparacion = "Se cocinan de 3 a 4 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección",
                            TipoMercaderiaId = 3
                        },
                        new
                        {
                            MercaderiaId = 10,
                            Imagen = "https://drive.google.com/file/d/1mjjIjiRTI_WU9fzdJO3KDNKHywHCB8-o/view",
                            Ingredientes = "Asado, vacío, chorizo, morcilla, riñon, molleja, entraña",
                            Nombre = "Parrillada para 2",
                            Precio = 3200,
                            Preparacion = "Carne salada y desgrasada previo a la cocción. Fuego encendido en base a leña y carbón. Cocción en tiempo adecuado para cada corte",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 11,
                            Imagen = "https://drive.google.com/file/d/1G6D0pSscTwnvLyFpkt3UN7JfvIjwHFzt/view",
                            Ingredientes = "Matambre de cerdo, salsa de tomate, cebolla, morrón, jamón, muzzarella",
                            Nombre = "Matambre a la pizza",
                            Precio = 2100,
                            Preparacion = "Matambre de cerdo tiernizado previo a su cocción en la parrilla. Salsa preparada con cebolla y morrón salteados en pure de tomate. El matambre se sella en la parrilla de un lado, luego se da vuelta y se agregan la salsa y el queso",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 12,
                            Imagen = "https://drive.google.com/file/d/1r2UJsC7elU9ypSs6qtGz1gJ2KhrvJXwI/view",
                            Ingredientes = "Harina, aceite, levadura, salsa de tomate, muzzarella",
                            Nombre = "Pizza Muzzarella",
                            Precio = 1300,
                            Preparacion = "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones que serán estiradas para formar cada pizza. Se agrega salsa de tomate y muzzarella y se cocina en el horno",
                            TipoMercaderiaId = 5
                        },
                        new
                        {
                            MercaderiaId = 13,
                            Imagen = "https://drive.google.com/file/d/1fLWpcDgcvOvuedhjH8xdcYgNN_sd9rB1/view",
                            Ingredientes = "Harina, aceite, levadura, salsa de tomate, muzzarella, jamón, morrón",
                            Nombre = "Pizza Especial",
                            Precio = 1500,
                            Preparacion = "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones que serán estiradas para formar cada pizza. Se agrega salsa de tomate, muzzarella, jamón y morrones y se cocina en el horno",
                            TipoMercaderiaId = 5
                        },
                        new
                        {
                            MercaderiaId = 14,
                            Imagen = "https://drive.google.com/file/d/1b8T3HsvPM0WNJ-N8k9J7I08yMXRGSiSS/view",
                            Ingredientes = "Harina, aceite, levadura, salsa de tomate, muzzarella, tomate, orégano, ajo",
                            Nombre = "Pizza Napolitana",
                            Precio = 1500,
                            Preparacion = "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones para formar cada pizza. Se agrega salsa de tomate, muzzarella, ajo tomate y orégano y se cocina en el horno",
                            TipoMercaderiaId = 5
                        },
                        new
                        {
                            MercaderiaId = 15,
                            Imagen = "https://drive.google.com/file/d/1uM26gOQHspyEWeS5KXlE6Ab4weCXybnU/view",
                            Ingredientes = "Milanesa de ternera con perejil y ajo, pan",
                            Nombre = "Sandwich Milanesa Simple",
                            Precio = 1000,
                            Preparacion = "La carne es marinada con huevos, perejil, ajo al menos 30 minutos. Es rebozada con pan rallado y se introduce en una sartén con aceite a 180°",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 16,
                            Imagen = "https://drive.google.com/file/d/1pVdf0j3VRW43ApQiM3hGBxm_w6EFpvbA/view",
                            Ingredientes = "Milanesa de ternera con perejil y ajo, pan, lechuga, tomate, huevo, jamón, queso",
                            Nombre = "Sandwich Milanesa Completo",
                            Precio = 1300,
                            Preparacion = "La carne es marinada con huevos, perejil, ajo al menos 30 minutos. Es rebozada con pan rallado y se introduce en una sartén con aceite a 180°. En el sandwicg se agrega lechuga, tomate, jamón, queso y un huevo frito",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 17,
                            Imagen = "https://drive.google.com/file/d/16bcH3whOAZVZyGWa2Ju3Egw4TtidwvB4/view",
                            Ingredientes = "Hamburguesa carne, ajo, perejil, huevo, leche, pan",
                            Nombre = "Hamburguesa Simple",
                            Precio = 750,
                            Preparacion = "Se introduce la carne picada en un bol con ajo ý perejil picados, huevos, sal, pimienta y un poco de leche. Se agrega pan rallado y se mezcla. Luego se separan porciones para dar forma a cada hamburguesa que será cocinada en una plancha",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 18,
                            Imagen = "https://drive.google.com/file/d/1WrjYHDq8v6BDs6eVcxXfDLgeVtoU0pKF/view",
                            Ingredientes = "Hamburguesa carne, lechuga, tomate, jamón, queso, huevo",
                            Nombre = "Hamburguesa Completa",
                            Precio = 1000,
                            Preparacion = "Se introduce la carne picada en un bol con ajo ý perejil, huevos, sal, pimienta y leche. Se agrega pan rallado y se mezcla. Se separan porciones para dar forma a cada hamburguesa. Al sandwich se agrega lechuga, tomate, jamón, queso y huevo",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 19,
                            Imagen = "https://drive.google.com/file/d/1J906WVvVzkdbkGVIBGactSueFypvf8ss/view",
                            Ingredientes = "Lechuga, tomate, cebolla",
                            Nombre = "Ensalada Simple",
                            Precio = 600,
                            Preparacion = "Se corta la lechuga, el tomate y la cebolla y se mezclan los cortes en un bol. ",
                            TipoMercaderiaId = 7
                        },
                        new
                        {
                            MercaderiaId = 20,
                            Imagen = "https://drive.google.com/file/d/1Mcozjvh0SWZweQygiQrzOrZrT9YVjOLZ/view",
                            Ingredientes = "Papa, zanahoria, arvejas, huevo, mayonesa",
                            Nombre = "Ensalada Rusa",
                            Precio = 700,
                            Preparacion = "Las papas, la zanahoria y los huevos son hervidos previamente. La papa, los huevos y la zanahoria son cortadas en pequeñas porciones y se agregan arvejas y mayonesa para mezclar todo posteriormente",
                            TipoMercaderiaId = 7
                        },
                        new
                        {
                            MercaderiaId = 21,
                            Imagen = "https://drive.google.com/file/d/1hMYDum13KkHld5PMHp3jSTM9Oh_ExSOD/view",
                            Ingredientes = "No aplica",
                            Nombre = "Gaseosa",
                            Precio = 500,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 22,
                            Imagen = "https://drive.google.com/file/d/1JslDFLsGxkWspmjjdnRlvAiHgXlJtOKI/view",
                            Ingredientes = "No aplica",
                            Nombre = "Agua saborizada",
                            Precio = 450,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 23,
                            Imagen = "https://drive.google.com/file/d/1LGTebh1vaG4CmJTFyJ3iz0Sfc6JGd_U2/view",
                            Ingredientes = "No aplica",
                            Nombre = "Agua mineral sin gas",
                            Precio = 300,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 24,
                            Imagen = "https://drive.google.com/file/d/1dwOplkCITA5xznlHXLVe-46OVOLI_Zvr/view",
                            Ingredientes = "No aplica",
                            Nombre = "Agua mineral con gas",
                            Precio = 300,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 25,
                            Imagen = "https://drive.google.com/file/d/1DGF9Z8OB95lkedMSXb7qAuJyWVU0DvmP/view",
                            Ingredientes = "Lúpulo, cebada, malta",
                            Nombre = "Cerveza IPA",
                            Precio = 750,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 9
                        },
                        new
                        {
                            MercaderiaId = 26,
                            Imagen = "https://drive.google.com/file/d/1ud32oxsTAjsVbfcny0G9gwQc_8Mmsn_1/view",
                            Ingredientes = "Lúpulo, cebada, malta, caramelo",
                            Nombre = "Cerveza Scotish",
                            Precio = 700,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 9
                        },
                        new
                        {
                            MercaderiaId = 27,
                            Imagen = "https://drive.google.com/file/d/17oe10vyvebzJUNPchjug88NWI85WRwJ3/view",
                            Ingredientes = "Lúpulo, cebada, malta, cacao",
                            Nombre = "Cerveza Stout",
                            Precio = 750,
                            Preparacion = "Ninguna",
                            TipoMercaderiaId = 9
                        },
                        new
                        {
                            MercaderiaId = 28,
                            Imagen = "https://drive.google.com/file/d/1qY-UUAqzQVBkPJ2o_ip_Wrx3MRFWVoQQ/view",
                            Ingredientes = "Leche, huevo, azúcar",
                            Nombre = "Flan",
                            Precio = 500,
                            Preparacion = "Se baten huevos con azúcar hasta disolver. Se calienta leche hasta el punto de hervor, se agrega la mezcla y se revuelve. En otro recipiente se prepara caramelo con azúcar y agua. El caramelo y la mezcla se cocinan a 170° en el horno a baño maría",
                            TipoMercaderiaId = 10
                        },
                        new
                        {
                            MercaderiaId = 29,
                            Imagen = "https://drive.google.com/file/d/15y_y2dY8brhQDwS8fMmK-5NXABSVMBc8/view",
                            Ingredientes = "Helado de chocolate, dulce de leche, vainilla",
                            Nombre = "Helado",
                            Precio = 600,
                            Preparacion = "No aplica",
                            TipoMercaderiaId = 10
                        },
                        new
                        {
                            MercaderiaId = 30,
                            Imagen = "https://drive.google.com/file/d/1E9j4LTrFyFVluEj0h72jHXZT5MSzrWOs/view",
                            Ingredientes = "Manzana, Naranja, Banana, Ananá, Durazno, Cereza",
                            Nombre = "Ensalada de frutas",
                            Precio = 400,
                            Preparacion = "Se quita la cascara de todas las frutas a excepción de la cereza. Luego se realizan cortes pequeños que serán mezclados en un bol con jugo de frutas",
                            TipoMercaderiaId = 10
                        });
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.TipoMercaderia", b =>
                {
                    b.Property<int>("TipoMercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMercaderiaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoMercaderiaId");

                    b.ToTable("TipoMercaderia", (string)null);

                    b.HasData(
                        new
                        {
                            TipoMercaderiaId = 1,
                            Descripcion = "Entrada"
                        },
                        new
                        {
                            TipoMercaderiaId = 2,
                            Descripcion = "Minutas"
                        },
                        new
                        {
                            TipoMercaderiaId = 3,
                            Descripcion = "Pastas"
                        },
                        new
                        {
                            TipoMercaderiaId = 4,
                            Descripcion = "Parrilla"
                        },
                        new
                        {
                            TipoMercaderiaId = 5,
                            Descripcion = "Pizzas"
                        },
                        new
                        {
                            TipoMercaderiaId = 6,
                            Descripcion = "Sandwich"
                        },
                        new
                        {
                            TipoMercaderiaId = 7,
                            Descripcion = "Ensaladas"
                        },
                        new
                        {
                            TipoMercaderiaId = 8,
                            Descripcion = "Bebidas"
                        },
                        new
                        {
                            TipoMercaderiaId = 9,
                            Descripcion = "Cerveza Artesanal"
                        },
                        new
                        {
                            TipoMercaderiaId = 10,
                            Descripcion = "Postres"
                        });
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.Comanda", b =>
                {
                    b.HasOne("ProyectoSoftware.Domain.Models.FormaEntrega", "FormaEntregaNavigation")
                        .WithMany("Comandas")
                        .HasForeignKey("FormaEntregaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaEntregaNavigation");
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.ComandaMercaderia", b =>
                {
                    b.HasOne("ProyectoSoftware.Domain.Models.Comanda", "ComandaNavigation")
                        .WithMany("ComandasMercaderia")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoSoftware.Domain.Models.Mercaderia", "MercaderiaNavigation")
                        .WithMany("ComandasMercaderia")
                        .HasForeignKey("MercaderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComandaNavigation");

                    b.Navigation("MercaderiaNavigation");
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.Mercaderia", b =>
                {
                    b.HasOne("ProyectoSoftware.Domain.Models.TipoMercaderia", "TipoMercaderiaNavigation")
                        .WithMany("Mercaderias")
                        .HasForeignKey("TipoMercaderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMercaderiaNavigation");
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.Comanda", b =>
                {
                    b.Navigation("ComandasMercaderia");
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.FormaEntrega", b =>
                {
                    b.Navigation("Comandas");
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.Mercaderia", b =>
                {
                    b.Navigation("ComandasMercaderia");
                });

            modelBuilder.Entity("ProyectoSoftware.Domain.Models.TipoMercaderia", b =>
                {
                    b.Navigation("Mercaderias");
                });
#pragma warning restore 612, 618
        }
    }
}
