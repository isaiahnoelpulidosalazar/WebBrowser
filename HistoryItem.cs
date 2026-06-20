namespace WebBrowser
{
    public class HistoryItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime VisitedTime { get; set; }

        public override string ToString()
        {
            return $"[{VisitedTime:HH:mm:ss}]  {Title}  ({Url})";
        }
    }
}
