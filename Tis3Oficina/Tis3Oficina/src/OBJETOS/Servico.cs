using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    public class Servico
    {

        string id,nomeServico,valor;

        public string Id { get => id; set => id = value; }
        public string NomeServico { get => nomeServico; set => nomeServico = value; }
        public string Valor { get => valor; set => valor = value; }
        

        public override string ToString() {

            return "ID: " + Id +
                "\nServico: " + NomeServico+
                "\nValor: " +Valor;
        }
    }
}
