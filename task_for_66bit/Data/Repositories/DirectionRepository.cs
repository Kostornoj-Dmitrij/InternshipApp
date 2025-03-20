using task_for_66bit.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace task_for_66bit.Data.Repositories;

public class DirectionRepository
{
    private readonly AppDbContext _context;

    public DirectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Direction>> GetAllAsync()
    {
        return await _context.Directions.ToListAsync();
    }

    public async Task<Direction?> GetByIdAsync(int id)
    {
        return await _context.Directions.FindAsync(id);
    }

    public async Task AddAsync(Direction direction)
    {
        await _context.Directions.AddAsync(direction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Direction direction)
    {
        _context.Directions.Update(direction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var direction = await _context.Directions.FindAsync(id);
        if (direction != null)
        {
            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();
        }
    }
}