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
        [Description("Walls paint works")]
        Walls_Paint_work,
        [Description("Floor paint works")]
        Floor_Paint_work,
        [Description("Ceiling paint works")]
        Ceiling_Paint_work,
        [Description("Walls priming works")]
        Walls_Priming_works,
        [Description("Floor priming works")]
        Floor_Priming_works,
        [Description("Ceiling priming works")]
        Ceiling_Priming_works,
        [Description("Walls dismantling")]
        Walls_dismantling,
        [Description("Floor dismantling")]
        Floor_dismantling,
        [Description("Ceiling dismantling")]
        Ceiling_dismantling,
        [Description("Walls installation")]
        Walls_Installation,
        [Description("Floor installation")]
        Floor_Installation,
        [Description("Ceiling installation")]
        Ceiling_Installation,
        [Description("Walls spackling works")]
        Walls_Spackling_work,
        [Description("Floor spackling works")]
        Floor_Spackling_work
    }
}
