using System;
using Application.Business;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(ApplicationBusiness.GetData());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(ApplicationBusiness.GetDataById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(ApplicationModel appModel)
        {
            try
            {
                return Ok(ApplicationBusiness.SaveData(appModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public ActionResult Patch(ApplicationModel appModel)
        {
            try
            {
                return Ok(ApplicationBusiness.UpdateData(appModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(ApplicationBusiness.DeleteData(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
