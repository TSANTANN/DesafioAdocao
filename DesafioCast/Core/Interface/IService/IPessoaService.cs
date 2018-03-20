using System.Collections.Generic;
using Core.Model;

namespace Core.Interface.IService
{
    public interface IPessoaService
    {

        IList<Pessoa> GetAll();
        bool Add(Pessoa pessoa);
        bool Update(Pessoa pessoa);
        bool Delete(int id);
        Pessoa GetPessoa(int Id);
    }
}
