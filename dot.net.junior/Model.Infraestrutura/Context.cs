using Model.Entidades.Entidades;
using System.Configuration;
using System.Data.Entity;

namespace Model.Infraestrutura
{
    public class Context : DbContext
    {
        public Context() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TelefoneCelular> TelefoneCelular { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasKey(k => k.IdCliente)
                .HasRequired(f => f.Endereco)
                .WithMany()
                .HasForeignKey(f => f.IdEndereco);


            modelBuilder.Entity<Cliente>()
                .HasKey(k => k.IdCliente)
                .HasRequired(f => f.TelefoneCelular)
                .WithMany()
                .HasForeignKey(f => f.IdTelefoneCelular);

            modelBuilder.Entity<Endereco>()
                .HasKey(k => k.IdEndereco)
                .HasMany<Cliente>(k => k.Clientes)
                .WithRequired(k => k.Endereco)
                .HasForeignKey(k => k.IdEndereco);

            modelBuilder.Entity<TelefoneCelular>()
                .HasKey(k => k.IdTelefoneCelular)
                .HasMany<Cliente>(k => k.Clientes)
                .WithRequired(k => k.TelefoneCelular)
                .HasForeignKey(k => k.IdTelefoneCelular);
        }
    }
}
