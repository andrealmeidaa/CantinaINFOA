using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCantina
{
    public class VendaProduto
    {
        public Venda Venda {get;set;}
        public Produto Produto{get;set;}
        public int Quantidade { get; set;}

        //Novas Propriedades para exibição no data Grid

        public double PrecoUnitario
        {
            get { return Produto.PrecoUnitario; }
        }

        public double Subtotal
        {
            get{
                return Quantidade*Produto.PrecoUnitario;
            }
        }
    }
}
