namespace SelfLearning.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // AutoMapper
        services.AddAutoMapper(typeof(Mappings.AutoMapperProfile));

        // Note: DbContext is registered in Program.cs with PostgreSQL
        // Repositories and Services can be added here when created

        return services;
    }
}

