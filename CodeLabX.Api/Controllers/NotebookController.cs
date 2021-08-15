using CodeLabX.Api.Models;
using CodeLabX.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class NotebookController : Controller
    {
        private readonly NotebookService notebookService;

        public NotebookController(NotebookService notebookService)
        {
            this.notebookService = notebookService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<Notebook>> Get(ODataQueryOptions dataQueryOptions)
        {
            return await notebookService.GetNotes();
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] string name)
        {
            await notebookService.AddAsync(name);

            return true;
        }
    }
}
