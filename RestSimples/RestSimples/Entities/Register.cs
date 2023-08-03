using System.ComponentModel.DataAnnotations;

namespace RestSimples.Entities
{
    public class Register
    {
        public Guid Id { get; set; }

        public int Idade { get; set; }
        public string Nome { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(int idade, string nome)
        {
            Idade = idade;
            Nome = nome;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
