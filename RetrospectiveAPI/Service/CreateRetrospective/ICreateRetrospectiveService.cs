using RetrospectiveAPI.Model;

namespace RetrospectiveAPI.Service.CreateRetrospective
{
    public interface ICreateRetrospectiveService
    {
        void CreateNewRetrospective(CreateRetrospectiveRequestEntity createRetrospectiveRequestEntity);
    }
}
