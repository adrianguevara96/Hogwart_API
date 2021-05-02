using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hogwart_API.Data;
using Hogwart_API.Models;

namespace Hogwart_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly Hogwart_APIContext _context;

        public RequestsController(Hogwart_APIContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        /// <summary>
        /// Get all request.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        /// <summary>
        /// Get a specific request.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Edit a request.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Requests/{id}
        ///     {
        ///        "id": "1"
        ///        "name": "Student",
        ///        "lastname": "Two",
        ///        "identification": 123456789,
        ///        "age": 2,
        ///        "house": "Slytherin"
        ///     }
        ///
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {

            if (id != request.id)
            {
                return BadRequest();
            }

            if (request.house == "Gryffindor" || request.house == "Hufflepuff" || request.house == "Ravenclaw" || request.house == "Slytherin")
            {
                _context.Entry(request).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(request);
            }
            else
            {
                return BadRequest("{ 'errors':{ 'house':['Use 'Gryffindor', 'Hufflepuff', 'Ravenclaw' or 'Slytherin' only']}}");
            }
        }

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a request.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Requests
        ///     {
        ///        "name": "Student",
        ///        "lastname": "One",
        ///        "identification": 123456789,
        ///        "age": 1,
        ///        "house": "Gryffindor"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {

            if (request.house == "Gryffindor" || request.house == "Hufflepuff" || request.house == "Ravenclaw" || request.house == "Slytherin")
            {
                _context.Requests.Add(request);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRequest", new { id = request.id }, request);
            }
            else
            {
                return BadRequest("{ 'errors':{ 'house':['Use 'Gryffindor', 'Hufflepuff', 'Ravenclaw' or 'Slytherin' only']}}");
            }
        }

        // DELETE: api/Requests/5
        /// <summary>
        /// Deletes a specific request.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return Ok("Request Deleted");
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.id == id);
        }
    }
}
