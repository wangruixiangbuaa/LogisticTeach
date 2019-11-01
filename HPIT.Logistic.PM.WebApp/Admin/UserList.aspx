<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HPIT.Logistic.PM.WebApp.Admin.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no" name="viewport">
    <link rel="stylesheet" href="../plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../plugins/ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="../plugins/iCheck/square/blue.css">
    <link rel="stylesheet" href="../plugins/morris/morris.css">
    <link rel="stylesheet" href="../plugins/jvectormap/jquery-jvectormap-1.2.2.css">
    <link rel="stylesheet" href="../plugins/datepicker/datepicker3.css">
    <link rel="stylesheet" href="../plugins/daterangepicker/daterangepicker.css">
    <link rel="stylesheet" href="../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
    <link rel="stylesheet" href="../plugins/datatables/dataTables.bootstrap.css">
    <link rel="stylesheet" href="../plugins/treeTable/jquery.treetable.css">
    <link rel="stylesheet" href="../plugins/treeTable/jquery.treetable.theme.default.css">
    <link rel="stylesheet" href="../plugins/select2/select2.css">
    <link rel="stylesheet" href="../plugins/colorpicker/bootstrap-colorpicker.min.css">
    <link rel="stylesheet" href="../plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
    <link rel="stylesheet" href="../plugins/adminLTE/css/AdminLTE.css">
    <link rel="stylesheet" href="../plugins/adminLTE/css/skins/_all-skins.min.css">
    <link rel="stylesheet" href="../css/style.css"/>
    <link rel="stylesheet" href="../plugins/ionslider/ion.rangeSlider.css" />
    <link rel="stylesheet" href="../plugins/ionslider/ion.rangeSlider.skinNice.css" />
    <link rel="stylesheet" href="../plugins/bootstrap-slider/slider.css" />
    <link rel="stylesheet" href="../plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.css" />
     <style>
         .has-feedback ul {
            list-style:none;
            margin-right:-148px;
         }
         .has-feedback ul li {
            float:left;
            width:270px;
            margin-left:5px;
         }
         .has-feedback ul li label {
            float:left;
            margin-top:4px;
            margin-right: -33px;
         }
         .has-feedback ul li input {
            float:left;
            width:170px;
         }
          .has-feedback ul li input[type=submit] {
            float:left;
            width:100px;
            height:31px;
         }
          .has-feedback ul li select {
            float:left;
            width:170px;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
           <!-- 内容头部 -->
            <section class="content-header">
                <h1>
                    <small>用户列表</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                    <li><a href="#">用户管理</a></li>
                    <li class="active">用户列表</li>
                </ol>
            </section>
            <!-- 内容头部 /-->

            <!-- 正文区域 -->
            <section class="content">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">用户列表</h3>
                    </div>
                   <%-- <a href="AddUser.aspx" target="_blank">添加用户</a>--%>
                    <div class="box-body">
                        <div class="pull-left">
                                <div class="form-group form-inline">
                                    <div class="btn-group">
                                        <a href="AddUser.aspx" class="btn btn-default" target="_self">添加用户</a><br/>
                                    </div>
                                </div>
                            </div>
                            <div class="box-tools pull-right">
                                <div class="has-feedback">
                                    <ul>
                                     <li><label>账号：</label> <asp:TextBox ID="TextBox_Account"  CssClass="form-control input-sm searchInput" runat="server"></asp:TextBox></li>
                                     <li><label>出生日期：</label> <asp:TextBox ID="TextBox_CreateTime"  CssClass="form-control input-sm searchInput" runat="server"></asp:TextBox></li>
                                     <li><label>角色类型：</label> <asp:DropDownList ID="DropDownList_Roles" CssClass="form-control input-sm searchInput" runat="server"></asp:DropDownList></li>
                                     <li><asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="查询" OnClick="Button1_Click" /></li>
                                     </ul>
                                </div>
                            </div>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                         <tr>
                             <th>头像</th>
                             <th>真实姓名</th>
                             <th>账号</th>
                             <th>性别</th>
                             <th>电话</th>
                             <th>角色名</th>
                             <th>创建时间</th>
                             <th style="width:200px;text-align:center;">操作</th>
                         </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                             <td><img src='/Handlers/GetImage.ashx?path=<%#Eval("ImagePath")%>' style="width:60px;height:60px;" /></td>
                             <td><%#Eval("UserName")%></td>
                             <td><%#Eval("Account")%></td>
                             <td><%# (int)Eval("Sex")==0 ? "男":"女" %></td>
                             <td><%#Eval("Phone")%></td>
                             <td><%#Eval("RoleName")%></td>
                             <td><%#Eval("CheckInTime")%></td>
                             <td style="text-align:center;">
                                 <asp:LinkButton ID="LinkButton1" CssClass="btn bg-olive btn-xs" runat="server" CommandName="update" CommandArgument='<%#Eval("UserID")%>'>编辑</asp:LinkButton>
                                 <asp:LinkButton ID="LinkButton2" CssClass="btn bg-olive btn-xs" runat="server" CommandName="delete" CommandArgument='<%#Eval("UserID")%>'>删除</asp:LinkButton>
                             </td>
                           </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                        </table>
                        </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </section>
    <script src="../plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="../plugins/jQueryUI/jquery-ui.min.js"></script>
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>
    <script src="../plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="../plugins/raphael/raphael-min.js"></script>
    <script src="../plugins/morris/morris.min.js"></script>
    <script src="../plugins/sparkline/jquery.sparkline.min.js"></script>
    <script src="../plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="../plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <script src="../plugins/knob/jquery.knob.js"></script>
    <script src="../plugins/daterangepicker/moment.min.js"></script>
    <script src="../plugins/daterangepicker/daterangepicker.js"></script>
    <script src="../plugins/daterangepicker/daterangepicker.zh-CN.js"></script>
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../plugins/datepicker/locales/bootstrap-datepicker.zh-CN.js"></script>
    <script src="../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <script src="../plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <script src="../plugins/fastclick/fastclick.js"></script>
    <script src="../plugins/iCheck/icheck.min.js"></script>
    <script src="../plugins/adminLTE/js/app.min.js"></script>
    <script src="../plugins/treeTable/jquery.treetable.js"></script>
    <script src="../plugins/select2/select2.full.min.js"></script>
    <script src="../plugins/colorpicker/bootstrap-colorpicker.min.js"></script>
    <script src="../plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.zh-CN.js"></script>
    <script src="../plugins/bootstrap-markdown/js/bootstrap-markdown.js"></script>
    <script src="../plugins/bootstrap-markdown/locale/bootstrap-markdown.zh.js"></script>
    <script src="../plugins/bootstrap-markdown/js/markdown.js"></script>
    <script src="../plugins/bootstrap-markdown/js/to-markdown.js"></script>
    <script src="../plugins/ckeditor/ckeditor.js"></script>
    <script src="../plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="../plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../plugins/chartjs/Chart.min.js"></script>
    <script src="../plugins/flot/jquery.flot.min.js"></script>
    <script src="../plugins/flot/jquery.flot.resize.min.js"></script>
    <script src="../plugins/flot/jquery.flot.pie.min.js"></script>
    <script src="../plugins/flot/jquery.flot.categories.min.js"></script>
    <script src="../plugins/ionslider/ion.rangeSlider.min.js"></script>
    <script src="../plugins/bootstrap-slider/bootstrap-slider.js"></script>
    <script src="../plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.js"></script>
    <script src="../plugins/bootstrap-datetimepicker/locales/bootstrap-datetimepicker.zh-CN.js"></script>
    <script>
        $(document).ready(function () {
               $('#TextBox_CreateTime').datepicker({
                autoclose: true,
                format: 'yyyy-dd-mm'
            });
        })
    </script>
    </form>
</body>
</html>
