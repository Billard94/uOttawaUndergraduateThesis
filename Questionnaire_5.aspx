<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Questionnaire_5.aspx.cs" Inherits="OSCS.Questionnaire_5" %>

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



            <!-- Placing GridView in UpdatePanel-->
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>

                    <br />


                    <br />

                    <div id="radio1Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="HidRadio1" runat="server" Value="-1" />

                        <asp:Label font-bold="true" Font-Size="Larger" Text="On average, over the past 4 weeks, select how bad it is in your:" runat="server"></asp:Label>

                        <asp:GridView ID="radio1grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedRadio1" OnSelectedIndexChanged="SelectedIndexChangedRadio1"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio1grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-8 col-sm-8 col-md-8 col-lg-8" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Not at all" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="1">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Several Day" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="2">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="More than half the days" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="2">
                                         
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Nearly every day" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="3">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                    </div>


                    <br />


                    <div id="radio2Div" runat="server" style="margin-left: auto; margin-right: auto; ">

                        <asp:HiddenField ID="Hidradio2" runat="server" Value="-1" />

                        <asp:Label Text="If you checked off any problems, how difficult have these problems made it for you to do your work, take care of things at home, or get along with other people?:" runat="server"></asp:Label>

                        <asp:GridView ID="radio2grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio2" OnSelectedIndexChanged="SelectedIndexChangedradio2"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio2grid_PageIndexChanging">
                  
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-8 col-sm-8 col-md-8 col-lg-8" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Not difficult at all" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="0">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Somewhat difficult" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="1">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Very Difficult" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="3">
                                         
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Extremely difficult" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="4">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                    </div>

                    <br />



                    <ul class="pagination">
                        <a href="Questionnaire_4.aspx" class="btn btn-danger" style="position: relative">&laquo;</a>
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

