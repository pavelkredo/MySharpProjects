using System.Collections.Generic;

namespace SibersProjectsData.Models
{
    // модель сотрудника
    public class Employee
    {
        // id
        public int Id { get; set; }
        // имя
        public string Name { get; set; }
        // фамилия
        public string Surname { get; set; }
        // отчество
        public string Patronymic { get; set; }
        // электронный адресс
        public string Email { get; set; }

        // ссылка на проекты
        public ICollection<Project> Projects { get; set; }
        public Employee()
        {
            Projects = new List<Project>();
        }
    }
}