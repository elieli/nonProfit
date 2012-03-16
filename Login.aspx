<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginAuth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    
    
    
    
     <div style="padding-left: 30px; height:100px; width:100px;  padding-right: 30px">
     
     <div  id="dvheader" runat ="server" style="padding-left: 30px; text-align:center; height:10px; width:100px;  padding-right: 30px"></div>
     
        <table cellpadding="4px" cellspacing="4px" width="600px" style="clear: both; border-collapse: separate">
                     
                                    <tr>
                                        <td align="right" valign="middle">
                                            Email:&nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLoginEmail" runat="server" ValidationGroup="gLogin" 
                                                Width="155px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLoginEmail"   runat="server" Text="txtLoginEmail">
                                                </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            Password:&nbsp;&nbsp;
                           </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" 
                                                ValidationGroup="gLogin" Width="155px"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtLoginPassword" runat="server" Text="txtLoginPassword">
                                                </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    
                                      
                                   
                                   
                                    <tr>                                    
                                     <td  align="right">
                                   <%--      <msc:FlexButton ID="btnLogin" runat="server" BackColor="#fed9a2" Font-Bold="True" Text="Login"
                                        Width="83px" Height="30px" onclick="btnLogin_Click" />--%>
                                          </td>
                                            </tr>
                                    
                                    
                                    <tr>                                    
                                     <td  align="left">
                                      <%--  <span class="ErrorMessage"><%=MessageLogin %></span> --%>
                                          </td>
                                            </tr>
                                    
                                    
                                    </table>   
    
      <div  id="dvmsg" runat ="server" style="padding-left: 30px; text-align:center; height:10px; width:100px;  padding-right: 30px"></div>
   
    
    
    
    
     </div>
    
    <div> <asp:Button  runat="server" id="btnSubmit"  OnClick="login"/> </div>
    </div>
    </form>
</body>
</html>
