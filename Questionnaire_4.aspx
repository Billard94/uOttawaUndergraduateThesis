<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Questionnaire_4.aspx.cs" Inherits="OSCS.Questionnaire_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    h
    <br />



    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <fieldset class="bg-patient-fieldset">
            <%--<h4 style="text-align: center; font-size: xx-large;">DELETE ME The Keele STarT Back Screening Tool</h4>--%>



            <!-- Placing GridView in UpdatePanel-->
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>

                    <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>

                    <br />

                    <div id="maindiv" runat="server" style="margin-left: auto; margin-right: auto; ">
                        <asp:Label ID="lblheader" runat="server" CssClass="blog-large" Font-Bold="true" Font-Size="20" Text="Thinking about the last 2 weeks tick your response to the following questions:"></asp:Label>
                        <asp:HiddenField ID="SelectedGridCellIndex" runat="server" Value="-1" />

                        <asp:GridView ID="gvphq9" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreated" OnSelectedIndexChanged="SelectedIndexChanged"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" OnPageIndexChanging="gvphq9_PageIndexChanging">
                            <Columns>

                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-6 col-sm-6 col-md-6 col-lg-6" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Disagree" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false" ItemStyle-HorizontalAlign="Center">
                                            <asp:ListItem Text="" Value="0">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Agree" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false" ItemStyle-HorizontalAlign="Center">
                                            <asp:ListItem Text="" Value="1">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <br />
                    <br />

                    <div id="DivS" runat="server" style="margin-left: auto; margin-right: auto; ">

                        <asp:HiddenField ID="Hidsec" runat="server" Value="-1" />

                        <asp:GridView ID="GvSec" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedS" OnSelectedIndexChanged="SelectedIndexChangedS"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="GvSec_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-7 col-sm-7 col-md-7 col-lg-7" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Not at all" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="0">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Slightly" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="0">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Moderately" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="0">
                                         
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Very much" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="1">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Extremely" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption5" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="1">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>


                    </div>


                    <br />

                   <ul class="pagination">
                        <a href="Questionnaire_3.aspx" class="btn btn-danger" style="position:relative">&laquo;</a>
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

