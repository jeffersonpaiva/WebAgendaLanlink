using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgendaLanlink.Models;

namespace WebAgendaLanlink.Repository
{
    public interface IContatosRepository
    {
        IEnumerable<Contato> Contatos { get; }

        IEnumerable<Contato> GetContatoById(int pessoaId);

        Contato GetContatoBypessoaID(int pessoaId, int contatoId);

        void SaveUpdate(Contato con);
        void SaveAdd(Contato con);

        void removerContato(int pessoaId, int contatoId);



    }
}
