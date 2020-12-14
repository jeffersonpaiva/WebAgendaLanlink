using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebAgendaLanlink.Models;
using WebAgendaLanlink.Repository;

namespace WebAgendaLanlink.Controllers
{
    public class HomeController : Controller
    {

        private readonly IContatosRepository _contatoRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public HomeController(IContatosRepository contatoRepository, IPessoaRepository pessoaRepository)
        {
            _contatoRepository = contatoRepository;
            _pessoaRepository = pessoaRepository;
        }

        public IActionResult Index()
        {

            var pessoas = _pessoaRepository.Pessoas;

            return View(pessoas);
        }

        public IActionResult Details(int PessoaId)
        {
            Geral geral = new Geral();

            var idPessoa = PessoaId;

            try
            {
                if (idPessoa != 0)
                {
                    var ind = _pessoaRepository.PessoById(idPessoa);

                    if (ind != null)
                    {
                        geral.PessoaId = ind.PessoaId;
                        geral.Nome = ind.Nome;
                    }

                    var cont = _contatoRepository.GetContatoById(idPessoa);

                    foreach (var item in cont)
                    {
                        Contato con = new Contato();

                        con.ContatoId = item.ContatoId;
                        con.TipoContato = item.TipoContato;
                        con.CodigoTipo = item.CodigoTipo;
                        con.TextoContato = item.TextoContato;
                        con.NumeroEnd = item.NumeroEnd;
                        con.Complemento = item.Complemento;
                        con.Bairro = item.Bairro;
                        con.Cidade = item.Cidade;
                        con.UF = item.UF;
                        con.CodigoAgp = item.CodigoAgp;
                        con.TipoAgp = item.TipoAgp;
                        con.TipoEnd = item.TipoEnd;
                        con.PessoaId = item.PessoaId;

                        geral.ContatosPessoa.Add(con);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw;
            }

            return View(geral);
        }

        [HttpPost]
        public PostCadastro Save(PostCadastro post)
        {
            try
            {
                if (post.PessoaId == 0)
                {

                    int seqId = 1;

                    var lastID = _pessoaRepository.lastId();

                    int? id = null;

                    if (lastID.Any())
                    {
                        id = lastID.Max();
                    }

                    if (id == null)
                    {
                        seqId = 1;
                    }
                    else
                    {
                        var lastSeq = id + 1;
                        seqId = Convert.ToByte(lastSeq);
                    }

                    Pessoa pessoaNew = new Pessoa();
                    pessoaNew.PessoaId = seqId;
                    pessoaNew.Nome = post.Nome;

                    _pessoaRepository.SaveAdd(pessoaNew);

                    foreach (var item in post.contatoPosts)
                    {

                        int seqCon = 1;

                        var lstSeq = _contatoRepository.Contatos.Where(x => x.PessoaId == pessoaNew.PessoaId).Select(x => x.SequenciaCont).ToList();

                        int? last = null;

                        if (lstSeq.Any())
                        {
                            last = lstSeq.Max();
                        }

                        if (last == null)
                        {
                            seqCon = 1;
                        }
                        else
                        {
                            var lastSeq = last + 1;
                            seqCon = Convert.ToByte(lastSeq);
                        }

                        int conId = 1;

                        var lastContId = _contatoRepository.Contatos.Select(x => x.ContatoId).ToList();

                        int? idLast = null;
                        if (lastContId.Any())
                        {
                            idLast = lastContId.Max();
                        }
                        if (idLast == null)
                        {
                            conId = 1;
                        }
                        else
                        {
                            var lastcontID = idLast + 1;
                            conId = Convert.ToByte(lastcontID);
                        }

                        Contato newCon = new Contato();

                        newCon.ContatoId = conId;
                        newCon.TipoContato = item.TipoContato;
                        newCon.CodigoTipo = item.CodigoTipo;
                        newCon.TextoContato = item.TextoContato;
                        newCon.NumeroEnd = null;
                        newCon.Complemento = null;
                        newCon.Bairro = null;
                        newCon.Cidade = null;
                        newCon.UF = null;
                        newCon.CodigoAgp = item.CodigoAgp;
                        newCon.TipoAgp = item.TipoAgp;
                        newCon.TipoEnd = null;
                        newCon.PessoaId = pessoaNew.PessoaId;
                        newCon.SequenciaCont = seqCon;

                        _contatoRepository.SaveAdd(newCon);
                    }

                    foreach (var item in post.enderecoPosts)
                    {

                        int seqEnd = 1;

                        var lstID = _contatoRepository.Contatos.Where(x => x.PessoaId == pessoaNew.PessoaId).Select(x => x.SequenciaCont).ToList();

                        int? last = null;

                        if (lstID.Any())
                        {
                            last = lstID.Max();
                        }

                        if (last == null)
                        {
                            seqEnd = 1;
                        }
                        else
                        {
                            var lastSeq = last + 1;
                            seqEnd = Convert.ToByte(lastSeq);
                        }

                        int endId = 1;

                        var ListEndId = _contatoRepository.Contatos.Select(x => x.ContatoId).ToList();

                        int? idLastEnd = null;
                        if (ListEndId.Any())
                        {
                            idLastEnd = ListEndId.Max();
                        }
                        if (idLastEnd == null)
                        {
                            endId = 1;
                        }
                        else
                        {
                            var lastEndId = idLastEnd + 1;
                            endId = Convert.ToByte(lastEndId);
                        }

                        Contato newEnd = new Contato();

                        newEnd.ContatoId = endId;
                        newEnd.TipoContato = "ENDERECO";
                        newEnd.CodigoTipo = item.CodigoTipo;
                        newEnd.TextoContato = item.TextoContato;
                        newEnd.NumeroEnd = item.NumeroEnd;
                        newEnd.Complemento = item.Complemento;
                        newEnd.Bairro = item.Bairro;
                        newEnd.Cidade = item.Cidade;
                        newEnd.UF = item.UF;
                        newEnd.CodigoAgp = item.CodigoAgp;
                        newEnd.TipoAgp = "";
                        newEnd.TipoEnd = item.TipoEnd;
                        newEnd.PessoaId = pessoaNew.PessoaId;
                        newEnd.SequenciaCont = seqEnd;

                        _contatoRepository.SaveAdd(newEnd);
                    }

                }
                else // Update No Cadastro
                {

                    var pes = _pessoaRepository.PessoById(post.PessoaId);

                    if (pes != null)
                    {
                        pes.Nome = post.Nome;
                        _pessoaRepository.SaveUpdate(pes);
                    }

                    var enderecos = _contatoRepository.GetContatoById(post.PessoaId);

                    if (enderecos.Count() == 0)
                    {
                        foreach (var item in post.contatoPosts)
                        {

                            int seqCon = 1;

                            var lstSeq = _contatoRepository.Contatos.Where(x => x.PessoaId == post.PessoaId).Select(x => x.SequenciaCont).ToList();

                            int? last = null;

                            if (lstSeq.Any())
                            {
                                last = lstSeq.Max();
                            }

                            if (last == null)
                            {
                                seqCon = 1;
                            }
                            else
                            {
                                var lastSeq = last + 1;
                                seqCon = Convert.ToByte(lastSeq);
                            }

                            int conId = 1;

                            var lastContId = _contatoRepository.Contatos.Select(x => x.ContatoId).ToList();

                            int? idLast = null;
                            if (lastContId.Any())
                            {
                                idLast = lastContId.Max();
                            }
                            if (idLast == null)
                            {
                                conId = 1;
                            }
                            else
                            {
                                var lastcontID = idLast + 1;
                                conId = Convert.ToByte(lastcontID);
                            }

                            Contato newCon = new Contato();

                            newCon.ContatoId = conId;
                            newCon.TipoContato = item.TipoContato;
                            newCon.CodigoTipo = item.CodigoTipo;
                            newCon.TextoContato = item.TextoContato;
                            newCon.NumeroEnd = null;
                            newCon.Complemento = null;
                            newCon.Bairro = null;
                            newCon.Cidade = null;
                            newCon.UF = null;
                            newCon.CodigoAgp = item.CodigoAgp;
                            newCon.TipoAgp = item.TipoAgp;
                            newCon.TipoEnd = null;
                            newCon.PessoaId = post.PessoaId;
                            newCon.SequenciaCont = seqCon;

                            _contatoRepository.SaveAdd(newCon);
                        }

                        foreach (var item in post.enderecoPosts)
                        {

                            int seqEnd = 1;

                            var lstID = _contatoRepository.Contatos.Where(x => x.PessoaId == post.PessoaId).Select(x => x.SequenciaCont).ToList();

                            int? last = null;

                            if (lstID.Any())
                            {
                                last = lstID.Max();
                            }

                            if (last == null)
                            {
                                seqEnd = 1;
                            }
                            else
                            {
                                var lastSeq = last + 1;
                                seqEnd = Convert.ToByte(lastSeq);
                            }

                            //ultimo idEnd
                            int endId = 1;

                            var ListEndId = _contatoRepository.Contatos.Select(x => x.ContatoId).ToList();

                            int? idLastEnd = null;
                            if (ListEndId.Any())
                            {
                                idLastEnd = ListEndId.Max();
                            }
                            if (idLastEnd == null)
                            {
                                endId = 1;
                            }
                            else
                            {
                                var lastEndId = idLastEnd + 1;
                                endId = Convert.ToByte(lastEndId);
                            }

                            Contato newEnd = new Contato();

                            newEnd.ContatoId = endId;
                            newEnd.TipoContato = "ENDERECO";
                            newEnd.CodigoTipo = item.CodigoTipo;
                            newEnd.TextoContato = item.TextoContato;
                            newEnd.NumeroEnd = item.NumeroEnd;
                            newEnd.Complemento = item.Complemento;
                            newEnd.Bairro = item.Bairro;
                            newEnd.Cidade = item.Cidade;
                            newEnd.UF = item.UF;
                            newEnd.CodigoAgp = item.CodigoAgp;
                            newEnd.TipoAgp = "";
                            newEnd.TipoEnd = item.TipoEnd;
                            newEnd.PessoaId = post.PessoaId;
                            newEnd.SequenciaCont = seqEnd;

                            _contatoRepository.SaveAdd(newEnd);
                        }
                    }
                    else
                    {
                        foreach (var cont in post.contatoPosts)
                        {
                            var seExiste = _contatoRepository.GetContatoBypessoaID(post.PessoaId, cont.ContatoId);

                            if (seExiste == null)
                            {

                                int seqCon = 1;
                                var lstSeq = _contatoRepository.Contatos.Where(x => x.PessoaId == post.PessoaId).Select(x => x.SequenciaCont).ToList();

                                int? last = null;

                                if (lstSeq.Any())
                                {
                                    last = lstSeq.Max();
                                }

                                if (last == null)
                                {
                                    seqCon = 1;
                                }
                                else
                                {
                                    var lastSeq = last + 1;
                                    seqCon = Convert.ToByte(lastSeq);
                                }

                                int conId = 1;

                                var lastContId = _contatoRepository.Contatos.Select(x => x.ContatoId).ToList();

                                int? idLast = null;
                                if (lastContId.Any())
                                {
                                    idLast = lastContId.Max();
                                }
                                if (idLast == null)
                                {
                                    conId = 1;
                                }
                                else
                                {
                                    var lastcontID = idLast + 1;
                                    conId = Convert.ToByte(lastcontID);
                                }


                                Contato newCon = new Contato();

                                newCon.ContatoId = conId;
                                newCon.TipoContato = cont.TipoContato;
                                newCon.CodigoTipo = cont.CodigoTipo;
                                newCon.TextoContato = cont.TextoContato;
                                newCon.NumeroEnd = null;
                                newCon.Complemento = null;
                                newCon.Bairro = null;
                                newCon.Cidade = null;
                                newCon.UF = null;
                                newCon.CodigoAgp = cont.CodigoAgp;
                                newCon.TipoAgp = cont.TipoAgp;
                                newCon.TipoEnd = null;
                                newCon.PessoaId = post.PessoaId;
                                newCon.SequenciaCont = seqCon;

                                _contatoRepository.SaveAdd(newCon);
                            }
                        }

                        foreach (var ende in post.enderecoPosts)
                        {
                            var seExiste = _contatoRepository.GetContatoBypessoaID(post.PessoaId, ende.ContatoId);

                            if (seExiste == null)
                            {


                                int seqEnd = 1;

                                var lstID = _contatoRepository.Contatos.Where(x => x.PessoaId == post.PessoaId).Select(x => x.SequenciaCont).ToList();

                                int? last = null;

                                if (lstID.Any())
                                {
                                    last = lstID.Max();
                                }

                                if (last == null)
                                {
                                    seqEnd = 1;
                                }
                                else
                                {
                                    var lastSeq = last + 1;
                                    seqEnd = Convert.ToByte(lastSeq);
                                }

                                //ultimo idEnd
                                int endId = 1;

                                var ListEndId = _contatoRepository.Contatos.Select(x => x.ContatoId).ToList();

                                int? idLastEnd = null;
                                if (ListEndId.Any())
                                {
                                    idLastEnd = ListEndId.Max();
                                }
                                if (idLastEnd == null)
                                {
                                    endId = 1;
                                }
                                else
                                {
                                    var lastEndId = idLastEnd + 1;
                                    endId = Convert.ToByte(lastEndId);
                                }


                                Contato newEnd = new Contato();

                                newEnd.ContatoId = endId;
                                newEnd.TipoContato = "ENDERECO";
                                newEnd.CodigoTipo = ende.CodigoTipo;
                                newEnd.TextoContato = ende.TextoContato;
                                newEnd.NumeroEnd = ende.NumeroEnd;
                                newEnd.Complemento = ende.Complemento;
                                newEnd.Bairro = ende.Bairro;
                                newEnd.Cidade = ende.Cidade;
                                newEnd.UF = ende.UF;
                                newEnd.CodigoAgp = ende.CodigoAgp;
                                newEnd.TipoAgp = "";
                                newEnd.TipoEnd = ende.TipoEnd;
                                newEnd.PessoaId = post.PessoaId;
                                newEnd.SequenciaCont = seqEnd;

                                _contatoRepository.SaveAdd(newEnd);

                            }
                        }

                    }


                }
            }
            catch (System.Exception e)
            {

                throw;
            }

            return post;




        }

        [HttpPost]
        public PostDelete ExcluirContato(PostDelete delete)
        {

            try
            {
                _contatoRepository.removerContato(delete.PessoaId, delete.ContatoId);
            }
            catch (Exception e)
            {

                throw;
            }

            return delete;
        }

        [HttpPost]
        public PostDelete Delete(PostDelete ps)
        {
            try
            {

                var contDelete = _contatoRepository.GetContatoById(ps.PessoaId);

                foreach (var item in contDelete)
                {
                    _contatoRepository.removerContato(ps.PessoaId, item.ContatoId);
                }

                _pessoaRepository.deleteCadastro(ps.PessoaId);
            }
            catch (Exception)
            {

                throw;
            }

            return ps;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
