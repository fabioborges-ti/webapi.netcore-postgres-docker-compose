using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Data.Dtos.Teachers;
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
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryTeachers _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public TeachersController(ILogger<TeachersController> logger, IMapper mapper, IRepositoryTeachers repository)
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

                var teachers = _mapper.Map<IEnumerable<TeacherDto>>(data);

                return Ok(teachers);
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

                var teacher = _mapper.Map<TeacherDto>(data);

                return Ok(teacher);
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
        [HttpGet("{id:guid}/students")]
        public async Task<IActionResult> GetStudentsByTeacherId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid Id");

            try
            {
                var teacher = await _repository.GetStudentsByTeacherId(id);

                return teacher == null ? NoContent() : Ok(teacher);
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
        [HttpGet("{id:guid}/disciplines")]
        public async Task<IActionResult> GetDisciplinesByTeacherId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid Id");

            try
            {
                var teacher = await _repository.GetDisciplinesByTeacherId(id);

                return teacher == null ? NoContent() : Ok(teacher);
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
        public async Task<IActionResult> Post(TeacherDtoCreate model)
        {
            if (string.IsNullOrWhiteSpace(model.Name)) return BadRequest();

            try
            {
                var teacher = _mapper.Map<Teacher>(model);

                await _repository.Add(teacher);

                return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
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
        public async Task<IActionResult> Put(Guid id, TeacherDtoUpdate model)
        {
            if (id == Guid.Empty) return BadRequest();

            if (id != model.Id) return BadRequest();

            try
            {
                var data = await _repository.GetById(id);

                if (data == null) return NoContent();

                var teacher = _mapper.Map<Teacher>(data);

                teacher.CreatedAt = data.CreatedAt;
                teacher.UpdatedAt = DateTime.UtcNow;

                await _repository.Update(teacher);

                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
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
