using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.API.Entities;
using Product.API.Repos.Interfaces;
using Shared.Dtos.Products;
using System.ComponentModel.DataAnnotations;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.GetProducts();

            var result = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var result = _mapper.Map<ProductDto>(product);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {

            var productOdl = await _repo.GetProductByNo(productDto.No);

            if (productOdl != null)
                return BadRequest($"Product No {productOdl.No} not exist !");

            var product = _mapper.Map<CatalogProduct>(productDto);
            await _repo.CreateProduct(product);
            await _repo.SaveChangesAsync();
            var result = _mapper.Map<ProductDto>(product);
            return Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateProduct([Required] long id, [FromBody] UpdateProductDto productDto)
        {
            var product = await _repo.GetProduct(id);

            if (product == null)
                return NotFound();

            var updateProduct = _mapper.Map(productDto, product);

            await _repo.UpdateProduct(updateProduct);
            await _repo.SaveChangesAsync();

            var result = _mapper.Map<ProductDto>(product);
            return Ok(result);
        }
        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateProduct([FromQuery] long id)
        {
            var product = await _repo.GetProduct(id);

            if (product == null)
                return NotFound();

            await _repo.DeleteAsync(product);

            await _repo.SaveChangesAsync();

            var result = _mapper.Map<ProductDto>(product);
            return Ok(result);
        }

        #endregion

        #region Additional Resources
        [HttpGet("{productNo}")]
        public async Task<IActionResult> UpdateProduct([Required] string productNo)
        {
            var product = await _repo.GetProductByNo(productNo);

            if (product == null)
                return NotFound();

            var result = _mapper.Map<ProductDto>(product);

            return Ok(result);
        }
        #endregion
    }
}
