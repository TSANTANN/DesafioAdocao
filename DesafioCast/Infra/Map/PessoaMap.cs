using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Map
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa");
            HasKey(x => x.Id);
        }
    }
}
