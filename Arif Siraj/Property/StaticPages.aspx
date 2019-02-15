﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Property_New.Master" AutoEventWireup="true"
    CodeBehind="StaticPages.aspx.cs" Inherits="Property.StaticPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/style.css" rel="stylesheet" />
<link href="css/style_002.css" rel="stylesheet" />
<link href="slider/css/style.css" rel="stylesheet" />
    <link href="css/shortcodes.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div>
    <div class="wrapper_new">
        <div class="Contact_US">
            <%
                string PgNam = "";
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd;
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = conn;
                int pageid = 0;
                if (Request.QueryString["pageid"] == null)
                    pageid = 17;
                else
                    pageid = int.Parse(Request.QueryString["pageid"].ToString());
                cmd.CommandText = "select * from tbl_PageBlogs where id=" + pageid;
                System.Data.SqlClient.SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    PgNam = dr["PageTitle"].ToString();
            %>
            </div>
            <div class="dt-sc-tabs-container" style="width: 100%;">
                <ul class="dt-sc-tabs-frame">
                    <li><a class="current" href="#">
                        <%=PgNam%></a></li>
                </ul>
                <div style="display: block; width: 100%;" class="dt-sc-tabs-frame-content">
                    <div class="property-type-module medium-module">
                        <div class="blog">
                            <p>
                                <% Response.Write(dr["PageDescription"].ToString()); %>
                        </div>
                        <%    
                            } dr.Close();

                cmd.Dispose();
                conn.Close();
                conn.Dispose();     
                        %>
                    </div>
                </div>
                </div>
        </div>
            </div>
</asp:Content>
