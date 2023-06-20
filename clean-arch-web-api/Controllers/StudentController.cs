using clean_arch_web_api.ViewModel;
using CleanArch.Domain.Interfaces.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace clean_arch_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController
    {
        private readonly IStudentUsecases _studentUsecases;
        public StudentController(IStudentUsecases studentUsecases)
        {
            _studentUsecases = studentUsecases;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var viewModelList = _studentUsecases.GetAll()?.Select(x => new StudentViewModel(x));
            var result = new { result = viewModelList };
            
            return new JsonResult(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = new { result = _studentUsecases.Get(id) };
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Save(StudentViewModel entity)
        {
            try
            {
                var studentEntity = entity.ToEntity();
                _studentUsecases.Save(studentEntity);
                var result = new { success = true, result = new StudentViewModel(studentEntity) };
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
                var courseSubject = _studentUsecases.Get(id);
                _studentUsecases.Delete(courseSubject);
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
