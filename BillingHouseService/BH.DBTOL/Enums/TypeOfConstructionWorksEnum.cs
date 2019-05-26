using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.DTOL.Enums
{
    public enum TypeOfConstructionWorksEnum
    {
        [Description("Plastering")]
        Plastering = 1,
        [Description("Paint works")]
        Paint_work,
        [Description("Priming works")]
        Priming_works,
        [Description("Dismantling")]
        Dismantling,
        [Description("Installation")]
        Installation,
        [Description("Spackling works")]
        Spackling_work
    }
}
