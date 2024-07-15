using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Entites
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime AddedAt { get; set; } = DateTime.Now;
        public TimeOnly UrlLifeCycle { get; set; } = TimeOnly.MinValue;

        public PostEntity Post { get; set; }
    }
}
