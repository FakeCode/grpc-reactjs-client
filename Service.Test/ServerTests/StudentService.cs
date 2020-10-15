//using Grpc.Core;
//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace Service.Test.ServerTests
//{
//    public class StudentServiceTest
//    {
//        private readonly Server _server;
//        const string Host = "localhost";
//        const int Port = 5003;
//        public StudentServiceTest()
//        {
//            var loggerMock = new Mock<ILogger<StudentService>>();
//            // ILoggerFactory doesntDoMuch = new Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory();
//            var cache = new Mock<IDistributedCache>();
//            //cache.Setup(redis => redis.GetAsync(It.IsAny<string>())).Returns(null);
//            _server = new Server
//            {

//                Services = { Student.BindService(new StudentService(loggerMock.Object, cache.Object)) },
//                Ports = { { Host, Port, ServerCredentials.Insecure } }
//            };
//            _server.Start();

//            Console.WriteLine("MathServer listening on port " + Port);

//            Console.WriteLine("Press any key to stop the server...");
//            Console.ReadKey();

//            _server.ShutdownAsync().Wait();
//        }

//        [Fact]
//        public void GetStudentInformationTest()
//        {

//        }
//    }
//}
