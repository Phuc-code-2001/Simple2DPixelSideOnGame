using DataLayer.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private AppDbContext _context;

        public RecordController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var dataset = _context.Records.OrderBy(record => record.SaveTime).ToList();
            return Ok(dataset);
        }

        [HttpPost]
        public IActionResult Post(Record record)
        {
            try
            {
                _context.Records.Add(record);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(record);
        }

        [HttpPut]
        public IActionResult Update(Record record)
        {
            try
            {
                _context.Records.Update(record);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(record);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Record record = _context.Records.Find(id);
                if(record == null)
                {
                    return BadRequest("Record not found");
                }

                _context.Records.Remove(record);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok("Delete record success at " + DateTime.Now.ToString("dd/MM, HH/mm/ss"));
        }

    }
}
