using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Map
{
    public class AdotanteMap : EntityTypeConfiguration<Adotante>
    {
        public AdotanteMap()
        {
            ToTable("Adotante");
            HasKey(x => x.Id);
        }
    }
}