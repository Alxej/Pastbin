﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pastbin.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Configurations
{
    public class TextBlockConfiguration : IEntityTypeConfiguration<TextBlockEntity>
    {
        public void Configure(EntityTypeBuilder<TextBlockEntity> builder)
        {

        }
    }
}
