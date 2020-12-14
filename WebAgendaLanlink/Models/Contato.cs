using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgendaLanlink.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        [StringLength(10)]
        public string TipoContato { get; set; }
        public int CodigoTipo { get; set; }
        [StringLength(120)]
        public string TextoContato { get; set; }
        [StringLength(10)]
        public string NumeroEnd { get; set; }
        [StringLength(20)]
        public string Complemento { get; set; }
        [StringLength(80)]
        public string Bairro { get; set; }
        [StringLength(80)]
        public string Cidade { get; set; }
        [StringLength(2)]
        public string UF { get; set; }
        public int CodigoAgp { get; set; }
        [StringLength(20)]
        public string TipoAgp { get; set; }
        [StringLength(20)]
        public string TipoEnd { get; set; }

        public int PessoaId { get; set; }
        public int SequenciaCont { get; set; }
        public virtual Pessoa Pessoa { get; set; }



    }
}
