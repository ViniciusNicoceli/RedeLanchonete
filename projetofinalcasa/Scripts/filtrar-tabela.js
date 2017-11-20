window.onload = function(){
    var filtro = document.querySelector("#filtrar-tabela");

    document.querySelector("#filtrar-tabela").addEventListener("input", function () {
        var linhas = document.querySelectorAll(".linha");
        for (var i = 0; i < linhas.length ; i++) {
            var linha = linhas[i];
            var tdNome = linha.querySelector(".info-nome");
            var nome = tdNome.textContent;
            var expressao = new RegExp(this.value, "i");
            if (!expressao.test(nome)) {
                linha.classList.add("invisivel");
            } else {
                linha.classList.remove("invisivel");
            }
            if (this.value == "") {
                for (var x = 0; x < linhas.length ; x++) {
                    linha = linhas[x];
                    linha.classList.remove("invisivel");
                }
            }
        }
    });
}