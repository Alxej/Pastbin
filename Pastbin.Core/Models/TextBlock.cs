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
        public string Metadata { get; } = string.Empty;
    }
}
