using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //EntityFramework
using Projeto.Entidades; //classes de entidade
using Projeto.DAL.Contexto; //classe de configuração

namespace Projeto.DAL.Repositorios
{
    public class ClienteRepositorio
    {
        public void Insert(Cliente c)
        {
            //instanciar a classe de contexto..
            using (DataContext data = new DataContext())
            {
                data.Clientes.Add(c);
                data.SaveChanges();
            }
        }


        public void Update(Cliente c)
        {
            //instanciar a classe de contexto
            using (DataContext data = new DataContext())
            {              
                data.Entry(c).State = EntityState.Modified;
                data.SaveChanges();
            }
        }

        public void Delete(int idCliente)
        {
            using (DataContext data = new DataContext())
            {
                //busca o cliente pelo id
                Cliente c = data.Clientes.Find(idCliente);
                //excluindo..
                data.Clientes.Remove(c);
                data.SaveChanges();
            }
        }

        public List<Cliente> FindAll()
        {
            using (DataContext data = new DataContext())
            {
                return data.Clientes.ToList();
            }
        }

        public Cliente FindById(int idCliente)
        {
            using (DataContext data = new DataContext())
            {
                return data.Clientes.Find(idCliente);
            }
        }
    }
}
