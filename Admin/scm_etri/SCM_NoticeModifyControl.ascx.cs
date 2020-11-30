﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public partial class Admin_SCM_NoticeModifyControl : System.Web.UI.UserControl
{
   #region [1]Event Handler
    //[1]그리드..
    protected void Page_Load(object sender, EventArgs e)
    {
        //[1]스크립트
        string strAlert = @"<script>location.href='../Default.aspx';</script>";
        
        //[2]로그인 체크
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Write(strAlert);
        }
        else
        {
            //[3]관리자만 접근가능
            if (Page.User.Identity.Name.ToLower() == "admin")
            {
                if (!IsPostBack)
                {
                    DisplayData();
                }
            }
            else
            {
                Response.Write(strAlert);                
            }
        }        
    }
    
    //수정
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //[1]제목과 내용 변수
        string strTitle = "";
	string strps = "";
	 
string strwt1 = "";
string strContent = "";
string UpfileName = "";   
string dbFileName = lblFileName.Text ; 
	                                                  
        

        //[1-1]script
        string strAlert = @"<script>alert('수정했습니다.');location.href='SCM_NoticeView.aspx?SCM_NewsID=" 
            + Request["SCM_NewsID"] 
            + "';</script>"; 


        if ((FileUpload1.PostedFile.FileName != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            UpfileName = FileUpload1.PostedFile.FileName;
    
            string SaveLocation = Server.MapPath("~\\fileUpload\\notice\\") + UpfileName;
            dbFileName = UpfileName;
            FileInfo fInfo = new FileInfo(SaveLocation);

            string newUpFile = string.Empty;

            if (!fInfo.Exists)
            {
                int fIndex = 0;
                string fExtension = fInfo.Extension;
                string fRealName = UpfileName.Replace(fExtension, "");

                do
                {
                    fIndex++;
                    dbFileName = fRealName + "" + fIndex.ToString() + fExtension;
		    SaveLocation =Server.MapPath("~\\fileUpload\\notice\\")+dbFileName ;
                    fInfo = new FileInfo(SaveLocation)  ;                                                    
                } while (fInfo.Exists);

                                                                                                              
             }
    
              FileUpload1.SaveAs(SaveLocation);
                                                                                                               
        }
 
       
        try
        {            
            //[2]리플레이스 변환
            strTitle = txtTitle.Text;       
            strContent = txtContent.Text;             				 
            strwt1 = txtwt1.Text;  
 

            using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
            {
                //[1]Excute
             
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UP_ModifySCM_ETRI", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", strTitle);
		cmd.Parameters.AddWithValue("@wt1", strwt1)
        ;
        cmd.Parameters.AddWithValue("@Content", strContent);  
        cmd.Parameters.AddWithValue("@upFileName", dbFileName);  
				
				
                cmd.Parameters.AddWithValue("@SCM_NewsID", Convert.ToInt32(Request["SCM_NewsID"]));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            //[2]리디렉트..수차후수정
            Response.Write(strAlert);            
        }
        catch (Exception err)
        {
            //[3]Exception
            Response.Write(err.Source + " : " + err.Message);
        }
        
    }
    //취소
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {        
        Response.Redirect("SCM_NoticeView.aspx?SCM_NewsID=" + Request["SCM_NewsID"]);
    }
    #endregion

    #region [2]Method
    //텍스트 박스 바인딩
    private void DisplayData()
    {
        //[1]dataset
        DataSet ds = null;
        
        try
        {
            using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
            {
                //[2]Fill
              //  ds = bsl.ViewNotice(Convert.ToInt32(Request["NoticeID"]));
                ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString, "UP_ViewSCM_ETRI", Convert.ToInt32(Request["SCM_NewsID"]));

                //[3]Bind
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
		txtwt1.Text = ds.Tables[0].Rows[0]["wt1"].ToString();  
		
lblFileName.Text = ds.Tables[0].Rows[0]["UpFileName"].ToString(); 
 
                
            }            
        }
        catch (Exception err)
        {
            //[4]예외
            Response.Write(err.Source + " : " + err.Message);
        }               
    } 
    #endregion
   
}
