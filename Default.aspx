<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoExcursionistas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
   
    <!-- Barra superior con el nombre de usuario -->
    <div class="bg-dark text-white py-4 px-5 mb-2 d-flex justify-content-between align-items-center" style="font-size: 1.9rem;">
        <span><i class="big bi-person-circle me-2"></i>Bienvenido, 
        <asp:Label ID="lblUsuario" runat="server" CssClass="fw-bold" />
        </span>
        <a href="Login.aspx" class="btn btn-outline-light btn-sm">Cerrar sesión</a>
    </div>


    <div class="bg-primary text-white text-center py-3 mb-4 rounded">
        <h1 class="m-0">Elementos permitidos para escalar un risco</h1>
    </div>

    <div class="bg-primary text-white text-center py-3 mb-4 rounded">
        <h3 class="m-0">Por favor, ingrese mínimo de calorías y peso máximo</h3>
    </div>

    <div class="container mb-3">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-sm p-4 text-center">
                    <!-- Campo mínimo de calorías -->
                    <div class="mb-3">
                        <label class="form-label fw-bold">Mínimo de Calorías:</label>
                        <asp:TextBox ID="txtMinCalorias" runat="server" CssClass="form-control  mx-auto" />
                    </div>

                    <!-- Campo peso máximo -->
                    <div class="mb-3">
                        <label class="form-label fw-bold">Peso Máximo:</label>
                        <asp:TextBox ID="txtPesoMaximo" runat="server" CssClass="form-control mx-auto" />
                    </div>

                    <!-- Botón -->
                    <div class="mb-3 d-flex justify-content-center gap-2 align-items-center">
                        <div class="d-flex align-items-center">
                            <i class="bi bi-calculator-fill me-2"></i>
                            <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btn btn-primary px-4" OnClick="btnCalcular_Click" />
                        </div>
                        <div class="d-flex align-items-center">
                            <i class="bi bi-trash-fill me-2"></i>
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-secondary px-4" OnClick="btnBorrar_Click" />
                        </div>
                    </div>
                    <!-- Resultado -->
                    <asp:Label ID="lblResultado" runat="server" CssClass="fw-bold text-primary d-block" />
                </div>
            </div>
        </div>
    </div>
    <div class="bg-success text-white text-center py-3 mb-4 rounded">
        <h5 class="m-0">La mejor combinación es la de menor peso</h5>
    </div>
</asp:Content>
