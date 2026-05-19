using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_7.DAL;
using Task_7.Models;

namespace Task_7.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCContoler : ControllerBase
{
    private MyDbContext _myDbContext;

    public PCContoler(MyDbContext dbContext)
    {
        this._myDbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetPCsAsync(CancellationToken cancellationToken)
    {
        var pcs = await _myDbContext.PCs.ToListAsync(cancellationToken);
        return Ok(pcs);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPCComponentsAsync(int id, CancellationToken cancellationToken)
    {
        var pcExists = await _myDbContext.PCs.AnyAsync(p => p.Id == id, cancellationToken);
        if (!pcExists) return NotFound($"PC does not exist");

        var components = await _myDbContext.PCComponents.Where(pc => pc.PCId == id).ToListAsync(cancellationToken);
        return Ok(components);

    }

    [HttpPost]
    public async Task<IActionResult> AddPCAsync([FromBody] PC newPC, CancellationToken cancellationToken)
    {
        try
        {
            await _myDbContext.PCs.AddAsync(newPC, cancellationToken);
            await _myDbContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }
        catch (Exception ex)
        {
            // incorrect or not full data provided 
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePCAsync(int id, [FromBody] PC updatedPC, CancellationToken cancellationToken)
    {
        var PC = await _myDbContext.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);

        if (PC == null)
        {
            return NotFound($"PC does not exist with provided id : {id}");
        }

        _myDbContext.Entry(PC).CurrentValues.SetValues(updatedPC);

        await _myDbContext.SaveChangesAsync(cancellationToken);


        return Ok(updatedPC);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePCAsync(int id, CancellationToken cancellationToken)
    {
        var PC = await _myDbContext.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);

        if (PC == null)
        {
            return NotFound($"Pc does not exists with provided id : {id}");
        }

        _myDbContext.PCs.Remove(PC);

        await _myDbContext.SaveChangesAsync(cancellationToken);


        return Ok(PC);
    }
}