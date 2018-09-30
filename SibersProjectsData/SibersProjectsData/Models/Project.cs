using System;
using System.ComponentModel.DataAnnotations;

namespace SibersProjectsData.Models
{
    // модель проекта
    public class Project
    {
        // id
        public int Id { get; set; }
        // название проекта
        public string ProjectName { get; set; }
        // название компании-заказчика
        public string CustomerName { get; set; }
        // название компании-исполнителя
        public string ImplementerName { get; set; }
        // руководитель проекта (внешний ключ)
        public int? ChiefId { get; set; }
        public Employee Chief { get; set; }
        // исполнитель проекта  (внешний ключ)
        public int? ImplementerId { get; set; }
        public Employee Implementer { get; set; }
        // дата начала проекта
        [Display(Name = "StartProjectDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? StartProjectDate { get; set; }
        // дата окончания проекта
        [Display(Name = "EndProjectDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? EndProjectDate { get; set; }
        // приоритет проекта
        public int Priority { get; set; }
        // текстовый комментарий
        public string Comment { get; set; }
    }
}