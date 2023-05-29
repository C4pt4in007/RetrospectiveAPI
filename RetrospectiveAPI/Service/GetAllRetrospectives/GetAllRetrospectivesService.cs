using RetrospectiveAPI.Model;
using RetrospectiveAPI.Repository;

namespace RetrospectiveAPI.Service.GetAllRetrospectives
{
    public class GetAllRetrospectivesService : IGetAllRetrospectivesService
    {
        public List<RetrospectiveStorageModel> GetAllRetrospectives() 
        {
            return RetrospectiveStorageRepository.RetrospectiveStorage;
        }
    }
}
