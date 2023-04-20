using Domain.Services;
using AutoMapper;
using Data.Repository;
using Domain.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CrossCuting.IoC
{
    public static class DependencyInjectionIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameHasUserRepository, GameHasUserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserHasCardsRepository, UserHasCardsRepository>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardHasAttributesRepository, CardHasAttributesRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IGameService, GameService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
