using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [SetUp]
        public void SetUp()
        {
            // Arrange - Create mock object
            _mockMailSender = new Mock<IMailSender>();

            // Inject the mock object into CustomerComm
            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ShouldCallSendMail_WithCorrectParameters()
        {
            // Arrange - Set up mock behavior
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            // Act - Call the method under test
            bool result = _customerComm.SendMailToCustomer();

            // Assert - Verify the method was called with correct parameters
            _mockMailSender.Verify(x => x.SendMail("cust123@abc.com", "Some Message"), Times.Once);
            Assert.IsTrue(result);
        }

        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailSentSuccessfully()
        {
            // Arrange
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            // Act
            bool result = _customerComm.SendMailToCustomer();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SendMailToCustomer_ShouldCallSendMailOnce()
        {
            // Arrange
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            // Act
            _customerComm.SendMailToCustomer();

            // Assert - Verify SendMail was called exactly once
            _mockMailSender.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}