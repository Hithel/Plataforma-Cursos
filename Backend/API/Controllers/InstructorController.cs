
using API.Dtos;
using API.Helpers.Paginacion;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
// [Authorize]

    public class InstructorController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public InstructorController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        _userService = userService;
        this.unitofwork = unitofwork;
        this.mapper = mapper;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InstructorDto>>> Get()
    {
        var entidad = await unitofwork.Instructor.GetAllAsync();
        return mapper.Map<List<InstructorDto>>(entidad);
    }


    // [HttpGet]
    // [MapToApiVersion("1.1")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<InstructorDto>>> GetPaginacion([FromQuery] Params usuarioParams)
    // {
    //     var entidad = await unitofwork.Instructor.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    //     var listEntidad = mapper.Map<List<InstructorDto>>(entidad.registros);
    //     return new Pager<InstructorDto>(listEntidad, entidad.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    // }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InstructorDto>> Get(int id)
    {
        var entidad = await unitofwork.Instructor.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<InstructorDto>(entidad);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Instructor>> Post(InstructorDto entidadDto)
    {
        var entidad = this.mapper.Map<Instructor>(entidadDto);
        this.unitofwork.Instructor.Add(entidad);
        await unitofwork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new { id = entidadDto.Id }, entidadDto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InstructorDto>> Put(int id, [FromBody] InstructorDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Instructor>(entidadDto);
        unitofwork.Instructor.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.Instructor.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Instructor.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    

}