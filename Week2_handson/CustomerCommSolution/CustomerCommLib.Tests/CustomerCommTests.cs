using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSentSuccessfully()
        {
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);
            var result = customerComm.SendMailToCustomer();

            Assert.IsTrue(result);
            mockMailSender.Verify(sender => sender.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}
