<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="questions.aspx.cs" Inherits="OSCS.questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal-backdrop {
            background-color: green;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
      <br />
        <br />
        <br />

        <br />

        <br />
        <h3 style="text-align: center;">Questions</h3>
         <p style="text-align: center;">OSCS</p>
        <!-- Placing GridView in UpdatePanel-->
        <asp:UpdatePanel ID="upCrudGrid" runat="server">
            <ContentTemplate>

                <asp:TextBox ID="txtsearch" runat="server" Height="30px"></asp:TextBox>
                <asp:LinkButton ID="LBSearch" runat="server" CssClass="btn btn-danger" OnClick="btnsearch_Click">
                        <i class="glyphicon glyphicon-search"></i>
                </asp:LinkButton>

                <br />
                <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>

                <br />
                <fieldset class="bg-patient-fieldset">
                    <div id="maindiv" runat="server" style="margin-left: auto; margin-right: auto; ">
                        <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnSorting="GridView1_Sorting"
                            DataKeyNames="questionid" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>

                                <asp:TemplateField ItemStyle-CssClass="col-sm-2">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnadd" runat="server" CommandName="editRecord" Text='<i class="glyphicon glyphicon-pencil"></i>' CssClass="btn btn-plus btn-xs" ToolTip="Edit questions" />
                                        <asp:LinkButton ID="btnremove" runat="server" CommandName="deleteRecord" Text='<i class="glyphicon glyphicon-remove"></i>' CssClass="btn btn-minus btn-xs" ToolTip="Delete questions" />

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" ItemStyle-CssClass="col-sm-4" ItemStyle-Font-Bold="true" SortExpression="questiondescription" />
                                <asp:BoundField DataField="questiontype" HeaderText="Type" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="questiontype" />
                                <asp:BoundField DataField="questionorder" HeaderText="Order" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="questionorder" />

                            </Columns>
                        </asp:GridView>

                    </div>
                </fieldset>
                <br />
                <asp:LinkButton ID="lbadd" runat="server" CssClass="btn btn-danger" OnClick="btnAdd_Click">
                        <i class="glyphicon glyphicon-plus"></i> </asp:LinkButton>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>


        <!-- Add Record Modal Starts here-->
        <div id="addModal" class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="vertical-alignment-helper">
                <div class="modal-dialog modal-lg vertical-align-center">


                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="addModalLabel">ADD questions</h3>
                        </div>
                        <asp:UpdatePanel ID="upAdd" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <table class="table table-bordered table-hover table-condensed ">

                                        <tr>
                                            <td>

                                                <asp:Label ID="lblid" runat="server" Text="ID:" Font-Bold="true" Width="120"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtcid" runat="server" CssClass="form-control" Width="280" Enabled="false"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblccode" runat="server" Text="questions:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtccode" runat="server" placeholder="questions" CssClass="form-control" Width="280" TextMode="MultiLine"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbltype" runat="server" Text="Type:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control" Font-Size="X-Small" Font-Bold="true" Width="280">
                                                    <asp:ListItem Text="SELECT Type" Value="SELECT Type" Selected="true" />
                                                    <asp:ListItem Text="General" Value="General" />
                                                    <asp:ListItem Text="Treatment" Value="Treatment" />
                                                    <asp:ListItem Text="Keele" Value="Keele" />
                                                    <asp:ListItem Text="PHQ9" Value="PHQ9" />
                                                    <asp:ListItem Text="PainHistory" Value="PainHistory" />
                                                    <asp:ListItem Text="EQ" Value="EQ" />
                                                    <asp:ListItem Text="GodinShepard" Value="GodinShepard" />
                                                    <asp:ListItem Text="IPAQ" Value="IPAQ" />

                                                </asp:DropDownList>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblgroup" runat="server" Text="Group:" Font-Bold="true" Width="120"></asp:Label></td>

                                            <td>
                                                <asp:DropDownList ID="ddlgroup" runat="server" CssClass="form-control" Font-Size="X-Small" Font-Bold="true" Width="280">
                                                    <asp:ListItem Text="SELECT Type" Value="SELECT Type" Selected="true" />
                                                    <asp:ListItem Text="YesNo" Value="1" />
                                                    <asp:ListItem Text="Radio" Value="2" />
                                                    <asp:ListItem Text="Text" Value="3" />
                                                    <asp:ListItem Text="Checkbox" Value="4" />
                                

                                                </asp:DropDownList>
                                            </td>
                                           

                                        </tr>

                                          <tr>
                                            <td>
                                                <asp:Label ID="lblorder" runat="server" Text="Order:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtorder" runat="server" placeholder="questions" CssClass="form-control" Width="280" TextMode="MultiLine"></asp:TextBox>
                                            </td>

                                        </tr>





                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                                    <asp:Button ID="btnAddRecord" runat="server" Text="ADD" CssClass="btn btn-info" OnClick="btnAddRecord_Click" />
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddRecord" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <!--Add Record Modal Ends here-->


        <!-- Edit Modal Starts here -->
        <div id="editModal" class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
            <div class="vertical-alignment-helper">
                <div class="modal-dialog modal-lg vertical-align-center">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="editModalLabel">Update</h3>
                        </div>
                        <asp:UpdatePanel ID="upEdit" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <table class="table table-bordered table-hover table-condensed ">

                                        <tr>
                                            <td>

                                                <asp:Label ID="lbluid" runat="server" Text="ID:" Font-Bold="true" Width="120"></asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="txtuid" runat="server" CssClass="form-control" Width="280" Enabled="false"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblucode" runat="server" Text="questions:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtucode" runat="server" placeholder="questions" CssClass="form-control" Width="480" TextMode="MultiLine"></asp:TextBox>
                                            </td>

                                        </tr>


                                        <tr>
                                            <td>
                                                <asp:Label ID="lblutpye" runat="server" Text="Type:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlutype" runat="server" CssClass="form-control" Font-Size="X-Small" Font-Bold="true" Width="280">
                                                    <asp:ListItem Text="SELECT Type" Value="SELECT Type" Selected="true" />
                                                    <asp:ListItem Text="PHQ - 9" Value="PHQ - 9" />
                                                    <asp:ListItem Text="SelfAssessment" Value="SelfAssessment" />


                                                </asp:DropDownList>
                                            </td>

                                        </tr>



                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                                    <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnSave_Click" />
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>
        <!-- Edit Modal Ends here -->

        <!-- Delete Record Modal Starts here-->
        <div id="deleteModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="delModalLabel" aria-hidden="true">
            <div class="vertical-alignment-helper">

                <div class="modal-dialog vertical-align-center">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="delModalLabel">Delete questions</h3>
                        </div>
                        <asp:UpdatePanel ID="upDel" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    Are you sure you would like to delete this questions?

                              <br />
                                    <asp:Label ID="lbldelete" CssClass="alert-danger" Visible="false" runat="server"></asp:Label>

                                    <asp:HiddenField ID="hfCode" runat="server" />
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-info" OnClick="btnDelete_Click" />
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <!--Delete Record Modal Ends here -->


    </div>


</asp:Content>

