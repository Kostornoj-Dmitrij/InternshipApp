using task_for_66bit.Data.Models;
using task_for_66bit.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task_for_66bit.Services;

public class DirectionService
{
    private readonly DirectionRepository _directionRepository;

    public DirectionService(DirectionRepository directionRepository)
    {
        _directionRepository = directionRepository;
    }

    public async Task<(IEnumerable<Direction> Directions, int TotalCount)> GetAllDirectionsAsync(
        string search = null, 
        string sortBy = null, 
        bool sortAsc = true, 
        int page = 1, 
        int pageSize = 10)
    {
        return await _directionRepository.GetAllAsync(search, sortBy, sortAsc, page, pageSize);
    }

    public async Task<Direction?> GetDirectionByIdAsync(int id)
    {
        return await _directionRepository.GetByIdAsync(id);
    }

    public async Task AddDirectionAsync(Direction direction)
    {
        await _directionRepository.AddAsync(direction);
    }

    public async Task UpdateDirectionAsync(Direction direction)
    {
        await _directionRepository.UpdateAsync(direction);
    }

    public async Task DeleteDirectionAsync(int id)
    {
        await _directionRepository.DeleteAsync(id);
    }
}