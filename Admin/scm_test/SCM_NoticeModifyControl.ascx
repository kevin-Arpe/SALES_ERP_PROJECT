<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeModifyControl.ascx.cs" Inherits="Admin_SCM_NoticeModifyControl"  %>

<link rel="stylesheet" href="build/kalendae.css" type="text/css" charset="utf-8">
	<script src="build/kalendae.js" type="text/javascript" charset="utf-8"></script>
	<style type="text/css" media="screen">
		.kalendae .k-days span.closed {
			background:red;
		}
	</style>
	
	
	
<table width=50% style="border: 1px solid #d7d7d7">
<tr height=30  bgcolor="#5D7B9D"><td  colspan=4 align=center><font color="#ffffff"><b>시험결과 기입	</b></td></tr> 
<tr height=30>
<td bgcolor="#efefef" width="33%" align=center><b> 시험자 </b></td>
<td align=left><b><asp:TextBox style="margin-left: 12px;" class="tester" ID="txttester" runat="server" Width="66%"></asp:TextBox></b></td></tr></table>
<br>

<table width=50% border="1" bordercolor="#d7d7d7">
<tr height="30">
<td bgcolor="#efefef" width="99%" align=center colspan="3"><b> 시험점수 </b></td>
</tr>
<tr height="30">
<td bgcolor="#efefef" width="33%" align=center><b>국어</b></td>
<td bgcolor="#efefef" width="33%" align=center><b>영어</b></td>
<td bgcolor="#efefef" width="33%" align=center><b>수학</b></td>
</tr>
<tr style="text-align: center;">
<td style="text-align: center;"><asp:TextBox style="text-align: center;" class="langScore" ID="txtlangScore" runat="server" Width="33%"></asp:TextBox></td>
<td style="text-align: center;"><asp:TextBox style="text-align: center;" class="engScore" ID="txtengScore" runat="server" width="33%"></asp:TextBox></td>
<td style="text-align: center;"><asp:TextBox style="text-align: center;" class="mathScore" ID="txtmathScore" runat="server" width="33%"></asp:TextBox></td>
</tr>
</table>

<hr>
<input type="button" value="결과확인" id="submitBtn" />
<table width=50% style="border: 1px solid #d7d7d7">
<tr height=30  bgcolor="#5D7B9D"><td  colspan=4 align=center><font color="#ffffff"><b>결과</b></td></tr> 
<td bgcolor="#efefef" width="49%" align=center><b>총점</b></td>
<td bgcolor="#efefef" width="49%" align=center><b>합격여부</b></td>
</tr>
<tr style="text-align: center;">
<td style="text-align: center;"><asp:TextBox style="text-align: center;" class="totalScore" ID="txttotalScore" runat="server" Width="49%"></asp:TextBox></td>
<td style="text-align: center;"><asp:TextBox style="text-align: center;" class="pf" ID="txtpf" runat="server" width="49%"></asp:TextBox></td>
</tr>
</table>
<br>


<br> 
 
 
 <table width="100%" border="0">
		<tr><td><HR SIZE=1></td></tr>
                <tr><td align="right">
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/ok_bt.gif" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/cancel_bt.gif"
                            OnClick="btnCancel_Click" />
                </td></tr>
            </table>
  
 
<script src="./src/score.js"></script>



                 
 



 

 