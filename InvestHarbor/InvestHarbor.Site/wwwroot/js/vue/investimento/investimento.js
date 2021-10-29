var investimento = new Vue({
    el: "#investimento",
    data: {
        //filtro
        Filtro: "",
        TipoFiltro: "",
        Investimentos: [],

        //cadastro
        Id: "",
        Nome: "",
        Tipo: "",
        Descricao: ""
    },
    methods: {
        Filtrar: function () {
            var self = this;

            $.get("/api/investimento?filtro=" + self.Filtro
                + "&tipo=" + self.TipoFiltro).done(function (response) {
                    if (response.Sucesso) {
                        self.Investimentos = response.Dados;
                    }
                }).fail(function () {
                    //log
                });
        },
        Adicionar: function () {
            var self = this;

            if (!self.Nome)
                return mensagemErro("Informe o nome do investimento!");

            if (self.Tipo === "")
                return mensagemErro("Informe o tipo do investimento!");

            if (!self.Descricao)
                return mensagemErro("Informe a descrição do investimento!");

            var dados = {
                Id: self.Id,
                Nome: self.Nome,
                Tipo: self.Tipo,
                Descricao: self.Descricao
            }

            $.post("/api/investimento", dados).done(function (response) {
                if (response.Sucesso) {
                    mensagem("Investimento adicionado");

                    if (!self.Id) {
                        self.Investimentos.push({
                            Id: response.Id,
                            Nome: self.Nome,
                            Tipo: self.Tipo,
                            Descricao: self.Descricao,
                            DescricaoTipo: $("#tipo option:selected").text()
                        });
                    } else {

                        for (var i = 0; i < self.Investimentos.length; i++) {

                            if (self.Investimentos[i].Id == self.Id) {
                                self.Investimentos[i].Nome = self.Nome;
                                self.Investimentos[i].Tipo = self.Tipo;
                                self.Investimentos[i].Descricao = self.Descricao;
                                self.Investimentos[i].DescricaoTipo = $("#tipo option:selected").text();
                            }
                        }
                    }

                    self.LimparCampos();
                }
            }).fail(function () {
                //log
            });
        },
        AbrirModalCadastro: function () {
            var self = this;

            self.Id = "";
            self.Nome = "";
            self.Tipo = null;
            self.Descricao = "";

            $('#modal-cadastro').modal("show");
        },
        LimparCampos: function () {
            var self = this;

            self.Nome = "";
            self.Tipo = null;
            self.Descricao = "";
        },
        Editar: function (item) {
            var self = this;

            self.Id = item.Id
            self.Nome = item.Nome;
            self.Tipo = item.Tipo;
            self.Descricao = item.Descricao;

            $('#modal-cadastro').modal("show");
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/investimento/RemoverInvestimento?id=" + id).done(function (resposta) {
                if (resposta.Sucesso) {
                    self.Investimentos.splice(index, 1);
                    mensagem("Investimento removido");
                } else {
                    mensagemErro("Não é possivel remover este investimento");
                }
            });
        }
    },
    created: function () {
        var self = this;

        self.Filtrar();
    }
})