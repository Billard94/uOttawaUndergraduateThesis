<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="QuesOption.aspx.cs" Inherits="OSCS.QuesOption" %>

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
        <fieldset class="bg-patient-fieldset">
            <h3 style="text-align: center;">Options For questions</h3>
            <p style="text-align: center;">OSCS</p>
            <!-- Placing GridView in UpdatePanel-->
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>

                    <asp:TextBox ID="txtsearch" runat="server" Height="30px"></asp:TextBox>
                    <asp:LinkButton ID="LBSearch" runat="server" CssClass="btn btn-danger" OnClick="btnsearch_Click">
                        <i class="glyphicon glyphicon-search"></i> </asp:LinkButton>

                    <br />
                    <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>

                    <br />

                    <div id="maindiv" runat="server" style="margin-left: auto; margin-right: auto;">

                        <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnSorting="GridView1_Sorting"
                            DataKeyNames="optionid" CssClass="" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>

                                <asp:TemplateField ItemStyle-Width="130">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnadd" runat="server" CommandName="editRecord" Text='<i class="glyphicon glyphicon-pencil"></i>' CssClass="btn btn-plus btn-xs" ToolTip="Edit Option" />
                                        <asp:LinkButton ID="btnremove" runat="server" CommandName="deleteRecord" Text='<i class="glyphicon glyphicon-remove"></i>' CssClass="btn btn-minus btn-xs" ToolTip="Delete Option" />

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="optionid" HeaderText="ID" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="optiondescription" HeaderText="Option" ItemStyle-Font-Bold="true" SortExpression="optiondescription" />
                                <asp:BoundField DataField="questiondescription" HeaderText="" ItemStyle-Font-Bold="true" SortExpression="questiondescription" />
                            </Columns>
                        </asp:GridView>

                    </div>
                    <asp:LinkButton ID="lbadd" runat="server" CssClass="btn btn-danger" OnClick="btnAdd_Click">
                        <i class="glyphicon glyphicon-plus"></i> </asp:LinkButton>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </fieldset>


        <!-- Add Record Modal Starts here-->
        <div id="addModal" class="modal fade" data-keyboard="false" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
            <div class="vertical-alignment-helper">
                <div class="modal-dialog modal-lg vertical-align-center">


                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="addModalLabel">ADD Option</h3>
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
                                                <asp:Label ID="lbloption" runat="server" Text="Option:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcdesc" runat="server" placeholder="Option" CssClass="form-control" Width="280"></asp:TextBox>
                                            </td>

                                        </tr>


                                        <tr>
                                            <td class="tbl">
                                                <asp:Label ID="lblquestions" runat="server" Text="Location:" Font-Bold="true" Width="120"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlquestions" runat="server" CssClass="form-control" Width="280"></asp:DropDownList>

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
                            <h3 id="editModalLabel">Update Option</h3>
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
                                                <asp:Label ID="lbluoption" runat="server" Text="Option:" Font-Bold="true" Width="120"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtuoption" runat="server" placeholder="Option" CssClass="form-control" Width="280"></asp:TextBox>
                                            </td>

                                        </tr>


                                        <tr>
                                            <td class="tbl">
                                                <asp:Label ID="lbluquestions" runat="server" Text="questions:" Font-Bold="true" Width="120"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddluquestions" runat="server" CssClass="form-control" Width="280"></asp:DropDownList>

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
                            <h3 id="delModalLabel">Delete Option</h3>
                        </div>
                        <asp:UpdatePanel ID="upDel" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    Are you sure you want to delete this option?

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

