using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using subway_project.Server.Data;
using subway_project.Server.Models;
using subway_shared.DTOs.CategoryDTOs;
using subway_shared.DTOs.ProductDTOs;
using subway_shared.DTOs.SubCategoryDTO;

namespace subway_project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGetDTO>>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.SubCategory).ToListAsync();

            var productDTOs = products.Select(p => new ProductGetDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                SubCategoryId = p.SubCategoryId,
                ImageUrl = p.ImageUrl ?? "images\\no-image-available.jpg",
                Calories = p.Calories,
                Protein = p.Protein,
                Carbohydrates = p.Carbohydrates,
                Fat = p.Fat,
                Fiber = p.Fiber,
                Salt = p.Salt
            }).ToList();
            return Ok(productDTOs);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetDTO>> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.SubCategory).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            var productDTO = new ProductGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId,
                ImageUrl = product.ImageUrl,
                Calories = product.Calories,
                Protein = product.Protein,
                Carbohydrates = product.Carbohydrates,
                Fat = product.Fat,
                Fiber = product.Fiber,
                Salt = product.Salt
            };

            return productDTO;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductPostDTO productDTO)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.CategoryId = productDTO.CategoryId;
            product.SubCategoryId = productDTO.SubCategoryId;
            product.ImageUrl = productDTO.ImageUrl;
            product.Calories = productDTO.Calories;
            product.Protein = productDTO.Protein;
            product.Carbohydrates = productDTO.Carbohydrates;
            product.Fat = productDTO.Fat;
            product.Fiber = productDTO.Fiber;
            product.Salt = productDTO.Salt;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductPostDTO productDTO)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == productDTO.SubCategoryId);

            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            var product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId,
                SubCategoryId = productDTO.SubCategoryId,
                ImageUrl = productDTO.ImageUrl,
                Calories = productDTO.Calories,
                Protein = productDTO.Protein,
                Carbohydrates = productDTO.Carbohydrates,
                Fat = productDTO.Fat,
                Fiber = productDTO.Fiber,
                Salt = productDTO.Salt
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productGetDTO = new ProductGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId,
                ImageUrl = product.ImageUrl,
                Calories = product.Calories,
                Protein = product.Protein,
                Carbohydrates = product.Carbohydrates,
                Fat = product.Fat,
                Fiber = product.Fiber,
                Salt = product.Salt
            };

            return CreatedAtAction("GetProduct", new { id = product.Id }, productGetDTO);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
