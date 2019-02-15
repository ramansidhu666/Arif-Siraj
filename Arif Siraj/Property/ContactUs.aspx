﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Property_New.Master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="Property.ContactUs" %>
<%@ Register TagName="ContactInfo" TagPrefix="uc" Src="~/Controls/ContactInfo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <link href="slider/css/style.css" rel="stylesheet" />
    <link href="css/style_002.css" rel="stylesheet" />
    <link href="css/font.css" rel="stylesheet" />
    <link href="css/shortcodes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="wrapper_new">
            <div class="Free-Home_new">
                <div class="col-md-6 col-sm-6">
                    <div class="contact_in_left">
                        <uc:ContactInfo ID="ContactInfo" runat="Server"></uc:ContactInfo>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="contact_in_right">
                        <img src="images/contct_img.png" alt="" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
