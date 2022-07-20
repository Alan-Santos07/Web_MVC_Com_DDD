using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCComDDD.Application.Interfaces;
using WebMVCComDDD.Application.ViewModels;
using WebMVCComDDD.Infra.Interfaces;
using WebMVCComDDD2.Domain.Entities;

namespace WebMVCComDDD.Application.Applications
{
    public class ProdutoApplication : IProdutoApplication
    {
        IProdutoRepository _produtoRepository;

        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            var produtos = _produtoRepository.GetAll();
            var produtosViewModel = produtos.Select(produto => new ProdutoViewModel
            {
                Marca = produto.Marca,
                Nome = produto.Nome,
                Id = produto.Id,
            });
            return produtosViewModel;
        }

        public void Insert(ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto
            {
                Marca = produtoViewModel.Marca,
                Nome = produtoViewModel.Nome,
            };
            _produtoRepository.Insert(produto);
        }
    }
}
