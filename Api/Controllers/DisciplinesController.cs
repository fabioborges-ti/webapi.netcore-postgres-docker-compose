using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Data.Dtos.Disciplines;
using Api.Data.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryDisciplines _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public DisciplinesController(ILogger<DisciplinesController> logger, IMapper mapper, IRepositoryDisciplines repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _repository.Get();

                if (data == null) return NoContent();

                var disciplines = _mapper.Map<IEnumerable<DisciplineDto>>(data);

                return Ok(disciplines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid Id");

            try
            {
                var data = await _repository.GetById(id);

                if (data == null) return NoContent();

                var discipline = _mapper.Map<DisciplineDto>(data);

                return Ok(discipline);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(DisciplineDtoCreate model)
        {
            try
            {
                var discipline = _mapper.Map<Discipline>(model);

                await _repository.Add(discipline);

                return RedirectToAction("GetById", new { id = discipline.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, DisciplineDtoUpdate model)
        {
            if (id == Guid.Empty) return BadRequest();

            if (id != model.Id) return BadRequest();

            try
            {
                var data = await _repository.GetById(id);

                if (data == null) return NoContent();

                var discipline = _mapper.Map<Discipline>(model);

                discipline.CreatedAt = data.CreatedAt;
                discipline.UpdatedAt = DateTime.UtcNow;

                await _repository.Update(discipline);

                return Created($"/api/disciplines/{model.Id}", _mapper.Map<DisciplineDto>(discipline));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            try
            {
                var data = await _repository.GetById(id);

                if (data == null) return NoContent();

                await _repository.Remove(data);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
