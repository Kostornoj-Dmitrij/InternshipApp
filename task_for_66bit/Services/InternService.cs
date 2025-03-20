using task_for_66bit.Data.Models;
using task_for_66bit.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task_for_66bit.Services
{
    public class InternService
    {
        private readonly InternRepository _internRepository;

        public InternService(InternRepository internRepository)
        {
            _internRepository = internRepository;
        }

        public async Task<IEnumerable<Intern>> GetAllInternsAsync()
        {
            return await _internRepository.GetAllAsync();
        }

        public async Task<Intern> GetInternByIdAsync(int id)
        {
            return await _internRepository.GetByIdAsync(id);
        }

        public async Task AddInternAsync(Intern intern)
        {
            await _internRepository.AddAsync(intern);
        }

        public async Task UpdateInternAsync(Intern intern)
        {
            await _internRepository.UpdateAsync(intern);
        }

        public async Task DeleteInternAsync(int id)
        {
            await _internRepository.DeleteAsync(id);
        }
    }
}