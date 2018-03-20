using Core.Interface.Repository;
using Core.Interface.IService;
using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public class PessoaService : IPessoaService
    {
        IRepository<Pessoa> _pessoaRepository;
        public PessoaService(IRepository<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public bool Add(Pessoa pessoa)
        {
            if (pessoa.IsValid)
                return _pessoaRepository.Insert(pessoa);

            return false;
        }

        public bool Delete(int id)
        {
            var pessoa = GetPessoa(id);
            return _pessoaRepository.Delete(pessoa);
        }

        public Pessoa GetPessoa(int Id)
        {
            return _pessoaRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll().ToList();
        }


        public bool Update(Pessoa pessoa)
        {
            if (pessoa.IsValid)
            {
                GetPessoa(pessoa.Id).Update(pessoa);

                return _pessoaRepository.SaveChanges();
            }

            return false;
        }
    }
}
