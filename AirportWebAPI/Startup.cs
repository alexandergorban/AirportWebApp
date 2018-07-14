using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebAPI.BusinessLayer.Services;
using AirportWebAPI.BusinessLayer.Interfaces;
using AirportWebAPI.BusinessLayer.Validators;
using AirportWebAPI.DataAccessLayer.Data;
using AirportWebAPI.DataAccessLayer.Interfaces;
using AirportWebAPI.DataAccessLayer.Entities;
using AirportWebAPI.DataAccessLayer.Repositories;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<AirportDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AirportDBConnectionString")));

            // Add Data Source in Memory
            services.AddSingleton<DataSource>();

            services.AddTransient<IRepository<Airplane>, AirplaneRepository>();
            services.AddTransient<IRepository<AirplaneType>, AirplaneTypeRepository>();
            services.AddTransient<IRepository<Crew>, CrewRepository>();
            services.AddTransient<IRepository<Departure>, DepartureRepository>();
            services.AddTransient<IRepository<Flight>, FlightRepository>();
            services.AddTransient<IRepository<Pilot>, PilotRepository>();
            services.AddTransient<IRepository<Stewardess>, StewardessRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();

            services.AddScoped<IService<AirplaneDto>, AirplaneService>();
            services.AddScoped<IService<AirplaneTypeDto>, AirplaneTypeService>();
            services.AddScoped<IService<CrewDto>, CrewService>();
            services.AddScoped<IService<DepartureDto>, DepartureService>();
            services.AddScoped<IService<FlightDto>, FlightService>();
            services.AddScoped<IService<PilotDto>, PilotService>();
            services.AddScoped<IService<StewardessDto>, StewardessService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddTransient<AbstractValidator<AirplaneDto>, AirplaneDtoValidator>();
            services.AddTransient<AbstractValidator<AirplaneTypeDto>, AirplaneTypeDtoValidator>();
            services.AddTransient<AbstractValidator<CrewDto>, CrewDtoValidator>();
            services.AddTransient<AbstractValidator<DepartureDto>, DepartureDtoValidator>();
            services.AddTransient<AbstractValidator<FlightDto>, FlightDtoValidator>();
            services.AddTransient<AbstractValidator<PilotDto>, PilotDtoValidator>();
            services.AddTransient<AbstractValidator<StewardessDto>, StewardessDtoValidator>();
            services.AddTransient<AbstractValidator<TicketDto>, TicketDtoValidator>();

            var mapper = MapperConfiguration().CreateMapper();
            services.AddTransient(_ => mapper);
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

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Airplane, AirplaneDto>();
                cfg.CreateMap<AirplaneDto, Airplane>();
                cfg.CreateMap<Airplane, Airplane>();

                cfg.CreateMap<AirplaneType, AirplaneTypeDto>();
                cfg.CreateMap<AirplaneTypeDto, AirplaneType>();
                cfg.CreateMap<AirplaneType, AirplaneType>();

                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<CrewDto, Crew>();
                cfg.CreateMap<Crew, Crew>();

                cfg.CreateMap<Departure, DepartureDto>();
                cfg.CreateMap<DepartureDto, Departure>();
                cfg.CreateMap<Departure, Departure>();

                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<FlightDto, Flight>();
                cfg.CreateMap<Flight, Flight>();

                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<PilotDto, Pilot>();
                cfg.CreateMap<Pilot, Pilot>();

                cfg.CreateMap<Stewardess, StewardessDto>();
                cfg.CreateMap<StewardessDto, Stewardess>();
                cfg.CreateMap<Stewardess, Stewardess>();

                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<TicketDto, Ticket>();
                cfg.CreateMap<Ticket, Ticket>();
            });

            return config;
        }
    }
}
