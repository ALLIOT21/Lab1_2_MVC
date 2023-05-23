using Lab1_2_MVC.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Lab1_2.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime IssueDate { get; set; }
        public string IssuePlace { get; set; }
    }
}
