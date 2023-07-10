//using Microsoft.AspNetCore.Mvc;
//using Core.Models;
//using Services.Interfaces;

//namespace Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        public readonly IProductService _productService;
//        public ProductsController(IProductService productService)
//        {
//            _productService = productService;
//        }

//        /// <summary>
//        /// Get the list of product
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        public async Task<IActionResult> GetProductList()
//        {
//            var productDetailsList = await _productService.GetAllProducts();
//            if(productDetailsList == null)
//            {
//                return NotFound();
//            }
//            return Ok(productDetailsList);
//        }

//        /// <summary>
//        /// Get product by id
//        /// </summary>
//        /// <param name="Id"></param>
//        /// <returns></returns>
//        [HttpGet("{Id}")]
//        public async Task<IActionResult> GetProductById(int Id)
//        {
//            var productDetails = await _productService.GetProductById(Id);

//            if (productDetails != null)
//            {
//                return Ok(productDetails);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        /// <summary>
//        /// Add a new product
//        /// </summary>
//        /// <param name="productDetails"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task<IActionResult> CreateProduct(ProductDetails productDetails)
//        {
//            var isProductCreated = await _productService.CreateProduct(productDetails);

//            if (isProductCreated)
//            {
//                return Ok(isProductCreated);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        /// <summary>
//        /// Update the product
//        /// </summary>
//        /// <param name="productDetails"></param>
//        /// <returns></returns>
//        [HttpPut]
//        public async Task<IActionResult> UpdateProduct(ProductDetails productDetails)
//        {
//            if (productDetails != null)
//            {
//                var isProductCreated = await _productService.UpdateProduct(productDetails);
//                if (isProductCreated)
//                {
//                    return Ok(isProductCreated);
//                }
//                return BadRequest();
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        /// <summary>
//        /// Delete product by id
//        /// </summary>
//        /// <param name="Id"></param>
//        /// <returns></returns>
//        [HttpDelete("{Id}")]
//        public async Task<IActionResult> DeleteProduct(int Id)
//        {
//            var isProductCreated = await _productService.DeleteProduct(Id);

//            if (isProductCreated)
//            {
//                return Ok(isProductCreated);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }
//    }
//}
