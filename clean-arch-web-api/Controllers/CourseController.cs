using CleanArch.Domain.Interfaces.Usecases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using clean_arch_web_api.ViewModel;
using CleanArch.Usecases;

namespace clean_arch_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseUsecases _courseUsecases;
        public CourseController(ICourseUsecases courseUsecases)
        {
            _courseUsecases = courseUsecases;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var result = new { result = _courseUsecases.GetAll().ToList() };
            return new JsonResult(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var entity = _courseUsecases.Get(id);
            var result = new { result = new { entity } };
            return new JsonResult(result);
        }


        [HttpPost]
        public IActionResult Save(CourseViewModel course)
        {
            try
            {
                var courseEntity = course.ToEntity();
                _courseUsecases.Save(courseEntity);
                var result = new { success = true, result = new CourseViewModel(courseEntity) };
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
                var courseSubject = _courseUsecases.Get(id);
                _courseUsecases.Delete(courseSubject);
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