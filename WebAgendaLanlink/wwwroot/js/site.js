// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    //$('#table_endereco').DataTable({
    //    "language": {
    //        "paginate": {
    //            "next": "Próximo",
    //            "previous": "Anterior"
    //        },
    //        "search": "Pesquisar:",
    //        "lengthMenu": "Mostrar _MENU_  por pagina",
    //        "zeroRecords": "Sem Endereço",
    //        "info": "página _PAGE_ De _PAGES_",
    //        "infoEmpty": "Sem Endereço",
    //        "infoFiltered": "(Total Filtrados: _MAX_ total)",
    //        "select": {
    //            "rows": " "
    //        }
    //    },
    //    "info": false,
    //    "bLengthChange": false,
    //    "paginate": false

    //});
    //$('#table_Contato').DataTable(
    //    {
    //        "language": {
    //            "paginate": {
    //                "next": "Próximo",
    //                "previous": "Anterior"
    //            },
    //            "search": "Pesquisar:",
    //            "lengthMenu": "Mostrar _MENU_  por pagina",
    //            "zeroRecords": "Sem Contatos",
    //            "info": "página _PAGE_ De _PAGES_",
    //            "infoEmpty": "Sem Contatos",
    //            "infoFiltered": "(Total Filtrados: _MAX_ total)",
    //            "select": {
    //                "rows": " "
    //            }
    //        },
    //        "info": false,
    //        "bLengthChange": false,
    //        "paginate": false

    //    }
    //);

    $('#table_index').DataTable(
        {
            "language": {
                "paginate": {
                    "next": "Próximo",
                    "previous": "Anterior"
                },
                "search": "Pesquisar:",
                "lengthMenu": "Mostrar _MENU_  por pagina",
                "zeroRecords": "Sem Cadastros",
                "info": "página _PAGE_ De _PAGES_",
                "infoEmpty": "Sem Cadastros",
                "infoFiltered": "(Total Filtrados: _MAX_ total)",
                "select": {
                    "rows": " "
                }
            },
            "info": false,
            "bLengthChange": false,
            "paginate": false

        }
    );

});

function AddContato() {

    debugger
    var Tipo = $("#InputTipCont").val();
    var contato = $("#InputContato").val();
    var TipoContato = $("#InputTipDoCont").val();
    var TipoContatoText = $("#InputTipDoCont option:selected").text();
    var tipText = $("#InputTipCont option:selected").text();




    if (contato == "" || contato == null) {
        $("#InputContato").focus();
        swal(
            'Web Agenda...',
            'Campo contato obrigatorio',
            'error'
        );
        return;
    }

    if (Tipo == 10) {
        if (contato.length == 11) {
            var ddd = contato.slice(0, 2);
            var parte1 = contato.slice(2, 7)
            var parte2 = contato.slice(7, 11)

            var textoAjustado = `(${ddd}) ${parte1}-${parte2}`;

            contato = textoAjustado;
        }
        else {
            $("#InputContato").focus();
            swal(
                "Web Agenda...",
                "Por Favor, Preencha o Telefone com o DDD",
                "error"
            );

            return;
        }
    }

    if (Tipo == 60) {
        if (contato.length == 10) {
            var ddd = contato.slice(0, 2);
            var parte1 = contato.slice(2, 6)
            var parte2 = contato.slice(6, 10)

            var textoAjustado = `(${ddd}) ${parte1}-${parte2}`;

            contato = textoAjustado;


        } else {
            $("#InputContato").focus();
            swal(
                "Web Agenda...",
                "Por Favor, Preencha o Telefone com o DDD",
                "error"
            );

            return;
        }
    }


    if (Tipo == 10 || Tipo == 60) {
        var msgTel = validaTelefone(contato, "Telefone");

        if (msgTel != '') {
            $("#InputContato").focus();
            swal(
                "Web Agenda...",
                msgTel,
                "error"
            );

            return;
        }
    }

    if (Tipo == 30) {
        var msgTel = validaEmail(contato, "Email");

        if (msgTel != '') {
            $("#InputContato").focus();
            swal(
                "Web Agenda...",
                msgTel,
                "error"
            );

            return;
        }
    }



    var ultimaColuna = `<td align="center"><button type="buttton" class="btn btn-danger"  title="Remover"> <i class="fas fa-trash-alt" style="font-size:15px"></i></button></td><td style="display:none">0</td>`;





    var newRowContent = `<tr><td>${tipText}</td><td>${contato}</td><td>${TipoContatoText}</td>${ultimaColuna}<td style="display:none">${Tipo}</td><td style="display:none">${TipoContato}</td></tr>`;

    $(newRowContent).appendTo($("#table_Contato"));

    $("#InputContato").val("");

}

$("#table_Contato").on("click", "button", function () {
    var $row = $(this).closest("tr").remove();    // Find the row
})


