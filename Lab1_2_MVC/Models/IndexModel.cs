using Lab1_2.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_2_MVC.Models
{
    public class IndexModel
    {
        public List<Person> Persons { get; set; }

        [BindProperty]
        public Person Person { get; set; }
    }
}
