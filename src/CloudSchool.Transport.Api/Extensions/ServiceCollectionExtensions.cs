using CloudSchool.Transport.Data;
using CloudSchool.Transport.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSchool.Transport.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCloudSchoolTransport(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Data Layer
        // services.AddTransportData(configuration); // Assuming this exists or will be added later

        // Add Service Layer
        // services.AddTransportServices(); // Assuming this exists or will be added later
        
        // For now, just return services as we don't have the specifics of Data/Service layers yet
        // But we establish the pattern
        return services;
    }
}
