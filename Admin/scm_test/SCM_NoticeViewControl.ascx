<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeViewControl.ascx.cs" Inherits="Admin_SCM_NoticeViewControl" %>

 
<table style="border: 1px solid #d7d7d7">
<asp:Label ID="lblNoticeError" runat="server" ForeColor="Red"></asp:Label>
</td></tr></table>   

<div style="width: 50%; background-color: #efefef;">
     <table width=98% style="border: 1px solid #d7d7d7; background-color: #fff;">
<tr height=30  bgcolor="#5D7B9D"><td  colspan=4 align=center><font color="#ffffff"><b>JobLink Project</b></td></tr> 
<tr height=30>
<td bgcolor="#efefef" width="10%" align=center><b> 시험자 </b></td>
<td     align=left><b><asp:Label ID="lbltester" runat="server"></asp:Label></b></td>  

<td bgcolor="#efefef" width="10%" align=center><b> 합격여부 </b></td>
<td  align=left><b><asp:Label ID="lblpf" runat="server"></asp:Label></b>
</td></tr></table>
<br> 			
			


			
<% if (lbltester.Text != "")  { %>
 <table width=98% border="1" bordercolor="#d7d7d7">
<tr height=30>
<td bgcolor="#efefef" width="10%" align=center><b> 국어점수 </b></td><td  align=left><b><asp:Label ID="lbllangScore" runat="server"></asp:Label></b></td>
<td bgcolor="#efefef" width="10%" align=center rowspan=3><b> 총점 </b></td>
<td width="50%" align=left valign=top rowspan=3><asp:Label style="display: flex; justify-content: center; line-height: 90px; font-size: 20px; font-weight: 600;" ID="lbltotalScore" runat="server"></asp:Label></td>
</tr>
<tr>
<td bgcolor="#efefef" width="10%" align=center><b> 영어점수 </b></td><td  align=left><b><asp:Label ID="lblengScore" runat="server"></asp:Label></b></td></tr>
<tr>
<td bgcolor="#efefef" width="10%" align=center><b> 수학점수 </b></td><td  align=left><b><asp:Label ID="lblmathScore" runat="server"></asp:Label></b></td></tr>
</table>

<%} else { %> 
<%} %>
<br>  



<table width=98% border="0" cellpadding="0" cellspacing="0" bgcolor="#5D7B9D" height=30>
                                        <tr><td width="80px" align=center><font color="#ffffff"><b>작성자</b></td>
                                            <td width="5px"></td>
                                            <td width="160px" align=left><font color="#ffffff">관리자</td>
                                            <td width="80px"><font color="#ffffff"><b>작성일</b></td>
                                            <td width="5px"></td>
                                            <td width="150px" align=left><font color="#ffffff"> 
					   <asp:Label ID="lblPostDate" runat="server"></asp:Label></td>
                                            <td width="80px"><font color="#ffffff"><b>조회수</b></td>
                                            <td width="5px"> </td>
                                            <td width="100px" align=left><font color="#ffffff">
                                                <asp:Label ID="lblReadCount" runat="server"></asp:Label>
                                            </td>  </tr>
                                    </table>     
</div>

<table width=98% border="0">
		<tr><td><HR SIZE=1></td></tr>
                <tr><td align="right">
                        <asp:ImageButton ID="btnList" runat="server" ImageUrl="~/Images/list_bt.gif" OnClick="btnList_Click" />
                        <asp:ImageButton ID="btnmodify" runat="server" ImageUrl="~/Images/re_bt.gif" OnClick="btnmodify_Click" />
                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete_bt.gif" 
                                        OnClick="btnDelete_Click" style="height: 24px" />
                </td></tr>
            </table>