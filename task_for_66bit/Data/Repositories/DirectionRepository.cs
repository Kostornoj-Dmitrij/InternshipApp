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

    public async Task<(IEnumerable<Direction> Directions, int TotalCount)> GetAllAsync(
        string search = null, 
        string sortBy = null, 
        bool sortAsc = true, 
        int page = 1, 
        int pageSize = 10)
    {
        var query = _context.Directions
            .Include(d => d.Interns)
            .AsNoTracking();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(d => d.Name.Contains(search));
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            if (sortBy == "Name")
            {
                query = sortAsc ? query.OrderBy(d => d.Name) : query.OrderByDescending(d => d.Name);
            }
            else if (sortBy == "InternsCount")
            {
                query = sortAsc ? query.OrderBy(d => d.Interns.Count) : query.OrderByDescending(d => d.Interns.Count);
            }
        }

        // Пагинация
        var totalCount = await query.CountAsync();
        var directions = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (directions, totalCount);
    }

    public async Task<Direction?> GetByIdAsync(int id)
    {
        return await _context.Directions
            .Include(d => d.Interns)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Direction direction)
    {
        await _context.Directions.AddAsync(direction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Direction direction)
    {
        var existingDirection = await _context.Directions
            .FirstOrDefaultAsync(d => d.Id == direction.Id);

        if (existingDirection != null)
        {
            existingDirection.Name = direction.Name;
            existingDirection.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
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