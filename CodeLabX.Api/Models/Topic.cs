using CodeLabX.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Models
{
    public class Topic : EntityContext
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
