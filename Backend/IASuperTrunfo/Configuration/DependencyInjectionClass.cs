
using CrossCuting.IoC;

namespace Application.Configuration
{
    public static class DependencyInjectionClass
    {
        public static void AddDpendencyInjection(this IServiceCollection services)
        {
            DependencyInjectionIoC.RegisterServices(services);
        }
    }
}
