﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HPIT.Logistic.PM.WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.6 -->
    <!-- Font Awesome -->
    <!-- Ionicons -->
    <!-- Theme style -->
    <!-- iCheck -->
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
    <link rel="stylesheet" href="plugins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="plugins/ionicons/css/ionicons.min.css" />
    <link rel="stylesheet" href="plugins/adminLTE/css/AdminLTE.css" />
    <link rel="stylesheet" href="plugins/iCheck/square/blue.css" />
</head>
<body style="background-image:url(../img/photo1.png);background-repeat:no-repeat;overflow-x:hidden;overflow-y:hidden;background-size:100%;">
        <div class="login-box">
        <div class="login-logo">
            <a href="all-admin-index.html"><b>数据</b>后台管理系统</a>
        </div>
            <div class="login-box-body">
            <p class="login-box-msg"></p>
            <form runat="server">
                <div class="form-group has-feedback">
               <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
               <%--<input type="email" class="form-control" placeholder="Email">--%>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<input type="password" class="form-control" placeholder="密码">--%>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label><input type="checkbox" /> 记住 下次自动登录</label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                     <asp:Button ID="Button1" runat="server" Text="登录"  CssClass="btn btn-primary btn-block btn-flat" OnClick="Button1_Click"/>
                     <asp:Label ID="Label1" runat="server"></asp:Label>
                        <%-- <button type="submit" class="btn btn-primary btn-block btn-flat">登录</button>--%>
                    </div>
                    <!-- /.col -->
                </div>
            </form>
            <!-- /.social-auth-links -->
            <a href="#">忘记密码</a><br>
            <a href="all-admin-register.html" class="text-center">新用户注册</a>
        </div>

        <!-- /.login-box-body -->
    </div>
    <!-- /.login-box -->

    <!-- jQuery 2.2.3 -->
    <!-- Bootstrap 3.3.6 -->
    <!-- iCheck -->
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function() {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
</html>
