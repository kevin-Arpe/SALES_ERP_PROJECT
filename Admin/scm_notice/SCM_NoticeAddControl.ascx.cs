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
using System.IO;

public partial class Admin_SCM_NoticeAddControl : System.Web.UI.UserControl
{
    #region [1]Event Handler
    //Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //[1]스크립트
        string strAlert = @"<script>alert('관리자만 접근가능합니다.');location.href='../Default.aspx';</script>";

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
                //
            }
            else
            {
                Response.Write(strAlert);
            }
        }
    }
    //Submit
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {        

        //[1]임시변수
        string strproject = "";
        string strContent = "";
string strdate1 = ""; 

string strcustomer = "";
string strts2 = "";
string strts3 = "";
string strts4 = "";
string strts5 = "";
string strts6 = "";
string strts7 = "";
string strts8 = "";



string strcode1 = ""; 
string stretc = "";
string strperiod1 = "";
string strdueDate = "";
string strprogress1 = "";
string strcompany = ""; 
string strlanguage1 = "";
string strtodo = "";
string strtech = "";
    string UpfileName = "";	

    string dbFileName = string.Empty;
     

         
	
       
                                                                        
        string path="d:\\_Mobile_System\\joblink\\fileUpload\\Notice\\";        


        string strAlert = @"<script>alert('입력했습니다.');location.href='SCM_NoticeList.aspx';</script>";


if ((FileUpload1.PostedFile.FileName != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            UpfileName = FileUpload1.PostedFile.FileName;
    
            string SaveLocation = Server.MapPath("~\\fileUpload\\Notice\\") + UpfileName;
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
		    SaveLocation =Server.MapPath("~\\fileUpload\\Notice\\")+dbFileName ;
                    fInfo = new FileInfo(SaveLocation)  ;                                              
                } while (fInfo.Exists);                                                                                                        
             }
                  FileUpload1.SaveAs(SaveLocation);                                                                                                          
        }


      

	 
        
        try
        {
            //[2]변환
            strproject = txtproject.Text
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r\n", "<br>")
                .Replace("\t", "&nbsp;&nbsp;&nbsp;");                
 
 		strContent = txtContent.Text
		 .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r\n", "<br>")
                .Replace("\t", "&nbsp;&nbsp;&nbsp;");   
		
		
strdate1 = txtdate1.Text; 	
strcode1 = txtcode1.Text; 		
strcustomer = txtcustomer.Text;
             

stretc = txtetc.Text;
strperiod1 = txtperiod1.Text;
strdueDate = txtdueDate.Text;
strprogress1 = txtprogress1.Text;
strcompany = txtcompany.Text; 
strlanguage1 = txtlanguage1.Text;
strtodo = txttodo.Text;
strtech = txttech.Text;
 











if (strcustomer !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strts2 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strts3 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strts4 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strts5 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}

if (strts6 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}


if (strts7 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}


if (strts8 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@date1", strdate1);
					cmd.Parameters.AddWithValue("@language1", strlanguage1);
					cmd.Parameters.AddWithValue("@customer", strcustomer);
					cmd.Parameters.AddWithValue("@etc", stretc);
					cmd.Parameters.AddWithValue("@period1", strperiod1);
					cmd.Parameters.AddWithValue("@dueDate", strdueDate);
					cmd.Parameters.AddWithValue("@progress1", strprogress1);
					cmd.Parameters.AddWithValue("@company", strcompany); 
					cmd.Parameters.AddWithValue("@todo", strtodo);
					cmd.Parameters.AddWithValue("@tech", strtech);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}




























   /*      
                using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@project", strproject);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
                    cmd.Parameters.AddWithValue("@code2", strcode2);	
                    cmd.Parameters.AddWithValue("@code3", strcode3);	
                    cmd.Parameters.AddWithValue("@code4", strcode4);	
                    cmd.Parameters.AddWithValue("@code5", strcode5);						
					
					
cmd.Parameters.AddWithValue("@upFileName", dbFileName);
cmd.Parameters.AddWithValue("@upFileName2", dbFileName2);
cmd.Parameters.AddWithValue("@upFileName3", dbFileName3);
cmd.Parameters.AddWithValue("@upFileName4", dbFileName4);
cmd.Parameters.AddWithValue("@upFileName5", dbFileName5);
                     
		     

cmd.Parameters.AddWithValue("@date1", strdate1);
cmd.Parameters.AddWithValue("@customer", strcustomer);
cmd.Parameters.AddWithValue("@ts2", strts2);
cmd.Parameters.AddWithValue("@ts3", strts3);
cmd.Parameters.AddWithValue("@ts4", strts4);
cmd.Parameters.AddWithValue("@ts5", strts5);

cmd.Parameters.AddWithValue("@etc", stretc);
cmd.Parameters.AddWithValue("@cs2", strcs2);
cmd.Parameters.AddWithValue("@cs3", strcs3);
cmd.Parameters.AddWithValue("@cs4", strcs4);
cmd.Parameters.AddWithValue("@cs5", strcs5);


cmd.Parameters.AddWithValue("@period1", strperiod1);
cmd.Parameters.AddWithValue("@link2", strlink2);
cmd.Parameters.AddWithValue("@link3", strlink3);
cmd.Parameters.AddWithValue("@link4", strlink4);
cmd.Parameters.AddWithValue("@link5", strlink5);

cmd.Parameters.AddWithValue("@dueDate", strdueDate);
cmd.Parameters.AddWithValue("@Dead2", strDead2);
cmd.Parameters.AddWithValue("@Dead3", strDead3);
cmd.Parameters.AddWithValue("@Dead4", strDead4);
cmd.Parameters.AddWithValue("@Dead5", strDead5);

cmd.Parameters.AddWithValue("@progress1", strprogress1);
cmd.Parameters.AddWithValue("@Progress2", strProgress2);
cmd.Parameters.AddWithValue("@Progress3", strProgress3);
cmd.Parameters.AddWithValue("@Progress4", strProgress4);
cmd.Parameters.AddWithValue("@Progress5", strProgress5);

cmd.Parameters.AddWithValue("@company", strcompany); 
cmd.Parameters.AddWithValue("@corp2", strcorp2);
cmd.Parameters.AddWithValue("@corp3", strcorp3);
cmd.Parameters.AddWithValue("@corp4", strcorp4);
cmd.Parameters.AddWithValue("@corp5", strcorp5); 

con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
         */ 

            //[4]
            Response.Write(strAlert);
        }
        catch (Exception err)
        {
            //[5]Exception
            Response.Write(err.Source + " : " + err.Message);
        }
    }
    //Cancel
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SCM_NoticeList.aspx");
    } 
    #endregion
}
