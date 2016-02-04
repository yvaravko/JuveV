using System;
using System.Net;
using DataAccess.Contracts;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace JuveV.Controllers.Api
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerRepository _repository;

        public PlayerController(IPlayerRepository playerRepository, ILogger<PlayerController> logger)
        {
            _repository = playerRepository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var results = _repository.GetList();

                if (results == null)
                {
                    return Json(null);
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                _logger.LogError("Error occurred getting players", ex);
                return Json("Error occurred getting players");
            }
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                var results = _repository.GetById(id);

                if (results == null)
                {
                    return Json(null);
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                _logger.LogError($"Error occurred getting player with id = {id}", ex);
                return Json("Error occurred getting player");
            }
        }

        [HttpGet]
        [Route("/api/player/search/{value}")]
        public JsonResult Search(string value)
        {
            try
            {
                var results = _repository.Search(value);

                if (results == null)
                {
                    return Json(null);
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                _logger.LogError("Error occurred getting players", ex);
                return Json("Error occurred getting players");
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}