using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Repositories;

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;

namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(_productRepository.GetAllProductAsync());

            }catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> getProductByID(int id)
        {
            var p = await _productRepository.GetProductByIdAsync(id);
            return p == null ? NotFound() : Ok(p);
        }
     
    
    }
}
