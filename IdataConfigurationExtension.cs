using Idata.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Idata
{
    public static class IdataServiceProvider
    {
        public static WebApplicationBuilder? Boot(WebApplicationBuilder? builder)
        {
            builder.Services.AddDbContext<IdataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient, ServiceLifetime.Scoped);
            return builder;

        }
    }
}
