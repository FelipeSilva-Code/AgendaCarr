using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Models.Request
{
    public class InformacoesRequest
    {
         public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CNH { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha {get; set;}
        public IFormFile ImagemUsuario { get; set; }
    }
}