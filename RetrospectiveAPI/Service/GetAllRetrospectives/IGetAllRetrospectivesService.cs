using RetrospectiveAPI.Model;

namespace RetrospectiveAPI.Service.GetAllRetrospectives
{
    public interface IGetAllRetrospectivesService
    {
        List<RetrospectiveStorageModel> GetAllRetrospectives();
    }
}
