using System;
using System.ComponentModel.DataAnnotations;

namespace SibersProjectsData.Models
{
    public class ProjectFilter
    {
        // Фильтр начала старта проекта
        [Display(Name = "StartProjectDateStart")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        // Фильтр конца старта проекта
        public DateTime? StartProjectDateStart { get; set; }
        [Display(Name = "StartProjectDateEnd")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        // Фильтр начала окончания проекта
        public DateTime? StartProjectDateEnd { get; set; }
        [Display(Name = "EndProjectDateStart")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        // Фильтр конца окончания проекта
        public DateTime? EndProjectDateStart { get; set; }
        [Display(Name = "EndProjectDateEnd")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? EndProjectDateEnd { get; set; }
        // Минимальный приоритет
        public int? PrioritiesMin { get; set; }
        // Максимальный приоритет
        public int? PrioritiesMax { get; set; }
    }
}