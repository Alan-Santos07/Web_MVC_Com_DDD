using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCComDDD.Infra.Interfaces;
using WebMVCComDDD2.Data;
using WebMVCComDDD2.Domain.Entities;

namespace WebMVCComDDD.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProdutoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _applicationDbContext.Produtos.ToList();
        }

        public void Insert(Produto produto)
        {
            _applicationDbContext.Produtos.Add(produto);
            _applicationDbContext.SaveChangesAsync();
        }
    }
}
