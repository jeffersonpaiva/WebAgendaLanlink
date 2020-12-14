using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgendaLanlink.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        [StringLength(120)]
        public string Nome { get; set; }

       // public List<Contato> Contatos { get; set; }
    }
}
