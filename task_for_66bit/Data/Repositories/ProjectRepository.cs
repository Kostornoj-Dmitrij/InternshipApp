using task_for_66bit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace task_for_66bit.Data.Repositories;

public class ProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<Project> Projects, int TotalCount)> GetAllAsync(
        string search = null, 
        string sortBy = null, 
        bool sortAsc = true, 
        int page = 1, 
        int pageSize = 10)
    {
        var query = _context.Projects
            .Include(p => p.Interns)
            .AsNoTracking();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.Contains(search));
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            if (sortBy == "Name")
            {
                query = sortAsc ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
            }
            else if (sortBy == "InternsCount")
            {
                query = sortAsc ? query.OrderBy(p => p.Interns.Count) : query.OrderByDescending(p => p.Interns.Count);
            }
        }

        var totalCount = await query.CountAsync();
        var projects = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (projects, totalCount);
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.Interns)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Project project)
    {
        var existingProject = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == project.Id);

        if (existingProject != null)
        {
            existingProject.Name = project.Name;
            existingProject.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}