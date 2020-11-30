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
        string strproject = "";
	string strdate1 = "";
	 
string strcustomer = "";
string stretc = "";
string strperiod1 = "";
string strdueDate = "";
string strlanguage1 = "";
string strprogress1 = "";
string strcompany = "";
string strcode1 = ""; 
string strtodo = "";
string strtech = "";
string strContent = "";
string UpfileName = "";   
string dbFileName = lblFileName.Text ; 
	                                                  
        

        //[1-1]script
        string strAlert = @"<script>alert('수정했습니다.');location.href='SCM_NoticeView.aspx?SCM_NoticeID=" 
            + Request["SCM_NoticeID"] 
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
            strproject = txtproject.Text;                    				
					
	    strdate1 = txtdate1.Text;  
            strcustomer = txtcustomer.Text;  
            stretc = txtetc.Text;  
            strperiod1 = txtperiod1.Text; 			
strdueDate = txtdueDate.Text; 
strprogress1 = txtprogress1.Text; 
strcompany = txtcompany.Text; 
strcode1 = txtcode1.Text; 
strlanguage1 = txtlanguage1.Text; 
strtodo = txttodo.Text; 
strtech = txttech.Text; 
strContent = txtContent.Text 
			.Replace("\r\n", "<br />");
 

            using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
            {
                //[1]Excute
             
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UP_ModifySCM_Notice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@project", strproject);
		cmd.Parameters.AddWithValue("@date1", strdate1);
		cmd.Parameters.AddWithValue("@customer", strcustomer); 
		cmd.Parameters.AddWithValue("@etc", stretc); 
		cmd.Parameters.AddWithValue("@period1", strperiod1); 		
		cmd.Parameters.AddWithValue("@dueDate", strdueDate); 
		cmd.Parameters.AddWithValue("@progress1", strprogress1); 
		cmd.Parameters.AddWithValue("@company", strcompany);  
		cmd.Parameters.AddWithValue("@code1", strcode1);  
		cmd.Parameters.AddWithValue("@language1", strlanguage1); 
		cmd.Parameters.AddWithValue("@todo", strtodo);   
		cmd.Parameters.AddWithValue("@tech", strtech);
        cmd.Parameters.AddWithValue("@Content", strContent);  
        cmd.Parameters.AddWithValue("@upFileName", dbFileName);  
				
				
                cmd.Parameters.AddWithValue("@SCM_NoticeID", Convert.ToInt32(Request["SCM_NoticeID"]));

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
        Response.Redirect("SCM_NoticeView.aspx?SCM_NoticeID=" + Request["SCM_NoticeID"]);
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
                ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString, "UP_ViewSCM_Notice", Convert.ToInt32(Request["SCM_NoticeID"]));

                //[3]Bind
                txtproject.Text = ds.Tables[0].Rows[0]["project"].ToString();
		txtdate1.Text = ds.Tables[0].Rows[0]["date1"].ToString(); 
		txtcustomer.Text = ds.Tables[0].Rows[0]["customer"].ToString();  
		txtetc.Text = ds.Tables[0].Rows[0]["etc"].ToString(); 
		txtperiod1.Text = ds.Tables[0].Rows[0]["period1"].ToString();  
		txtlanguage1.Text = ds.Tables[0].Rows[0]["language1"].ToString();
		txttodo.Text = ds.Tables[0].Rows[0]["todo"].ToString();		
		txtdueDate.Text = ds.Tables[0].Rows[0]["dueDate"].ToString();  
		txtprogress1.Text = ds.Tables[0].Rows[0]["progress1"].ToString();  
		txtcompany.Text = ds.Tables[0].Rows[0]["company"].ToString();  
		txtcode1.Text = ds.Tables[0].Rows[0]["code1"].ToString();  		
        txtContent.Text = ds.Tables[0].Rows[0]["Content"].ToString()  
		.Replace("\r\n", "<br />");
		txttech.Text = ds.Tables[0].Rows[0]["tech"].ToString(); 
		
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
