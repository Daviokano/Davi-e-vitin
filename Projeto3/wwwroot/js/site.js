$(document).ready(function () {
    $('.cep').mask("00.000-000");
});

$(document).ready(function () {

    function limpa_formulario_cep() {
        // Limpa valores do formulário de cep.
        $("#Estado").val("");
        $("#Cidade").val("");
        $("#Endereco").val("");
        $("#Bairro").val("");
        $("#Complemento").val("");
    }

    // Quando o campo cep perde o foco.
    $("#CEP").blur(function () {

        // Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        // Verifica se campo cep possui valor informado.
        if (cep != "") {

            // Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            // Valida o formato do CEP.
            if (validacep.test(cep)) {

                // Preenche os campos com "..." enquanto consulta webservice.
                $("#Estado").val("...");
                $("#Cidade").val("...");
                $("#Logradouro").val("...");
                $("#Bairro").val("...");
                $("#Complemento").val("...");

                // Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        // Atualiza os campos com os valores da consulta.
                        $("#Estado").val(dados.uf);
                        $("#Cidade").val(dados.localidade);
                        $("#Logradouro").val(dados.logradouro);
                        $("#Bairro").val(dados.bairro);
                        $("#Complemento").val(dados.complemento);
                    } else {
                        // CEP pesquisado não foi encontrado.
                        limpa_formulario_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } else {
                // CEP é inválido.
                limpa_formulario_cep();
                alert("Formato de CEP inválido.");
            }
        } else {
            // CEP sem valor, limpa formulário.
            limpa_formulario_cep();
        }
    });
});
