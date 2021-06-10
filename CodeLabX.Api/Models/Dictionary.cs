using CodeLabX.EntityFramework;
using CodeLabX.EntityFramework.Attributes;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Models
{
    public class Dictionary : Book<Dictionary>, IEntityContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedData { get; set; }

        public string Name { get; set; }
        public string Definition { get; set; }

        [ForeignKey(nameof(DictionaryCategory))]
        public long CategoryId { get; set; }
        [AllowExpand]
        public DictionaryCategory Category { get; set; }
    }
}
