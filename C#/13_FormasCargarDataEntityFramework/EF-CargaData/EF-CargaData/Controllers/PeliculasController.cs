using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_CargaData.Data;
using EF_CargaData.Entidades;
using AutoMapper;
using EF_CargaData.Entidades.DTO_s;

namespace EF_CargaData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly EF_CargaDataContext _context;
        private readonly IMapper _mapper;

        public PeliculasController(EF_CargaDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("eagerLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDto>> GetEagerLoading(int id)
        {
            //Carga toda la data principal y relacional con todos los campos
            var pelicula = await _context.Peliculas
                .Include(p => p.Generos)
                .Include(p => p.SalasDeCine)
                    .ThenInclude(s => s.Cine)
                .Include(p => p.PeliculasActores)
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);

            var peliculaDto = _mapper.Map<PeliculaDto>(pelicula);
            peliculaDto.Cines = peliculaDto.Cines.DistinctBy(x => x.Id).ToList();
            return peliculaDto;
        }

        [HttpGet("selectLoading/{id: int}")]
        public async Task<ActionResult> GetSelectLoading(int id)
        {
            //Carga toda la data principal y la relacional la trae filtrada solo por los campos que le indiquemos
            var pelicula = await _context.Peliculas.Select(p => new
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre).ToList(),
                PeliculasActores = p.PeliculasActores.Select(pa => new
                {
                    ActorId = pa.ActorId,
                    Personaje = pa.Personaje,
                    NombreActor = pa.Actor.Nombre
                }),
                CantidadCines = p.SalasDeCine.Select(s => s.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(p => p.Id == id);

            return Ok(pelicula);
        }

        [HttpGet("explicitLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDto>> GetExplicitLoading(int id)
        {
            //Carga las listas dentro del context "pelicula" cuando se lo indiquemos con LoadAsync
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(p => p.Id == id);

            await _context.Entry(pelicula).Collection(p => p.Generos).LoadAsync();
            //await _context.Entry(pelicula).Collection(p => p.SalasDeCine).LoadAsync();

            var cantidadGeneros = await _context.Entry(pelicula).Collection(p => p.Generos).Query().CountAsync();

            var peliculaDto = _mapper.Map<PeliculaDto>(pelicula);
            //return peliculaDto;

            return Ok(new
            {
                Pelicula = pelicula,
                CantidadGeneros = cantidadGeneros
            });
        }

        [HttpGet("lazyLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDto>> GetLazyLoading(int id)
        {
            //La data se carga al intentar acceder a la colección seleccionada, por ejemplo con AutoMapper se carg toda la data altiro, y esto genera muchas querys a la BD (poco eficiente)

            //Se deben hacer unas configuraciones a nivel global para que funcione

            // 1) instalar paquete NuGet >>> Microsoft.EntityFrameworkCore.Proxies
            // 2) agregar en Program.cs > en builder.Services.AddDbContext >>> options.UseLazyLoadingProxies();
            // 3) En cada una de las propiedades de la navegación se debe agregar "virtual" a todas las Listas o HashSet. Pelicula >>> public List<Genero> >>> public virtual List<Genero>

            var peliculas = await _context.Peliculas.ToListAsync();
            var peliculasDto = _mapper.Map<PeliculaDto>(peliculas);
            return peliculasDto;
        }
    }
}