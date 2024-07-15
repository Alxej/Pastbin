using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Entites
{
    public class TextBlockEntity
    {
        public Guid Id { get; set; }
        public string TextFileName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime AddedAt { get; set; } = DateTime.Now;
        public TimeOnly UrlLifeCycle { get; set; } = TimeOnly.MinValue;

        public PostEntity Post { get; set; }
    }
}
