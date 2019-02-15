﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Property.Master" AutoEventWireup="true" CodeBehind="Testimonial.aspx.cs" Inherits="Property.Testimonial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="slider/css/bootstrap.min.css" rel="stylesheet" />
    <link href="slider/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="slider/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="slider/css/media-queries.css" rel="stylesheet" />
    <link href="slider/css/font.css" rel="stylesheet" />
    <link href="slider/css/style.css" rel="stylesheet" />
    <link href="css/shortcodes.css" rel="stylesheet" />
    <link href="slider/css/font-awesome.css" rel="stylesheet" />
    <script src="slider/js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="js/jssor.js"></script>
    <script type="text/javascript" src="js/jssor.slider.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div class="Free-Home_new">
            <div class="property-search-container">
                <div class="dt-sc-tabs-container" style="width: 100%;">
                    <ul class="dt-sc-tabs-frame">
                        <li><a class="current" href="#">Testimonials</a></li>
                    </ul>
                    <div style="display: block;" class="dt-sc-tabs-frame-content">
                        <div class="Free-Home_new">
<div id="comsoon" runat="server" class="comin_soon">
    <img alt="" src="images/cming_soon.png" />
</div>
                  <asp:Repeater ID="grdTestimonials" runat="server"  OnItemDataBound="grdTestimonials_ItemDataBound" >
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                          <div class="test_bg">
                                <div  class="comments">
                                    <asp:Label ID="lbllink" CssClass="lblcomment" Text='<%# Eval("comments") %>' runat="server"></asp:Label>
                                </div>
                                <div class="name" >
                                    <asp:Label ID="lblby" Text="By" runat="server"></asp:Label>
                                    <%-- <span>$<%# Eval("ListPrice")%></span>--%>
                                    <span ><%# Eval("FirstName") %> <%# Eval("LastName") %></span>
                                 <%--   <asp:Label ID="lblname"  CssClass="lblname"  runat="server"></asp:Label>--%>
                                </div>
                     </div>
                      
                    </ItemTemplate>
                </asp:Repeater>
                        
                               </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



</asp:Content>
