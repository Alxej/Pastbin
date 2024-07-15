using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Core.Models
{
    public class Image
    {
        private Image(Guid id, string imageName, string url, DateTime addedAt, TimeOnly urlLifeCycle) 
        { 
            Id = id;
            Name = imageName;
            Url = url;
            AddedAt = addedAt;
            UrlLifeCycle = urlLifeCycle;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Url { get; } = string.Empty;
        public DateTime AddedAt { get; } = DateTime.Now;
        public TimeOnly UrlLifeCycle { get; } = TimeOnly.MinValue;

        public (Image Image, List<string> Errors) Create(Guid id, string name, string url, DateTime addedAt, TimeOnly urlLifeCycle)
        {
            var errors = new List<string>();

            var bannedSymbols = new List<char>() {'\\', '/', ':', '?', '\"', '<', '>', '|'};

            if (bannedSymbols.Any(x => name.Contains(x)))
                errors.Append("image name contains banned symbols");

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                errors.Append("url is not valid");

            if (addedAt.CompareTo(DateTime.Now) > 0)
                errors.Append("added time if greater than now");

            var image = new Image(id, name, url, addedAt, urlLifeCycle);

            return (image, errors);
        }
    }
}
