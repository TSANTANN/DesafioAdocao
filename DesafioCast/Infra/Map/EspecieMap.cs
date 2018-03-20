using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Map
{
    public class EspecieMap : EntityTypeConfiguration<Especie>
    {
        public EspecieMap()
        {
            ToTable("Especie");
            HasKey(x => x.Id);
        }
    }
}