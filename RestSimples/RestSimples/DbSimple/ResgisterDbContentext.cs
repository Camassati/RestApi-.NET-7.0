using RestSimples.Entities;

namespace RestSimples.DbSimple
{
    public class ResgisterDbContentext
    {
        public List<Register> Registers { get; set; }
        public ResgisterDbContentext() 
        {
            Registers = new List<Register>();
        }
    }
}
