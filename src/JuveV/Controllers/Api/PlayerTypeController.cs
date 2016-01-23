using System;
using System.Net;
using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.AspNet.Mvc;

namespace JuveV.Controllers.Api
{
    [Route("api/[controller]")]
    public class PlayerTypeController : Controller
    {
        private readonly IPlayerTypeRepository<PlayerType> _repository;

        public PlayerTypeController(IPlayerTypeRepository<PlayerType> playerTypeRepository)
        {
            _repository = playerTypeRepository;
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
                return Json("Error occurred getting player types");
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
                return Json("Error occurred getting player type");
            }
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] PlayerType vm)
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
                return Json("Error occurred creating player type");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PlayerType vm)
        {
            _repository.Update(vm);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}