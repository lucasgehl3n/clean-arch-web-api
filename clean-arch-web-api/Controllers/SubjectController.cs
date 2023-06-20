using Microsoft.AspNetCore.Mvc;
using CleanArch.Domain.Interfaces.Usecases;
using Microsoft.AspNetCore.Http;
using clean_arch_web_api.ViewModel;

namespace clean_arch_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController
    {
        private readonly ISubjectUsecases _subjectUsecases;
        public SubjectController(ISubjectUsecases subjectUsecases)
        {
            _subjectUsecases = subjectUsecases;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var result = new { result = _subjectUsecases.GetAll().ToList() };
            return new JsonResult(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = new { result = _subjectUsecases.Get(id) };
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Save(SubjectViewModel entity)
        {
            try
            {
                var subjectEntity = entity.ToEntity();
                _subjectUsecases.Save(subjectEntity);
                var result = new { success = true, result = new SubjectViewModel(subjectEntity) };
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new JsonResult(new { success = false, message = "Ocorreu um erro durante o salvamento dos dados" });
            }
        }
    }
}
