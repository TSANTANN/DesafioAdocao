using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
        }
    }
}