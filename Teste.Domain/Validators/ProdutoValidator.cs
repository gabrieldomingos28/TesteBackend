using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entities;

namespace Teste.Domain.Validators
{
    public class ProdutoValidator: AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(_ => _.Nome).NotNull();
            RuleFor(_ => _.Sku).NotNull();
            RuleFor(_ => _.Preco).NotNull().GreaterThan(0);
        }
    }
}
