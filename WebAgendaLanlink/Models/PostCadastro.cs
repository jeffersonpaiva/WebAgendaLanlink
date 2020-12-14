using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAgendaLanlink.Models
{
    public class PostCadastro
    {
        public PostCadastro()
        {
            this.enderecoPosts = new List<EnderecoPost>();
            this.contatoPosts = new List<ContatoPost>();
        }
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public List<EnderecoPost> enderecoPosts { get; set; }
        public List<ContatoPost> contatoPosts { get; set; }
    }

    public class EnderecoPost
    {
    
        public string TextoContato { get; set; }
        public string NumeroEnd { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string TipoEnd { get; set; }
        public int ContatoId { get; set; }
        public int CodigoTipo { get; set; }
        public int CodigoAgp { get; set; }

    }

    public class ContatoPost
    {
        public string TipoContato { get; set; }
        public string TextoContato { get; set; }
        public string TipoAgp { get; set; }
        public int ContatoId { get; set; }
        public int CodigoTipo { get; set; }
        public int CodigoAgp { get; set; }
    }


    public class PostDelete
    {
        public int PessoaId { get; set; }
        public int ContatoId { get; set; }
    }

    public class PostDeleteCadastro
    {
        public int PessoaId { get; set; }
    }

}
