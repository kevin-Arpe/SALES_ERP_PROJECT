using System;
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
        string strtester = "";
	string strlangScore = "";
	 
string strengScore = "";
string strmathScore = "";
string strtotalScore = "";
string strpf = "";
	                                                  
        

        //[1-1]script
        string strAlert = @"<script>alert('수정했습니다.');location.href='SCM_NoticeView.aspx?SCM_ScoreID=" 
            + Request["SCM_ScoreID"] 
            + "';</script>"; 
       
        try
        {            
            //[2]리플레이스 변환
            strtester = txttester.Text;
            strlangScore = txtlangScore.Text;                    				

            strengScore = txtengScore.Text; 
            strmathScore = txtmathScore.Text;
strtotalScore = txttotalScore.Text;
strpf = txtpf.Text;
 

            using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
            {
                //[1]Excute
             
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UP_ModifySCM_SCORE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tester", strtester);
        cmd.Parameters.AddWithValue("@langScore", strlangScore);
		cmd.Parameters.AddWithValue("@engScore", strengScore);
		cmd.Parameters.AddWithValue("@mathScore", strmathScore);
		cmd.Parameters.AddWithValue("@totalScore", strtotalScore);
        cmd.Parameters.AddWithValue("@pf", strpf);
				
				
                cmd.Parameters.AddWithValue("@SCM_ScoreID", Convert.ToInt32(Request["SCM_ScoreID"]));

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
        Response.Redirect("SCM_NoticeView.aspx?SCM_ScoreID=" + Request["SCM_ScoreID"]);
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
                ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString, "UP_ViewSCM_SCORE", Convert.ToInt32(Request["SCM_ScoreID"]));

                //[3]Bind
                txttester.Text = ds.Tables[0].Rows[0]["tester"].ToString();
                txtlangScore.Text = ds.Tables[0].Rows[0]["langScore"].ToString();
		txtengScore.Text = ds.Tables[0].Rows[0]["engScore"].ToString();
		txtmathScore.Text = ds.Tables[0].Rows[0]["mathScore"].ToString();
		txttotalScore.Text = ds.Tables[0].Rows[0]["totalScore"].ToString();
        txtpf.Text = ds.Tables[0].Rows[0]["pf"].ToString();
        
                
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
