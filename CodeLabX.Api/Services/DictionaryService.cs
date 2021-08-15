using CodeLabX.EntityFramework.Extensions;
using CodeLabX.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Services
{
    public class DictionaryService
    {
        private readonly IRepository _repository;

        public DictionaryService(IRepository repository) => _repository = repository;

        public async Task Create(Models.Dictionary dictinoary)
        {
            await _repository.AddAsync(dictinoary);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(long id, Models.Dictionary dictinoary)
        {
            var dic = await _repository.GetAsync<Models.Dictionary>();
            var result = await dictinoary.ResolveEntity(dic.ToList().FirstOrDefault(d => d.Id == id));
            await _repository.UpdateAsync(result);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Dictionary>> GetDictionaries()
        {
            return await _repository.GetAsync<Models.Dictionary>();
        }

        public async Task<IEnumerable<Models.Dictionary>> GetDictionaries(string expandProperties)
        {
            var list = await _repository.GetAsync<Models.Dictionary>();
            return list.Include(expandProperties.Split(','));
        }
    }
}
