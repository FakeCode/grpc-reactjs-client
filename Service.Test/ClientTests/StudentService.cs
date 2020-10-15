using System;
using Grpc.Core;
using Grpc.Core.Testing;
using Xunit;
using Grpc.Core.Utils;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Grpc.Net.Client;

namespace Service.Test
{
    /// <summary>
    /// Client testing
    /// </summary>
    public class StudentServiceClientTest : IDisposable
    {
        const string URL = "http://localhost/grpc";
        readonly GrpcChannel _channel;
        readonly Student.StudentClient _client;
        /// we may create server testing where it will start server auto and start testing
        /// Client will only consume running test
        public StudentServiceClientTest()
        {
            _channel = GrpcChannel.ForAddress(URL);
            _client = new Student.StudentClient(_channel);
        }

        public void Dispose()
        {
            _channel.ShutdownAsync().Wait();
        }

        [Fact, Trait("Category", "ClientTesting")]
        public void TestGetStudentInformation()
        {
            var expectedMessage = "hello 555";
            StudentReply response = _client.GetStudentInformation(new StudentRequest { Id = "555" });
            Assert.True(expectedMessage == response.Message);
        }

        [Fact]
        public void MocTesting()
        {
            var mockClient = new Moq.Mock<Student.StudentClient>();
            // Use a factory method provided by Grpc.Core.Testing.TestCalls to create an instance of a call.
            var fakeCall = TestCalls.AsyncUnaryCall<StudentReply>(Task.FromResult(new StudentReply()), Task.FromResult(new Metadata()), () => Status.DefaultSuccess, () => new Metadata(), () => { });
            mockClient.Setup(m => m.GetStudentInformationAsync(Moq.It.IsAny<StudentRequest>(), null, null, CancellationToken.None)).Returns(fakeCall);
            var test = mockClient.Object.GetStudentInformation(new StudentRequest());
            Assert.Same(fakeCall, mockClient.Object.GetStudentInformation(new StudentRequest()));
        }
    }
}
