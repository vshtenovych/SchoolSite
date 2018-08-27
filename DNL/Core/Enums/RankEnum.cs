using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Enums
{
    public enum RankEnum
    {
        [Description("Не вибрано")]
        None = 0,
        [Description("Старший вчитель")]
        Senior = 1,
        [Description("Друга категорія")]
        SecondCategory = 2,
        [Description("Вчитель методист")]
        Methodist = 3
    }
}
