using ElectronicsApplication.Data;
using ElectronicsApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsApplication.Services
{
    public class ElectronicServices
    {
        private readonly ElectronicDbContext _dbContext;

        public ElectronicServices(ElectronicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all electronic products asynchronously.
        /// </summary>
        /// <returns>A list of electronic products.</returns>
        public async Task<List<Electronics>> GetProductsAsync()
        {
            return await _dbContext.Electronics.ToListAsync();
        }

        /// <summary>
        /// Retrieves an electronic product by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the electronic product to retrieve.</param>
        /// <returns>The electronic product with the specified ID.</returns>
        public async Task<Electronics> GetProductByIdAsync(int id)
        {
            return await _dbContext.Electronics.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Adds a new electronic product asynchronously.
        /// </summary>
        /// <param name="product">The electronic product to add.</param>
        public async Task AddProductAsync(Electronics product)
        {
            _dbContext.Electronics.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing electronic product asynchronously.
        /// </summary>
        /// <param name="product">The electronic product to update.</param>
        public async Task UpdateProductAsync(Electronics product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an electronic product by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the electronic product to delete.</param>
        public async Task DeleteProductAsync(int id)
        {
            var product = await _dbContext.Electronics.FindAsync(id);
            if (product != null)
            {
                _dbContext.Electronics.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
