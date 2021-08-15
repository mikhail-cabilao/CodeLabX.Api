using CodeLabX.Api.Services;
using CodeLabX.EntityFramework.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
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

        [EnableQuery()]
        public async Task<IEnumerable<Models.Dictionary>> Get(ODataQueryOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.SelectExpand?.RawExpand))
                return await _dictionaryService.GetDictionaries(options.SelectExpand.RawExpand);

            return await _dictionaryService.GetDictionaries();
        }

        [EnableQuery()]
        public async Task<IEnumerable<Models.Dictionary>> Get([FromODataUri] long key, ODataQueryOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.SelectExpand?.RawExpand))
                return (await _dictionaryService.GetDictionaries(options.SelectExpand.RawExpand)).ToList().Where(d => d.Id == key);

            return (await _dictionaryService.GetDictionaries()).ToList().Where(d => d.Id == key);
        }

        public async Task<bool> Post([FromBody] Models.Dictionary dictionary)
        {
            await _dictionaryService.Create(dictionary);

            return true;
        }

        public async Task<bool> Put([FromODataUri] long key, [FromBody] Models.Dictionary dictionary)
        {
            await _dictionaryService.Update(key, dictionary);

            return true;
        }
    }
}
