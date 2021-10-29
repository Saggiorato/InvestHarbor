var ordem = new Vue({
    el: "#ordem",
    data: {
        FundoId: "",
        Valor: "",
        Porcentagem: "",
        ClienteFiltro: "",
        ValorDisponivel: "",
        Clientes: []
    },
    methods: {
        Filtrar: function () {
            var self = this;

            $.get("/api/Cliente/ObterClientesComSaldoDisponivel?nome=" + self.ClienteFiltro, function (resposta) {
                self.Clientes = resposta.Dados;
            });
        }
    },
    created: function () {
        var self = this;

        self.Filtrar();
    }
})