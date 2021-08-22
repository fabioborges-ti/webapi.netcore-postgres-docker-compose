using Api.Data.Dtos.Disciplines;
using Api.Data.Dtos.Students;
using Api.Data.Dtos.Teachers;
using Api.Models;
using AutoMapper;

namespace Api.Configs
{
    public class ConfigureMappings : Profile
    {
        public ConfigureMappings()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentDtoCreate>().ReverseMap();
            CreateMap<Student, StudentDtoUpdate>().ReverseMap();

            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Teacher, TeacherDtoCreate>().ReverseMap();
            CreateMap<Teacher, TeacherDtoUpdate>().ReverseMap();

            CreateMap<Discipline, DisciplineDto>().ReverseMap();
            CreateMap<Discipline, DisciplineDtoCreate>().ReverseMap();
            CreateMap<Discipline, DisciplineDtoUpdate>().ReverseMap();
        }
    }
}