function AddEndereco() {

    debugger
    var logadouro = $("#InputEnd").val();
    var numero = $("#InputNum").val();
    var complemento = $("#InputComple").val();
    var bairro = $("#InputBairro").val();
    var cidade = $("#InputCidade").val();
    var uf = $("#InputUF").val();
    var TipoEnd = $("#InputTipoEnd").val();


    if (logadouro == "" || logadouro == null) {
        $("#InputEnd").focus();
        swal(
            'Web Agenda...',
            'Para adicionar um endereço, o logradouro será obrigatório.',
            'error'
        );
        return;
    }


    var ultimaColuna = `<td align="center"><button type="buttton" class="btn btn-danger"  title="Remover"> <i class="fas fa-trash-alt" style="font-size:15px"></i></button></td><td style="display:none">0</td>`;

    var newRowContent = `<tr><td>${logadouro}</td><td>${numero}</td><td>${complemento}</td><td>${bairro}</td><td>${cidade}</td><td>${uf}</td><td>${TipoEnd}</td>${ultimaColuna}<td style="display:none">20</td><td style="display:none">1</td></tr>`;

    $(newRowContent).appendTo($("#table_endereco"));


    $("#InputEnd").val("");
    $("#InputNum").val("");
    $("#InputComple").val("");
    $("#InputBairro").val("");
    $("#InputCidade").val("");
    $("#InputUF").val("");
    $("#InputTipoEnd").val("");



}

$("#table_endereco").on("click", "button", function () {
    var $row = $(this).closest("tr").remove();    // Find the row
})




function validaTelefone(fone, campo) {

    if ((fone == "") || (fone == null)) {

        return campo + ' é obrigatório.';
    }

    //remover a mascara
    fone = fone.replace('(', '');
    fone = fone.replace(')', '');
    fone = fone.replace('-', '');
    fone = fone.replace('.', '');
    fone = fone.replace(/\s+/g, '');

    if ((fone.length != 10) && (fone.length != 11)) {

        return campo + ' inválido.';
    }


    return '';

}



function validaEmail(email, campo) {

    if ((email == "") || (email == null)) {

        return campo + ' é obrigatório.';
    }


    var liAux1 = email.indexOf("@");

    var liAux2 = null;

    if (liAux1 > 0)
        liAux2 = email.indexOf(".", liAux1 + 1);


    if ((liAux1 == null) || (liAux1 < 2) || (liAux2 == null) || (liAux2 < (liAux1 + 2))) {

        return campo + ' inválido.';
    }

    var emailSplit = email.split("@");

    if (emailSplit.length != 2) {
        return campo + ' inválido.';
    }
    else {
        var emailPonto = emailSplit[1].split(".")

        if (emailPonto.length < 1) {
            return campo + ' inválido.';
        }

        if (emailPonto[0].length < 2) {
            return campo + ' inválido.';
        }

        if (emailPonto[1].length < 2) {
            return campo + ' inválido.';
        }
    }


    return '';

}



$('#btnSalvar').click(async function () {

    await SalveOrUpdate();
});


function SalveOrUpdate() {

    debugger
    var model = new Object();
    model.Nome = $("#inputNome").val();

    var nome = $("#inputNome").val();

    if (nome == "" || nome == null) {
        $("#inputNome").focus();
        swal(
            'Web Agenda...',
            'Campo NOME é obrigatorio',
            'error'
        );
        return;
    }



    model.PessoaId = $("#idPessoa").val();


    var contatos = $('#table_Contato tbody tr').map(function (index) {
        var cols = $(this).find('td');
        return {
            TipoContato: cols[0].innerHTML,
            TextoContato: cols[1].innerHTML,
            TipoAgp: cols[2].innerHTML,
            ContatoId: cols[4].innerHTML,
            CodigoTipo: cols[5].innerHTML,
            CodigoAgp: cols[6].innerHTML
        };
    }).get();

    model.contatoPosts = contatos;


    var endereco = $('#table_endereco tbody tr').map(function (index) {
        var cols = $(this).find('td');
        return {
            TextoContato: cols[0].innerHTML,
            NumeroEnd: cols[1].innerHTML,
            Complemento: cols[2].innerHTML,
            Bairro: cols[3].innerHTML,
            Cidade: cols[4].innerHTML,
            UF: cols[5].innerHTML,
            TipoEnd: cols[6].innerHTML,
            ContatoId: cols[8].innerHTML,
            CodigoTipo: cols[9].innerHTML,
            CodigoAgp: cols[10].innerHTML
        };
    }).get();

    model.enderecoPosts = endereco;




    $.ajax({
        type: "POST",
        data: model,
        url: "../Home/save"
    }).done(function (res) {
        swal(
            'Web Agenda...',
            'Operação realizada com sucesso!',
            'success'
        );
    });

}



function fncRemoverContato(idP, idC) {

    debugger

    var model = new Object();
    model.PessoaId = idP;
    model.ContatoId = idC;


    swal({
        title: 'Web Agenda...',
        text: "Deseja realmente excluir?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {


            $.ajax({
                type: "POST",
                data: model,
                url: "../Home/ExcluirContato"
            }).done(function (res) {
                swal(
                    'Web Agenda...',
                    'Operação realizada com sucesso!',
                    'success'
                );
            });

        } else {
            swal("Seu contato está seguro!");
        }
    });


}


function fncRemoverCadastro(idP) {

    debugger

    var model = new Object();
    model.PessoaId = idP;
    model.ContatoId = 0;



    swal({
        title: 'Web Agenda...',
        text: "Deseja realmente excluir?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {

            $.ajax({
                type: "POST",
                data: model,
                url: "../Home/Delete"
            }).done(function (res) {

                document.location.reload(true);

                swal(
                    'Web Agenda...',
                    'Operação realizada com sucesso!',
                    'success'
                );
            });

        } else {
            swal("Seu contato está seguro!");
        }
    });


}