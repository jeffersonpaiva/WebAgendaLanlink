using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgendaLanlink.Context;
using WebAgendaLanlink.Models;

namespace WebAgendaLanlink.Repository
{
    public class ContatoRepository : IContatosRepository
    {
        private readonly AppDbContext _contexto;

        public ContatoRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Contato> Contatos => _contexto.Contatos.Include(c => c.Pessoa);

        public IEnumerable<Contato> GetContatoById(int pessoaId)
        {
          return  _contexto.Contatos.Include(c => c.Pessoa).Where(x => x.PessoaId == pessoaId).ToList();
        }

        public Contato GetContatoBypessoaID(int pessoaId, int contatoId)
        {
            return _contexto.Contatos.FirstOrDefault(x => x.PessoaId == pessoaId && x.ContatoId == contatoId);
        }

        public void removerContato(int pessoaId, int contatoId)
        {
            var itemToRemove = _contexto.Contatos.FirstOrDefault(x=>x.PessoaId == pessoaId && x.ContatoId == contatoId); 

            if (itemToRemove != null)
            {

                _contexto.Contatos.Remove(itemToRemove);
                _contexto.SaveChanges();
            }
        }

        public void SaveAdd(Contato con)
        {
            Contato contato = new Contato();

            contato.ContatoId = con.ContatoId;
            contato.TipoContato = con.TipoContato;
            contato.CodigoTipo = con.CodigoTipo;
            contato.TextoContato = con.TextoContato;
            contato.NumeroEnd = con.NumeroEnd;
            contato.Complemento = con.Complemento;
            contato.Bairro = con.Bairro;
            contato.Cidade = con.Cidade;
            contato.UF = con.UF;
            contato.CodigoAgp = con.CodigoAgp;
            contato.TipoAgp = con.TipoAgp;
            contato.TipoEnd = con.TipoEnd;
            contato.PessoaId = con.PessoaId;
            contato.SequenciaCont = con.SequenciaCont;

            _contexto.Contatos.Add(contato);
            _contexto.SaveChanges();
        }

        public void SaveUpdate(Contato con)
        {
            throw new NotImplementedException();
        }
    }
}
