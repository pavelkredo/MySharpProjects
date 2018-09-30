using System;
using System.Data.Entity;

namespace SibersProjectsData.Models
{
    public class ProjectDbInitializer : DropCreateDatabaseAlways<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            // Задать стартовые данные работников
            context.Employees.Add(new Employee { Name = "Иван", Surname = "Ващенко", Patronymic = "Дмитриевич", Email = "ivan.vaschenko@mail.ru " });
            context.Employees.Add(new Employee { Name = "Дмитрий", Surname = "Четкасов", Patronymic = "Владимирович", Email = "chetkasov100@yandex.ru" });

            // Задать стартовые данные проектов
            context.Projects.Add(new Project
            {
                ProjectName = "Сервис-Тест",
                CustomerName = "Строительная компания",
                ImplementerName = "Сервис-Технолоджи",
                ChiefId = 1,
                ImplementerId = 2,
                StartProjectDate = new DateTime(2008, 8, 15),
                EndProjectDate = new DateTime(2009, 2, 10),
                Priority = 10,
                Comment = "Нет"
            });

            base.Seed(context);
        }
    }
}