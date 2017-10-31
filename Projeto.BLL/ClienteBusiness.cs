using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades;
using Projeto.DAL.Repositorios;

namespace Projeto.BLL
{
    public class ClienteBusiness
    {
        public void Cadastrar(Cliente c)
        {
            c.DataHoraCadastro = DateTime.Now; //data e hora atual

            ClienteRepositorio rep = new ClienteRepositorio();
            rep.Insert(c); //gravando
        }

        public void Atulizar(Cliente c)
        {
            //atualizando o cliente
            ClienteRepositorio rep = new ClienteRepositorio();
            rep.Update(c);
        }

        public void Excluir(int IdCliente)
        {
            //excluindo cliente
            ClienteRepositorio rep = new ClienteRepositorio();
            rep.Delete(IdCliente);
        }

        public List<Cliente> Listar()
        {
            //listar todos os clientes
            ClienteRepositorio rep = new ClienteRepositorio();
            return rep.FindAll();
        }


        public Cliente ObterPorId(int IdCliente)
        {
            ClienteRepositorio rep = new ClienteRepositorio();
            return rep.FindById(IdCliente); //Obter um Cliente poR id
           
        }
    }
}
