var cadastroCliente = new Vue({
    data: {
        Nome: "",
        Sobrenome: "",
        Cpf: "",
        DataNascimento: "",
        Cep: ""
    },
    methods: {
        Confirmar: function () {
            var self = this;

            if (!self.Nome)
                return mensagemErro("Informe o seu nome", "#nome");

            if (!self.Sobrenome)
                return mensagemErro("Informe o seu sobrenome", "#sobrenome");

            if (!self.Cpf)
                return mensagemErro("Informe o seu CPF", "#cpf");

            if (!self.DataNascimento)
                return mensagemErro("Informe a sua data de nascimento", "#dataNascimento");

            if (!self.Cep)
                return mensagemErro("Informe o seu CEP", "#cep");

            var dados = {
                Nome: self.Nome,
                Sobrenome: self.Sobrenome,
                Cpf: self.Cpf,
                DataNascimento: self.DataNascimento,
                Cep: self.Cep
            }

            $.post("/api/cadastro/cliente", dados).done(function (response) {
                if (response.Sucesso) {
                    mensagem("Dados cadastrados com sucesso!");
                    window.location = "/Login";
                }
            }).fail(function () {
                //log
            });
        }
    }
})