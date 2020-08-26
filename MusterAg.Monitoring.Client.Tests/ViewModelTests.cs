using System.Collections.Generic;
using Autofac;
using MusterAg.Monitoring.Client.Config;
using MusterAg.Monitoring.Client.Customer;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;
using NUnit.Framework;

namespace MusterAg.Monitoring.Client.Tests
{
    [TestFixture]
    public class ViewModelTests
    {

        private IContainer _container;
        private ILifetimeScope _lifetimeScope;
        
        [SetUp]
        public void SetUp()
        {
            _container = ContainerConfig.BuildTestingAutofacContainer();
            _lifetimeScope = _container.BeginLifetimeScope();
        }
        
        [Test]
        public void TestFindDuplicates()
        {
            var logRepository = _lifetimeScope.Resolve<IMainViewModel>();
            string duplicates = logRepository.FindDuplicates();
            Assert.AreEqual("TestDuplicates", duplicates);
        }
        
        [Test]
        public void TestSearchKey()
        {
            var logRepository = _lifetimeScope.Resolve<ICustomerViewModel>();
            string searchKey = logRepository.SearchKey;
            Assert.AreEqual("TestSearchKey", searchKey);
        }
        
        [Test]
        public void TestCustomer()
        {
            var logRepository = _lifetimeScope.Resolve<ICustomerDetailViewModel>();
            Models.Customer customer = logRepository.Customer;
            Assert.AreEqual("TestFirstname", customer.Firstname);
        }
        
        [Test]
        public void TestLog()
        {
            var logRepository = _lifetimeScope.Resolve<ILogViewModel>();
            VLogentries log = logRepository.Log;
            Assert.AreEqual("TestMessage", log.Message);
        }
        
        [Test]
        public void TestLocTreeItem()
        {
            var logRepository = _lifetimeScope.Resolve<ILocationViewModel>();
            LocTreeNode locTreeItem = logRepository.LocTreeItem;
            Assert.AreEqual("TestAddress", locTreeItem.Source.Address);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _lifetimeScope.Dispose();
        }
        
    }
}