<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Questionnaire_8.aspx.cs" Inherits="OSCS.Questionnaire_8" %>

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

                    <asp:Label Font-Size="Larger" Text="This page asks for your views about your overall clinical health. This information will help keep track of how you feel and how well you are able to do your usual activities." runat="server"></asp:Label>

                    <br />

                    <div id="radio1Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="HidRadio1" runat="server" Value="-1" />


                        <asp:GridView ID="radio1grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedRadio1" OnSelectedIndexChanged="SelectedIndexChangedRadio1"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio1grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="I have no problems in walking about" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have no problems in walking about">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="I have some problems in walking about" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have some problems in walking about">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="I am confined to bed" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I am confined to bed">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>


                    </div>


                    <br />

                    <div id="radio2Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidradio2" runat="server" Value="-1" />


                        <asp:GridView ID="radio2grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio2" OnSelectedIndexChanged="SelectedIndexChangedradio2"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio2grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="I have no problems with self-care" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have no problems with self-care">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="I have some problems washing or dressing myself" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have some problems washing or dressing myself">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="I am unable to wash or dress myself" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I am unable to wash or dress myself">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>


                    </div>


                    <br />

                    <div id="radio3Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidradio3" runat="server" Value="-1" />


                        <asp:GridView ID="radio3grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio3" OnSelectedIndexChanged="SelectedIndexChangedradio3"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio3grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="I have no problems with performing my usual activities" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have no problems with performing my usual activities">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="I have some problems with performing my usual activities" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have some problems with performing my usual activities">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="I am unable to perform my usual activities" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I am unable to perform my usual activities">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                    </div>

                    <br />

                    <div id="radio4Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidradio4" runat="server" Value="-1" />


                        <asp:GridView ID="radio4grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio4" OnSelectedIndexChanged="SelectedIndexChangedradio4"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio4grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="I have no pain or discomfort" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have no pain or discomfort">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="I have moderate pain or discomfort" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have moderate pain or discomfort">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="I have extreme pain or discomfort" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I have extreme pain or discomfort">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <br />

                    <div id="radio5Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidradio5" runat="server" Value="-1" />
                        <asp:GridView ID="radio5grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio5" OnSelectedIndexChanged="SelectedIndexChangedradio5"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio5grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />
                                
                                <asp:TemplateField HeaderText="I am not anxious or depressed" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I am not anxious or depressed">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="I am moderately anxious or depressed" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I am moderately anxious or depressed">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="I am extremely anxious or depressed" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="I am extremely anxious or depressed">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>


                    </div>

                    <br />

                    <div id="radio6Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidradio6" runat="server" Value="-1" />
                        <asp:GridView ID="radio6grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio6" OnSelectedIndexChanged="SelectedIndexChangedradio6"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio6grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField Visible="false" DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Worst imaginable health state" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="0">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="1">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="2">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="3">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption5" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="4">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption6" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="5">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption7" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="6">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption8" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="7">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption9" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="8">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption10" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="9">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Best imaginable health state" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption11" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="10">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>



                            </Columns>
                        </asp:GridView>


                    </div>

                    <br />

                

                    <br />

                    <ul class="pagination">
                        <a href="Questionnaire_7.aspx" class="btn btn-danger" style="position: relative">&laquo;</a>
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

