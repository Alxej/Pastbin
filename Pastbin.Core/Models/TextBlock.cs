namespace Pastbin.Core.Models
{
    public class TextBlock
    {
        private TextBlock(Guid id, string textFileName, string url, DateTime addedAt, TimeOnly urlLiveCycle) 
        { 
            Id = id;
            TextFileName = textFileName;
            Url = url;
            AddedAt = addedAt;
            UrlLifeCycle = urlLiveCycle;
        }

        public Guid Id { get; }
        public string TextFileName = string.Empty;
        public string Url { get; } = string.Empty;
        public DateTime AddedAt { get; } = DateTime.Now;
        public TimeOnly UrlLifeCycle { get; } = TimeOnly.MinValue;

        public static (TextBlock TextBlock, List<string> Errors) Create(Guid id, string textFileName, string url, DateTime addedAt, TimeOnly urlLifeCycle)
        {
            var errors = new List<string>();

            var bannedSymbols = new List<char>() { '\\', '/', ':', '?', '\"', '<', '>', '|' };

            if (bannedSymbols.Any(x => textFileName.Contains(x)))
                errors.Add("text file name contains banned symbols");

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                errors.Add("url is not valid");

            if (addedAt.CompareTo(DateTime.Now) > 0)
                errors.Add("added time if greater than now");

            var TextBlock = new TextBlock(id, textFileName, url, addedAt, urlLifeCycle);

            return (TextBlock, errors);
        }
    }
}
