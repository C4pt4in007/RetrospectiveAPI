using RetrospectiveAPI.Model;

namespace RetrospectiveAPI.Service.AddFeedback
{
    public interface IAddFeedbackService
    {
        void AddFeedback(string restrospectiveID, FeedbackItem feedbackItem);
    }
}
