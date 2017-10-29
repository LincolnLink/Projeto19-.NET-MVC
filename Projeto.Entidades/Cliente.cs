using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataHoraCadastro { get; set; }

        public Cliente()
        {

        }
        public Cliente(int idCliente, string nome, string email, DateTime dataHoraCadastro)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            DataHoraCadastro = dataHoraCadastro;
        }

        public override string ToString()
        {
            return $"Id: {IdCliente}, Nome: {Nome}, Email: {Email}," +
                $"Data e Hora do Cadastro: {DataHoraCadastro}";
        }
    }
}
