'use strict'


var editarBtns = document.querySelectorAll('.btn-warning');
function preencherFormularioModal(id, nome, email, imagem, nivelAcesso, status) 
{
    var modal = document.getElementById('editarModal');
    modal.querySelector('#editarId').value = id;
    modal.querySelector('#editarNome').value = nome;
    modal.querySelector('#editarEmail').value = email;

    var opcoesNivelAcesso = 
    {
        'Normal': 1,
        'Administrador': 2   
    };

    var valorNumericoNivelAcesso = opcoesNivelAcesso[nivelAcesso];

    modal.querySelector('#editarNivelAcesso').selectedIndex = valorNumericoNivelAcesso  - 1;
    modal.querySelector('#editarStatus').checked = status == "True" ? true : false;
}

editarBtns.forEach(function(btn) {
    btn.addEventListener('click', function() 
    {
        var id = this.dataset.id;
        var nome = this.dataset.nome;
        var email = this.dataset.email;
        var imagem = this.dataset.imagem;
        var nivelAcesso = this.dataset.nivelacesso;
        var status = this.dataset.status;

        console.log('id:', id);
        console.log('nome:', nome);
        console.log('email:', email);
        console.log('imagem:', imagem);
        console.log('nivelAcesso:', nivelAcesso);
        console.log('status:', status);

        preencherFormularioModal(id, nome, email, imagem, nivelAcesso, status);
    });
});

const modal = document.getElementById('excluirModal')
const botoesExcluir = document.querySelectorAll('.excluirButton')

botoesExcluir.forEach(botao => {
botao.addEventListener('click', (e) => {
e.preventDefault();
modal.classList.add('show');
modal.style.display = 'block';

const confirmarBtn = modal.querySelector('#confirmarExclusaoBtn');
const cancelarBtn = modal.querySelector('#cancelarExclusaoBtn');
const fecharBtn = modal.querySelector('#fecharExclusaoBtn');

confirmarBtn.addEventListener('click', () => {
const form = botao.closest('form');
form.submit();
});

cancelarBtn.addEventListener('click', () => {
modal.classList.remove('show');
modal.style.display = 'none';
});

fecharBtn.addEventListener('click', () => {
modal.classList.remove('show');
modal.style.display = 'none';
});
});
});


    