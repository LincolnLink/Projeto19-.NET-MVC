using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //configuração

namespace Projeto.WEB.Models
{
    //Modelo de dados para /Cliente/Cadastro
    public class ClienteViewModelCadastro
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        [Display(Name = "Nome do Cliente:")] //label
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        [Display(Name = "Email do Cliente:")] //label
        public string Email { get; set; }
    }
}