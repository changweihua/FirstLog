<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="WriteLog.aspx.cs" Inherits="admin_WriteLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="ueditor/editor_config.js" ></script>
    <script type="text/javascript" src="ueditor/editor_all.js" ></script>
    <link rel="Stylesheet" href="ueditor/themes/default/ueditor.css" />
    <script type="text/javascript">
        var UEditor;
        var UEditor2;
        $(function () {

            UEditor = new baidu.editor.ui.Editor({
                autoHeightEnabled: false,
                initialContent: '这里输入日志正文'
            });
            UEditor.render('uEditor');

            UEditor2 = new baidu.editor.ui.Editor({
                toolbars: [['customstyle', 'paragraph', 'rowspacingtop', 'rowspacingbottom', 'lineheight', 'fontfamily', 'fontsize', 'imagenone', 'imageleft', 'imageright', 'imagecenter'], ['Undo', 'Redo', 'Blod', 'searchreplace', 'link', 'unlink', 'insertunorderedlist', 'insertorderedlist', 'cleardoc', 'selectall', 'preview', '|', 'gmap', 'map', 'webapp', 'insertimage', 'snapscreen', 'spechars', 'blockquote', 'highlightcode', 'emotion', 'attachment'], ['bold', 'italic', 'underline', 'strikethrough', 'forecolor', 'backcolor', 'superscript', 'subscript', 'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', 'directionalityltr', 'directionalityrtl', 'indent', 'removeformat', 'formatmatch', 'autotypeset', 'pasteplain']],
                elementPathEnabled: false,
                autoHeightEnabled: false,
                initialContent: '请输入摘要'
            });
            UEditor2.render('uEditor2');

            $('#showOptions').toggle(function () {
                $(this).css({ 'backgroundImage': 'url(images/icons/up.gif)' });
                $('.options').show('slow');
            }, function () {
                $(this).css({ 'backgroundImage': 'url(images/icons/down.gif)' });
                $('.options').hide('fast');
            });

            $('#<%= txtLogTitle.ClientID %>').val('请输入日志标题').focus().bind('click', function () { if ($(this).val() == '请输入日志标题') { $(this).val(''); } }).blur(function () {
                if ($(this).val() == '') { $(this).val('请输入日志标题'); }
            }); ;

            $('#<%= txtTag.ClientID %>').val('请输入日志标签，逗号或空格分隔').focus(function () { if ($(this).val() == '请输入日志标签，逗号或空格分隔') { $(this).val(''); } }).blur(function () {
                if ($(this).val() == '') { $(this).val('请输入日志标签，逗号或空格分隔'); }
            }); ;

            $('#chooseTag').toggle(function () {
                $(this).css({ 'backgroundImage': 'url(images/icons/up.gif)' });
                $('#tags').show('slow');
                $.ajax({
                    dataType: 'text',
                    async: false, //是否异步传输false，否
                    cache: false, //是否从浏览器中读取缓存
                    type: 'get',
                    success: function (data, textStatus, jqXHR) {
                        var json = eval("(" + data + ")"); //转为JSON对象
                        $.each(json.rows, function (index, item) {
                            var $sp = '<span class="tag">' + item.TagName + '</span>';
                            $('#tags').append($sp);
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("错误状态码" + XMLHttpRequest.status);
                    },
                    url: '<%=VirtualPathUtility.ToAbsolute("~/") %>admin/handlers/TagHandler.ashx'
                });
            }, function () {
                $('#tags').hide('fast');
                $(this).css({ 'backgroundImage': 'url(images/icons/down.gif)' });
            });


            $('span.tag').live('click', function () {
                var txtTag = $('#<%=txtTag.ClientID %>');
                txtTag.focus();
                var t = txtTag.val();
                t = t + ' ' + $(this).text();
                txtTag.val(t);
            });

        });

    </script>

    <style type="text/css">
        .articleWriting
        {}
        
        .articleWriting input
        {
            margin:5px 0;
            height:20px;
            line-height:20px;
        }
        
        .articleWriting select
        {
            margin:5px 0;
            line-height:20px;
        }
       
        #showOptions
        {
            cursor:pointer;
        }
        
        .options
        {
            width:100%;
            display:none;
        }
        
        .options input[type=text]
        {
            width:95%;
        }
        
        .options input[type=checkbox]
        {
            vertical-align:middle;
            margin-right:5px;
            padding-right:10px;
        }
        
        .txtLogTitle
        {
            width:98%;
        }
        
        .txtTag
        {
            width:35%;
        }
        
        .ddlCateogry
        {
            width:30%;
            margin:0;
            padding:0;
        }
        
        .txtPublishDate
        {
            width:30%;    
        }
        
        #chooseTag
        {
            font-weight:bold;
            cursor:pointer;
            vertical-align:middle;
            background-image:url(images/icons/down.gif);
            background-repeat:no-repeat;
            background-position:right;
        }
        
        #tags
        {
            display:none;
            margin-top:5px;
        }
        
        #showOptions
        {
            font-weight:bold; 
            vertical-align:middle;
            background-image:url(images/icons/down.gif);
            background-repeat:no-repeat;
            background-position:right;
        }
        
        .options
        {
            margin:6px 0;
        }
        
        .options span
        {
            font-weight:bold;
        }
        
        .txtQuote
        {
            width:95%;
            height:80px;
            overflow:auto;
        }
        
        .articleWriting input[type=submit]
        {
            width:100px;
            height:30px;
        }
        .tag
        {
            padding:3px;
            display:inline-block;
            margin:3px;
            color:Red;
            cursor:pointer;
        }
        
        .tag:hover
        {
            color:Red;
            cursor:pointer;
            border:1px solid gray;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div class="articleWriting">
            <h3>写日志</h3>
            <asp:TextBox ID="txtLogTitle" CssClass="txtLogTitle" runat="server"></asp:TextBox>
            <div name="content" id="uEditor">    
            </div>
            <asp:TextBox ID="txtTag" CssClass="txtTag" runat="server" ></asp:TextBox>
            <asp:DropDownList ID="ddlCateogry" CssClass="ddlCateogry" runat="server">
            </asp:DropDownList>
            <asp:TextBox ID="txtPublishDate" CssClass="txtPublishDate" runat="server" ></asp:TextBox><br />
            <span id="chooseTag">选择已有标签&nbsp;&nbsp;&nbsp;&nbsp;</span>
            <div id="tags">
                <span class="tag">标签1</span> <span class="tag">标签1</span><span class="tag">标签1</span><span class="tag">标签1</span>
            </div>
            <br />
            <span id="showOptions">高级选项&nbsp;&nbsp;&nbsp;&nbsp;</span>
            <div class="options">
                <span>日志摘要</span>
                <br />
                <div name="summary" id="uEditor2">
                    
                </div>
                <br />
                <span>链接别名</span>
                <br />
                <asp:TextBox ID="txtAlias" runat="server"></asp:TextBox>
                <br />
                <span>引用通告</span>
                <br />
                <asp:TextBox ID="txtQuote" CssClass="txtQuote" TextMode="MultiLine" runat="server"></asp:TextBox>
                <br />
                <span>
                    日志访问密码   
                </span>
                <br />
                <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
                <br />
                <span>
                    其他   
                </span>
                <br />
                <asp:CheckBox ID="cbIsTop" Text="是否置顶" runat="server" />
                <asp:CheckBox ID="cbAllowComment" Text="允许评论" runat="server" />
                <asp:CheckBox ID="cbAllowQuote" Text="允许引用" runat="server" />               
            </div>
            <div style="text-align:center;">
                <asp:Button ID="Button1" runat="server" Text="发布日志" onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="保存草稿" />
            </div>
        </div>
    </form>
</asp:Content>

