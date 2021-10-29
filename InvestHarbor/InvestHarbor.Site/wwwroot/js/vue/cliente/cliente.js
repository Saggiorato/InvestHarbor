var cliente = new Vue({
    el: "#clientes",
    data: {
        //consulta
        NomeFiltro: "",
        Lista: [],

    },
    methods: {
        Filtrar: function () {
            var self = this;

            $.get("/api/cliente?nome=" + self.NomeFiltro).done(function (response) {
                if (response.Sucesso) {
                    self.Lista = response.Dados;
                }
            }).fail(function () {
                //log
            });
        }
    },
    created: function () {
        var self = this;

        self.Filtrar();
    }
})