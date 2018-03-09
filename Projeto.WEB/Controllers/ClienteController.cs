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
            List<ClienteViewModelConsulta> lista = CarregarDados();
            return View(lista);           
        }
        #endregion

        #region Exclusao
        // GET: Cliente/Exclusao/id
        public ActionResult Exclusao(int id)
        {
            try
            {
                ClienteBusiness business = new ClienteBusiness();
                business.Excluir(id);

                ViewBag.mensagem = "Cliente excluido com sucesso!";
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
            }

            List<ClienteViewModelConsulta> lista = CarregarDados();
            //Nome da pagina
            return View("Consulta", lista);
        }
        #endregion

        #region Edicao
        // GET: Cliente/Edicao/id
        public ActionResult Edicao(int id)
        {
            ClienteViewModelEdicao model = new ClienteViewModelEdicao();

            try
            {
                ClienteBusiness business = new ClienteBusiness();
                Cliente c = business.ObterPorId(id);

                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;
                model.DataHoraCadastro = c.DataHoraCadastro;
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            
            //enviando a model para a pagina
            return View(model);
        }

        // POST: Cliente/Edicao
        [HttpPost]
        public ActionResult Edicao(ClienteViewModelEdicao model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.DataHoraCadastro = model.DataHoraCadastro;

                    ClienteBusiness business = new ClienteBusiness();
                    business.Atulizar(c);

                    ViewBag.Mensagem = "Cliente atualizado com sucesso!";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            List<ClienteViewModelConsulta> lista = CarregarDados();
            return View("Consulta", lista);
        }

        #endregion

        #region CarregarDados

        private List<ClienteViewModelConsulta> CarregarDados()
        {
            List<ClienteViewModelConsulta> lista = new List<ClienteViewModelConsulta>();
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
            return lista; //fazendo o envio da lista para a página..
        }

        #endregion

    }
}




