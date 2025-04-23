using AutoMapper;

namespace ToDoApp.Application.Mappers
{
    public static class ToDoItemMapper
    {
        public static class PersonMapper
        {
            private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    cfg.AddProfile<ToDoItemMappingProfile>();
                });
                var mapper = config.CreateMapper();
                return mapper;
            });

            public static IMapper Mapper => Lazy.Value;
        }
    }
}
