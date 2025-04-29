using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using subway_project.Server.Data;
using subway_project.Server.Models;
using subway_shared.DTOs.OrderDTOs;
using subway_shared.DTOs.ProductDTOs;
using subway_shared.DTOs.SubDTOs;

namespace subway_project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
{
    try
    {
        return await _context.Orders.Include(o => o.Products)
            .Include(o => o.Subs).ThenInclude(s => s.Products)
            .ToListAsync();
    }
    catch (Exception ex)
    {
        // Print detailed error to server console
        Console.WriteLine("Exception in GetOrders: " + ex.ToString());
        return StatusCode(500, "An internal error occurred. Check the server logs.");
    }
}




        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet("by-customer/{customerId}")]
        public async Task<ActionResult<Order>> GetOrderWithCustomerId(string customerId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(_=>_.CustomerId == customerId);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // PUT: /api/Orders/progress-order/7
        [HttpPut("progress-order/{id}")]
        public async Task<IActionResult> ProgressOrder(int id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
                
            existingOrder.OrderInProgress = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        
        // PUT: /api/Orders/complete-order/7
        [HttpPut("complete-order/{id}")]
        public async Task<IActionResult> CompleteOrder(int id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            
            existingOrder.OrderCompleted = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // PUT: /api/Orders/collect-order/7
        [HttpPut("collect-order/{id}")]
        public async Task<IActionResult> CollectedOrder(int id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.OrderCollected = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);

            foreach (var productDTO in orderDTO.Products)
            {
                var productToFind = await _context.Products.FirstOrDefaultAsync(_=>_.Name == productDTO.Name);
                if (productToFind != null) order.Products.Add(productToFind);
            }

            foreach (var sub in order.Subs)
            {
                foreach (var subDTO in orderDTO.Subs)
                {
                    foreach (var productDTO in subDTO.Products)
                    {
                        var existingProduct = await _context.Products.FirstOrDefaultAsync(_ => _.Name == productDTO.Name);
                        if (existingProduct != null) sub.Products.Add(existingProduct);
                    }
                    
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
