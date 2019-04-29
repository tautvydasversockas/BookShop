using BookShop.Persistence;
using BookShop.Web.GraphQL;
using BookShop.Web.GraphQL.Messaging;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookShopDbContext>(options =>
               options.UseSqlServer(_configuration.GetConnectionString("BookShopDatabase")));

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<BookShopSchema>();
            services.AddSingleton<ReviewMessageService>();

            services
                .AddGraphQL(o => o.ExposeExceptions = true)
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(ctx => ctx.User)
                .AddDataLoader()
                .AddWebSockets();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, BookShopDbContext dbContext)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseWebSockets();
            app.UseGraphQLWebSockets<BookShopSchema>("/graphql");
            app.UseGraphQL<BookShopSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContext.SeedAsync().GetAwaiter().GetResult();
        }
    }
}
