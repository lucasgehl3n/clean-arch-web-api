using clean_arch_web_api.Domain.Entities;
using clean_arch_web_api.Domain.Structures;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Usecases;

namespace clean_arch_web_api.Domain.Interfaces.Usecases
{
    public interface IStudentSubjectUsecases : IEntityUsecases<StudentSubject>
    {
        List<StudentSubjectRepresentation> GetAllSubjects(int idStudent);
        void ValidateDelete(StudentSubject entity);
    }
}
