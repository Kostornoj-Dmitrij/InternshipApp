using task_for_66bit.Data.Models;
using task_for_66bit.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task_for_66bit.Services;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;

    public ProjectService(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<(IEnumerable<Project> Projects, int TotalCount)> GetAllProjectsAsync(
        string search = null, 
        string sortBy = null, 
        bool sortAsc = true, 
        int page = 1, 
        int pageSize = 10)
    {
        return await _projectRepository.GetAllAsync(search, sortBy, sortAsc, page, pageSize);
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task AddProjectAsync(Project project)
    {
        await _projectRepository.AddAsync(project);
    }

    public async Task UpdateProjectAsync(Project project)
    {
        await _projectRepository.UpdateAsync(project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        await _projectRepository.DeleteAsync(id);
    }
}