﻿using Base.DTOs.PRJ;
using PagingExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Params.Outputs
{
    public class PriceListPaging
    {
        public List<PriceListDTO> PriceLists { get; set; }
        public PageOutput PageOutput { get; set; }
    }
}