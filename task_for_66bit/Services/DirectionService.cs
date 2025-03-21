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

    public async Task<IEnumerable<Direction>> GetAllDirectionsAsync()
    {
        return await _directionRepository.GetAllAsync();
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