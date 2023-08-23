namespace Backend_Hotel_Management.Extensions;

public static class ApplicationServiceExtensions
{
    //Adds extra services to the program.cs allowing for a clearer declaration between app components
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors();
    }
}