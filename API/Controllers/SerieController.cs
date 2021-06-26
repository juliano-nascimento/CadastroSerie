
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly IRepositorio<Serie> _repositorio;
        private readonly ILogger<Serie> _logger;

        public SerieController(IRepositorio<Serie> repositorio, ILogger<Serie> logger)
        {
            _repositorio = repositorio;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _repositorio.Lista();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var result = _repositorio.RetornaPorId(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Serie serie)
        {
            try
            {
                _repositorio.Insere(serie);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);                
            }
        }

        [HttpPut]
        public IActionResult Put(int Id, Serie serie)
        {
            try
            {
                var result = _repositorio.RetornaPorId(Id);
                if (result == null) return NotFound();

                serie.Id = Id;
                _repositorio.Atualiza(serie);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                var serie = _repositorio.RetornaPorId(Id);
                if (serie == null) return NotFound();

                serie.Excluido = true;

                _repositorio.Atualiza(serie);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

    }
}
