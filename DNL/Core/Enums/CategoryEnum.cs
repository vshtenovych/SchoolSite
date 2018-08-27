using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Enums
{
    public enum CategoryEnum
    {
        [Description("Не вибрано")]
        None = 0,
        [Description("Спеціаліст")]
        Specialist = 1,
        [Description("Друга категорія")]
        SecondCategory = 2,
        [Description("Перша категорія")]
        FirstCategory = 3,
        [Description("Вища категорія")]
        HighestCategory = 4
    }
}
