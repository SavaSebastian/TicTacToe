using System;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Data;
using TicTacToe.Dtos;
using TicTacToe.Helpers;
using TicTacToe.Model;

namespace TicTacToe.Controllers
{
    [Route("apiMatch")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _repository;
        private readonly JwtService _jwtService;

        public MatchController(IMatchRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("AddMatch")]
        public IActionResult AddMatch(MatchDto dto)
        {
            
            Console.WriteLine(dto.MatchState + " " + dto.UserId);
            
            var match = new Match
            {
                UserId = dto.UserId,
                MatchState = dto.MatchState
            };

            _repository.AddMatch(match);
            
            return Ok(new
            {
                message = "Success"
            });
        }

        [HttpGet("GetMatchHistory")]
        public IActionResult GetMatchHistory()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var matches = _repository.GetMatchHistory(userId);

                return Ok(matches);
            }
            catch
            {
                return Unauthorized("Unauthorized access");
            }
        }
    }
}