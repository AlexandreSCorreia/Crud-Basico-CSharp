namespace CRUD.Models
{
    public class Usuario : BaseModel
    {
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
        public bool Status { get; set; }
    }
}