using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Core.Models
{
    public class TextBlock
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Url { get; } = string.Empty;
        public DateTime AddedAt { get; } = DateTime.Now;
        public TimeOnly UrlLifeCycle { get; } = TimeOnly.MinValue;
    }
}
