using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Enums
{
    public enum RoleEnum
    {
        [Description("Не вибрано")]
        None = 0,
        [Description("Адміністратор")]
        Admin = 1,
        [Description("Вчитель")]
        Teacher = 2,
        [Description("Батьки")]
        Parents = 3,
        [Description("Учень")]
        Pupil = 4,
        [Description("Персонал")]
        Personal = 5
    }
}
