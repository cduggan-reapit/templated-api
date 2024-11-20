using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reapit.Peepit.Keepit.Data.Context;
using Reapit.Peepit.Keepit.Data.Services;

namespace Reapit.Peepit.Keepit.Data;

[ExcludeFromCodeCoverage]
public static class Startup
{
    public static WebApplicationBuilder AddDataServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DemoDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
        
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return builder; 
    }
}
