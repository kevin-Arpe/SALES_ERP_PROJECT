<%@Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeListControl.ascx.cs" Inherit="Admin_SCM_NoticeListControl" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table width="98%" border="0" cellpadding="0" cellspacing="0">
    <tr><td height="30" colspan="9" align="center" bgcolor="#5d7b9d">
        <font color="#fff"><b>잡링크 프로젝트 알림</b></font>
    </td></tr>
    <tr><td height="40px" align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="ctlNoticeList" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                width="100%" font-size="11px" cellpadding="0" forecolor="#333" pagesize="50"
                onPageIndexChanging="ctlNoticeList_pageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SCM_NoticeID" HeaderText="번호" ItemStyle-width="70px" ItemStyle-HorizontalAlign="center"
                        HeaderStyle-width="5%" HeaderStyle-HorizontalAlign="center" />
                        
                        <asp:TemplateField HeaderText="TITLE">
                            <ItemTemplate>
                                <a href='SCM_NoticeView.aspx?SCM_NoticeID=<%#Eval("SCM_NoticeID")%>'>
                                    <%#FuncCutStrng(Eval("Title"))%>
                                    &nbsp;
                                    <%#FuncNew(Eval("PostDate"))%>
                                </a>
                            </ItemTemplate>
                            <ItemStyle width="15%" HorizontalAlign="left" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="구분">
                            <ItemTemplate>
                                <%#FuncCutStrng(Eval("cus_code"))%>
                            </ItemTemplate>
                            <ItemStyle width="5%" HorizontalAlign="center" />
                        <asp:TemplateField>

                        <asp:TemplateField HeaderText="고객사">
                            <ItemTemplate>
                                <%#FuncCutStrng(Eval("customer"))%>
                            </ItemTemplate>
                            <ItemStyle width="10%" HorizontalAlign="left" />
                        <asp:TemplateField>

                        <asp:TemplateField HeaderText="기간">
                            <ItemTemplate>
                                <%#FuncCutStrng(Eval("term"))%>
                            </ItemTemplate>
                            <ItemStyle width="5%" HorizontalAlign="left" />
                        <asp:TemplateField>

                        <asp:TemplateField HeaderText="언어">
                            <ItemTemplate>
                                <%#FuncCutStrng(Eval("lang"))%>
                            </ItemTemplate>
                            <ItemStyle width="8%" HorizontalAlign="left" />
                        <asp:TemplateField>

                        <asp:TemplateField HeaderText="종료">
                            <ItemTemplate>
                                <%#FuncCutStrng(Eval("st_date"))%>
                            </ItemTemplate>
                            <ItemStyle width="8%" HorizontalAlign="center" />
                        <asp:TemplateField>

                        <asp:TemplateField HeaderText="진행">
                            <ItemTemplate>
                                &nbsp;
                                <font color="<%#FuncCutStrng(Eval("Color"))%>">
                                    <b>
                                        <%#FuncCutStrng(Eval("progress"))%>
                                    </b>
                                </font>
                            </ItemTemplate>
                            <ItemStyle width="5%" HorizontalAlign="center" />
                        <asp:TemplateField>

                        <asp:BoundField DataField="PostDate" HeaderText="작성일" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="center" width="5%">
                        <asp:BoundField>

                        <asp:BoundField DataField="ReadCount" HeaderText="조회">
                            <ItemStyle HorizontalAlign="center" width="5%">
                        <asp:BoundField>

                        <asp:TemplateField HeaderText="기술">
                            <ItemTemplate>
                                <%#FuncCutStrng(Eval("tech"))%>
                            </ItemTemplate>
                            <ItemStyle width="20%" HorizontalAlign="left" />
                        <asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckChanged="chkAll_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                    </Columns>
                
                    <FooterStyle BackColor="#5d7b9d" font-bold="true" foreColor="white" />
                    <RowStyle BackColor="#f7f6f3" foreColor="#333" />
                    <EditRowStyle BackColor="#999" />
                    <SelectedRowStyle BackColor="#284775" foreColor="white" HorizontalAlign="center" />
                    <HeaderStyle BackColor="#d7d7d7" font-bold="true" foreColor="black" />
                    <AlternatingRowStyle BackColor="white" foreColor="#284775" />
                </asp:GridView>
                
                <asp:Label ID="lblError" runat="server" foreColor="red"></asp:Label>
            </ContentTemplate>
        </asp::UpdatePanel>
    </td></tr>
    <tr><td heigth="1px" bgcolor="#ccc"></td></tr>
    <tr><td colspan="3" align="right">
        <table border="0" cellpadding="1" cellspacing="1" align="right">
            <tr>
                <td height="40px" align="right" valign="top">
                    <asp:Panel ID="Panel1" runat="server" width="100%" DefaultButton="btnSearch">
                        <asp:DropDownList ID="lstField" runat="server" CssClass="DropList">
                            <asp:ListItem Selected="true" value="Title">제목</asp:ListItem>
                            <asp:ListItem value="Content">내용</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                </td>
                <td height="40px" align="left" valign="top"><nobr>
                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/find_bt.gif" onClick="btnSearch_Click" />
                    <asp:ImageButton ID="btnWrite" runat="server" ImageUrl="~/Images/write_bt.gif" onClick="btnWrite_Click" />
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete_bt.gif" onClick="btnDelete_Click" />
                    <asp:ImageButton ID="btnPush" runat="server" ImageUrl="~/Images/push_bt.gif" onClick="btnPush_Click" />
                </td>
                <!--
                    <td align="center" valign="middle" width="100%" bgcolor="red">
                        <a href="./PushNotice.ashx?aaa=12345">
                            <font color="#fff"><b>PushNotice</b></font>
                        </a>
                    </td>
                -->
            </tr>
        </table>
    </td></tr>
</table>