using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.Entidades;
using Projeto.DAL.Mapeamento;
using System.Configuration;

namespace Projeto.DAL.Contexto
{
    //Regra 1) Herdar DbContext
    public class DataContext : DbContext
    {

        //Regra 4) Construtor que envie para o DbContext a connectionstring..
        public DataContext()
            : base(ConfigurationManager
                  .ConnectionStrings["aula"].ConnectionString)
        {

        }

        //Regra 2) Sobrescrever o método OnModelCreating
        //Este método servirá para configurar todos os mapeamentos feitos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adiciona cada classe de mapeamento criada no projeto
            modelBuilder.Configurations.Add(new ClienteMap());
        }

        //Regra 3) Para cada entidade deverá ser declarado um DbSet<Entidade>
        //Este DbSet iré fornecer as operações de CRUD com entidade
        //[prop] + 2x[tab]
        public DbSet<Cliente> Clientes  { get; set; }
    }
}
