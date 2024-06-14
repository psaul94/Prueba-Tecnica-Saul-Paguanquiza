using JuegoRuleta.Models;
using JuegoRuleta.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using Persistencia.Model;
using Persistencia.Services;


namespace JuegoRuleta.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IGamerService _gamerService;
        public GeneralController(IGamerService gamerService)
        {
            _gamerService = gamerService;
        }

        [HttpGet("GetRandom")]
        public ResponseGamerDto GetRandom()
        {
            Random random = new Random();
            int numberRandom = random.Next(1, 36);
            int numberRandomColor = random.Next(2);
            return new ResponseGamerDto()
            {
                Number = numberRandom,
                Color = numberRandomColor == 0 ? "Negro" : "Rojo"
            };
        }

        

        [HttpPost("PostGamer")]
        public async Task<IActionResult> PostGamer([FromBody] ApiModelDto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name)) throw new ArgumentOutOfRangeException("El nombre es obligatorio.");
                if (await _gamerService.GetExistGamer(model.Name)) throw new Exception("El nombre de usuario ya existe.");
                var gamer = await _gamerService.AddGamer(new Gamer()
                {
                    Name = model.Name,
                    Amount = model.Amount
                });
                return Ok(gamer);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, "", StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost("AmountAcumulated")]
        public async Task<IActionResult> AmountAcumulated([FromBody] ApiModelDto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name)) throw new ArgumentOutOfRangeException("El nombre es obligatorio.");
                if (await _gamerService.GetExistGamer(model.Name)) throw new Exception("El nombre de usuario ya existe.");
                var gamer = await _gamerService.AddGamer(new Gamer()
                {
                    Name = model.Name,
                    Amount = model.Amount
                });
                return Ok(gamer);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, "", StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost("Bet")]
        public async Task<IActionResult> Bet([FromBody] ApiBetModelDto model)
        {
            try
            {               
                var resultGame = Game.ResultGame();
                var apuesta = Game.ValdationGame(resultGame, model);

                return Ok(apuesta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, "", StatusCodes.Status400BadRequest);
            }
        }
    }
}
