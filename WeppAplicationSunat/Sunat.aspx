<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Sunat.aspx.cs" 
    Inherits="WeppAplicationSunat.Sunat" %>
<asp:Content ID="Content1" 
    ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento para Sunat</h3>


    <p>
        RUC : <asp:TextBox runat="server" Id="txtRuc"  />
    </p>
    <p>
        Nombre de la empresa : <asp:TextBox runat="server" Id="txtNombre" />
    </p>
    
    
    
    
    <p>
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar"  />
        <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" />
        <asp:Button Text="Actualizar" runat="server" Id="btnActualizar"/>
    </p>
    <p>
        Buscar : <asp:TextBox runat="server" Id="txtTexto" />    
        <asp:DropDownList runat="server" Id="List">
            <asp:ListItem text="Ruc" />
            <asp:ListItem text="Nombre" />
        </asp:DropDownList>
        
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click"/>

    </p>
    <p>
        <asp:GridView runat="server" ID ="gvSunat"></asp:GridView>
    </p>

</asp:Content>
