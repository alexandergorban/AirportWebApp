using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Services;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.BusinessLayer.Validators;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Models;
using AirportWebAPI.DataAccessLayer.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AirportWebAPI
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

            // Add Data Source in Memory
            services.AddSingleton<DataSource>();

            services.AddTransient<IRepository<Airplane>, AirplaneRepository>();
            services.AddTransient<IRepository<AirplaneType>, AirplaneTypeRepository>();
            services.AddTransient<IRepository<Crew>, CrewRepository>();
            services.AddTransient<IRepository<Departure>, DepartureRepository>();
            services.AddTransient<IRepository<Flight>, FlightRepository>();
            services.AddTransient<IRepository<Pilot>, PilotRepository>();
            services.AddTransient<IRepository<Stewardess>, StewardessRepository>();
            services.AddTransient<IRepository<Ticket>, TicketRepository>();

            services.AddScoped<IService<AirplaneDto>, AirplaneService>();
            services.AddScoped<IService<AirplaneTypeDto>, AirplaneTypeService>();
            services.AddScoped<IService<CrewDto>, CrewService>();
            services.AddScoped<IService<DepartureDto>, DepartureService>();
            services.AddScoped<IService<FlightDto>, FlightService>();
            services.AddScoped<IService<PilotDto>, PilotService>();
            services.AddScoped<IService<StewardessDto>, StewardessService>();
            services.AddScoped<IService<TicketDto>, TicketService>();

            services.AddTransient<AbstractValidator<AirplaneDto>, AirplaneDtoValidator>();
            services.AddTransient<AbstractValidator<AirplaneTypeDto>, AirplaneTypeDtoValidator>();
            services.AddTransient<AbstractValidator<CrewDto>, CrewDtoValidator>();
            services.AddTransient<AbstractValidator<DepartureDto>, DepartureDtoValidator>();
            services.AddTransient<AbstractValidator<FlightDto>, FlightDtoValidator>();
            services.AddTransient<AbstractValidator<PilotDto>, PilotDtoValidator>();
            services.AddTransient<AbstractValidator<StewardessDto>, StewardessDtoValidator>();
            services.AddTransient<AbstractValidator<TicketDto>, TicketDtoValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
