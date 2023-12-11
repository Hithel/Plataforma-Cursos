

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

    public class AsignaturaController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public AsignaturaController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        _userService = userService;
        this.unitofwork = unitofwork;
        this.mapper = mapper;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
    {
        var entidad = await unitofwork.Asignaturas.GetAllAsync();
        return mapper.Map<List<AsignaturaDto>>(entidad);
    }


    // [HttpGet]
    // [MapToApiVersion("1.1")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<AsignaturaDto>>> GetPaginacion([FromQuery] Params usuarioParams)
    // {
    //     var entidad = await unitofwork.Asignaturas.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    //     var listEntidad = mapper.Map<List<AsignaturaDto>>(entidad.registros);
    //     return new Pager<AsignaturaDto>(listEntidad, entidad.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    // }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AsignaturaDto>> Get(int id)
    {
        var entidad = await unitofwork.Asignaturas.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<AsignaturaDto>(entidad);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Asignatura>> Post(AsignaturaDto entidadDto)
    {
        var entidad = this.mapper.Map<Asignatura>(entidadDto);
        this.unitofwork.Asignaturas.Add(entidad);
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
    public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody] AsignaturaDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Asignatura>(entidadDto);
        unitofwork.Asignaturas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.Asignaturas.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Asignaturas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    

}