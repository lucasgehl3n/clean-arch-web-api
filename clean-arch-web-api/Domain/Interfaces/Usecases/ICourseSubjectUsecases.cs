using clean_arch_web_api.Domain.Structures;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces.Usecases
{
    public interface ICourseSubjectUsecases : IEntityUsecases<CourseSubject>
    {
        List<CourseSubjectRepresentation> GetAllSubjects(int idCourse);

        void ValidateDelete(CourseSubject entity);
    }
}
