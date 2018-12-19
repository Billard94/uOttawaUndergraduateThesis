<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Questionnaire_6.aspx.cs" Inherits="OSCS.Questionnaire_6" %>

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
            <%--<h4 style="text-align: center; font-size: xx-large;">DELETE ME The Keele STarT Back Screening Tool</h4>--%>



            <!-- Placing GridView in UpdatePanel-->
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>

                    <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>

                    <br />


                    <br />

                    <div id="radio1Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="HidRadio1" runat="server" Value="-1" />

                        <asp:Label Text="On average, over the past 4 weeks, select how bad it is in your:" runat="server"></asp:Label>

                        <asp:GridView ID="radio1grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedRadio1" OnSelectedIndexChanged="SelectedIndexChangedRadio1"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio1grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-6 col-sm-6 col-md-6 col-lg-6" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="None" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="None">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Very Mild" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="Very Mild">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Mild" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="Mild">
                                         
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Moderate" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="Moderate">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Severe" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption5" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="Severe">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Very Severe" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption6" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="Very Severe">
                                         
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

                    <div id="radio2Div" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:HiddenField ID="Hidradio2" runat="server" Value="-1" />

                        <asp:GridView ID="radio2grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio2" OnSelectedIndexChanged="SelectedIndexChangedradio2"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio2grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-5 col-sm-5 col-md-5 col-lg-5" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="The pain is 100% in my neck compared to 0% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="The pain is 100% in my neck compared to 0% in my arms">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 80% in my neck compared to 20% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 80% in my neck compared to 20% in my arms">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="The pain is 60% in my neck compared to 40% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 60% in my neck compared to 40% in my arms">
                                         
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 50% in my neck compared to 50% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 50% in my neck compared to 50% in my arms">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 40% in my neck compared to 60% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption5" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 40% in my neck compared to 60% in my arms">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="The pain is 20% in my neck compared to 80% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption6" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 20% in my neck compared to 80% in my arms">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 0% in my neck compared to 100% in my arms" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption7" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 0% in my neck compared to 100% in my arms">
                                         
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
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-5 col-sm-5 col-md-5 col-lg-5" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="The pain is 100% in my back compared to 0% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">

                                            <asp:ListItem Text="" Value="The pain is 100% in my back compared to 0% in my legs">
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 80% in my back compared to 20% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 80% in my back compared to 20% in my legs">
                                         
                                            </asp:ListItem>



                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="The pain is 60% in my back compared to 40% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 60% in my back compared to 40% in my legs">
                                         
                                            </asp:ListItem>

                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 50% in my back compared to 50% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 50% in my back compared to 50% in my legs">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 40% in my back compared to 60% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption5" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 40% in my back compared to 60% in my legs">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="The pain is 20% in my back compared to 80% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption6" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 20% in my back compared to 80% in my legs">
                                         
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="The pain is 0% in my back compared to 100% in my legs" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption7" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">


                                            <asp:ListItem Text="" Value="The pain is 0% in my back compared to 100% in my legs">
                                         
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

                        <asp:Label Font-Size="Large" Text="Please check the box which is most correct for the problem you are having " runat="server"></asp:Label>

                        <asp:GridView ID="radio4grid" runat="server" HorizontalAlign="Center" OnRowCreated="OnRowCreatedradio4" OnSelectedIndexChanged="SelectedIndexChangedradio4"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" DataKeyNames="questionid" CssClass="" OnPageIndexChanging="radio4grid_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" HeaderStyle-CssClass="text-center text-danger" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="col-xs-4 col-sm-4 col-md-4 col-lg-4" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="large" />

                                <asp:TemplateField HeaderText="Neck" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption1" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="Neck">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Arm(s)" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption2" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="Arm(s)">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Back" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption3" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="Back">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Leg(s)" HeaderStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-danger" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="cbloption4" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="" Value="Leg(s)">
                                            </asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                    </div>

                   
                    <br />

                    <ul class="pagination">
                        <a href="Questionnaire_5.aspx" class="btn btn-danger" style="position: relative">&laquo;</a>
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

