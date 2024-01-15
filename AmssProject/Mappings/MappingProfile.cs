using AutoMapper;
using AmssProject.Dto;
using AmssProject.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Grup, GrupDto>();

        CreateMap<CheltuieliCalatorie, CheltuialaDto>();

        CreateMap<Calatorie, CalatorieDto>();

    }
}
