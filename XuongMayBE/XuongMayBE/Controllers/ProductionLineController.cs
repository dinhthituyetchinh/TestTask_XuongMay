using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XuongMayBE.Data;
using XuongMayBE.Repositories;

namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLinesController : ControllerBase
    {
        private readonly IProductionLineRepository _productionLineRepository;
        private readonly ILogger<ProductionLinesController> _logger;

        public ProductionLinesController(IProductionLineRepository productionLineRepository, ILogger<ProductionLinesController> logger)
        {
            _productionLineRepository = productionLineRepository;
            _logger = logger;
        }

        // GET: api/ProductionLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionLineDTO>>> GetProductionLines()
        {
            try
            {
                var productionLines = await _productionLineRepository.GetAllAsync();
                var productionLineDTOs = productionLines.Select(pl => new ProductionLineDTO
                {
                    LineID = pl.LineID,
                    LineName = pl.LineName,
                    WorkerCount = pl.WorkerCount
                });
                return Ok(productionLineDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching production lines");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // GET: api/ProductionLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionLineDTO>> GetProductionLine(int id)
        {
            try
            {
                var productionLine = await _productionLineRepository.GetByIdAsync(id);
                if (productionLine == null)
                {
                    return NotFound();
                }

                var productionLineDTO = new ProductionLineDTO
                {
                    LineID = productionLine.LineID,
                    LineName = productionLine.LineName,
                    WorkerCount = productionLine.WorkerCount
                };

                return Ok(productionLineDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching production line with id {id}");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // POST: api/ProductionLines
        [HttpPost]
        public async Task<ActionResult<ProductionLineDTO>> CreateProductionLine(ProductionLineDTO productionLineDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productionLine = new ProductionLine
                {
                    LineName = productionLineDTO.LineName,
                    WorkerCount = productionLineDTO.WorkerCount
                };

                await _productionLineRepository.AddAsync(productionLine);

                productionLineDTO.LineID = productionLine.LineID;

                return CreatedAtAction(nameof(GetProductionLine), new { id = productionLine.LineID }, productionLineDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new production line");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // PUT: api/ProductionLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductionLine(int id, ProductionLineDTO productionLineDTO)
        {
            if (id != productionLineDTO.LineID)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingProductionLine = await _productionLineRepository.GetByIdAsync(id);
                if (existingProductionLine == null)
                {
                    return NotFound();
                }

                existingProductionLine.LineName = productionLineDTO.LineName;
                existingProductionLine.WorkerCount = productionLineDTO.WorkerCount;

                await _productionLineRepository.UpdateAsync(existingProductionLine);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating production line with id {id}");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // DELETE: api/ProductionLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionLine(int id)
        {
            try
            {
                var productionLine = await _productionLineRepository.GetByIdAsync(id);
                if (productionLine == null)
                {
                    return NotFound();
                }

                await _productionLineRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting production line with id {id}");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}