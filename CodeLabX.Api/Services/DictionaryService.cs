using CodeLabX.EntityFramework.Extensions;
using CodeLabX.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
        }

        public async Task Update(Models.Dictionary dictinoary)
        {
            await _repository.UpdateAsync(dictinoary);
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
