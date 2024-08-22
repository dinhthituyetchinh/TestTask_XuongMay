using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XuongMayBE.Data;
using XuongMayBE.Repositories;

[Route("api/[controller]")]
[ApiController]
public class ProductionLineController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProductionLineRepository _productionLineRepository;

    public ProductionLineController(IMapper mapper, IProductionLineRepository productionLineRepository)
    {
        _mapper = mapper;
        _productionLineRepository = productionLineRepository;
    }

    // GET: api/ProductionLine
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductionLineDTO>>> GetProductionLines()
    {
        var productionLines = await _productionLineRepository.GetAllAsync();
        var productionLineDTOs = _mapper.Map<IEnumerable<ProductionLineDTO>>(productionLines);
        return Ok(productionLineDTOs);
    }

    // POST: api/ProductionLine
    [HttpPost]
    public async Task<ActionResult<ProductionLineDTO>> CreateProductionLine(ProductionLineDTO productionLineDTO)
    {
        var productionLine = _mapper.Map<ProductionLine>(productionLineDTO);
        await _productionLineRepository.AddAsync(productionLine);
        return CreatedAtAction(nameof(GetProductionLines), new { id = productionLine.LineID }, productionLineDTO);
    }

    // PUT: api/ProductionLine/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductionLine(int id, ProductionLineDTO productionLineDTO)
    {
        if (id != productionLineDTO.LineID)
        {
            return BadRequest();
        }

        var productionLine = _mapper.Map<ProductionLine>(productionLineDTO);
        await _productionLineRepository.UpdateAsync(productionLine);

        return NoContent();
    }

    // DELETE: api/ProductionLine/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductionLine(int id)
    {
        await _productionLineRepository.DeleteAsync(id);
        return NoContent();
    }
}
