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
    public class RepositoryTests
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
        public void TestReadCustomerList()
        {
            var logRepository = _lifetimeScope.Resolve<ICustomerRepository>();
            List<Models.Customer> list = logRepository.ReadCustomerList();
            Assert.AreEqual("TestFirstname", list[0].Firstname);
        }
        
        [Test]
        public void TestReadLogList()
        {
            var logRepository = _lifetimeScope.Resolve<ILogRepository>();
            List<VLogentries> list = logRepository.ReadLogList();
            Assert.AreEqual("TestMessage", list[0].Message);
        }
        
        [Test]
        public void TestReadAllLocationList()
        {
            var logRepository = _lifetimeScope.Resolve<ILocationRepository>();
            List<Location> list = logRepository.ReadAllLocationList();
            Assert.AreEqual("TestAddress", list[0].Address);
        }
        
        [Test]
        public void TestReadPodList()
        {
            var logRepository = _lifetimeScope.Resolve<IPodRepository>();
            List<Pod> list = logRepository.ReadPodList();
            Assert.AreEqual("TestDescription", list[0].Description);
        }
        
        [Test]
        public void TestReadSeverityList()
        {
            var logRepository = _lifetimeScope.Resolve<ISeverityRepository>();
            List<Severity> list = logRepository.ReadSeverityList();
            Assert.AreEqual("TestSeverity", list[0].Severity1);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _lifetimeScope.Dispose();
        }
        
    }
}