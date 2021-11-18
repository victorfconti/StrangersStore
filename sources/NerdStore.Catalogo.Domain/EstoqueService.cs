using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.core;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private IMediatrHandler _bus;
        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            this._bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;
            
            produto.DebitarEstoque(quantidade);

            if (produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produtoId, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit(); 
        }

        public async Task<bool> reporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

    }
}