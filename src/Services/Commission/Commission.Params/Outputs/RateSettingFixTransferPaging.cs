﻿using System;
using System.Collections.Generic;
using Base.DTOs.CMS;
using PagingExtensions;

namespace Commission.Params.Outputs
{
    public class RateSettingFixTransferPaging
    {
        public List<RateSettingFixSaleTransferDTO> RateSettingFixTransfers { get; set; }
        public PageOutput PageOutput { get; set; }
    }
}