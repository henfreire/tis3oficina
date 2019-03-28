using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tis3Oficina.src.OBJETO
{
    class Cliente
    {
        string nome, cpf, telefone, email, endereco, observacao;

        public Cliente(string nome, string cpf, string telefone, string email, string endereco, string observacao)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            this.endereco = endereco;
            this.observacao = observacao;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Observacao { get => observacao; set => observacao = value; }
    }
}
