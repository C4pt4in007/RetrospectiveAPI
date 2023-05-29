using RetrospectiveAPI.Model;
using RetrospectiveAPI.Repository;

namespace RetrospectiveAPI.Service.CreateRetrospective
{
    public class CreateRetrospectiveService : ICreateRetrospectiveService
    {
        
        public void CreateNewRetrospective(CreateRetrospectiveRequestEntity createRetrospectiveRequestEntity)
        {
            if (!(RetrospectiveStorageRepository.RetrospectiveStorage.Exists(item => item.Name == createRetrospectiveRequestEntity.Name))) 
            {
                RetrospectiveStorageModel retrospectiveStorageModel = new RetrospectiveStorageModel();
                retrospectiveStorageModel.Date = createRetrospectiveRequestEntity.Date;
                retrospectiveStorageModel.Summary = createRetrospectiveRequestEntity.Summary;
                retrospectiveStorageModel.Name = createRetrospectiveRequestEntity.Name;
                retrospectiveStorageModel.Participants = createRetrospectiveRequestEntity.Participants;
                RetrospectiveStorageRepository.RetrospectiveStorage.Add(retrospectiveStorageModel);
            }
            else
                throw new Exception("Retrospective already exists");
        }
    }
}
