using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETOS
{
    public class Cliente
    {

        string id,nome, cpf, telefone, endereco, observacao,email;
        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public string Email { get => email; set => email = value; }
    }
}
