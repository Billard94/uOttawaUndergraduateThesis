<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="LoginCredentials.aspx.cs" Inherits="OSCS.LoginCredentials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Online Spinal Consulting System </title>
    <%-- <link runat="server" rel="shortcut icon" href="~/Images/.ico" type="image/x-icon"/>--%>

    <!-- Meta tag Keywords -->
    <!-- css files -->
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
    <!-- Style-CSS -->
    <link rel="stylesheet" href="css/font-awesome.css" />
    <!-- Font-Awesome-Icons-CSS -->
    <!-- //css files -->
    <!-- online-fonts -->
    <link href="//fonts.googleapis.com/css?family=Tangerine:400,700" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />

    <div class="header-w3l">
        <h1>
            <span>Online</span>Spinal
			<span>Consulting</span>System
        </h1>
    </div>
    <!--//header-->

    <div class="row">
        <div class="col-xs-5 col-sm-5 col-md-4 col-lg-4">
        </div>
        <div class="col-xs-2 col-sm-2 col-md-4 col-lg-4">
            
        </div>
        <div class="col-xs-5 col-sm-5 col-md-4 col-lg-4"">
            
        </div>
    </div>

    <div class="main-content-agile">
        <div class="sub-main-w3">
            <%--<asp:form action="#" method="post" runat="server">--%>
            <asp:Label Font-Size="Larger" BackColor="White" Font-Bold="true" Text="Enter registered patient credentials" runat="server"></asp:Label>
            <div class="pom-agile">
                <span class="fa fa-user-o" aria-hidden="true"></span>
                <asp:TextBox ID="txtusername" runat="server" placeholder="Username" class="user"></asp:TextBox>
            </div>
            <div class="pom-agile">
                <span class="fa fa-key" aria-hidden="true"></span>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" class="pass" TextMode="Password"></asp:TextBox>
            </div>
            <div class="sub-w3l">
                <div class="sub-agile">
                    <input type="checkbox" id="brand1" value="" />
                    <label for="brand1">
                        <span></span>Remember me</label>
                </div>
                <div class="clear"></div>
            </div>
            <div class="right-w3l">
                <asp:Button ID="btncheck" runat="server" CssClass="Button1" Text="Submit" OnClick="btncheck_Click" />


                <br />
                <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false" ForeColor="#990000"></asp:Label>
            </div>
            <div class="forgot-w3l">
                <a href="#">Forgot Password?</a>
            </div>
            <%--</asp:form>--%>
        </div>
    </div>

    <div class="main-content-agile">
        <div class="sub-main-w3">
            <%--<asp:form action="#" method="post" runat="server">--%>
            <asp:Label Font-Size="Larger" Font-Bold="true" BackColor="White" Text="Enter your hospital provided Identification Code" runat="server"></asp:Label>
            <div class="pom-agile">
                <span class="fa fa-user-o" aria-hidden="true"></span>
                <asp:TextBox ID="txtHospitalID" runat="server" placeholder="Hospital Identification Code" class="user"></asp:TextBox>
            </div>

            <div class="right-w3l">
                <asp:Button ID="Button1" runat="server" CssClass="Button1" Text="Submit" OnClick="btncheckHospitalD_Click" />
            </div>

            <%--</asp:form>--%>
        </div>
    </div>




</asp:Content>
