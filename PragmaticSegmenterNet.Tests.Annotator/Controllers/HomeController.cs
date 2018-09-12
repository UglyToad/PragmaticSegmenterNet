namespace PragmaticSegmenterNet.Tests.Annotator.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models;

    public class HomeController : Controller
    {
        private readonly IOptions<ServiceSettings> settings;

        public HomeController(IOptions<ServiceSettings> settings)
        {
            this.settings = settings;
        }

        public IActionResult Index()
        {
            var data = TestDataRepository.GetExistingTests(settings.Value.FileLocation);
            var vm = new IndexViewModel
            {
                ExistingTests = data.ToList()
            };

            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public IActionResult Save(string text, string[] sentences)
        {
            TestDataRepository.SaveNewTest(settings.Value.FileLocation, text, sentences);
            return Ok("saved");
        }

        public IActionResult Generate(string text)
        {
            var result = Segmenter.Segment(text);

            return Ok(result);
        }
    }
}