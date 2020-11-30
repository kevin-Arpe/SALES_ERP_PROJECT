<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeAddControl.ascx.cs" Inherits="Admin_SCM_NoticeAddControl" %>

 <link rel="stylesheet" href="build/kalendae.css" type="text/css" charset="utf-8">
	<script src="build/kalendae.js" type="text/javascript" charset="utf-8"></script>
	<style type="text/css" media="screen">
		.kalendae .k-days span.closed {
			background:red;
		}
	</style>
	
 <!--1-->

<table width=98% style="border: 1px solid #d7d7d7">

<tr height=30  bgcolor="#5D7B9D"><td  colspan=4 align=center><font color="#ffffff"><b>JobLink Project</b></td></tr> 
<tr height=30>
<td bgcolor="#efefef" width="10%" align=center><b> 프로젝트명 </b></td>
<td align=left><b><asp:TextBox ID="txtTitle" runat="server" Width="80%"></asp:TextBox> </b></td> 
</tr></table>
<br> 

<table width=98% border="1" bordercolor="#d7d7d7">

<tr height=30>
<td bgcolor="#efefef" width="10%" align=center><b> 작성자 </b></td>
<td  width="40%" align=left><b><asp:TextBox ID="txtwt1" runat="server" Width="50%"></asp:TextBox></b>
</td>	
<td bgcolor="#efefef" width="10%" align=center><b> 이미지 </b></td><td  align=left width="40%"><asp:FileUpload ID="FileUpload1" runat="server" /></asp:FileUpload></td></tr> 
</table>
<br>





<table width=98% border="1" bordercolor="#d7d7d7">
<tr>
<td bgcolor="#efefef" width="10%" align=center rowspan=2><b> 내용 </b></td>
<td width="40%" align=left valign=top><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine"  width="100%" Rows="30">
</asp:TextBox></td> 
</tr>
</table> 





 
<table width="100%" border="0">
		<tr><td><HR SIZE=1></td></tr>
                <tr><td align="right">
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/ok_bt.gif" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/cancel_bt.gif"
                            OnClick="btnCancel_Click" />
                </td></tr>
            </table>



 
                                                                
													
						                                

 
                        
                           
                        
