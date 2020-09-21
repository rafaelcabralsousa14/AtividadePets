using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadPets.Context;
using AtividadPets.Domains;
using AtividadPets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtividadPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        ClinicaRepository repo = new ClinicaRepository();

        // GET: api/<PetsController>
        [HttpGet]
        public List<Clinica> Get()
        {
            return repo.ListarTodos();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public Clinica Get(int id)
        {
            return repo.BuscarPorID(id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public Clinica Post([FromBody] Clinica a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public Clinica Put(int id, [FromBody] Clinica a)
        {
            return repo.Alterar(id, a);
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
