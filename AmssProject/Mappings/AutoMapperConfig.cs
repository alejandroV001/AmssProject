using AutoMapper;

public static class AutoMapperConfig
{
    private static IMapper _mapper;

    public static IMapper GetMapper()
    {
        if (_mapper == null)
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                // Add other profiles as needed
            }).CreateMapper();
        }

        return _mapper;
    }
}
