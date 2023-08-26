'use strict'

//EDITAR

function preencherEditarFrom(data)
{
    const id = data.id;
    const nome = data.nome;
    const email = data.email;
    const imagem = data.imagem;
    const nivelAcesso = data.nivelacesso;
    const status = data.status;

    const opcoesNivelAcesso = {
        'Normal': 1,
        'Administrador': 2   
    };

    let modal = document.getElementById('editarModal');
    modal.querySelector('#editarId').value = id;
    modal.querySelector('#editarNome').value = nome;
    modal.querySelector('#editarEmail').value = email;

    let valorNumericoNivelAcesso = opcoesNivelAcesso[nivelAcesso];

    modal.querySelector('#editarNivelAcesso').selectedIndex = valorNumericoNivelAcesso  - 1;
    modal.querySelector('#editarStatus').checked = status == "True" ? true : false;
}

const botoesEditar = document.querySelectorAll('.editarButton')
botoesEditar.forEach(botao => {
    botao.addEventListener('click', (event) => {
      
        preencherEditarFrom(botao.dataset);
 
        const confirmarEditarBtn = document.getElementById('confirmarEditarBtn');
        confirmarEditarBtn.addEventListener('click', (e) => {
            console.log("Click")
        
            var editarForm = confirmarEditarBtn.closest("form");
            editarForm.addEventListener('submit', function(event) {
                event.preventDefault();
                console.log("Submit")
                // Cria um objeto FormData com os dados do formulário
                const formData = new FormData(editarForm);

                fetch(editarForm.action, {
                    method: 'PUT',
                    body: formData
                })
                .then(response => {
                    if (response.status === 204) {
                        console.log("Deu certo! Os dados foram atualizados.");
                    } else {
                        console.log("Ocorreu um erro ao atualizar os dados.");
                    }
                })
                .catch(error => console.error(error));
            });
        });
    });
});
