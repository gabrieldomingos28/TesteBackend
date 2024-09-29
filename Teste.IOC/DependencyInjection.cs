using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces.Repository;
using Teste.Domain.Validators;
using Teste.Repository.Infrastructure;
using Teste.Repository.Infrastructure.Context;

namespace Teste.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {

            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                  )
                );
             services.AddScoped<IProdutoRespository, ProdutoRepository>();
             services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }

        public static IServiceCollection AddValidators(
         this IServiceCollection services
        )
        {
            services.AddScoped<IValidator<Produto>, ProdutoValidator>();
            return services;
        }
    }
}
