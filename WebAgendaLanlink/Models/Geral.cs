using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgendaLanlink.Models
{
    public class Geral
    {
        public Geral()
        {
            this.ContatosPessoa = new List<Contato>();
        }
        public int PessoaId { get; set; }
        public string Nome { get; set; }

        public List<Contato> ContatosPessoa { get; set; }

      

    }
}
