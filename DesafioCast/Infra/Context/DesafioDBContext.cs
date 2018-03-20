using Core.Model;
using Infra.Map;
using Infra.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Context
{
    public class DesafioDBContext : DbContext
    {
        public DbSet<Adotante> Adotantes { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DesafioDBContext()
           : base("DesafioConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DesafioDBContext, Configuration>());
            //Configuration.ProxyCreationEnabled = true;
            //Configuration.LazyLoadingEnabled = true;

            modelBuilder.Configurations.Add(new AdotanteMap());
            modelBuilder.Configurations.Add(new AnimalMap());
            modelBuilder.Configurations.Add(new EspecieMap());
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }

        public static DesafioDBContext Create()
        {
            return new DesafioDBContext();
        }



    }
}
