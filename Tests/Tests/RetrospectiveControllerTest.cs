#nullable disable
namespace Tests.Tests
{
    [TestFixture]
    public class RetrospectiveControllerTest
    {
        private Mock<IGetAllRetrospectivesService> _getallRetrospectivesServiceMock;
        private Mock<ICreateRetrospectiveService> _createRetrospectiveServiceMock;
        private Mock<IGetRetrospectivesByDate> _getRetrospectiveByDateMock;
        private Mock<IAddFeedbackService> _addFeedbackServiceMock;
        private RetrospectiveController _controller;

        [SetUp]
        public void Setup()
        {
            _getallRetrospectivesServiceMock = new Mock<IGetAllRetrospectivesService>();
            _createRetrospectiveServiceMock = new Mock<ICreateRetrospectiveService>();
            _getRetrospectiveByDateMock = new Mock<IGetRetrospectivesByDate>();
            _addFeedbackServiceMock = new Mock<IAddFeedbackService>();
            _controller = new RetrospectiveController(_createRetrospectiveServiceMock.Object, _getallRetrospectivesServiceMock.Object, _getRetrospectiveByDateMock.Object, _addFeedbackServiceMock.Object);
        }


        [Test]
        public void GetAllRetrospectivesWithZeroRetrospectives()
        {
            _getallRetrospectivesServiceMock.Setup(service => service.GetAllRetrospectives()).Returns(new List<RetrospectiveStorageModel>());
            IActionResult result = _controller.GetAllRetrospectives();
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetAllRetrospectivesWithOneRetrospective() 
        {
            List<RetrospectiveStorageModel> dummyRetrospectiveList = new List<RetrospectiveStorageModel> { new RetrospectiveStorageModel { Name = "Retrospective1", Date = DateTime.Now.Date, Summary = "Dummy Summary", Participants = new List<string> { "ParticipantOne", "ParticipantTwo" } } };
            _getallRetrospectivesServiceMock.Setup(service => service.GetAllRetrospectives()).Returns(dummyRetrospectiveList);
            IActionResult result = _controller.GetAllRetrospectives();
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void AddFeedbackToRetrospectiveTestWithException() 
        {
            _addFeedbackServiceMock.Setup(service => service.AddFeedback("Retrospective1", It.IsAny<FeedbackItem>())).Throws(new Exception("Unable To Add Feedback"));
            IActionResult result = _controller.AddFeedbackToRetrospective("Retrospective1", new FeedbackItem());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }

        [Test]
        public void AddFeedbackToRetrospectiveTest()
        {
            _addFeedbackServiceMock.Setup(service => service.AddFeedback("Retrospective1", It.IsAny<FeedbackItem>()));
            IActionResult result = _controller.AddFeedbackToRetrospective("Retrospective1", It.IsAny<FeedbackItem>());
            Assert.IsInstanceOf<OkResult>(result);
        }

    }
}
