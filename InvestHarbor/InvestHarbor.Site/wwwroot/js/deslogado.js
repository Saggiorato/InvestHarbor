//https://ned.im/noty/#/types
//SUCESSO
function mensagem(texto, focus) {

    new Noty({
        layout: 'topRight',
        theme: 'relax',
        type: "success",
        text: texto,
        timeout: 5000
    }).show();

    if (focus)
        $(focus).focus();
}

//ERRO
function mensagemErro(texto, focus) {
    new Noty({
        layout: 'topRight',
        theme: 'relax',
        type: "error",
        text: texto,
        // closeWith: ['button', 'click'],
        timeout: 15000
    }).show();

    if (focus)
        $(focus).focus();
}

//ALERT
function mensagemAlerta(texto, focus) {
    new Noty({
        layout: 'topRight',
        theme: 'relax',
        type: "alert",
        text: texto,
        // closeWith: ['button', 'click'],
        timeout: 20000
    }).show();

    if (focus)
        $(focus).focus();
}

//INFO
function mensagemInfo(texto, focus) {
    new Noty({
        layout: 'topRight',
        theme: 'relax',
        type: "info",
        text: texto,
        // closeWith: ['button', 'click'],
        timeout: 20000
    }).show();

    if (focus)
        $(focus).focus();
}

//WARNING
function mensagemAviso(texto, focus) {
    new Noty({
        layout: 'topRight',
        theme: 'relax',
        type: "warning",
        text: texto,
        // closeWith: ['button', 'click'],
        timeout: 5000
    }).show();

    if (focus)
        $(focus).focus();
}