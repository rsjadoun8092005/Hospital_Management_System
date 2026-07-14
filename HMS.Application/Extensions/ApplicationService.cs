namespace HMS.Application.Extensions
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);

            services.AddValidatorsFromAssembly(assembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);

                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(Behaviour.ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
