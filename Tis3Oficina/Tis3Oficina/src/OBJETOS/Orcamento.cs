using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    public class Orcamento
    {


        int codOrc, qtdeItens, idCliente;
        double totOrc;
        public int QtdeItens { get => qtdeItens; set => qtdeItens = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public double TotOrc { get => totOrc; set => totOrc = value; }
        public int CodOrc { get => codOrc; set => codOrc = value; }
    }
}
