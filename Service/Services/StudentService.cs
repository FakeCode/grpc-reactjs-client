using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Service
{
    public class StudentService : Student.StudentBase
    {
        private readonly ILogger<StudentService> _logger;
        private readonly IDistributedCache _distributedCache;

        public StudentService(ILogger<StudentService> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public override async Task<StudentReply> GetStudentInformation(StudentRequest request, ServerCallContext context)
        {
            return await GetStudent(request.Id);
        }

        protected async Task<StudentReply> GetStudent(string id)
        {
            var cacheKey = id;
            string serializedReply = string.Empty;
            StudentReply reply;
            try
            {
                var msg = await _distributedCache.GetAsync(cacheKey);


                if (msg != null)
                {
                    serializedReply = Encoding.UTF8.GetString(msg);
                    reply = JsonConvert.DeserializeObject<StudentReply>(serializedReply);
                }
                else
                {
                    ////retrieve from api or database
                    reply = await Task.FromResult(new StudentReply
                    {
                        Message = "hello " + id
                    });
                    serializedReply = JsonConvert.SerializeObject(reply);
                    msg = Encoding.UTF8.GetBytes(serializedReply);

                    var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                        .SetAbsoluteExpiration(DateTime.Now.AddHours(1));
                    await _distributedCache.SetAsync(cacheKey, msg, options);
                }
            }
            catch(Exception ex)
            {
                reply = new StudentReply
                {
                    Message = "hello " + id
                };
            }

            return reply;
        }
    }
}

