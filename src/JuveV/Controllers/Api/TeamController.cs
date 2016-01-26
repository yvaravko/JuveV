using System;
using System.Net;
using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace JuveV.Controllers.Api
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _repository;
        private ILogger<TeamController> _logger;

        public TeamController(ITeamRepository repository, ILogger<TeamController> logger)
        {
            _repository = repository;
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
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("Error occurred getting teams", ex);
                return Json("Error occurred getting teams");
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
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError($"Error occurred getting team with id = {id}", ex);
                return Json("Error occurred getting team");
            }

        }

        [HttpPost]
        public JsonResult Post([FromBody] Team vm)
        {
            try
            {
                var id = _repository.Create(vm);
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(new { id = id });
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError("Error occurred creating player type", ex);
                return Json("Error occurred creating player type");
            }

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