using EstacionamentoRhitmo.Interfaces;
using EstacionamentoRhitmo.Services;

namespace EstacionamentoRhitmo.ConfigureServices
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEstacionamentoService, EstacionamentoService>();
            services.AddControllers();
        }
    }
}