using clean_arch_web_api.Domain.Exceptions;
using clean_arch_web_api.Domain.Interfaces.Usecases;
using clean_arch_web_api.ViewModel;
using CleanArch.Domain.Interfaces.Usecases;
using CleanArch.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace clean_arch_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentSubjectController
    {
        private readonly IStudentSubjectUsecases _studentSubjectUsecases;
        public StudentSubjectController(IStudentSubjectUsecases studentSubjectUsecases)
        {
            _studentSubjectUsecases = studentSubjectUsecases;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var result = new { result = _studentSubjectUsecases.GetAll().ToList() };
            return new JsonResult(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = new { result = _studentSubjectUsecases.Get(id) };
            return new JsonResult(result);
        }



        [HttpGet("/GetSubjectsStudent/{id}")]
        public IActionResult GetSubjectsStudent(int id)
        {
            var subjects = _studentSubjectUsecases.GetAllSubjects(id);
            var result = new { result = new { subjects } };
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Save(StudentSubjectViewModel entity)
        {
            try
            {
                var subjectEntity = entity.ToEntity();
                _studentSubjectUsecases.Save(subjectEntity);
                var result = new { success = true, result = new StudentSubjectViewModel(subjectEntity) };
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
                var studentSubject = _studentSubjectUsecases.Get(id);
                _studentSubjectUsecases.ValidateDelete(studentSubject);
                _studentSubjectUsecases.Delete(studentSubject);
                var result = new { success = true };
                return new JsonResult(result);
            }
            catch (BusinessRule ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new JsonResult(new { success = false, message = "Ocorreu um erro durante a exclusão da matrícula" });
            }
        }
    }
}
