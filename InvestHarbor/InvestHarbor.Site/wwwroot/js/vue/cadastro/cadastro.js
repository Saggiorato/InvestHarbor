var cadastro = new Vue({
    el: "#cadastro",
    data: {
        Email: "",
        Telefone: "",
        Senha: "",
        Confirmacao: ""
    },
    methods: {
        Confirmar: function () {
            var self = this;

            if (!self.Email)
                return mensagemErro("Informe o e-mail", "#email");

            if (!self.Telefone)
                return mensagemErro("Informe o telefone", "#telefone");

            if (!self.Senha)
                return mensagemErro("Informe a senha", "#senha");

            if (!self.Confirmacao)
                return mensagemErro("Informe a confirmação da senha", "#confirmacao");

            if (self.Senha != self.Confirmacao)
                return mensagemErro("As senhas não coincidem", "#senha");

            var dados = {
                Email: self.Email,
                Telefone: self.Telefone,
                Senha: self.Senha,
                Confirmacao: self.Confirmacao
            }

            $.post("/api/cadastro/", dados).done(function (response) {
                if (response.Sucesso) {
                    mensagem("Usuário cadastrado com sucesso!");
                    window.location = "/Cadastro/Cliente";
                }
            }).fail(function () {
                //log
            });
        }
    }
})