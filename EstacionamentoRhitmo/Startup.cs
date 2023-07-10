using EstacionamentoRhitmo.Interfaces;
using EstacionamentoRhitmo.Services;

namespace EstacionamentoRhitmo
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
