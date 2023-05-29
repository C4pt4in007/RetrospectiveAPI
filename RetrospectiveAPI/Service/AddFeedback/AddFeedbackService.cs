using RetrospectiveAPI.Model;
using RetrospectiveAPI.Repository;

namespace RetrospectiveAPI.Service.AddFeedback
{
    public class AddFeedbackService : IAddFeedbackService
    {
        public void AddFeedback(string restrospectiveID, FeedbackItem feedbackItem) 
        {
            if (RetrospectiveStorageRepository.RetrospectiveStorage.Exists(item => item.Name == restrospectiveID)) 
                RetrospectiveStorageRepository.RetrospectiveStorage.First(item => item.Name == restrospectiveID).FeedbackItems.Add(feedbackItem);
            
            else
                throw new Exception("Retrospective with entered name doesn't exist");

        }
    }
}
