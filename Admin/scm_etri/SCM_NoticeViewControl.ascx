<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeViewControl.ascx.cs" Inherits="Admin_SCM_NoticeViewControl" %>

 
<table style="border: 1px solid #d7d7d7">
<asp:Label ID="lblNoticeError" runat="server" ForeColor="Red"></asp:Label>
</td></tr></table>   

   
 <table width=98% style="border: 1px solid #d7d7d7">
<tr height=30  bgcolor="#5D7B9D"><td  colspan=4 align=center><font color="#ffffff"><b>JobLink Project</b></td></tr> 
<tr height=30>
<td bgcolor="#efefef" width="10%" align=center><b> Title </b></td>
<td     align=left><b><asp:Label class="text" ID="lblTitle" runat="server"></asp:Label></b></td>
</tr></table>
<br> 			
			
<div style="padding: 0 20px;">
    <div>
        <% if (lblFileName.Text != "")  { %>
        <img src ="../../fileUpload/notice/<%= lblFileName.Text %>" width=30%>
        <%} else { %> 
        <%} %>
        <!--<asp:Label ID="lblFileName" runat="server"></asp:Label><asp:Button  ID="btnFile"  runat="server" onclick="btnFile_Click" Text="download" />-->
    </div>
    <div>
        <asp:Label class="text" ID="lblContents" runat="server"></asp:Label>
    </div>
    <div class="text" style="display: flex; justify-content: flex-end; font-weight: 600; margin-top: 40px;">
        <asp:Label class="text" ID="lblwt1" runat="server"></asp:Label>
    </div>
</div>
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

<table width=98% border="0">
		<tr><td><HR SIZE=1></td></tr>
                <tr><td align="right">
                        <asp:ImageButton ID="btnList" runat="server" ImageUrl="~/Images/list_bt.gif" OnClick="btnList_Click" />
                        <asp:ImageButton ID="btnmodify" runat="server" ImageUrl="~/Images/re_bt.gif" OnClick="btnmodify_Click" />
                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete_bt.gif" 
                                        OnClick="btnDelete_Click" style="height: 24px" />
                </td></tr>
            </table>
   

<!--
<asp:Label ID="lblFileName2" runat="server"></asp:Label><asp:Button  ID="btnFile2"  runat="server" onclick="btnFile_Click" Text="download" />
<asp:Label ID="lblFileName3" runat="server"></asp:Label><asp:Button  ID="btnFile3"  runat="server" onclick="btnFile_Click" Text="download" />
<asp:Label ID="lblFileName4" runat="server"></asp:Label><asp:Button  ID="btnFile4"  runat="server" onclick="btnFile_Click" Text="download" />
<asp:Label ID="lblFileName5" runat="server"></asp:Label><asp:Button  ID="btnFile5"  runat="server" onclick="btnFile_Click" Text="download" />-->

