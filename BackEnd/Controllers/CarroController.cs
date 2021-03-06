using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        Business.CarroBusiness business = new Business.CarroBusiness();
        Utils.CarroConversor conversor = new Utils.CarroConversor();

        [HttpPost]
        public ActionResult<Models.Response.SucessoResponse> AdicionarCarros (Models.Request.NovoCarroRequest carroRequest)
        {
            try
            {
                business.ValidarInformacoesDoCarroQueSeraAdicionado(carroRequest);

                Models.TbCarro carro = conversor.ParaTbCarro(carroRequest);
                
                business.AdicionarNovoCarro(carro);
                
                return new Models.Response.SucessoResponse(400, "Carro adicionado.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet]
        public ActionResult<List<Models.Response.CarrosResponse>> ListarCarros (string busca)
        {
            try
            {
                List<Models.TbCarro> carros = business.ListarCarros(busca);
                if (carros.Count == 0)
                    return NotFound("Nenhum carro encontrado.");

                return conversor.ListarCarros(carros);

            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }    
        }

        [HttpDelete("{idCarro}")]
        public ActionResult<Models.Response.SucessoResponse> DeletarCarro (int? idCarro)
        {
            try
            {
                if (idCarro == 0 || idCarro == null)
                    throw new ArgumentException("Houve um erro ao excluir o carro, tente novamente mais tarde.");

                business.DeletarCarro(idCarro);

                return new Models.Response.SucessoResponse(200, "Carro excluído com sucesso.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("pegarCarro/{idCarro}")]
        public ActionResult<Models.Response.CarrosResponse> PegarInfoDoCarro (int? idCarro)
        {
            try
            {
                Models.TbCarro carro =  business.PegarInfoDoCarro(idCarro);

                Models.Response.CarrosResponse carroResponse = conversor.SomenteUmCarroResponse(carro);

                return carroResponse;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpPut("{idCarro}")]
        public ActionResult<Models.Response.CarrosResponse> AlterarInfoCarro (int? idCarro, Models.Request.NovoCarroRequest carroRequest)
        {
            try
            {
                
                business.ValidarInformacoesDoCarroQueSeraAdicionado(carroRequest);

                Models.TbCarro carro = conversor.ParaTbCarro(carroRequest);

                carro = business.AlterarInfoCarro( idCarro ,carro);

                Models.Response.CarrosResponse carrosResponse = conversor.SomenteUmCarroResponse(carro);

                return carrosResponse;
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