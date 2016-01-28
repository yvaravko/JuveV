using System;
using System.Linq;
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

        [HttpGet]
        [Route("/api/team/search/{value}")]
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
        public JsonResult Put(int id, [FromBody] Team vm)
        {
            try
            {
                _repository.Update(vm);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("updated");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError($"Error occurred updating player type with id = {id}", ex);
                return Json("Error occurred updating player type");
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("deleted");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError($"Error occurred deleting player type with id = {id}", ex);
                return Json("Error occurred deleting player type");
            }
        }
    }
}