﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Base.DTOs.PRM
{
    public class MasterBookingPromotionItemSortByParam
    {
        public MasterBookingPromotionItemSortBy? SortBy { get; set; }
        public bool Ascending { get; set; }
    }

    public enum MasterBookingPromotionItemSortBy
    {
        NameTH,
        NameEN,
        Quantity,
        UnitTH,
        UnitEN,
        PricePerUnit,
        TotalPrice,
        ReceiveDays,
        WhenPromotionReceive,
        IsPurchasing,
        IsShowInContract,
        PromotionItemStatus,
        ExpireDate,
        PromotionMaterial_AgreementNo,
        PromotionMaterial_ItemNo,
        PromotionMaterial_NameTH,
        Updated,
        UpdatedBy
    }
}