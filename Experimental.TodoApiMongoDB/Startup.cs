using Experimental.TodoApiMongoDB.Models;
using Experimental.TodoApiMongoDB.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Experimental.TodoApiMongoDB
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<BookstoreDatabaseSettings>(
        Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

      services.AddSingleton<IBookstoreDatabaseSettings>(sp => 
        sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

      services.AddSingleton<BookService>();

      services.Configure<TodoDatabaseSettings>(
        Configuration.GetSection(nameof(TodoDatabaseSettings)));

      services.AddSingleton<ITodoDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<TodoDatabaseSettings>>().Value);

      services.AddSingleton<TodoService>();

      services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
