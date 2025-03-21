using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_for_66bit.Data.Models;

namespace task_for_66bit.Data.Repositories;

public class InternRepository
{
    private readonly AppDbContext _context;

    public InternRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Intern>> GetAllAsync()
    {
        return await _context.Interns
            .Include(i => i.Direction)
            .Include(i => i.Project)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Intern> GetByIdAsync(int id)
    {
        return await _context.Interns.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Intern intern)
    {
        await _context.Interns.AddAsync(intern);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Intern intern)
    {
        _context.Interns.Update(intern);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var intern = await _context.Interns
            .Include(i => i.Direction)
            .Include(i => i.Project)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (intern == null)
        {
            throw new InvalidOperationException("Intern not found");
        }

        _context.Interns.Remove(intern);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Interns.AnyAsync(i => i.Email == email);
    }
    
    public async Task<IEnumerable<Intern>> GetInternsByDirectionIdAsync(int directionId)
    {
        return await _context.Interns
            .Where(i => i.DirectionId == directionId)
            .Include(i => i.Direction)
            .Include(i => i.Project)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Intern>> GetInternsByProjectIdAsync(int projectId)
    {
        return await _context.Interns
            .Where(i => i.ProjectId == projectId)
            .Include(i => i.Direction)
            .Include(i => i.Project)
            .AsNoTracking()
            .ToListAsync();
    }
}