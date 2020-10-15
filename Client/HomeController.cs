using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Client
{
    public class HomeController : Controller
    {
        private readonly Student.StudentClient _client;

        public HomeController(Student.StudentClient client)
        {
            _client = client;
        }

        // GET: /<controller>/
        [Route("home/index")]
        public async Task<IActionResult> Index()
        {
            var studentRequest = new StudentRequest { Id = "100" };
            StudentReply response = null;
            using (var service = _client.GetStudentInformationAsync(studentRequest))
            {
                response = await service;
            }

            return View();
        }
    }
}
