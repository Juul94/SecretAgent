<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SecretAgentNew.index" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Secret Agent</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>

<body>

    <form id="form1" runat="server">

        <div class="container">

            <nav class="navbar justify-content-between">

            <div class="narbar-brand"><img src="images/logo-heading.png" /></div>

                <div class="form-inline">

                    <div class="container" id="changeBtn">
                        <asp:Button ID="Button_Show_Agents" runat="server" Text="Show Agents" OnClick="Button_Show_Agents_Click" class="display-4" />
                        <asp:Button ID="Button_Show_Create" runat="server" Text="Create Agent" OnClick="Button_Show_Create_Click" class="display-4" />
                        <asp:Button ID="Button_Show_Update" runat="server" Text="Update Agent" OnClick="Button_Show_Update_Click" class="display-4" />
                        <asp:Button ID="Button_EncrypCode" runat="server" Text="Encryption" OnClick="Button_EncrypCode_Click" class="display-4" />
                    </div>

                </div>
            </nav>

            <asp:Label ID="Label_Success" runat="server" Text=""></asp:Label>

            <div class="row mt-5" id="div_Show" runat="server">

                <div class="col-md-12 text-center">
                    <h2 class="display-1">Agents</h2>
                </div>

                <div id="ShowAgentError" class="alert alert-danger" runat="server">
                    <p>No agents found!</p>
                    <p>Add one to see them listed here</p>
                </div>

                <div class="row setWidth">
                    <div class="col-md-8 offset-2">
                        <asp:ListBox ID="ListBox_Agents" runat="server" Rows="6" Width="100%"></asp:ListBox>
                    </div>
                </div>
                
            </div>

            <div class="row mt-5" id="div_Create" runat="server">
                
                <div class="col-md-12 mb-2 text-center">
                    <h2 class="display-1">Create Agent</h2>
                </div>

                <div class="col-md-4 offset-4 display-3">
                    <asp:Label ID="Label_realName" runat="server" Text="Real Name"></asp:Label>
                    <asp:TextBox ID="TextBox_realName" runat="server" class="form-control"></asp:TextBox>
                    <asp:Label ID="ErrorMessage_realName" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

                    <asp:Label ID="Label_codeName" runat="server" Text="Code Name"></asp:Label>
                    <asp:TextBox ID="TextBox_codeName" runat="server" class="form-control"></asp:TextBox>
                    <asp:Label ID="ErrorMessage_codeName" runat="server" Text="" CssClass="ErrorMessage">Please fill out your code name</asp:Label>

                    <asp:Label ID="Label_Language1" runat="server" Text="1. Language"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Language1" runat="server" CssClass="btn btn-light dropdown-toggle setWidth"></asp:DropDownList>
                    <asp:Label ID="ErrorMessage_lang1" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>
      
                    <asp:Label ID="Label_Language2" runat="server" Text="2. Language"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Language2" runat="server" CssClass="btn btn-light dropdown-toggle setWidth"></asp:DropDownList>
                    <asp:Label ID="ErrorMessage_lang2" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

                    <asp:Button ID="Button_CreateAgent" runat="server" Text="Create Agent" class="btn btn-dark" OnClick="Button_CreateAgent_Click"/>
                </div>

            </div>

            <div class="row mt-5 mb-4" id="div_Update"  runat="server">

                <div class="col-md-12 mb-2 text-center">
                    <h2 class="display-1">Update Agent</h2>
                </div>

                <div class="col-md-4 offset-4  display-3">
                    <asp:Label ID="Label_realName_h" runat="server" Text="Real Name (Search for Agent)"></asp:Label>
                    <asp:TextBox ID="TextBox_realName_h" runat="server" class="form-control"></asp:TextBox>
                    <asp:Label ID="ErrorMessage_realName_h" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

                    <asp:Label ID="Label_Language1_h" runat="server" Text="1. Language"></asp:Label>
                    <asp:DropDownList ID="DropDownList_lang1" runat="server" CssClass="btn btn-light dropdown-toggle setWidth"></asp:DropDownList>
                    <asp:Label ID="ErrorMessage_lang1_h" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>
      
                    <asp:Label ID="Label_Language2_h" runat="server" Text="2. Language"></asp:Label>
                    <asp:DropDownList ID="DropDownList_lang2" runat="server" CssClass="btn btn-light dropdown-toggle setWidth"></asp:DropDownList>
                    <asp:Label ID="ErrorMessage_lang2_h" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

                    <asp:Button ID="Button_UpdateAgent" runat="server" Text="Update Agent" class="btn btn-dark" OnClick="Button_UpdateAgent_Click"/>

                </div>
            </div>
            
            <div class="row mt-5" id="div_encryption" runat="server">

                <div class="col-md-12 mb-2 text-center">
                    <h2 class="display-1">Encrypt text</h2>
                </div>

                <div class="col-md-4 offset-4 display-3">

                    <asp:Label ID="Label_Encryption" runat="server" Text="Text"></asp:Label>
                    <asp:TextBox ID="Text_encruptedText" runat="server" class="form-control"></asp:TextBox>
                    <asp:Label ID="ErrorMessage_Encrypton" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

                    <asp:Label ID="Label_PickKey" runat="server" Text="Key"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Encryption" runat="server" class="btn btn-light dropdown-toggle"></asp:DropDownList>
                    <asp:Label ID="ErrorMessage_Encrypton_Key" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

                    <asp:Button ID="Button_Encrypion" runat="server" Text="Encrypt text" class="btn btn-dark" OnClick="Button_Encrypion_Click"/>

                </div>

                <div class="col-md-8 offset-2 mt-5">
                    <asp:ListBox ID="ListBox_Encryption" runat="server" Rows="1000"></asp:ListBox>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
