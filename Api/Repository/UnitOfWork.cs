using Api.Data;
using API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMSDbContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        private IGenericRepository<Store> _store;
        private IGenericRepository<Product> _product;

        public UnitOfWork(CMSDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);
        public IGenericRepository<Store> Stores => _store ??= new GenericRepository<Store>(_context);
        public IGenericRepository<Product> Products => _product ??= new GenericRepository<Product>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
