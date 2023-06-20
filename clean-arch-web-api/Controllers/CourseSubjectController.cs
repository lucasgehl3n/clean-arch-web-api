using clean_arch_web_api.ViewModel;
using CleanArch.Domain.Interfaces.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace clean_arch_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseSubjectController
    {
        private readonly ICourseSubjectUsecases _courseSubjectUsecases;
        public CourseSubjectController(ICourseSubjectUsecases curriculumSubjectUsecases)
        {
            _courseSubjectUsecases = curriculumSubjectUsecases;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var result = new { result = _courseSubjectUsecases.GetAll() };
            return new JsonResult(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = new { result = _courseSubjectUsecases.Get(id) };
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Save(CourseSubjectViewModel entity)
        {
            try
            {
                var subjectEntity = entity.ToEntity();
                _courseSubjectUsecases.Save(subjectEntity);
                var result = new { success = true, result = new CourseSubjectViewModel(subjectEntity) };
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new JsonResult(new { success = false, message = "Ocorreu um erro durante o salvamento dos dados" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var courseSubject = _courseSubjectUsecases.Get(id);
                _courseSubjectUsecases.Delete(courseSubject);
                var result = new { success = true };
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new JsonResult(new { success = false, message = "Ocorreu um erro durante a exclusão da matrícula" });
            }
        }
    }
}
