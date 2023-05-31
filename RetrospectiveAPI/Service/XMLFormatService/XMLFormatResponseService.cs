using Microsoft.AspNetCore.Mvc;
using RetrospectiveAPI.Model;
using System.Xml.Linq;

namespace RetrospectiveAPI.Service.XMLFormatService
{
    public class XMLFormatResponseService : IXMLFormatResponseService
    {
        public IActionResult formatResponse(List<RetrospectiveStorageModel> retrospectives)
        {
            var xmlResponse = new XElement("response",
                from data in retrospectives
                select new XElement("Retrospective",
                    new XElement("Name", data.Name),
                    new XElement("Summary", data.Summary),
                    new XElement("Date", data.Date),
                    new XElement("Participants", from participant in data.Participants
                                                 select new XElement("Participant", participant)),
                    new XElement("FeedbackItems", from feedback in data.FeedbackItems
                                                  select new XElement("Feedback",
                                                  new XElement("Name", feedback.Name),
                                                  new XElement("Body", feedback.Summary),
                                                  new XElement("FeedbackType", feedback.Feedback)))));
            return new ContentResult
            {
                Content = xmlResponse.ToString(),
                ContentType = "application/xml",
                StatusCode = 200
            }; ;
        }
    }
}
