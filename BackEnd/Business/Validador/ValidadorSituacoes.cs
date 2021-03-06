using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business.Validador
{
    public class ValidadorSituacoes
    {
        Database.ValidacoesDatabase db = new Database.ValidacoesDatabase();


        public Models.TbLogin TirarEspacosDosCamposLogin (Models.TbLogin login)
        {
            if(!string.IsNullOrEmpty(login.DsEmail) && !string.IsNullOrEmpty(login.DsSenha))
            {
                login.DsEmail = login.DsEmail.Trim();
                login.DsSenha = login.DsSenha.Trim();
            }
            
            return login;
        }

        public Models.TbCliente TirarEspacosDosCamposCliente (Models.TbCliente cliente)
        {
            if(!string.IsNullOrEmpty(cliente.DsCnh) && !string.IsNullOrEmpty(cliente.NmCliente))
            {
                cliente.DsCnh = cliente.DsCnh.Trim();
                cliente.NmCliente = cliente.NmCliente.Trim();
            }

            return cliente;
        }

        public Models.TbFuncionario TirarEspacosDosCamposFuncionario(Models.TbFuncionario funcionario)
        {
            if (!string.IsNullOrEmpty(funcionario.NmFuncionario))
            {
                funcionario.NmFuncionario = funcionario.NmFuncionario.Trim();
            }

            return funcionario;
        }



        public void ValidarEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ArgumentException("O e-mail é obrigatório");

            else if (!email.Contains("@gmail.com") && !email.Contains("@hotmail.com") && !email.Contains("@bol.com"))
                throw new ArgumentException("O e-mail está incorreto.");

        }

        public void ValidarId (int? id)
        {
            if(id == 0 || id == null)
            throw new ArgumentException("Algo errado, tente novamente.");
        }

        public void ValidarNota (int nota)
        {
            if(nota < 1)
             throw new ArgumentException("A nota não pode ser menor que 1");

            if(nota > 5)
              throw new ArgumentException("A nota não pode ser maior que 5");
        }

    }
}