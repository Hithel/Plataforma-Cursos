

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

    public class CalificacionController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CalificacionController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        _userService = userService;
        this.unitofwork = unitofwork;
        this.mapper = mapper;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CalificacionDto>>> Get()
    {
        var entidad = await unitofwork.Calificaciones.GetAllAsync();
        return mapper.Map<List<CalificacionDto>>(entidad);
    }


    // [HttpGet]
    // [MapToApiVersion("1.1")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<CalificacionDto>>> GetPaginacion([FromQuery] Params usuarioParams)
    // {
    //     var entidad = await unitofwork.Calificaciones.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    //     var listEntidad = mapper.Map<List<CalificacionDto>>(entidad.registros);
    //     return new Pager<CalificacionDto>(listEntidad, entidad.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    // }

    

    [HttpGet("{IdUserFk}/{IdCursoFK}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CalificacionDto>> Get(int IdUserFk, int  IdCursoFK)
    {
        var entidad = await unitofwork.Calificaciones.GetByIdAsync(e => e.IdUserFk == IdUserFk && e.IdCursoFK == IdCursoFK);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<CalificacionDto>(entidad);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Calificacion>> Post(CalificacionDto entidadDto)
    {
        var entidad = this.mapper.Map<Calificacion>(entidadDto);
        this.unitofwork.Calificaciones.Add(entidad);
        await unitofwork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { IdUserFk = entidadDto.IdUserFk, IdCursoFK = entidadDto.IdCursoFK }, entidadDto);
    }


    [HttpPut("{IdUserFk}/{IdCursoFK}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CalificacionDto>> Put(int IdUserFk, int  IdCursoFK, [FromBody] CalificacionDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Calificacion>(entidadDto);
        unitofwork.Calificaciones.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{IdUserFk}/{IdCursoFK}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int IdUserFk, int  IdCursoFK)
    {
        var entidad = await unitofwork.Calificaciones.GetByIdAsync(e => e.IdUserFk == IdUserFk && e.IdCursoFK == IdCursoFK);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Calificaciones.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    

}