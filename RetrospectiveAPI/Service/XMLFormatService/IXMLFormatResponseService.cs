using Microsoft.AspNetCore.Mvc;
using RetrospectiveAPI.Model;

namespace RetrospectiveAPI.Service.XMLFormatService
{
    public interface IXMLFormatResponseService
    {
        IActionResult formatResponse(List<RetrospectiveStorageModel> retrospectives);
    }
}
