using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    class Peca
    {
        string codPec, nomePec, valPec, qtdePeca;

        public string CodPec { get => codPec; set => codPec = value; }
        public string NomePec { get => nomePec; set => nomePec = value; }
        public string ValPec { get => valPec; set => valPec = value; }
        public string QtdePeca { get => qtdePeca; set => qtdePeca = value; }

        public override string ToString()
        {

            return "Cod Servico: " + CodPec +
                "\nNome Peca: " + NomePec +
                "\nValor Peca: " + ValPec;
        }
    }
}
