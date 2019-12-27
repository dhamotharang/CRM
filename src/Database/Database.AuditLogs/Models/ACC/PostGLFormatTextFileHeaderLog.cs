﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.AuditLogs.ACC
{
    [Description("ข้อมูลประวัติการแก้ไข PostGLFormatTextFileHeader")]
    [Table("PostGLFormatTextFileHeader", Schema = Schema.ACCOUNT)]
    public class PostGLFormatTextFileHeaderLog : BaseEntityLog
    {
    }
}