using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly static IUsuarioRepository _iusuarioRepository =  new UsuarioRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lista = _iusuarioRepository.FindAll();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Find(int id)
        {
            var usuario = _iusuarioRepository.Find(id);
            return Json(usuario);
        }  
        
        [HttpGet]
        public IActionResult Usuario()
        {
            var lista = _iusuarioRepository.FindAll();
            return Json(lista);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario, IFormCollection form)
        {
            var imagemFile = form.Files["imagem"];
            if (imagemFile != null && imagemFile.Length > 0)
            {
                // Salvar a imagem no servidor
                var fileName = Path.GetFileName(imagemFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagemFile.CopyTo(fileStream);
                }

                usuario.Imagem = fileName;
            }
            else
            {
                usuario.Imagem = "profile.png";
            }

            usuario.Status = form["status"] == "on";

            _iusuarioRepository.Create(usuario);

            Console.WriteLine($"Usuário cadastrado com sucesso");
            return CreatedAtAction(nameof(Find), new { Id = usuario.Id }, usuario);
        }

        [HttpPut]
        public IActionResult Editar(Usuario usuario, IFormCollection form)
        {
            Console.WriteLine("id: " + usuario.Id);
            Console.WriteLine("nome: " + usuario.Nome);
            Console.WriteLine("email: " + usuario.Email);
            Console.WriteLine("imagem: " + usuario.Imagem);
            Console.WriteLine("nivelAcesso: " + usuario.NivelAcesso);
            Console.WriteLine("status: " + usuario.Status);
            Console.WriteLine("Status2: " + (form["status"] == "on"));

            var usuarioEncontrado = _iusuarioRepository.Find(usuario.Id);
            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            var imagemFile = form.Files["editarImagem"];
            if (imagemFile != null && imagemFile.Length > 0)
            {
                if (!string.IsNullOrEmpty(usuarioEncontrado.Imagem))
                {
                    if(usuarioEncontrado.Imagem != "profile.png")
                    {
                        var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", usuarioEncontrado.Imagem.TrimStart('/'));
                        if (System.IO.File.Exists(filePath2))
                        {
                            System.IO.File.Delete(filePath2);
                        }
                    }
                }

                var fileName = Path.GetFileName(imagemFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagemFile.CopyTo(fileStream);
                }

                usuario.Imagem = fileName;
            }
            else
            {
                usuario.Imagem = usuarioEncontrado.Imagem ;
            }

            usuario.Status = form["status"] == "on";

            _iusuarioRepository.Update(usuario.Id, usuario);

            Console.WriteLine($"Usuário atualizado com sucesso");

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            Console.WriteLine("Entrou no delete");
            Console.WriteLine(id);

            var usuario = _iusuarioRepository.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Deletar a imagem do servidor
            if (!string.IsNullOrEmpty(usuario.Imagem))
            {
                if(usuario.Imagem != "profile.png")
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", usuario.Imagem.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

            _iusuarioRepository.Destroy(usuario.Id);

           return NoContent();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
