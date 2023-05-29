using RetrospectiveAPI.Model;
using RetrospectiveAPI.Repository;

namespace RetrospectiveAPI.Service.GetRetrospectivesByDate
{
    public class GetRetrospectivesByDateService : IGetRetrospectivesByDate
    {
        public List<RetrospectiveStorageModel> GetRetrospectives(DateTime date) 
        {
            return RetrospectiveStorageRepository.RetrospectiveStorage.Where(item => item.Date.Date == date.Date).ToList();

        }
    }
}
