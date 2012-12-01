<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
    <link rel="Stylesheet" href="lib/ligerUI/skins/Aqua/css/ligerui-all.css" />
    <script type="text/javascript" src="lib/jquery/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="lib/ligerUI/js/core/base.js"></script>
    <script type="text/javascript" src="lib/ligerUI/js/plugins/ligerLayout.js"></script>
    <script type="text/javascript" src="lib/ligerUI/js/plugins/ligerTab.js"></script>
   <%-- <script type="text/javascript" src="lib/ligerUI/js/plugins/ligerMenu.js"></script>
    <script type="text/javascript" src="lib/ligerUI/js/plugins/ligerDrag.js"></script>--%>

    <script type="text/javascript">
        $(function () {
            //Layout
            $("#layout1").ligerLayout({ leftWidth: 200,  allowLeftResize: false });
            var layoutManager = $('#layout1').ligerGetLayoutManager();
            //Tab
            $('#tab1').ligerTab({ height: $('#framecenter').height() });
            var tabManager = $('#tab1').ligerGetTabManager();

        });
    </script>
    <style type="text/css">

    </style>
</head>
<body>
    <div id="layout1"> 
        <div position="top">
            <div style="margin-top: 10px; margin-left: 10px">博客后台管理</div>
        </div>
        <div position="left" id="accordion1">
            <div>123123123</div>
        </div>
        <div position="center" id="framecenter">
            <div id="tab1">
                <div title="标签1">
                   <iframe src="main.aspx" style="height:100%;width:100%;"></iframe>
                </div>
                <div title="标签2">
                    <p>内容2</p>
                </div>
                <div title="标签3">
                    <iframe src="http://www.cmono.net" width="100%" height="100%" ></iframe>
                </div>
            </div>
        </div>
        <%--<div position="right">
            123
        </div>
        <div position="bottom">
            <div>123123123</div>
        </div>--%>
    </div>
</body>
</html>
