using RetrospectiveAPI.Model;

namespace RetrospectiveAPI.Service.GetRetrospectivesByDate
{
    public interface IGetRetrospectivesByDate
    {
        List<RetrospectiveStorageModel> GetRetrospectives(DateTime date);
    }
}
