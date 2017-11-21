function remover(id, url) {
    if (confirm("Você tem certeza que quer deletar esta linha?")) {
        $.ajax({
            type: "POST",
            url: url,
            data: { id : id}
        });
        console.log("eoq");
        $("#linha"+id).hide().remove();
    }
}

function favoritar(id, url) {
    $.ajax({
        type: "POST",
        url: url,
        data: { id : id }
    });
    $("#botaoFavoritar"+id).toggleClass("btn-warning");
}