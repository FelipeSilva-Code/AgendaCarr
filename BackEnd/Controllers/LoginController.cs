using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using BackEnd.Business;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {
        Business.LoginBusiness business = new Business.LoginBusiness();
        Business.GerenciadorFotoBusiness gerenciadorFoto = new Business.GerenciadorFotoBusiness();
        Utils.LoginConversor loginConversor = new Utils.LoginConversor();


        [HttpPost]
        public ActionResult<Models.Response.LoginResponse> Logar(Models.Request.LoginRequest loginRequest)
        {
            try
            {
                Models.TbLogin tbLogin = loginConversor.ParaTbLogin(loginRequest);
                tbLogin = business.Logar(tbLogin);

                Models.Response.LoginResponse resp = loginConversor.ParaLoginResponse(tbLogin);

                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }


        [HttpGet("PegarFoto/{nome}")]
        public ActionResult BuscarFoto(string nome)
        {
            try
            {
                byte[] foto = gerenciadorFoto.LerFoto(nome);

                string contentType = gerenciadorFoto.GerarContentType(nome);
                return File(foto, contentType);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

   
   
   
    }
}