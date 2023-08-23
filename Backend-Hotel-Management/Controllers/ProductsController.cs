using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Hotel_Management.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
        [FromQuery] int pageIndex, 
        [FromQuery] int pageSize, 
        [FromQuery] List<string>? categoryNames)
    {
        try
        {
            var products = await _productRepository.GetAllProducts(pageIndex, pageSize, categoryNames);
            return Ok(products);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new ApplicationException(ex.Message);
        }
    }
    
    [HttpGet("id")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);

            if (product is null) return NotFound();

            return Ok(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(Product product)
    {
        try
        {
            await _productRepository.CreateProduct(product);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }
    

    [HttpPut]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
        try
        {
            var result = await _productRepository.UpdateProduct(product);
            if (result) return NoContent();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
        return BadRequest("Something went wrong when we tried to update the product");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        try
        {
            var result = await _productRepository.DeleteProduct(id);
            if (result) return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
        return BadRequest("Something went wrong when deleting the product");
    }
    
    
}