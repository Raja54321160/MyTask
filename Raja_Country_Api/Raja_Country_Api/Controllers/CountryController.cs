using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raja_Country_Api.Models;

namespace Raja_Country_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryDbContext ctx;

        public CountryController(CountryDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [Route("GetCountry")]
        public IActionResult GetCountry()
        {
            try
            {
                var dts = ctx.CountryDetails.ToList();
                return Ok(dts);
            } catch(Exception ex)
            {
                return BadRequest($"GetCountry Error Is : {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetState")]
        public IActionResult GetState()
        {
            try
            {
                var dts = ctx.StateDetails.ToList();
                return Ok(dts);
            } catch(Exception ex)
            {
                return BadRequest($"GetState Error Is : {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetDistrict")]
        public IActionResult GetDistrict()
        {
            try
            {
                var dts = ctx.DistrictDetails.ToList();
                return Ok(dts);
            } catch(Exception ex)
            {
                return BadRequest($"GetDistrict Error Is : {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult LoacationAdd(Location dts)
        {
            try
            {
                ctx.LocationDetails.Add(dts);
                ctx.SaveChanges();
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest($"LoacationAdd Error Is : {ex.Message}");
            }
        }

        [HttpGet]
        [Route("List")]

        public IActionResult LocationList()
        {
            try
            {
                var dts = ctx.LocationDetails.ToList();
                return Ok(dts);
            } catch (Exception ex)
            {
                return BadRequest($"LocationList Error Is : {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int id)
        {
            try
            {
                var dts = ctx.LocationDetails.Find(id);
                return Ok(dts);

            }
            catch (Exception ex)
            {
                return BadRequest($"GetById Error Is : {ex.Message}");
            }
        }

        [HttpPatch]
        [Route("Update")]

        public IActionResult LocationUpdate(Location dts)
        {
            try
            {
                ctx.LocationDetails.Update(dts);
                ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"LocationUpdate Error Is : {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Del")]

        public IActionResult LocationDelete(int id)
        {
            try
            {
                var dts = ctx.LocationDetails.Find(id);
                ctx.LocationDetails.Remove(dts);
                ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"LocationDelete Error Is : {ex.Message}");
            }
        }
    } 
}
