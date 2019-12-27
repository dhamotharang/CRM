﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMReport.Extensions;
using System.IO;
using CRMReport.Reports.LC;
using Newtonsoft.Json;

namespace CRMReport.Reports.LC
{
    public partial class SaleReport_Week1 : System.Web.UI.Page
    {
        //Parameter
        LCParams LCP = new LCParams();
        DBConnection connection = new DBConnection();
        ReportDocument crystalReport = new ReportDocument();
        SharedMethod SM = new SharedMethod();

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dtAdapter = new SqlDataAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Default Value
            LCP.dbConnection = connection.dbConnection;
            LCP.dbUsername = connection.dbUsername;
            LCP.dbPassword = connection.dbPassword;
            con.ConnectionString = LCP.dbConnection;

            //Parameter 
            LCP.token = Request.QueryString["token"];
            LCP.param = Request.QueryString["params"];
            LCP.downloadAs = Request.QueryString["DownloadAs"];
            
            if (LCP.downloadAs == null)
            {
                LCP.downloadAs = string.Empty;
            }

            try
            {
                LCP.reportName = "SaleReport_Week";

                //Check for authorization
                var isAuthorized = SM.checkForAuthorization(LCP.token, LCP.reportName);
                LCP.fullReportPath = "/Reports/LC/" + LCP.reportName + ".rpt";

                string reportPath = SM.reportPath(LCP.fullReportPath);
                crystalReport.Load(reportPath);

                //Check for params
                //LCP.ProductID = Request.QueryString["ProductID"] != null ? Request.QueryString["ProductID"] : "";
                //LCP.HomeType = Request.QueryString["HomeType"] != null ? Request.QueryString["HomeType"] : "";
                //LCP.UserName = Request.QueryString["UserName"] != null ? Request.QueryString["UserName"] : "";
                //LCP.Year = Request.QueryString["Year"] != null ? Request.QueryString["Year"] : "";
                //LCP.WeekStart = Request.QueryString["WeekStart"] != null ? Request.QueryString["WeekStart"] : "";
                //LCP.WeekEnd = Request.QueryString["WeekEnd"] != null ? Request.QueryString["WeekEnd"] : "";

                var paramDicts = SM.checkForParams(LCP.param);
                LCParams jsonParam = JsonConvert.DeserializeObject<LCParams>(paramDicts);

                if (jsonParam != null)
                {
                    LCP.ProductID = jsonParam.ProductID;
                    LCP.HomeType = jsonParam.HomeType;
                    LCP.UserName = jsonParam.UserName;
                    LCP.Year = jsonParam.Year;
                    LCP.WeekStart = jsonParam.WeekStart;
                    LCP.WeekEnd = jsonParam.WeekEnd;
                    
                }

                SqlCommand cmd = new SqlCommand("SP_RPT_SaleReport_Week", con);
                cmd.CommandTimeout = 6000;
                cmd.Parameters.AddWithValue("@ProductID", LCP.ProductID);
                cmd.Parameters.AddWithValue("@HomeType", LCP.HomeType);
                cmd.Parameters.AddWithValue("@UserName", LCP.UserName);
                cmd.Parameters.AddWithValue("@Year", Convert.ToInt16(LCP.Year));
                cmd.Parameters.AddWithValue("@WeekStart", Convert.ToInt16(LCP.WeekStart));
                cmd.Parameters.AddWithValue("@WeekEnd", Convert.ToInt16(LCP.WeekEnd));
                cmd.CommandType = CommandType.StoredProcedure;
                dtAdapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dtAdapter.Fill(dt);
                ds.Tables.Add(dt);

                crystalReport.SetDataSource(ds.Tables[0]);
                crystalReport.SetParameterValue("@ProductID", LCP.ProductID);
                crystalReport.SetParameterValue("@HomeType", LCP.HomeType);
                crystalReport.SetParameterValue("@UserName", LCP.UserName);
                crystalReport.SetParameterValue("@Year", Convert.ToInt16(LCP.Year));
                crystalReport.SetParameterValue("@WeekStart", Convert.ToInt16(LCP.WeekStart));
                crystalReport.SetParameterValue("@WeekEnd", Convert.ToInt16(LCP.WeekEnd));

                CRV.ReportSource = crystalReport;
                CRV.Visible = true;

                CRS.ReportDocument.SetDatabaseLogon(LCP.dbUsername, LCP.dbPassword);

                if (!string.IsNullOrEmpty(LCP.reportName))
                {
                    if (LCP.downloadAs.ToLower() == DownloadAs.pdf.ToString())
                    {
                        SM.exportAsPDF(crystalReport, Response, LCP.reportName);
                    }
                    else if (LCP.downloadAs.ToLower() == DownloadAs.excel.ToString())
                    {
                        SM.exportAsExcel(crystalReport, Response, LCP.reportName);
                    }
                    else if (LCP.downloadAs.ToLower() == DownloadAs.showpdf.ToString())
                    {
                        SM.exportAsStream(crystalReport, Response, LCP.reportName);
                    }
                    else
                    {
                        SM.standardView(CRV);
                    }
                }
            }
            catch (Exception custom)
            {
                throw custom;
            }

        }

        protected void PDF_Click(object sender, ImageClickEventArgs e)
        {
            SM.exportAsPDF(crystalReport, Response, LCP.reportName);
        }

        protected void Excel_Click(object sender, ImageClickEventArgs e)
        {
            SM.exportAsExcel(crystalReport, Response, LCP.reportName);
        }
    }
}