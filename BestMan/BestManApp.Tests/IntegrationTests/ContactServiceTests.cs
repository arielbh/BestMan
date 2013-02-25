using System.Threading.Tasks;
using BestManApp.Services;
using Microsoft.Phone.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BestManApp.Tests.IntegrationTests
{
    [TestClass]
    public class ContactServiceTests : WorkItemTest
    {
        [TestMethod]
        public void TestDemo()
        {
            int a = 1;
            int b = 2;
            Assert.AreEqual(3, a + b);
        }

        [TestMethod]
        [Asynchronous]
        public async Task GetAllContacts_ReturnsContactsFromEmulator()
        {
            ContactService contactService = new ContactService();
            var result = await contactService.GetAllContacts();
            Assert.IsTrue(result.Length > 0);
            EnqueueTestComplete();   
        }
         
    }
}