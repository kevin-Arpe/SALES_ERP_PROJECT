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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_SCM_NoticeViewControl : System.Web.UI.UserControl
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

    //자료 목록보기
    protected void btnList_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SCM_NoticeList.aspx");
    }
    //[3]MoDify
    protected void btnmodify_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SCM_NoticeModify.aspx?SCM_ScoreID=" + Request["SCM_ScoreID"]);
    }
    //[4]삭제
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        //[1]script
        string strAlert = @"<script>alert('삭제되었습니다.');location.href='SCM_NoticeList.aspx';</script>";

        try
        {
            using (Is.Notice.Bsl.Notice_RTx rBsl = new Is.Notice.Bsl.Notice_RTx())
            {
               
                SqlConnection con = new SqlConnection(
                                 ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UP_DeleteSCM_SCORE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SCM_ScoreID", Convert.ToInt32(Request["SCM_ScoreID"]));
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            //[3]
            Page.RegisterStartupScript("EndScript", strAlert);
        }
        catch (Exception err)
        {
            //[4]
            //Response.Write(err.Source + " : " + err.Message);
        }
    } 
    #endregion

    #region [2]Mehtod
    //레이블 바인딩
    private void DisplayData()
    {
        //[1]dataset
        DataSet ds = new DataSet();

        using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
        {
            //[2]Fill
          //  ds = bsl.ViewNotice(Convert.ToInt32(Request["NoticeID"]));
            ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString, "UP_ViewSCM_SCORE", Convert.ToInt32(Request["SCM_ScoreID"]));


            if (ds.Tables[0].Rows.Count > 0)
            {
                //[3]내용이 길어서.. 출력 오류 날수 있으니..나중에 체크하자..

                lblPostDate.Text = ds.Tables[0].Rows[0]["PostDate"].ToString().Substring(0, 10);
                lbltester.Text = ds.Tables[0].Rows[0]["tester"].ToString();

lbllangScore.Text = ds.Tables[0].Rows[0]["langScore"].ToString();
lblengScore.Text = ds.Tables[0].Rows[0]["engScore"].ToString();
lblmathScore.Text = ds.Tables[0].Rows[0]["mathScore"].ToString()
.Replace("\r\n", "<br />");

lbltotalScore.Text = ds.Tables[0].Rows[0]["totalScore"].ToString(); 
lblpf.Text = ds.Tables[0].Rows[0]["pf"].ToString();
        lblReadCount.Text = ds.Tables[0].Rows[0]["ReadCount"].ToString() 
		.Replace("\r\n", "<br />");
		    }        
        }
    }
    #endregion 
}