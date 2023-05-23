using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSoftware.AccessData
{
    public class ProyectoSoftwareContext : DbContext
    {
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<ComandaMercaderia> ComandasMercaderia { get; set; }
        public DbSet<FormaEntrega> FormasEntrega { get; set; }
        public DbSet<Mercaderia> Mercaderias { get; set; }
        public DbSet<TipoMercaderia> TiposMercaderia { get; set; }

        public ProyectoSoftwareContext(DbContextOptions<ProyectoSoftwareContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProyectoSoftware;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=ProyectoSoftware; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>().ToTable("Comanda").HasOne<FormaEntrega>(s => s.FormaEntregaNavigation).WithMany(g => g.Comandas).HasForeignKey(s => s.FormaEntregaId);
            modelBuilder.Entity<ComandaMercaderia>().ToTable("ComandaMercaderia");
            modelBuilder.Entity<ComandaMercaderia>().HasOne<Comanda>(s => s.ComandaNavigation).WithMany(g => g.ComandasMercaderia).HasForeignKey(s => s.ComandaId);
            modelBuilder.Entity<ComandaMercaderia>().HasOne<Mercaderia>(s => s.MercaderiaNavigation).WithMany(g => g.ComandasMercaderia).HasForeignKey(s => s.MercaderiaId);
            modelBuilder.Entity<Mercaderia>().ToTable("Mercaderia").HasOne<TipoMercaderia>(s => s.TipoMercaderiaNavigation).WithMany(g => g.Mercaderias).HasForeignKey(s => s.TipoMercaderiaId);
            modelBuilder.Entity<FormaEntrega>().ToTable("FormaEntrega");
            modelBuilder.Entity<TipoMercaderia>().ToTable("TipoMercaderia");

            modelBuilder.Entity<Comanda>().Property(x => x.Fecha).HasColumnType("Date");
            modelBuilder.Entity<FormaEntrega>().Property(x => x.Descripcion).HasMaxLength(50);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Nombre).HasMaxLength(50);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Ingredientes).HasMaxLength(255);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Preparacion).HasMaxLength(255);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Imagen).HasMaxLength(255);
            modelBuilder.Entity<TipoMercaderia>().Property(x => x.Descripcion).HasMaxLength(50);

            modelBuilder.Entity<TipoMercaderia>().HasData(
                new TipoMercaderia { TipoMercaderiaId = 1, Descripcion = "Entrada" },
                new TipoMercaderia { TipoMercaderiaId = 2, Descripcion = "Minutas" },
                new TipoMercaderia { TipoMercaderiaId = 3, Descripcion = "Pastas" },
                new TipoMercaderia { TipoMercaderiaId = 4, Descripcion = "Parrilla" },
                new TipoMercaderia { TipoMercaderiaId = 5, Descripcion = "Pizzas" },
                new TipoMercaderia { TipoMercaderiaId = 6, Descripcion = "Sandwich" },
                new TipoMercaderia { TipoMercaderiaId = 7, Descripcion = "Ensaladas" },
                new TipoMercaderia { TipoMercaderiaId = 8, Descripcion = "Bebidas" },
                new TipoMercaderia { TipoMercaderiaId = 9, Descripcion = "Cerveza Artesanal" },
                new TipoMercaderia { TipoMercaderiaId = 10, Descripcion = "Postres" }
            );

            modelBuilder.Entity<FormaEntrega>().HasData(
                new FormaEntrega { FormaEntregaId = 1, Descripcion = "Salon" },
                new FormaEntrega { FormaEntregaId = 2, Descripcion = "Delivery" },
                new FormaEntrega { FormaEntregaId = 3, Descripcion = "Pedidos Ya" }
            );

            modelBuilder.Entity<Mercaderia>().HasData(
                new Mercaderia { MercaderiaId = 1, Nombre = "Empanada Jamón y Queso", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Jamón y Queso", Preparacion = "Extender la masa para empanadas. Rellenar con trozos de jamón y queso rallado. Luego cerrar la masa sobre el relleno y sellar los bordes con los dedos. Por último, colocarf las empanadas en el horno durante 15 o 20 minutos a 180°", Imagen = "http://drive.google.com/uc?export=view&id=1dP5O3M5hkZ_HkBuGnPqDIF7cc6omspoy" },
                new Mercaderia { MercaderiaId = 2, Nombre = "Empanada Carne", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Carne, cebolla, morrón, huevo, salsa de tomate", Preparacion = "Saltear cebolla y morrón en una sartén con aceite. Incorpororar carne picada, huevo cocido y salsa de tomate. Rellenar la masa con la preparación. Cerrar y sellar los bordes con los dedos. Colocar las empanadas en el horno durante 15 o 20 minutos a 180°", Imagen = "http://drive.google.com/uc?export=view&id=1HAsix1qgpinQNCYRTVMkupXSUO7h4Gd-" },
                new Mercaderia { MercaderiaId = 3, Nombre = "Empanada Pollo", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Pollo, cebolla, morrón, huevo", Preparacion = "Saltear cebolla y morrón en una sartén con aceite. Incorpororar pollo trozado, huevo cocido y salsa de tomate. Rellenar la masa con la preparación. Cerrar y sellar los bordes con los dedos. Colocar las empanadas en el horno durante 15 minutos a 180°", Imagen = "http://drive.google.com/uc?export=view&id=1nXQuQ8YGwwcYlPZgyxTAdbbvqRYInXX2" },
                new Mercaderia { MercaderiaId = 4, Nombre = "Papas fritas", TipoMercaderiaId = 2, Precio = 800, Ingredientes = "Papa, sal", Preparacion = "Cortar las papas en bastones. Precalentar una sartén con aceite y sumergir los bastones de papa hasta dorar", Imagen = "http://drive.google.com/uc?export=view&id=1-bqg5N6evDjhE94SnDSyIx2mwS7wBUyn" },
                new Mercaderia { MercaderiaId = 5, Nombre = "Papas fritas con cheddar", TipoMercaderiaId = 2, Precio = 950, Ingredientes = "Papa, sal, Queso cheddar", Preparacion = "Cortar las papas en bastones. Precalentar una sartén con aceite y sumergir los bastones de papa hasta dorar. Mezcñar las papas con queso cheddar", Imagen = "http://drive.google.com/uc?export=view&id=1wKPc99Dk9pRwdnB7Hez5l7yQhP-3Vcpf" },
                new Mercaderia { MercaderiaId = 6, Nombre = "Bastones de muzzarella", TipoMercaderiaId = 2, Precio = 850, Ingredientes = "Muzzarella, pan rallado", Preparacion = "Cortar trozos de queso muzzarella. Marinar y rebozar con pan rallado. Precalentar una sartén con aceite y sumergir los bastones hasta dorar", Imagen = "http://drive.google.com/uc?export=view&id=1Jc4rZ65jBg8BEabxlbUshoaUYbf-qHRu" },
                new Mercaderia { MercaderiaId = 7, Nombre = "Sorrentinos", TipoMercaderiaId = 3, Precio = 1100, Ingredientes = "Harina, Jamón y Queso", Preparacion = "Se cocinan de 5 a 6 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección ", Imagen = "http://drive.google.com/uc?export=view&id=1bKbmpUGxozKYJOMnuXdRdpXom_Le13zI" },
                new Mercaderia { MercaderiaId = 8, Nombre = "Ravioles", TipoMercaderiaId = 3, Precio = 1000, Ingredientes = "Harina, espinaca, ricota", Preparacion = "Se cocinan de 5 a 6 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección", Imagen = "http://drive.google.com/uc?export=view&id=1j0NjEwgzN2yf2cKwhEAFHXm5Ys37er2M" },
                new Mercaderia { MercaderiaId = 9, Nombre = "Ñoquis", TipoMercaderiaId = 3, Precio = 1050, Ingredientes = "Papa, harina, manteca", Preparacion = "Se cocinan de 3 a 4 minutos, fuego suave. Se echan en la olla, cuando el agua hierve. Salsa a elección", Imagen = "http://drive.google.com/uc?export=view&id=1y4NG5yqIR8D_WitrKMBqM6EWdx6H4p0a" },
                new Mercaderia { MercaderiaId = 10, Nombre = "Parrillada para 2", TipoMercaderiaId = 4, Precio = 3200, Ingredientes = "Asado, vacío, chorizo, morcilla, riñon, molleja, entraña", Preparacion = "Carne salada y desgrasada previo a la cocción. Fuego encendido en base a leña y carbón. Cocción en tiempo adecuado para cada corte", Imagen = "http://drive.google.com/uc?export=view&id=1mjjIjiRTI_WU9fzdJO3KDNKHywHCB8-o" },
                new Mercaderia { MercaderiaId = 11, Nombre = "Matambre a la pizza", TipoMercaderiaId = 4, Precio = 2100, Ingredientes = "Matambre de cerdo, salsa de tomate, cebolla, morrón, jamón, muzzarella", Preparacion = "Matambre de cerdo tiernizado previo a su cocción en la parrilla. Salsa preparada con cebolla y morrón salteados en pure de tomate. El matambre se sella en la parrilla de un lado, luego se da vuelta y se agregan la salsa y el queso", Imagen = "http://drive.google.com/uc?export=view&id=1G6D0pSscTwnvLyFpkt3UN7JfvIjwHFzt" },
                new Mercaderia { MercaderiaId = 12, Nombre = "Pizza Muzzarella", TipoMercaderiaId = 5, Precio = 1300, Ingredientes = "Harina, aceite, levadura, salsa de tomate, muzzarella", Preparacion = "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones que serán estiradas para formar cada pizza. Se agrega salsa de tomate y muzzarella y se cocina en el horno", Imagen = "http://drive.google.com/uc?export=view&id=1r2UJsC7elU9ypSs6qtGz1gJ2KhrvJXwI" },
                new Mercaderia { MercaderiaId = 13, Nombre = "Pizza Especial", TipoMercaderiaId = 5, Precio = 1500, Ingredientes = "Harina, aceite, levadura, salsa de tomate, muzzarella, jamón, morrón", Preparacion = "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones que serán estiradas para formar cada pizza. Se agrega salsa de tomate, muzzarella, jamón y morrones y se cocina en el horno", Imagen = "http://drive.google.com/uc?export=view&id=1fLWpcDgcvOvuedhjH8xdcYgNN_sd9rB1" },
                new Mercaderia { MercaderiaId = 14, Nombre = "Pizza Napolitana", TipoMercaderiaId = 5, Precio = 1500, Ingredientes = "Harina, aceite, levadura, salsa de tomate, muzzarella, tomate, orégano, ajo", Preparacion = "La masa se prepara con harina, aceite, levadura y agua. Luego de amasar, se deja reposar. Se separa la masa en porciones para formar cada pizza. Se agrega salsa de tomate, muzzarella, ajo tomate y orégano y se cocina en el horno", Imagen = "http://drive.google.com/uc?export=view&id=1b8T3HsvPM0WNJ-N8k9J7I08yMXRGSiSS" },
                new Mercaderia { MercaderiaId = 15, Nombre = "Sandwich Milanesa Simple", TipoMercaderiaId = 6, Precio = 1000, Ingredientes = "Milanesa de ternera con perejil y ajo, pan", Preparacion = "La carne es marinada con huevos, perejil, ajo al menos 30 minutos. Es rebozada con pan rallado y se introduce en una sartén con aceite a 180°", Imagen = "http://drive.google.com/uc?export=view&id=1uM26gOQHspyEWeS5KXlE6Ab4weCXybnU" },
                new Mercaderia { MercaderiaId = 16, Nombre = "Sandwich Milanesa Completo", TipoMercaderiaId = 6, Precio = 1300, Ingredientes = "Milanesa de ternera con perejil y ajo, pan, lechuga, tomate, huevo, jamón, queso", Preparacion = "La carne es marinada con huevos, perejil, ajo al menos 30 minutos. Es rebozada con pan rallado y se introduce en una sartén con aceite a 180°. En el sandwicg se agrega lechuga, tomate, jamón, queso y un huevo frito", Imagen = "http://drive.google.com/uc?export=view&id=1pVdf0j3VRW43ApQiM3hGBxm_w6EFpvbA" },
                new Mercaderia { MercaderiaId = 17, Nombre = "Hamburguesa Simple", TipoMercaderiaId = 6, Precio = 750, Ingredientes = "Hamburguesa carne, ajo, perejil, huevo, leche, pan", Preparacion = "Se introduce la carne picada en un bol con ajo ý perejil picados, huevos, sal, pimienta y un poco de leche. Se agrega pan rallado y se mezcla. Luego se separan porciones para dar forma a cada hamburguesa que será cocinada en una plancha", Imagen = "http://drive.google.com/uc?export=view&id=16bcH3whOAZVZyGWa2Ju3Egw4TtidwvB4" },
                new Mercaderia { MercaderiaId = 18, Nombre = "Hamburguesa Completa", TipoMercaderiaId = 6, Precio = 1000, Ingredientes = "Hamburguesa carne, lechuga, tomate, jamón, queso, huevo", Preparacion = "Se introduce la carne picada en un bol con ajo ý perejil, huevos, sal, pimienta y leche. Se agrega pan rallado y se mezcla. Se separan porciones para dar forma a cada hamburguesa. Al sandwich se agrega lechuga, tomate, jamón, queso y huevo", Imagen = "http://drive.google.com/uc?export=view&id=1WrjYHDq8v6BDs6eVcxXfDLgeVtoU0pKF" },
                new Mercaderia { MercaderiaId = 19, Nombre = "Ensalada Simple", TipoMercaderiaId = 7, Precio = 600, Ingredientes = "Lechuga, tomate, cebolla", Preparacion = "Se corta la lechuga, el tomate y la cebolla y se mezclan los cortes en un bol. ", Imagen = "http://drive.google.com/uc?export=view&id=1J906WVvVzkdbkGVIBGactSueFypvf8ss" },
                new Mercaderia { MercaderiaId = 20, Nombre = "Ensalada Rusa", TipoMercaderiaId = 7, Precio = 700, Ingredientes = "Papa, zanahoria, arvejas, huevo, mayonesa", Preparacion = "Las papas, la zanahoria y los huevos son hervidos previamente. La papa, los huevos y la zanahoria son cortadas en pequeñas porciones y se agregan arvejas y mayonesa para mezclar todo posteriormente", Imagen = "http://drive.google.com/uc?export=view&id=1Mcozjvh0SWZweQygiQrzOrZrT9YVjOLZ" },
                new Mercaderia { MercaderiaId = 21, Nombre = "Gaseosa", TipoMercaderiaId = 8, Precio = 500, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=1hMYDum13KkHld5PMHp3jSTM9Oh_ExSOD" },
                new Mercaderia { MercaderiaId = 22, Nombre = "Agua saborizada", TipoMercaderiaId = 8, Precio = 450, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=1JslDFLsGxkWspmjjdnRlvAiHgXlJtOKI" },
                new Mercaderia { MercaderiaId = 23, Nombre = "Agua mineral sin gas", TipoMercaderiaId = 8, Precio = 300, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=1LGTebh1vaG4CmJTFyJ3iz0Sfc6JGd_U2" },
                new Mercaderia { MercaderiaId = 24, Nombre = "Agua mineral con gas", TipoMercaderiaId = 8, Precio = 300, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=1dwOplkCITA5xznlHXLVe-46OVOLI_Zvr" },
                new Mercaderia { MercaderiaId = 25, Nombre = "Cerveza IPA", TipoMercaderiaId = 9, Precio = 750, Ingredientes = "Lúpulo, cebada, malta", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=1DGF9Z8OB95lkedMSXb7qAuJyWVU0DvmP" },
                new Mercaderia { MercaderiaId = 26, Nombre = "Cerveza Scotish", TipoMercaderiaId = 9, Precio = 700, Ingredientes = "Lúpulo, cebada, malta, caramelo", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=1ud32oxsTAjsVbfcny0G9gwQc_8Mmsn_1" },
                new Mercaderia { MercaderiaId = 27, Nombre = "Cerveza Stout", TipoMercaderiaId = 9, Precio = 750, Ingredientes = "Lúpulo, cebada, malta, cacao", Preparacion = "Ninguna", Imagen = "http://drive.google.com/uc?export=view&id=17oe10vyvebzJUNPchjug88NWI85WRwJ3" },
                new Mercaderia { MercaderiaId = 28, Nombre = "Flan", TipoMercaderiaId = 10, Precio = 500, Ingredientes = "Leche, huevo, azúcar", Preparacion = "Se baten huevos con azúcar hasta disolver. Se calienta leche hasta el punto de hervor, se agrega la mezcla y se revuelve. En otro recipiente se prepara caramelo con azúcar y agua. El caramelo y la mezcla se cocinan a 170° en el horno a baño maría", Imagen = "http://drive.google.com/uc?export=view&id=1qY-UUAqzQVBkPJ2o_ip_Wrx3MRFWVoQQ" },
                new Mercaderia { MercaderiaId = 29, Nombre = "Helado", TipoMercaderiaId = 10, Precio = 600, Ingredientes = "Helado de chocolate, dulce de leche, vainilla", Preparacion = "No aplica", Imagen = "http://drive.google.com/uc?export=view&id=15y_y2dY8brhQDwS8fMmK-5NXABSVMBc8" },
                new Mercaderia { MercaderiaId = 30, Nombre = "Ensalada de frutas", TipoMercaderiaId = 10, Precio = 400, Ingredientes = "Manzana, Naranja, Banana, Ananá, Durazno, Cereza", Preparacion = "Se quita la cascara de todas las frutas a excepción de la cereza. Luego se realizan cortes pequeños que serán mezclados en un bol con jugo de frutas", Imagen = "http://drive.google.com/uc?export=view&id=1E9j4LTrFyFVluEj0h72jHXZT5MSzrWOs" }
            );
        }
    }
}
