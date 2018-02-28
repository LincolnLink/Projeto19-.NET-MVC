using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.Entidades;
using Projeto.BLL;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        #region Cadastrar       
        // GET: Cliente/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Cliente/Cadastro
        [HttpPost] //recebe o submit da página de cadastro
        public ActionResult Cadastro(ClienteViewModelCadastro model)
        {
            //verificar se os dados da model passaram nas validações
            if (ModelState.IsValid) //validação da model esta ok?
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = model.Nome;
                    c.Email = model.Nome;

                    //Cadastra o cliente
                    ClienteBusiness business = new ClienteBusiness();
                    business.Cadastrar(c);

                    //exibir mensagem de sucesso..
                    ViewBag.Mensagem = "Cliente cadastrado com sucesso";
                    ModelState.Clear(); //limpar os dados da model..                    
                }
                catch (Exception e)
                {
                    //Exibe Mensagem de erro
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();
        }
        #endregion

        #region Consultar
        
        // GET: Cliente/Consulta
        public ActionResult Consulta()
        {
            //declarando uma lista da classe de modelo..
            List<ClienteViewModelConsulta> lista
           = new List<ClienteViewModelConsulta>();
            try
            {
                //instanciar na classe de regras de negócio..
                ClienteBusiness business = new ClienteBusiness();
                //varrendo os clientes obtidos na camada de negocio..
                foreach (Cliente c in business.Listar())
                {
                    ClienteViewModelConsulta model
                   = new ClienteViewModelConsulta();
                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataHoraCadastro = c.DataHoraCadastro;
                    lista.Add(model); //adicionando na lista..
                }
            }
            catch (Exception e)
            {
                //exibir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //enviando a lista para a página..
            return View(lista); //fazendo o envio da lista para a página..
        }     

    }
}



#endregion
