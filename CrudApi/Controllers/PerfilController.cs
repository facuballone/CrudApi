using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAPI.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using CrudApi.DTOS;
using CrudApi.Entities;
namespace CrudApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PerfilController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<PerfilDTO>>> Get()  //aca para solo mostrar los datos que yo quiera y no todo lo de la base de datos. 
        {
            var listaDTO = new List<PerfilDTO>();
            var listaPerfil = await _context.Perfiles.ToListAsync();

            foreach (var item in listaPerfil)
            {
                listaDTO.Add(new PerfilDTO
                {
                    IdPerfil = item.IdPerfil,
                    Nombre = item.Nombre
                });
            }

            return Ok(listaDTO);
        }



    }
}
