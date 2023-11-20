<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MashUp.index" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <link href="estilos/styles.css" rel="stylesheet" />
    <script src="JScript/PlayerYoutube.js"></script>

    <title>MashUp Híbdrida</title>
</head>
<body onload="onYoutubeFrameApiReady()">

    <header class="">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">MashUp Híbrida</a>
    <button class="navbar-toggler bg-light" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse text-center" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Link</a>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Dropdown
          </a>
          <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><hr class="dropdown-divider"/></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
    </header>

    <div class="container text-center">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            <!-- Creamos la clase card para mostrar los datos de la ciudad de Puebla -->
            <div class="container mt-3 mb-3">
                <div class="card">
                    <img src="https://visitmexico.com/wp-content/uploads/2022/09/Puebla_Portada.png" class="card-img-top img-fluid" alt="Imagen_puebla"/>
                    <div class="card-body">
                        <h2>Puebla</h2>
                        <p class="card-text">Ubicada en un valle cerca de cuatro volcanes, Puebla está a 2 160 metros sobre nivel del mar en el centro oriente del territorio mexicano. Colinda al este con el estado de Veracruz, al poniente con los estados de Hidalgo, México, Tlaxcala y Morelos y al sur con los estados de Oaxaca y Guerrero. </p>
                        <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalDatosClimatologicos">Ver datos climatológicos</button>
                    </div>
                    <!-- Modal -->
                    <div class="modal fade" id="modalDatosClimatologicos" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                      <div class="modal-dialog">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Datos Climatológicos</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                          </div>
                          <div class="modal-body">
                             <asp:Label ID="Label2" runat="server" Text="title" CssClass="title"></asp:Label>
                              <p>Temperatura actual: <asp:Label ID="LabelTempActual" runat="server" CssClass="title"></asp:Label></p>
                              <p>Temperatura máxima: <asp:Label ID="LabelTempMaxima" runat="server" CssClass="title"></asp:Label></p>
                              <p>Temperatura mínima: <asp:Label ID="LabelTempMinima" runat="server" CssClass="title"></asp:Label></p>
                              <asp:Image ID="ImagenDescriptiva" src="" runat="server" />
                              <asp:Label ID="Label4" runat="server" Text="title" CssClass=""> °</asp:Label>
                              <p>Nubosidad: <asp:Label ID="Nubosidad" runat="server" CssClass="title"></asp:Label></p>
                              <p>Humedad: <asp:Label ID="Humedad" runat="server" CssClass="title"></asp:Label></p>

                              <p>Hora de salida del sol: <asp:Label ID="HoraSalida" runat="server" CssClass="title"></asp:Label></p>
                              <p>Hora de puesta del sol: <asp:Label ID="HoraPuesta" runat="server" CssClass="title"></asp:Label></p>
                              <h1>ESTE ES NUEVO</h1>
                              <asp:Label ID="latitudNuevo" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="modal-footer text-center">
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                          </div>
                        </div>
                      </div>
                    </div>
                </div>

            </div>

    </div>
   

        <form runat="server">
            <div class="container text-center">
                <h1>Visualizar costos de gasolina</h1>
                Ciudad:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Consultar" CssClass="btn btn-success"/>
                <iframe width="230" height="200" frameborder="0" runat="server" id="gasolina"></iframe>
            </div>
        </form> 
    <div class="container text-center mt-4">
        <div id="player"></div>
    </div>
</body>
</html>
