namespace YogaBackendAPI.Models
{
    public class YogaDatabaseSettings : IYogaDatabaseSettings
    {
        public string MessagesCollectionName { get; set; }
        public string MessagesCollectionNameTest { get; set; }
        public string VisitsCollectionName { get; set; }
        public string VisitsCollectionNameTest { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IYogaDatabaseSettings
    {
        string MessagesCollectionName { get; set; }
        string MessagesCollectionNameTest { get; set; }
        string VisitsCollectionName { get; set; }
        string VisitsCollectionNameTest { get; set; }
        string DatabaseName { get; set; }
    }
}