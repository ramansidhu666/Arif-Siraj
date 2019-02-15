﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactInfo.ascx.cs"
    Inherits="Property.ContactInfo" %>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../slider/css/style.css" rel="stylesheet" />
    <link href="../css/style_002.css" rel="stylesheet" />
    <link href="../css/shortcodes.css" rel="stylesheet" />
<h2>
    Contact Info</h2>
<div class="agent_input">
    <p>
        First Name:<%--<asp:RequiredFieldValidator  ID="reqFirstName" runat="server" ErrorMessage="*"
            ControlToValidate="txtFirstName" ValidationGroup="SaveContactInfo" ForeColor="Red"
            Display="Dynamic"></asp:RequiredFieldValidator>--%>
    </p>
    <asp:TextBox ID="txtFirstName" CssClass="CTextBox" runat="server" PlaceHolder="First Name" MaxLength="20" Display="Dynamic"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ValidationGroup="SaveContactInfo" runat="server" Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="First Name required" SetFocusOnError="true"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="SaveContactInfo"
        ControlToValidate="txtFirstName" ErrorMessage="Only alphabets are allowed"
        ForeColor="Red" ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"> </asp:RegularExpressionValidator>
</div>
<div class="agent_input">
    <p>
        Last Name:
        <%--<asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="*" ControlToValidate="txtLastName"
            ValidationGroup="SaveContactInfo" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
    </p>
    <asp:TextBox ID="txtLastName" CssClass="CTextBox" MaxLength="20" runat="server" PlaceHolder="Last Name" Display="Dynamic"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="SaveContactInfo" ForeColor="Red" runat="server" Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="Last Name required" SetFocusOnError="true"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
        ControlToValidate="txtLastName" ErrorMessage="Only alphabets are allowed" ValidationGroup="SaveContactInfo"
        ForeColor="Red" ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"> </asp:RegularExpressionValidator>
</div>
<div class="agent_input">
    <p>
        E-mail:
    <asp:TextBox ID="txtEmail" CssClass="CTextBox" runat="server" PlaceHolder="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" ForeColor="Red" runat="server" ValidationGroup="SaveContactInfo" ControlToValidate="txtEmail" ErrorMessage="EmailID required" SetFocusOnError="true"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="rgeEmail" runat="server" ValidationGroup="SaveContactInfo" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
</div>
<div class="agent_input">
    <p>
        Phone Number:      
    <asp:TextBox ID="txtPhoneno" CssClass="CTextBox" runat="server" PlaceHolder="Phone Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" runat="server" ValidationGroup="SaveContactInfo" Display="Dynamic" ControlToValidate="txtPhoneno" ErrorMessage="Phone No. required" SetFocusOnError="true"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="regPhone" ValidationGroup="SaveContactInfo" runat="server" ControlToValidate="txtPhoneno" Display="Dynamic"
            ValidationExpression="^(\(\d{3}\) \d{3}-\d{4}|\d{3}-\d{3}-\d{4}|\d{10})$"
            Text="Enter a valid phone number" ForeColor="Red" />
</div>
<div class="agent_input">
    <p>
        Message
    </p>
    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="90px" PlaceHolder="Message"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Message Required"
        ControlToValidate="txtMessage" ValidationGroup="SaveContactInfo" ForeColor="Red"
        Display="Dynamic"></asp:RequiredFieldValidator>
</div>
<div style="margin: 0 0 50px 0">
    <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="Sendbutton" Width="24%"
        UseSubmitBehavior="false" ValidationGroup="SaveContactInfo" OnClick="btnSend_Click" />
</div>

