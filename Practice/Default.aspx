<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Practice.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="firstname"  runat="server"></asp:TextBox>
            <asp:TextBox ID="lastname" runat="server"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="DropDownSelect"></asp:DropDownList>
            <asp:GridView        DataKeyNames="account_id"  ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SelectRow" OnRowDeleting="RowDelete">
                       <Columns> 
                    <asp:BoundField DataField="account_id"  HeaderText="ID" ></asp:BoundField>
                     <asp:BoundField DataField="firstname"  HeaderText="FIRSTNAME" ></asp:BoundField>
                      <asp:BoundField DataField="lastname"  HeaderText="LASTNAME" ></asp:BoundField>
                       <asp:CommandField ShowDeleteButton="true" />
                
                </Columns>
            </asp:GridView>
            <asp:GridView DataKeyNames="account_id" ID="GridView2" runat="server" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                    <asp:CommandField ShowEditButton="True"></asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                </Columns>


            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [account] WHERE [account_id] = @account_id" InsertCommand="INSERT INTO [account] ([firstname], [lastname], [is_active], [created_date], [updated_date]) VALUES (@firstname, @lastname, @is_active, @created_date, @updated_date)" SelectCommand="SELECT * FROM [account]" UpdateCommand="UPDATE [account] SET [firstname] = @firstname, [lastname] = @lastname, [is_active] = @is_active, [created_date] = @created_date, [updated_date] = @updated_date WHERE [account_id] = @account_id">
                <DeleteParameters>
                    <asp:Parameter Name="account_id" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="firstname" Type="String"></asp:Parameter>
                    <asp:Parameter Name="lastname" Type="String"></asp:Parameter>
                    <asp:Parameter Name="is_active" Type="Boolean"></asp:Parameter>
                    <asp:Parameter Name="created_date" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="updated_date" Type="DateTime"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="firstname" Type="String"></asp:Parameter>
                    <asp:Parameter Name="lastname" Type="String"></asp:Parameter>
                    <asp:Parameter Name="is_active" Type="Boolean"></asp:Parameter>
                    <asp:Parameter Name="created_date" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="updated_date" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="account_id" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>

            <asp:ListView ID="ListView1" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                <LayoutTemplate>
                    <table>
               <tr>
                   <th>Firstname</th>
                   <th>Lastname</th>
               </tr>
                             <asp:PlaceHolder ID="groupPlaceHolder1" runat="server"></asp:PlaceHolder>
                        </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder1" runat="server"></asp:PlaceHolder>
                </GroupTemplate>
                <ItemTemplate>
            
         
                      
                       
                            <tr>
                                <td><%# Eval("firstname") %></td>
                          
                    
                                <td><%# Eval("lastname") %></td>
                            </tr>
               
              
                    
                
                </ItemTemplate>


            </asp:ListView>
        </div>
    </form>
</body>
</html>
