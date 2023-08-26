using System.Collections.Generic;

namespace CRUD.Models
{
   public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {     
             private List<Usuario> listaUsuarios = new List<Usuario>
            {
                new Usuario { Imagem = "profile.png", Nome = "Naruto", Email = "naruto@brlink.com", NivelAcesso = NivelAcesso.Administrador, Status = true },
                new Usuario { Imagem = "profile.png", Nome = "Goku", Email = "goku@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = true },
                new Usuario { Imagem = "profile.png", Nome = "Luffy", Email = "luffy@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = false },
                new Usuario { Imagem = "profile.png", Nome = "Ichigo", Email = "ichigo@brlink.com", NivelAcesso = NivelAcesso.Administrador, Status = true },
                new Usuario { Imagem = "profile.png", Nome = "Sailor Moon", Email = "sailormoon@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = false },
                new Usuario { Imagem = "profile.png", Nome = "Naruto Uzumaki", Email = "narutouzumaki@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = true },
                new Usuario { Imagem = "profile.png", Nome = "Vegeta", Email = "vegeta@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = true },
                new Usuario { Imagem = "profile.png", Nome = "Monkey D. Luffy", Email = "monkeydluffy@brlink.com", NivelAcesso = NivelAcesso.Administrador, Status = false },
                new Usuario { Imagem = "profile.png", Nome = "Edward Elric", Email = "edwardelric@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = true },
                new Usuario { Imagem = "profile.png", Nome = "Pikachu", Email = "pikachu@brlink.com", NivelAcesso = NivelAcesso.Normal, Status = false },
                new Usuario { Imagem = "profile.png", Nome = "Rick Sanchez", Email = "rick@brlink.com", NivelAcesso = NivelAcesso.Administrador, Status = false }
            };
            
        public UsuarioRepository()
        {
            foreach (var usuario in listaUsuarios)
            {
                this.Create(usuario);
            }
        }
    }
}