namespace RetrospectiveAPI.Model
{
    public class FeedbackItem
    {
        public string? Name { get; set; }

        public string? Summary { get; set; }

        public enum FeedbackType { positive, negative, idea, praise}

        public FeedbackType Feedback { get; set; }
    }
}
