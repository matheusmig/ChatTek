using ChatTek.Infrastructure.DataAccess;
using ChatTek.Infrastructure.DataAccess.Repositories;
using ChatTek.Infrastructure.Identity;
using ChatTek.UseCases.CreateConversation;
using ChatTek.UseCases.CreateParticipant;
using ChatTek.UseCases.GetAllParticipants;
using ChatTek.UseCases.RetrieveConversationByParticipantPaginated;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            // DI
            services.AddDbContext<ChattekDbContext>();
            services.AddScoped<IConversationsRepository, ConversationsRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IRetrieveConversationsByParticipantPaginatedUseCase, RetrieveConversationsByParticipantPaginatedUseCase>();
            services.AddTransient<ICreateConversationUseCase, CreateConversationUseCase>();
            services.AddTransient<ICreateParticipantUseCase, CreateParticipantUseCase>();
            services.AddTransient<IGetAllParticipantsUseCase, GetAllParticipantsUseCase>();
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
