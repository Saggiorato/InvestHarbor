var carteira = new Vue({
    el: "#carteira",
    data: {
        //filtro
        Carteira: "",
        Investimento: "",
        TipoFiltro: "",
        Carteiras: [],

        //cadastro
        Id: "",
        Nome: "",
        Descricao: "",
        LimiteUtilizacao: "",
        //carteira investimentos
        CarteiraInvestimentos: [],
        InvestimentoId: "",
        PorcentagemCarteira: "",
        Investimentos: [],
    },
    methods: {
        Filtrar: function () {
            var self = this;

            $.get("/api/carteira?carteira=" + self.Carteira
                + "&investimento=" + self.Investimento).done(function (response) {
                    if (response.Sucesso) {
                        self.Carteiras = response.Dados;
                    }
                }).fail(function () {
                    //log
                });
        },
        Adicionar: function () {
            var self = this;

            if (!self.Nome)
                return mensagemErro("Informe o nome da carteira!");

            if (!self.Descricao)
                return mensagemErro("Informe a descrição da carteira!");

            var dados = {
                Id: self.Id,
                Nome: self.Nome,
                Descricao: self.Descricao,
                LimiteUtilizacao: self.LimiteUtilizacao,
                CarteiraInvestimentos: self.CarteiraInvestimentos
            }

            $.post("/api/carteira", dados).done(function (response) {
                if (response.Sucesso) {
                    mensagem("Carteira adicionada");

                    if (!self.Id) {
                        self.Carteiras.push({
                            Id: self.Id,
                            Nome: self.Nome,
                            Descricao: self.Descricao,
                            LimiteUtilizacao: self.LimiteUtilizacao,
                            CarteiraInvestimentos: self.CarteiraInvestimentos
                        });
                    } else {

                        for (var i = 0; i < self.Investimentos.length; i++) {

                            if (self.Carteiras[i].Id == self.Id) {
                                self.Carteiras[i].Nome = self.Nome;
                                self.Carteiras[i].Descricao = self.Descricao;
                                self.Carteiras[i].LimiteUtilizacao = self.LimiteUtilizacao;
                                self.Carteiras[i].CarteiraInvestimentos = self.CarteiraInvestimentos;
                            }
                        }
                    }

                    self.LimparCampos();
                } else {
                    mensagemErro("Não foi possivel adicionar esta carteira!");
                }
            }).fail(function () {
                //log
            });
        },
        AbrirModalCadastro: function () {
            var self = this;

            self.LimparCampos();

            $('#modal-cadastro').modal("show");
        },
        LimparCampos: function () {
            var self = this;

            self.Id = "";
            self.Nome = "";
            self.Descricao = "";
            self.LimiteUtilizacao = "";
            self.CarteiraInvestimentos = [];
            self.InvestimentoId = "";
            self.PorcentagemCarteira = "";
        },
        Editar: function (item) {
            var self = this;

            self.Id = item.Id
            self.Nome = item.Nome;
            self.Descricao = item.Descricao;
            self.LimiteUtilizacao = item.LimiteUtilizacao;

            $.get("/api/carteira/ObterCarteiraInvestimentos?id=" + item.Id).done(function (retorno) {
                if (retorno.Sucesso) {
                    self.CarteiraInvestimentos = retorno.Dados;
                } else {
                    mensagemErro("Não foi possivel obter os dados de investimento");
                }
            }).fail(function (retorno) {
                //log
                mensagemErro("Não foi possivel obter os dados de investimento");
            });

            $('#modal-cadastro').modal("show");
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/carteira/Remover?id=" + id).done(function (resposta) {
                if (resposta.Sucesso) {
                    self.Carteiras.splice(index, 1);
                    mensagem("Carteira removida");
                } else {
                    mensagemErro("Não é possivel remover esta carteira");
                }
            });
        },
        //carteira investimentos
        AdicionarInvestimento: function () {
            var self = this;

            self.CarteiraInvestimentos.push({
                CarteiraId: self.Id,
                InvestimentoId: self.InvestimentoId,
                PorcentagemCarteira: self.PorcentagemCarteira,
                Nome: $("#investimento-select option:selected").text()
            });
        },
        ExcluirInvestimento: function (id, index) {
            var self = this;

            $.post("/api/carteira/RemoverCarteiraInvestimento?id=" + id).done(function (resposta) {
                if (resposta.Sucesso) {
                    self.CarteiraInvestimentos.splice(index, 1);
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

        $.get("/api/investimento", function (resposta) {
            for (let i in resposta.Dados) {
                self.Investimentos.push({
                    id: resposta.Dados[i].Id,
                    text: resposta.Dados[i].Nome
                });
            }
        });
    }
})