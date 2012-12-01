<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .infoBlock
        {
           width:300px;
           height:500px;
           overflow:hidden; 
        }     
        .infotTitle
        {
            background-color:#F4F4F4; 
        } 
        .fullWidth
        {
            width:100%;
            margin:0;
            padding:0;
            border:none;
            text-align:left;
        }
        dt.fullWidth
        {
            background:none;
            color:Black;
            background-color:Gray;
            font-size:larger;
        }
        dd.fullWidth
        {
            border-bottom:1px dotted Gray;
            padding:3px 0;
            margin:3px 0;
            background-color:transparent;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    小贴士<hr />
    碎语<hr />
    <div>
        <div class="infoBlock" style="float:left;">
           <dl class="fullWidth">
                <dt  class="fullWidth">11111</dt>
                <dd  class="fullWidth">111111</dd>
                <dd  class="fullWidth">111111</dd>
                <dd  class="fullWidth">111111</dd>
           </dl>
        </div>
        <div class="infoBlock" style="float:right;">
            <dl class="fullWidth">
                <dt class="fullWidth">11111</dt>
                <dd  class="fullWidth">111111</dd>
                <dd  class="fullWidth">111111</dd>
                <dd  class="fullWidth">111111</dd>
           </dl>
        </div>
    </div>
</asp:Content>

