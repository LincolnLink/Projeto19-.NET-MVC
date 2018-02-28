using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento
using Projeto.Entidades;


namespace Projeto.DAL.Mapeamentos
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // nome da tabela
            ToTable("Cliente");

            // chave primaria
            HasKey(c => c.IdCliente);

            //mapeando cada campo da tabela
            Property(c => c.IdCliente) //propriedade da classe
                .HasColumnName("IdCliente") //nome do campo na tabela
                .IsRequired(); //not null

            Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.DataHoraCadastro)
                .HasColumnName("DataHoraCadastro")
                .IsRequired();
        }
    }
}
