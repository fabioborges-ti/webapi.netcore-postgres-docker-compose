using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Data.Dtos.Students;
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
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryStudents _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public StudentsController(ILogger<StudentsController> logger, IMapper mapper, IRepositoryStudents repository)
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

                var result = _mapper.Map<IEnumerable<StudentDto>>(data);

                return Ok(result);
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
                var student = await _repository.GetById(id);

                if (student == null) return NoContent();

                var result = _mapper.Map<StudentDto>(student);

                return Ok(result);
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
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Invalid Name");

            try
            {
                var data = await _repository.GetByName(name);

                if (data == null) return NoContent();

                var student = _mapper.Map<IEnumerable<StudentDto>>(data);

                return Ok(student);
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
        public async Task<IActionResult> GetDisciplines(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid Id");

            try
            {
                var student = await _repository.GetDisciplinesByStudentId(id);

                return student != null ? Ok(student) : NoContent();
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
        public async Task<IActionResult> Post(StudentDtoCreate model)
        {
            try
            {
                var student = _mapper.Map<Student>(model);

                await _repository.Add(student);

                return RedirectToAction("GetById", new { id = student.Id });
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
        public async Task<IActionResult> Put(Guid id, StudentDtoUpdate model)
        {
            if (id == Guid.Empty) return BadRequest();

            if (id != model.Id) return BadRequest();

            try
            {
                var data = await _repository.GetById(id);

                if (data == null) return NoContent();

                var student = _mapper.Map<Student>(data);

                student.CreatedAt = data.CreatedAt;
                student.UpdatedAt = DateTime.UtcNow;

                await _repository.Update(student);

                return Created($"/api/students/{model.Id}", _mapper.Map<StudentDto>(student));
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