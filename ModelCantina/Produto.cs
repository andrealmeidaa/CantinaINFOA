using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCantina
{
    public class Produto
    {
        public int IDProduto { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }

        //Dessa forma quando referenciar um objeto apresenta a descrição
        public override string ToString()
        {
            return Descricao;
        }
    }
}
