using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    public class ItemOrcamento
    {

        string nome, observacao;
        int id, idPeca, idServico, idOrcamento;
        double valor;

        public string Nome { get => nome; set => nome = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public int Id { get => id; set => id = value; }
        public int IdPeca { get => idPeca; set => idPeca = value; }
        public int IdServico { get => idServico; set => idServico = value; }
        public int IdOrcamento { get => idOrcamento; set => idOrcamento = value; }
        public double Valor { get => valor; set => valor = value; }
    }
}
