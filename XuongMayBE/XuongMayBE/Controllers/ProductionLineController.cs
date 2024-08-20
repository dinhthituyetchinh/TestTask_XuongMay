using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;

[ApiController]
[Route("api/[controller]")]
public class ProductionLinesController : ControllerBase
{
    private readonly GarmentFactoryContext _context;

    public ProductionLinesController(GarmentFactoryContext context)
    {
        _context = context;
    }

    // GET: api/ProductionLines
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductionLine>>> GetProductionLines()
    {
        return await _context.ProductionLines.ToListAsync();
    }

    // GET: api/ProductionLines/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductionLine>> GetProductionLine(int id)
    {
        var productionLine = await _context.ProductionLines.FindAsync(id);

        if (productionLine == null)
        {
            return NotFound();
        }

        return productionLine;
    }

    // POST: api/ProductionLines
    [HttpPost]
    public async Task<ActionResult<ProductionLine>> PostProductionLine(ProductionLine productionLine)
    {
        _context.ProductionLines.Add(productionLine);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductionLine), new { id = productionLine.LineID }, productionLine);
    }

    // PUT: api/ProductionLines/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductionLine(int id, ProductionLine productionLine)
    {
        if (id != productionLine.LineID)
        {
            return BadRequest();
        }

        _context.Entry(productionLine).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductionLineExists(id))
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

    // DELETE: api/ProductionLines/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductionLine(int id)
    {
        var productionLine = await _context.ProductionLines.FindAsync(id);
        if (productionLine == null)
        {
            return NotFound();
        }

        _context.ProductionLines.Remove(productionLine);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductionLineExists(int id)
    {
        return _context.ProductionLines.Any(e => e.LineID == id);
    }
}