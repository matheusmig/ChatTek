using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Identity;
using Application.UseCases.CreateConversation;
using Application.UseCases.CreateParticipant;
using Application.UseCases.GetAllParticipants;
using Application.UseCases.RetrieveConversationByParticipantPaginated;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Domain.Conversations;
using Domain.Participants;
using ChatTek.Modules;
using Application.Common;

namespace ChatTek
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatTek", Version = "v1" });
            });

            // DI Persistence
            services.AddDbContext<ChattekDbContext>();
            services.AddScoped<IConversationsRepository, ConversationsRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddTransient<IParticipantFactory, EntityFactory>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddInfrastructure()
                .AddUseCases();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatTek v1"));
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
