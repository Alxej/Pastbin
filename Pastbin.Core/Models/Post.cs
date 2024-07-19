using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Core.Models
{
    public class Post
    {
        public const int MAX_HEADER_LENGTH = 64;
        private Post(Guid id, string header, User? author, Image? image, TextBlock? text)
        {
            Id = id;
            Header = header;
            Author = author;
            Image = image;
            Text = text;
        }

        public Guid Id { get; }
        public string Header { get; } = string.Empty;
        public User? Author { get; } = null;

        public Image? Image { get; } = null;

        public TextBlock? Text { get; } = null;

        public static (Post Post, List<string> Errors)  Create(Guid id, string header, User? author, Image? image, TextBlock? text)
        {
            var errors = new List<string>();

            if (header.Length > MAX_HEADER_LENGTH)
                errors.Add("header length must be less than 65 symbols");

            return (new Post(id, header, author, image, text), errors);
        }
    }
}
