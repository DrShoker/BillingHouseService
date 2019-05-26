using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.DTOL.Enums
{
    public enum TypeOfConstructionMaterialEnum
    {
        [Description("Concrete")]
        Concrete = 1,
        [Description("Drywall")]
        Drywall,
        [Description("Wallpaper")]
        Wallpaper,
        [Description("Paint")]
        Paint,
        [Description("Tile")]
        Tile,
        [Description("Brick")]
        Brick,
        [Description("Putty")]
        Putty,
        [Description("Plaster")]
        Plaster,
        [Description("Cement")]
        Cement,
        [Description("Primer")]
        Primer,
        [Description("Drywall adhesive")]
        Drywall_adhesive,
        [Description("Wallpaper glue")]
        Wallpaper_glue,
        [Description("Glue for foam plastic")]
        Foam_plastics_glue,
        [Description("Tile adhesive")]
        Tile_adhesive,
        [Description("Wood glue")]
        Wood_glue,
        [Description("Glue for linoleum")]
        Linoleum_glue,
        [Description("Liquid nails")]
        Liquid_nails,
        [Description("Linoleum")]
        Linoleum,
        [Description("Nails")]
        Nails,
        [Description("Self-tapping screws")]
        Self_tapping_screws,
        [Description("Baseboards")]
        Baseboards
    }
}
