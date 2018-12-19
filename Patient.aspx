<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="OSCS.Patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function checkIDAvailability() {
            $.ajax({
                type: "POST",
                url: "JqueryAjaxPost.aspx/CheckUserName",
                data: "{IDVal: '" + $("#<% =txtusername.ClientID %>").val() + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                failure: function (AjaxResponse) {
                    document.getElementById("lblresult").innerHTML = "Dfgdfg";
                }
            });
            function onSuccess(AjaxResponse) {
                document.getElementById("lblresult").innerHTML = AjaxResponse.d;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />

    <br />

    <br />
    <br />
    <br />

    <br />

    <br />
    <br />
    <br />

    <br />

    <br />
    <br />
    <br />

    <br />

    <br />
    <br />

    <br />

    <div class="container centered">

        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <fieldset class="bg-patient-fieldset">
                <div class="locationform">
                    <div class="form-horizontal">
                         <fieldset>
                            <legend>Register <i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                                <asp:Label ID="lblname" runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtname" runat="server" placeholder="Full Name" CssClass="form-control" oninvalid="this.setCustomValidity('Please Enter Full Name')" oninput="setCustomValidity('')"></asp:TextBox>
                                </div>
                                <br />

                                <asp:Label ID="lblemail" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtemail" runat="server" placeholder="Email Address" TextMode="Email" CssClass="form-control" required="" oninvalid="this.setCustomValidity('Please Enter Email Address')" oninput="setCustomValidity('')"></asp:TextBox>
                                </div>
                                <br />

                                <asp:Label ID="lblsex" runat="server" Text="Gender" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control" Font-Size="X-Small" Font-Bold="true">
                                        <asp:ListItem Text="SELECT Gender" Value="SELECT Gender" Selected="true" />
                                        <asp:ListItem Text="Male" Value="Male" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                        <asp:ListItem Text="Other" Value="Other" />
                                    </asp:DropDownList>
                                </div>
                                <br />

                                <asp:Label ID="lblpostal" runat="server" Text="Postal" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="postal" runat="server" placeholder="First 3 digits of postal code" CssClass="form-control" required="" oninvalid="this.setCustomValidity('Please Enter Postal Code')" oninput="setCustomValidity('')"></asp:TextBox>
                                </div>
                                <br />

                                <asp:Label ID="lbldecbirth" runat="server" Text="Birth" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="decbirth" runat="server" CssClass="form-control" Font-Size="X-Small" Font-Bold="true">
                                        <asp:ListItem Text="SELECT decade of birthday" Value="SELECT dob" Selected="true" />
                                        <asp:ListItem Text="1900-1909" Value="1900-1909" />
                                        <asp:ListItem Text="1910-1919" Value="1910-1919" />
                                        <asp:ListItem Text="1920-1929" Value="1920-1929" />
                                        <asp:ListItem Text="1930-1939" Value="1930-1939" />
                                        <asp:ListItem Text="1940-1949" Value="1940-1949" />
                                        <asp:ListItem Text="1950-1959" Value="1950-1959" />
                                        <asp:ListItem Text="1960-1969" Value="1960-1969" />
                                        <asp:ListItem Text="1970-1979" Value="1970-1979" />
                                        <asp:ListItem Text="1980-1989" Value="1980-1989" />
                                        <asp:ListItem Text="1990-1999" Value="1990-1999" />
                                        <asp:ListItem Text="2000-2009" Value="2000-2009" />
                                    </asp:DropDownList>
                                </div>
                                <br />

                                <asp:Label ID="lblusername" runat="server" Text="Username" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtusername" runat="server" placeholder="Username" CssClass="form-control" required="" oninvalid="this.setCustomValidity('Please Enter username')" oninput="setCustomValidity('')"></asp:TextBox>
                                    <asp:Label ID="lblresult" runat="server" Text="" CssClass="col-lg-2 control-label"></asp:Label>

                                </div>
                                <br />

                                <asp:Label ID="lblpassword" runat="server" Text="Password" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtpassword" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control" required="" oninvalid="this.setCustomValidity('Please Enter Password')" oninput="setCustomValidity('')"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger" Text="Submit" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Cancel" />

                                    <br />
                                    <asp:Label ID="lblerrormain" runat="server" CssClass="alert-danger" Font-Bold="true" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </fieldset>
        </div>

    </div>

</asp:Content>
