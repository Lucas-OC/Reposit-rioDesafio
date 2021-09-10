using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Data;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;
using System.Text;
using System.Reflection.Metadata;
using System.Data.Common;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Reflection.PortableExecutable;
using System.Globalization;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{

    [Controller]
    [Route("[controller]")]

    public class PessoaController : ControllerBase
    {

        private DataContext dc;

        public PessoaController(DataContext context)
        {
            this.dc = context;
        }

        [HttpPost("api")]

        public async Task<ActionResult> create ([FromBody] Pessoa p)
        {

            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();

            return Created("objeto pessoa", p);

        } 

        [HttpGet("api")]

        public async Task<ActionResult> get()
        {

            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);

        }

        [HttpGet("api/{id}")]

        public Pessoa getbyid(int id)
        {

            Pessoa p = dc.pessoa.Find(id);
            return p;

        }

        [HttpPut("api")]

        public async Task<ActionResult> update([FromBody] Pessoa p)
        {

            dc.pessoa.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);

        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            Pessoa p = getbyid(id);

            if(p == null){
                return NotFound();
            }else{
                dc.pessoa.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }

        }

        [HttpGet("oi")]

        public string oi ()
        {
            return "Hello World";
        }

    }
}