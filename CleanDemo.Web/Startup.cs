using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanDemo.Core;
using CleanDemo.Entities;
using CleanDemo.UseCases;
using CleanDemo.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDemo.Web
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
            services.AddMvc();
            services.AddScoped<AgendaContext>(s => new AgendaContext(new DbContextOptionsBuilder<AgendaContext>().UseInMemoryDatabase("Agenda").Options));
            services.AddTransient<CadastrarTurmaInteractor>();
            services.AddTransient<IRepository<Turma>, TurmaRepository>();
            services.AddTransient<IRepository<Professor>, ProfessorRepository>();
            services.AddTransient<IRepository<Curso>, CursoRepository>();
        }

        private static void AddTestData(AgendaContext agendaContext)
        {
            agendaContext.Professores.Add(new Professor { Nome = "Ericson Fonseca", EMail = "ericson.fonseca@opensourcebootcamp.org.br" });
            agendaContext.Professores.Add(new Professor { Nome = "Robson Araújo", EMail = "robson.araujo@opensourcebootcamp.org.br" });
            agendaContext.Professores.Add(new Professor { Nome = "Renato Groffe", EMail = "renato.groffe@opensourcebootcamp.org.br" });
            agendaContext.Professores.Add(new Professor { Nome = "Adriano Maringolo", EMail = "adriano.maringolo@opensourcebootcamp.org.br" });
            agendaContext.Cursos.Add(new Curso { Nome = "Quick Start: ASP.NET Core Fundamentals", CargaHorariaHoras = 4, Descricao = "Aprenda os primeiros passos do ASP.NET Core na prática!" });
            agendaContext.Cursos.Add(new Curso { Nome = "Quick Start: Entity Framework Core Fundamentals", CargaHorariaHoras = 4, Descricao = "Aprenda os primeiros passos do Entity Framework Core na prática!" });
            agendaContext.Cursos.Add(new Curso { Nome = "Quick Start: Azure Fundamentals", CargaHorariaHoras = 4, Descricao = "Aprenda os primeiros passos do Azure na prática!" });
            agendaContext.SaveChanges();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AgendaContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            AddTestData(dbContext);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
