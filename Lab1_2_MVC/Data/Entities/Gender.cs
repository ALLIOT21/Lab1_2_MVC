using System.ComponentModel;

namespace Lab1_2_MVC.Data.Entities
{
    public enum Gender
    {
        [Description("Мужской")]
        Male = 1,
        [Description("Женский")]
        Female = 2
    }
}
