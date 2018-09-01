using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Enums
{
    public enum AdministrationPositionEnum
    {
        [Description("Не вибрано")]
        None = 0,
        [Description("Директор")]
        Director = 1,
        [Description("Заступник директора")]
        Assistant = 2
    }
}
