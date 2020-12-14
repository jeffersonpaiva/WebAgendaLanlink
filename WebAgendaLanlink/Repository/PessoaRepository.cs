using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgendaLanlink.Context;
using WebAgendaLanlink.Models;

namespace WebAgendaLanlink.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _contexto;
       

        public PessoaRepository(AppDbContext contexto)
        {
            _contexto = contexto;
           
        }

        public IEnumerable<Pessoa> Pessoas => _contexto.Pessoas;

        public Pessoa PessoById(int pessoaId)
        {
            return _contexto.Pessoas.FirstOrDefault(x => x.PessoaId == pessoaId);
        }


        public IEnumerable<int> lastId()
        {
            return _contexto.Pessoas.ToList().Select(x => x.PessoaId);
        }


        public void SaveUpdate(Pessoa pessoa)
        {

            _contexto.SaveChanges();
        
        }

        public void SaveAdd(Pessoa pessoa)
        {
            Pessoa pes = new Pessoa();

            pes.PessoaId = pessoa.PessoaId;
            pes.Nome = pessoa.Nome;

            _contexto.Pessoas.Add(pes);
            _contexto.SaveChanges();

        }

        public void deleteCadastro(int pessoaId)
        {
           var cadastro = _contexto.Pessoas.FirstOrDefault(x => x.PessoaId == pessoaId);

            if (cadastro != null)
            {
                _contexto.Pessoas.Remove(cadastro);
                _contexto.SaveChanges();
            }

        }
    }
}
