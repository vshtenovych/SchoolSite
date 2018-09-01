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
        [Description("Старший учитель")]
        Senior = 1,
        [Description("Вчитель методист")]
        Methodist = 2
    }
}
