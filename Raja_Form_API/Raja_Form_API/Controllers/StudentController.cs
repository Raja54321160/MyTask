using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raja_Form_API.Models;

namespace Raja_Form_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext ctx;

        public StudentController (StudentDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            try
            {
                var dts = ctx.StudentDetails.ToList();
                return Ok(dts);
            } catch (Exception ex)
            {
                return BadRequest("List Error Is : " + ex.Message);
            }
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]  Student dts)
        {
            try
            {
                ctx.StudentDetails.Add(dts);
                ctx.SaveChanges();
                return Ok("New Data Create Successfully !!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Create Error Is : " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var dts = ctx.StudentDetails.Find(id);
                return Ok(dts);
            } catch(Exception ex)
            {
                return BadRequest("GetById Error Is : " + ex.Message);
            }
        }

        [HttpPatch]
        [Route("Update")]
        public IActionResult Update([FromBody] Student dts)
        {
            try
            {
                ctx.StudentDetails.Update(dts);
                ctx.SaveChanges();
                return Ok("Update Successfully !!!");
            } catch (Exception ex)
            {
                return BadRequest("Update Error Is : " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var dts = ctx.StudentDetails.Find(id);
                ctx.StudentDetails.Remove(dts);
                ctx.SaveChanges();
                return Ok("Delete Successfully !!!");
            } catch(Exception ex)
            {
                return BadRequest("Delete Error Is : " + ex.Message);
            }
        }

    }
}
