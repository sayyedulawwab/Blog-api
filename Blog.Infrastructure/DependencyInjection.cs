using Blog.Application.Abstractions.Auth;
using Blog.Application.Abstractions.Clock;
using Blog.Domain.Posts;
using Blog.Domain.Users;
using Blog.Infrastructure.Auth;
using Blog.Infrastructure.Clock;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;

namespace Blog.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        AddPersistence(services, configuration);
        AddAuthentication(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var blogDatabase = configuration.GetSection("BlogDatabase") ?? throw new ArgumentNullException(nameof(configuration));

        services.Configure<MongoDatabaseOptions>(options =>
        {
            configuration.GetSection(nameof(MongoDatabaseOptions)).Bind(options);
        });

        services.AddSingleton(serviceProvider =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<MongoDatabaseOptions>>().Value;
            return new ApplicationDbContext(settings.ConnectionString, settings.DatabaseName);
        });

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        BsonSerializer.RegisterSerializer(new PostIdSerializer());
        BsonSerializer.RegisterSerializer(new UserIdSerializer());

    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.ConfigureOptions<JwtOptionsSetup>();

        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddSingleton<IJwtService, JwtService>();
        services.AddSingleton<IAuthService, AuthService>();
    }
}
