using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAgendaLanlink.Models;

namespace WebAgendaLanlink.Repository
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> Pessoas { get; }

        Pessoa PessoById(int pessoaId);

        IEnumerable<int> lastId();

        void deleteCadastro(int pessoaId);

        void SaveUpdate(Pessoa pessoa);
        void SaveAdd(Pessoa pessoa);
    }
}
