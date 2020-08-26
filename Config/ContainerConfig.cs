using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Moq;
using MusterAg.Monitoring.Client.Customer;
using MusterAg.Monitoring.Client.Model;
using MusterAg.Monitoring.Client.Models;
using MusterAg.Monitoring.Client.Repository;
using MusterAg.Monitoring.Client.View;
using Location = MusterAg.Monitoring.Client.Models.Location;
using Pod = MusterAg.Monitoring.Client.Models.Pod;
using Severity = MusterAg.Monitoring.Client.Models.Severity;

namespace MusterAg.Monitoring.Client.Config
{
    public class ContainerConfig
    {

        public static IContainer BuildAutofacContainer() {
            var builder = new ContainerBuilder();
            
            // Windows
            builder.RegisterType<CustomerDetailWindow>().AsSelf();
            builder.RegisterType<CustomerWindow>().AsSelf();
            builder.RegisterType<LogWindow>().AsSelf();
            builder.RegisterType<LocationTreeWindow>().AsSelf();
            
            // ViewModels
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<CustomerViewModel>().As<ICustomerViewModel>();
            builder.RegisterType<CustomerDetailViewModel>().As<ICustomerDetailViewModel>();
            builder.RegisterType<LogViewModel>().As<ILogViewModel>();
            builder.RegisterType<LocationViewModel>().As<ILocationViewModel>();

            // Repositories
            builder.RegisterType<CustomerEFRepository>().As<ICustomerRepository>();
            builder.RegisterType<LogEFRepository>().As<ILogRepository>();
            builder.RegisterType<LocationEFRepository>().As<ILocationRepository>();
            builder.RegisterType<PodEFRepository>().As<IPodRepository>();
            builder.RegisterType<SeverityEFRepository>().As<ISeverityRepository>();
            
            return builder.Build();
        }
        public static IContainer BuildTestingAutofacContainer() {
            var builder = new ContainerBuilder();
            
            // ViewModels
            var mock = new Mock<IMainViewModel>();
            mock.Setup(l => l.FindDuplicates()).Returns("TestDuplicates");
            var mock2 = new Mock<ICustomerViewModel>();
            mock2.Setup(l => l.SearchKey).Returns("TestSearchKey");
            var mock3 = new Mock<ICustomerDetailViewModel>();
            mock3.Setup(l => l.Customer).Returns(new Models.Customer { Firstname = "TestFirstname" });
            var mock4 = new Mock<ILogViewModel>();
            mock4.Setup(l => l.Log).Returns(new VLogentries { Message = "TestMessage" });
            var mock5 = new Mock<ILocationViewModel>();
            mock5.Setup(l => l.LocTreeItem).Returns(new LocTreeNode { Source = new LocTree {Address = "TestAddress"} });
            
            // Repositories
            var mock6 = new Mock<ICustomerRepository>();
            mock6.Setup(l => l.ReadCustomerList()).Returns(new List<Models.Customer>{new Models.Customer { Firstname = "TestFirstname" }});
            var mock7 = new Mock<ILogRepository>();
            mock7.Setup(l => l.ReadLogList()).Returns(new List<VLogentries>{new VLogentries { Message = "TestMessage" }});
            var mock8 = new Mock<ILocationRepository>();
            mock8.Setup(l => l.ReadAllLocationList()).Returns(new List<Location>{new Location { Address = "TestAddress" }});
            var mock9 = new Mock<IPodRepository>();
            mock9.Setup(l => l.ReadPodList()).Returns(new List<Pod>{new Pod { Description = "TestDescription" }});
            var mock10 = new Mock<ISeverityRepository>();
            mock10.Setup(l => l.ReadSeverityList()).Returns(new List<Severity>{new Severity { Severity1 = "TestSeverity" }});
            
            builder.RegisterInstance(mock.Object).As<IMainViewModel>();
            builder.RegisterInstance(mock2.Object).As<ICustomerViewModel>();
            builder.RegisterInstance(mock3.Object).As<ICustomerDetailViewModel>();
            builder.RegisterInstance(mock4.Object).As<ILogViewModel>();
            builder.RegisterInstance(mock5.Object).As<ILocationViewModel>();
            builder.RegisterInstance(mock6.Object).As<ICustomerRepository>();
            builder.RegisterInstance(mock7.Object).As<ILogRepository>();
            builder.RegisterInstance(mock8.Object).As<ILocationRepository>();
            builder.RegisterInstance(mock9.Object).As<IPodRepository>();
            builder.RegisterInstance(mock10.Object).As<ISeverityRepository>();

            return builder.Build();
        }

    }
}