<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="Questionnaire_2.aspx.cs" Inherits="OSCS.Questionnaire_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <br />

    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <fieldset class="bg-patient-fieldset">
            <h4 style="text-align: center; font-size: xx-large;"></h4>

            <!-- Placing GridView in UpdatePanel-->
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>

                    <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>

                    <br />
                    <br />

                     <div id="YesNodiv1" runat="server" style="margin-left: auto; margin-right: auto; ">

                        <asp:HiddenField ID="SelectedGridCellIndexYesNo1" runat="server" Value="-1" />

                        <asp:GridView ID="YesNo1" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedYesNo1" OnSelectedIndexChanged="SelectedIndexChangedYesNo1"
                            AutoGenerateColumns="false" AllowPaging="False" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="YesNo1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-6 col-sm-6 col-md-6 col-lg-6" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Yes" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="0">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="1">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    
                    <br />

                    <div id="textdiv1" runat="server" style="margin-left: auto; margin-right: auto; ">
                        <asp:HiddenField ID="SelectedGridCellIndexText1" runat="server" Value="-1" />
                        <%--ID was gvphq9--%>
                        <asp:GridView ID="Stringquestions1" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedText1" OnSelectedIndexChanged="SelectedIndexChangedText1" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="true" DataKeyNames="questionid" OnPageIndexChanging="Stringquestions1_PageIndexChanging">
                            <Columns>

                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-6 col-sm-6 col-md-6 col-lg-6" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Stringquestions1" runat="server" CssClass="tb-width" RepeatDirection="Horizontal" AutoPostBack="false" ItemStyle-HorizontalAlign="Center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>

                    <br />

                    <ul class="pagination">
                        <a href="Questionnaire_1.aspx" class="btn btn-danger" style="position:relative">&laquo;</a>
                        <asp:LinkButton ID="lbadd" Text="" runat="server" CssClass="btn btn-danger" Style="position: relative" OnClick="btnAdd_Click">
                            &raquo</asp:LinkButton>
                    </ul>
                    <br />
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </fieldset>

    </div>

</asp:Content>
