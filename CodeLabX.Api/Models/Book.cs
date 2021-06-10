using CodeLabX.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Models
{
    public class Book<T> where T: class
    {
        public Guid BookId { get; set; } = Guid.NewGuid();
        public string BookType { get; set; } = typeof(T).Name;
    }
}
