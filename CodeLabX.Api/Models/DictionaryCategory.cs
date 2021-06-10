using CodeLabX.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Models
{
    public class DictionaryCategory : EntityContext
    {
        public string Name { get; set; }
    }
}
