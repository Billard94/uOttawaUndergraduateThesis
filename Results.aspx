<%@ Page Title="" Language="C#" MasterPageFile="~/Mastermain.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="OSCS.Results" %>

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



                    <div id="smokes" runat="server" style="margin-left: auto; margin-right: auto;" class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <label>Due to your choice to smoke cigarettes, please visit this link:</label>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <a href="https://www.ottawaheart.ca/clinic/quit-smoking-program">Ottawa Heart Institude Cessation Program </a></label>
                            </div>
                        </div>
                    </div>
                    <br />

                    <br />
                    <br />
                    <div id="WalkingStanding" visible="false" runat="server" style="margin-left: auto; margin-right: auto;" class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">


                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <label>Due to your pain whilst walking or standing, we recommend:</label>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <label>Stationary Bike Exercises</label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div id="SittingBendingForward" visible="false" runat="server" style="margin-left: auto; margin-right: auto;" class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <label>Due to your pain whilst sitting or bending forward, we recommend:</label>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                <label>Walking Exercises</label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            <label>For all patients, we recommend:</label>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            <a href="http://manippt.org">Manipulative Therapy for high quality physiotherapy links </a></label>
                        </div>
                    </div>
                    <%--</div>--%>




                    <br />




                    <br />
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </fieldset>

    </div>

</asp:Content>

