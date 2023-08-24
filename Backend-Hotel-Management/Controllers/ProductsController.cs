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

    //Returns all products with pagination options or with specific
    //one or many categoryNames (pagination/categoryNames params can be ignored)
    //Test with missing params: http://localhost:14727/api/Products?pageIndex=0&pageSize=10&categoryNames= 
    //Test with params: http://localhost:14727/api/Products?pageIndex=0&pageSize=10&categoryNames=2&categoryNames=4
    //Test without params (returns everything): http://localhost:14727/api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
        [FromQuery] int pageIndex, 
        [FromQuery] int pageSize, 
        [FromQuery] List<string>? categoryNames)
    {
        try
        {
            var products = await _productRepository.GetProducts(pageIndex, pageSize, categoryNames);
            return Ok(products);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new ApplicationException(ex.Message);
        }
    }
    
    //Returns a specific product by id
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

    //Creates a new product
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
    
    //Updates a product or throws an exception with bad request
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

    //Deletes a product by id or throws an exception with bad request
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