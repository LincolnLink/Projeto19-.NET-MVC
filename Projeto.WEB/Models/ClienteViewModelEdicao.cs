using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class ClienteViewModelEdicao
    {
        [Display(Name = "Código do Cliente:")]
        public int IdCliente { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        [Display(Name = "Nome do Cliente:")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        [Display(Name = "Email do Cliente:")]
        public string Email { get; set; }

        [Display(Name = "Data/Hora de Cadastro:")]
        public DateTime DataHoraCadastro { get; set; }
    }
}