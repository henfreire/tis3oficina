using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    public class Orcamento
    {
        int  qtdeItens;
        List <Cliente> cliente;
        List <ItemOrcamento> itemOrc;
        String idCliente, codOrc;
        double totOrc;
        public int QtdeItens { get => qtdeItens; set => qtdeItens = value; }
        public String IdCliente { get => idCliente; set => idCliente = value; }
        public double TotOrc { get => totOrc; set => totOrc = value; }
        public String CodOrc { get => codOrc; set => codOrc = value; }
        public List<Cliente> Cliente { get => cliente; set => cliente = value; }
        public List<ItemOrcamento> ItemOrc { get => itemOrc; set => itemOrc = value; }
    }
}
