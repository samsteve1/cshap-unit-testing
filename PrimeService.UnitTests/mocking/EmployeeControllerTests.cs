using Moq;
using NUnit.Framework;
using PrimeService.mocking;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{

    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _mockStorage;
        private EmployeeController _employeeController;
        [SetUp]
        public void SetUp()
        {
            _mockStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_mockStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployee()
        {
            _employeeController.DeleteEmployee(1);

            _mockStorage.Verify(s => s.DeleteEmployee(1));
        }
        [Test]
        public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
        {
           var result = _employeeController.DeleteEmployee(1);

           Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}