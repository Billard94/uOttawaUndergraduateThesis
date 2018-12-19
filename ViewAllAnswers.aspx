<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="ViewAllAnswers.aspx.cs" Inherits="OSCS.ViewAllAnswers" %>

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
         <h3 style="text-align: center;">Patients Answers</h3>
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

                                <asp:BoundField DataField="questionid" HeaderText="ID" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" Visible="false" />
                                <asp:BoundField DataField="questiontype" HeaderText="Type" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="questiontype" />
                                <asp:BoundField DataField="questiondescription" HeaderText="Question" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="questiondescription" />
                                <asp:BoundField DataField="answer" HeaderText="Answer" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="answer" />
                                <asp:BoundField DataField="HospitalPatientID" HeaderText="HospitalPatientID" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="HospitalPatientID" />
                                <asp:BoundField DataField="RegisteredPatientID" HeaderText="RegisteredPatientID" ItemStyle-CssClass="col-sm-2" ItemStyle-Font-Bold="true" SortExpression="RegisteredPatientID" />

                            </Columns>
                        </asp:GridView>

                    </div>
                </fieldset>
                <br />
               <%-- <asp:LinkButton ID="lbadd" runat="server" CssClass="btn btn-danger" OnClick="btnAdd_Click">
                        <i class="glyphicon glyphicon-plus"></i> </asp:LinkButton>--%>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>


</asp:Content>

