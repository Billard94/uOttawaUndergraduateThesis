<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="OSCS.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

     <div class="row">
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
        </div>
        <div class="col-xs-1 col-sm-6 col-md-4 col-lg-4">
             <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" Text="Question Management" runat="server" Style="float: right; width: 100%; text-wrap: normal; initial-letter-wrap: first; overflow-wrap: break-word"
                OnClick="btnQuestion_Click">
            </asp:LinkButton>
        </div>
        <div class="col-xs-10 col-sm-3 col-md-4 col-lg-4">
        </div>
    </div>

    <br />

    <br />

     <div class="row">
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
        </div>
        <div class="col-xs-10 col-sm-6 col-md-4 col-lg-4">
            <asp:LinkButton ID="LinkButton3" CssClass="btn btn-danger" Text="Option Management" runat="server" Style="float: right; width: 100%; text-wrap: normal; initial-letter-wrap: first; overflow-wrap: break-word"
                OnClick="btnOption_Click">
            </asp:LinkButton>
        </div>
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
           
        </div>
    </div>

    <br />

    <br />

     <div class="row">
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
        </div>
        <div class="col-xs-10 col-sm-6 col-md-4 col-lg-4">
            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger" Text="View all Patients" runat="server" Style="float: right; width: 100%; text-wrap: normal; initial-letter-wrap: first; overflow-wrap: break-word"
                OnClick="btnPatients_Click">
            </asp:LinkButton>
        </div>
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
            
        </div>
    </div>



    <br />

    <br />

     <div class="row">
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
        </div>
        <div class="col-xs-10 col-sm-6 col-md-4 col-lg-4">
            <asp:LinkButton ID="LinkButton4" CssClass="btn btn-danger" Text="View all Answers" runat="server" Style="float: right; width: 100%; text-wrap: normal; initial-letter-wrap: first; overflow-wrap: break-word"
                OnClick="btnAnswers_Click">
            </asp:LinkButton>
        </div>
        <div class="col-xs-1 col-sm-3 col-md-4 col-lg-4">
            
        </div>
    </div>



    <br />
    <br />
    <br />
    <br />
    <br />
    <br />



</asp:Content>

