<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="ViewAllPatients.aspx.cs" Inherits="OSCS.ViewAllPatients" %>

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
         <h3 style="text-align: center;">All Patients</h3>
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
                            DataKeyNames="username" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>

                                <asp:BoundField DataField="username" HeaderText="Username" ItemStyle-CssClass="col-sm-1" ItemStyle-Font-Bold="true" SortExpression="username"  />
                                <asp:BoundField DataField="registeredpatientid" HeaderText="Registered Patient Identification" ItemStyle-CssClass="col-sm-1" ItemStyle-Font-Bold="true" SortExpression="registeredpatientid" />
                                <asp:BoundField DataField="to" HeaderText="Email" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="to" />
                                <asp:BoundField DataField="gender" HeaderText="Gender" ItemStyle-CssClass="col-sm-1" ItemStyle-Font-Bold="true" SortExpression="gender" />
                                <asp:BoundField DataField="DecadeOfBirth" HeaderText="Decade Of Birth" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="DecadeOfBirth" />
                                <asp:BoundField DataField="PostalCodeHome" HeaderText="Postal Code Home" ItemStyle-CssClass="col-sm-1" ItemStyle-Font-Bold="true" SortExpression="PostalCodeHome" />
                                <asp:BoundField DataField="RegisterDate" HeaderText="Registered Date" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="RegisterDate" />
                                <asp:BoundField DataField="requiresurgery" HeaderText="Does patient require surgery" ItemStyle-CssClass="col-sm-1" ItemStyle-Font-Bold="true" SortExpression="requiresurgery" />
                                <asp:BoundField DataField="doctoragrees" HeaderText="Does the doctor agree?" ItemStyle-CssClass="col-sm-1" ItemStyle-Font-Bold="true" SortExpression="doctoragrees" />

                            </Columns>
                        </asp:GridView>

                    </div>
                </fieldset>
                <br />
               </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />

        <br />
        <br />

        <br />
        <asp:UpdatePanel ID="upCrudGrid2" runat="server">
            <ContentTemplate>

                <asp:TextBox ID="txtsearch2" runat="server" Height="30px"></asp:TextBox>
                <asp:LinkButton ID="LBSearch2" runat="server" CssClass="btn btn-danger" OnClick="btnsearch2_Click">
                        <i class="glyphicon glyphicon-search"></i>
                </asp:LinkButton>

                <br />
                <fieldset class="bg-patient-fieldset">
                    <div id="maindiv2" runat="server" style="margin-left: auto; margin-right: auto; ">
                        <asp:GridView ID="Gridview2" runat="server" HorizontalAlign="Center"
                            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnSorting="GridView2_Sorting"
                            DataKeyNames="hospitalpatientid" OnRowCommand="GridView2_RowCommand" OnPageIndexChanging="GridView2_PageIndexChanging">
                            <Columns>

                                <asp:BoundField DataField="hospitalpatientid" HeaderText="Hospital Patient Identification" ItemStyle-CssClass="col-sm-3" ItemStyle-Font-Bold="true" SortExpression="hospitalpatientid" />
                                <asp:BoundField DataField="to" HeaderText="Email" ItemStyle-CssClass="col-sm-3" ItemStyle-Font-Bold="true" SortExpression="to" />
                                <asp:BoundField DataField="requiresurgery" HeaderText="Does patient require surgery?" ItemStyle-CssClass="col-sm-3" ItemStyle-Font-Bold="true" SortExpression="requiresurgery" />
                                <asp:BoundField DataField="doctoragrees" HeaderText="Does the doctor agree?" ItemStyle-CssClass="col-sm-3" ItemStyle-Font-Bold="true" SortExpression="doctoragrees" />

                            </Columns>
                        </asp:GridView>

                    </div>
                </fieldset>
                <br />
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>


    </div>


</asp:Content>


