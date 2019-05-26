using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class ConstructionMaterialConfiguration : IEntityTypeConfiguration<ConstructionMaterial>
    {
        public void Configure(EntityTypeBuilder<ConstructionMaterial> builder)
        {

        }
    }
}
