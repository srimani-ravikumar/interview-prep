using BackendMastery.CoreAPI.CRUDBasics.Database.Data;
using BackendMastery.CoreAPI.CRUDBasics.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendMastery.CoreAPI.CRUDBasics.Database.Repositories;

/// <summary>
/// EF Core based repository
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll() => _context.Products.AsNoTracking().ToList();

    public Product? GetById(Guid id) => _context.Products.Find(id);

    public void Add(Product product) => _context.Products.Add(product);

    public void Update(Product product) => _context.Products.Update(product);

    public void Delete(Product product) => _context.Products.Remove(product);

    public void SaveChanges() => _context.SaveChanges();
}