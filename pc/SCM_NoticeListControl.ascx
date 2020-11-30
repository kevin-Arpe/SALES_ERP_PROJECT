<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeListControl.ascx.cs"  Inherits="SCM_NoticeListControl" %>   
<asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>

<link rel="stylesheet" href="js/fancybox/source/jquery.fancybox.css?v=2.1.5" type="text/css" media="screen" />
<script type="text/javascript" src="js/fancybox/source/jquery.fancybox.pack.js?v=2.1.5"></script> 
<script src="jquery.min.js"></script>

<SCRIPT LANGUAGE="JavaScript">
<!--
  function viewStyle(obj){
    while(true){
      if((obj=obj.nextSibling).nodeName=="DIV"){
        obj.style.display=(obj.style.display!='block')?'block':'none';
        obj.style.fontSize = "13px";	
        obj.style.color = "#000000";
		//obj.style.backgroundColor = "#ffffff";
		obj.style.width = "100%";		
        break;
      }
    }
  }
 
//-->

</script>
<link type="text/css" rel="stylesheet" href="./css/userList1.css" />

<div class="top">
    <div class="dropdown">
        <button class="dropbtn"><a href="SCM_NoticeList.aspx">담당자</a></button>
        <div class="dropdown-content">
            <a href="SCM_NoticeList2.aspx">김가연</a>
            <a href="SCM_NoticeList5.aspx">장지인</a>
            <a href="SCM_NoticeList3.aspx">오민준</a>
            <a href="SCM_NoticeList4.aspx">이정현</a>
        </div>
    </div>
    <div class="check">
        <input type="checkbox" class="totalcheck" /><span>담당자 합계</span>
    </div>
</div>
<!--
    <ul class="menu-wrap" style="padding:1px;">
    <li style="font-size:1rem; width:65px; text-align:center; height:50px; line-height:47px;">
-->



<!-- 
<table width="40%">
<tr height=50>
<td align=Center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList7.aspx"><span><b>전체</b></span></td>
<td align=center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList2.aspx"><span class="List2"><b>전자기기</b></span></td>
<td align=center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList.aspx"><span class="List3"><b>의류</b></span></td>
<td align=center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList3.aspx"><span class="List4"><b>생활용품</b></span></td>
<td align=center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList4.aspx"><span class="List5"><b>식품</b></span></td>
<td align=center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList5.aspx"><span class="List5"><b>건강</b></span></td>
<td align=center width="10%" onmouseover="this.style.background='#b3d1ff'" onmouseout="this.style.background='white'"><a href="SCM_NoticeList6.aspx"><span class="List7"><b>도서</b></span></td>
</tr>
</table> 
-->
<div class="container">
<div class="innerBox">
<div class="title"><b>담당자별 판매 실적</b></div>
<div class="header">
    <span>회사명 : 이카운트</span>
    <span id="date">2020/11/12 ~ </span>
