//NESTE ARQUIVO ESTAO AS CONSULTAS AS APIS
//O OBJETIVO É EVITAR A REPETIÇÃO DE CÓDIGO E UTILIZAR OUTROS ARQUIVOS APENAS PARA CONSULTA
//NÃO IRA PESAR NO CARREGAMENTO POIS APENAS SÃO EXECUTADOS OS MÉTODOS CHAMADOS NOS ARQUIVOS
//O NOME DOS METODOS DEVE SEGUIR O PADRÃO PASCAL CASE E O NOME DEVE SER OBJETIVO A SUA FUNÇÃO
//OBSERVAR QUE ESTES METODOS APENAS SERVEM PARA LISTAS E OBJETOS DEVIDO AS PARTICULARIDADES DO JS
//NA CHAMADA ObterNiveisPlanoContasPlanoPadrao(self.NiveisPlanoContas); DEVE SER PASSADA A REFERENCIA A UM OBJETO OU ARRAY
//NÃO FUNCIONA COM SELECT2

function ObterInvestimentos(objeto) {

    $.get("/api/investimento", function (resposta) {
        for (let i in resposta.Dados) {
            objeto.push({
                id: resposta.Dados[i].Id,
                text: resposta.Dados[i].Nome
            });
        }
    });
}

function ObterClientes(objeto) {

    $.get("/api/Cliente", function (resposta) {
        for (let i in resposta.Dados) {
            objeto.push({
                id: resposta.Dados[i].Id,
                text: resposta.Dados[i].Nome
            });
        }
    });
}