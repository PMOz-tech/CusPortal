<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CusPortal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

    <div class="row">
      <div class ="form_container" />
           ID :   <asp:TextBox ID="tbId" runat="server" /> <br />
            Name:   <asp:TextBox ID="tbName" runat="server" /> <br />
           Account Number <asp:TextBox ID="tbAcc" runat="server" /> <br />
            Address:   <asp:TextBox ID="tbAddress" runat="server" /> <br />

        <asp:Button ID="btsave" Text="Submit" runat="server" OnClick="btsave_Click" />

           <asp:Label ID="lbResult" runat="server" />
       

         <asp:GridView ID="dataTable" runat="server" >
            
        </asp:GridView>
        
        <asp:Button ID="Button1" Text="Update" runat="server" OnClick="Button1_Click" />
        <asp:Button ID="Button2" Text="Delete" runat="server" OnClick="Button2_Click" />
      
        <asp:Button ID="Button4" Text="Clear" runat="server" OnClick="Button4_Click" />
              
    </div>

</asp:Content>
