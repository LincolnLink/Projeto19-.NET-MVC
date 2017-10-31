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

        // GET: Cliente/Consulta
        public ActionResult Consulta()
        {
            return View();
        }
    }
}