</div>
     <font face='맑은 고딕'>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="ctlNoticeList" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    Width="100%" Font-Size="13px" CellPadding="1" ForeColor="#a29e9e"  PageSize="50"
                                    OnPageIndexChanging="ctlNoticeList_PageIndexChanging">

                                    <Columns>
										<asp:TemplateField HeaderText="일자" ItemStyle-Width="70px" ItemStyle-Height="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderStyle-height="35px" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>      
                                                <div class="salesdate">
                                                    <%#FuncCutStrng(Eval("salesdate1"))%> 
                                                </div>                                           
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" HorizontalAlign="center"   verticalAlign="middle"/>
                                        </asp:TemplateField> 
                                        
                                        <asp:TemplateField HeaderText="담당자명">
                                            <ItemTemplate>
                                                <div class="salesman getsalesman">
                                                    <%#FuncCutStrng(Eval("salesman1"))%>
                                                </div> 
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="center"   verticalAlign="middle"/>
                                        </asp:TemplateField> 	
											
											

                                        <asp:TemplateField HeaderText="품목 및 규격">
                                            <ItemTemplate>


                                                <a href='SCM_NoticeView.aspx?SCM_SalesID=<%#Eval("SCM_SalesID") %>' onclick="viewStyle(this);return false">													
												<!a class="fancybox fancybox.iframe"  href='SCM_NoticeView.aspx?SCM_SalesID=<%#Eval("SCM_SalesID") %>' onfocus="this.blur()" rel="external"> 
												
                                                    &nbsp;<%#FuncCutStrng(Eval("Title"))%>....<b>more</b>
                                                    &nbsp;<%#FuncNew(Eval("PostDate")) %></a>
												 
												<DIV style='display:none'>
												 <br>
												<img src='../../fileUpload/notice/<%#FuncCutStrng(Eval("UpFileName"))%>' width=50% height=60%>													
												    <br><br>
                                                   * 수량 : \ <%#FuncLineReturn(Eval("ea1"))%> <br>
                                                   * 단가 : \ <%#FuncCutStrng(Eval("price1"))%> <br>
                                                   * 공급가액 : \ <%#FuncCutStrng(Eval("supply1"))%> 	<br>
                                                   * 부가세 : \ <%#FuncCutStrng(Eval("vat1"))%> 	<br>
                                                   * 합계 : \ <%#FuncCutStrng(Eval("total1"))%> <br>
                                                   * 판매처명 : <%#FuncCutStrng(Eval("company1"))%> 
														<br><br>												   
													</div>
													
													
												 </ItemTemplate>
                                            <ItemStyle Width="35%"   HorizontalAlign="left" verticalAlign="middle"/>
                                        </asp:TemplateField>  
										
										
										<asp:TemplateField HeaderText="수량">
                                            <ItemTemplate>
                                                <div class="ea">
                                                    <%#FuncCutStrng(Eval("ea1"))%> 
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" HorizontalAlign="right"   verticalAlign="middle"/>
                                        </asp:TemplateField>  
										
										<asp:TemplateField HeaderText="단가">
                                            <ItemTemplate>
                                                <div class="price">
                                                    <%#FuncCutStrng(Eval("price1"))%> 
                                                </div>                                                 
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" HorizontalAlign="right"   verticalAlign="middle"/>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="공급가액">
                                            <ItemTemplate>
                                                <div class="supply">
                                                    <%#FuncCutStrng(Eval("supply1"))%> 
                                                </div>                                                 
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" HorizontalAlign="right"   verticalAlign="middle"/>
                                        </asp:TemplateField> 
										
										
										<asp:TemplateField HeaderText="부가세">
                                            <ItemTemplate> 
                                                <div class="vat">
                                                    <%#FuncCutStrng(Eval("vat1"))%>	
                                                </div>									   
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" HorizontalAlign="right" verticalAlign="middle"/>
                                        </asp:TemplateField> 
										
										<asp:TemplateField HeaderText="합계">
                                            <ItemTemplate>
                                                <div class="total">
                                                    <%#FuncCutStrng(Eval("total1"))%>
                                                </div>                                                
                                             </font> 											
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" HorizontalAlign="right"   verticalAlign="middle"/>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="판매처명">
                                            <ItemTemplate>                                                
                                             &nbsp;<%#FuncCutStrng(Eval("company1"))%></font> 											
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center"   verticalAlign="middle"/>
                                        </asp:TemplateField>
                                    </Columns>
									 <HeaderStyle BackColor="#efefef"  Font-Bold="True" ForeColor="#2f99bd" HorizontalAlign="Center"/> 
									<RowStyle BackColor="#ffffff" ForeColor="#333333" />
									
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /> 
                                    <EditRowStyle BackColor="#999999" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#a29e9e" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#000000" />								
									
									
                                </asp:GridView>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>			
         </font>	 
</div>
</div>
  						
 
 
 
 
 
 
 <script type="text/javascript" src="js/jquery-latest.js"></script> 
 <link rel="stylesheet" href="js/fancybox/source/jquery.fancybox.css?v=2.1.5" type="text/css" media="screen" />
<script type="text/javascript" src="js/fancybox/source/jquery.fancybox.pack.js?v=2.1.5"></script> 

<script type="text/javascript">
	$(document).ready(function() {
		$(".fancybox").fancybox({		
		fitToView	: false,
		width		: '100%',
		height	: '300',
		autoSize	: false,
		autoCenter	: false,
		closeClick	: false,
		openEffect	: 'none',
		closeEffect	: 'none'
	});
});
</script> 

<script src="./js/func.js" type="text/javascript"></script>

<!-- <style type="text/css">
.menu-wrap li{
    display: inline-block;
    background: #ffffff;
    border-radius: 10px;
    height= 30px;
    padding: 10px;
    line-height=30px;}
.menu-wrap li.selected{
    background-color: #000;
    color:#fff;
    font-weight: 600;
}
</style>-->
 		
