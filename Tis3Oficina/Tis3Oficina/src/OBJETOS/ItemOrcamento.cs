using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    public class ItemOrcamento
    {

        string nome, observacao, id, idPeca, idServico, idOrcamento;

        double valor;
        int quantidade;

        public string Nome { get => nome; set => nome = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public string Id { get => id; set => id = value; }
        public string IdPeca { get => idPeca; set => idPeca = value; }
        public string IdServico { get => idServico; set => idServico = value; }
        public string IdOrcamento { get => idOrcamento; set => idOrcamento = value; }
        public double Valor { get => valor; set => valor = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
    }
}
