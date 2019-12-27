﻿using System;
namespace Report.Integration.Reports.FI
{
    public class RP_FI_016
    {
        /// <summary>
        /// รายงานการส่ง Text File ให้ธนาคาร
        /// </summary>

        //param
        public string CompanyID { get; set; }
        public string ProductID { get; set; }
        public string UnitNumber { get; set; }
        public long? DateStart { get; set; }
        public long? DateEnd { get; set; }
        public string UserName { get; set; }
    }
}