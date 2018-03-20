using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Map
{
    public class AnimalMap : EntityTypeConfiguration<Animal>
    {
        public AnimalMap()
        {
            ToTable("Animal");
            HasKey(x => x.Id);
        }
    }
}