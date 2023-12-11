

using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Asignatura,AsignaturaDto>().ReverseMap();
        CreateMap<Calificacion,CalificacionDto>().ReverseMap();
        CreateMap<Curso,CursoDto>().ReverseMap();
        CreateMap<Instructor,InstructorDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<Rol,RolDto>().ReverseMap();
        

    }
}