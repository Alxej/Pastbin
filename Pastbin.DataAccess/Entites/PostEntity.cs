using Pastbin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Entites
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public string Header { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public Guid ImageId { get; set; }
        public Guid TextBlockId { get; set; }
        public UserEntity Author { get; set; }

        public ImageEntity Image { get; set; }

        public TextBlockEntity Text { get; set; }
    }
}
