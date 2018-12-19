<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="Questionnaire_3.aspx.cs" Inherits="OSCS.Questionnaire_3" %>

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

                    <div id="Radiodiv1" runat="server" style="margin-left: auto; margin-right: auto; ">

                        <asp:HiddenField ID="SelectedGridCellIndexRadio1" runat="server" Value="-1" />

                        <asp:GridView ID="Radio1" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedRadio1" OnSelectedIndexChanged="SelectedIndexChangedRadio1"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="Radio1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-4 col-sm-4 col-md-4 col-lg-4" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="No emotional stress" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="0">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="A little stress" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="1">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Moderate stress" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="2">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="A lot of emotional stress" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="2">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

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
                        <asp:GridView ID="Stringquestions1" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedText1" OnSelectedIndexChanged="SelectedIndexChangedText1"
                            AutoGenerateColumns="false" AllowPaging="false" AllowSorting="true" DataKeyNames="questionid" OnPageIndexChanging="Stringquestions1_PageIndexChanging">
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
                    <br />

                   <ul class="pagination">
                        <a href="Questionnaire_2.aspx" class="btn btn-danger" style="position:relative">&laquo;</a>
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
