using CodeLabX.Api.Services;
using CodeLabX.EntityFramework.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class DictionaryController : Controller
    {
        private readonly DictionaryService _dictionaryService;

        public DictionaryController(DictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<Models.Dictionary>> Get(ODataQueryOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.SelectExpand?.RawExpand))
                return await _dictionaryService.GetDictionaries(options.SelectExpand.RawExpand);

            return await _dictionaryService.GetDictionaries();
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<Models.Dictionary>> Get(int key)
        {
            var result = await _dictionaryService.GetDictionaries();
            return result.ToList();
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] Models.Dictionary dictionary)
        {
            await _dictionaryService.Create(dictionary);

            return true;
        }

        [HttpPut]
        public async Task<bool> Put(int id, [FromBody] Models.Dictionary dictionary)
        {
            await _dictionaryService.Update(dictionary);

            return true;
        }
    }
}
