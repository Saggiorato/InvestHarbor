var login = new Vue({
    el: "#login",
    data: {
        Cpf: "",
        Senha: "",
    },
    methods: {
        Acessar: function () {
            var self = this;

            if (!self.Cpf)
                return mensagemErro("Informe o CPF", "#cpf");
            if (!self.Senha)
                return mensagemErro("Informe a Senha", "#senha");

            var acesso = {
                Cpf: self.Cpf,
                Senha: self.Senha
            }

            $.post("/api/Login/", acesso).done(function (response) {
                if (response.Sucesso)
                    window.location = "/Administracao";
            }).fail(function (error) {
                //log
            });
        }
    }
})