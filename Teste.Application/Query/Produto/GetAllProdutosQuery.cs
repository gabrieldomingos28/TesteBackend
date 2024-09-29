
using MediatR;
using Teste.Domain.Domain;
using Teste.Domain.Interfaces.Repository;

namespace Teste.Application.Query.Produto
{
    public class GetAllProdutosQuery : IRequest<Response<IEnumerable<Domain.Entities.Produto>>>
    {
        public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, Response<IEnumerable<Domain.Entities.Produto>>>
        {
            private readonly IProdutoRespository _produtoRespository;
            private readonly IMediator _mediator;

            public GetAllProdutosQueryHandler(
                IProdutoRespository produtoRespository,
                IMediator mediator
            )
            {
                _produtoRespository = produtoRespository;
                _mediator = mediator;
            }

            public async Task<Response<IEnumerable<Domain.Entities.Produto>>> Handle(
                GetAllProdutosQuery query,
                CancellationToken cancellationToken
            )
            {
                try
                {


                    var produtos = await _produtoRespository.GetAllAsync();

                  

                    return new Response<IEnumerable<Domain.Entities.Produto>>()
                    {
                        Sucesso = true,
                        Data = produtos
                    };
                }
                catch (Exception ex)
                {

                    return new Response<IEnumerable<Domain.Entities.Produto>>()
                    {
                        Sucesso = false,
                        Data = null,
                        Mensagem = $"Erro ao buscar  o produto [Error] ==> {ex.Message}"
                    };
                }
            }
        }
    }
}
