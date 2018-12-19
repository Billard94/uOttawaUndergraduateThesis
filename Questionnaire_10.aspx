<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Questionnaire_10.aspx.cs" Inherits="OSCS.Questionnaire_10" %>

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

                    <div id="yesno1Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidyesno1" runat="server" Value="-1" />

                        <asp:Label Text="On average, over the past 4 weeks, select how bad it is in your:" runat="server"></asp:Label>

                        <asp:GridView ID="yesno1grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedyesno1" OnSelectedIndexChanged="SelectedIndexChangedyesno1"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="yesno1grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-8 col-sm-8 col-md-8 col-lg-8" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Yes" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="Yes">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="No">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>


                    </div>


                    <br />

                     <div id="textdiv1" runat="server" style="margin-left: auto; margin-right: auto;">
                        <asp:HiddenField ID="SelectedGridCellIndexText1" runat="server" Value="-1" />
                        
                        <asp:GridView ID="Stringquestions1" runat="server" HorizontalAlign="Center" 
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid">
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
                        <a href="Questionnaire_4.aspx" class="btn btn-danger" style="position: relative">&laquo;</a>
                        <asp:LinkButton ID="lbadd" Text="" runat="server" CssClass="btn btn-danger" Style="position: relative" OnClick="btnAdd_Click">
                            Results </asp:LinkButton>
                    </ul>
                    <br />
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </fieldset>

    </div>

</asp:Content>

