using System.ComponentModel.DataAnnotations;

namespace RetrospectiveAPI.Model
{
    public class RetrospectiveStorageModel
    {
        public string? Name { get; set; }

        public string? Summary { get; set; }

 
        public DateTime Date { get; set; }

     
        public List<string>? Participants { get; set; }

        public List<FeedbackItem> FeedbackItems { get; set; }

        public RetrospectiveStorageModel()
        {
            FeedbackItems = new List<FeedbackItem>();
        }
    }
}
