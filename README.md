# EvNet

Sistema web de gestión de clientes y facturación desarrollado en **ASP.NET MVC 5** con **Entity Framework 6** y **SQL Server**.

## Funcionalidades

- **Gestión de clientes** — Alta, baja y modificación con datos personales y domicilio.
- **Facturación** — Registro y consulta de facturas por cliente.
- **Autenticación** — Login por email y contraseña con sesión.
- **Ciudades** — Catálogo de localidades vinculado a los clientes.

## Tecnologías

| Capa          | Tecnología                              |
|---------------|-----------------------------------------|
| Backend       | C# / ASP.NET MVC 5 (.NET Framework 4.8) |
| ORM           | Entity Framework 6.2                    |
| Frontend      | Razor Views, Bootstrap 3, jQuery 3.3.1  |
| Base de datos | SQL Server                              |

## Arquitectura

Solución en N capas con separación entre presentación (`EvNet`) y acceso a datos (`EvNet.Data`), siguiendo el patrón Repository con una interfaz genérica `IABM<T>` para las operaciones CRUD.

## Requisitos previos

- Visual Studio 2019 o superior
- .NET Framework 4.8
- SQL Server (local o Azure SQL)

## Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/EvNet2.git
```

### 2. Crear la base de datos

Ejecutar los scripts de la carpeta `[SQL Scripts]` en orden sobre tu instancia de SQL Server:

```
01 - Ciudades.sql
02 - Clientes.sql
03 - Facturas.sql
04 - Inserts.sql   ← carga datos de prueba
```

### 3. Configurar la cadena de conexión

Editar `EvNet/Web.config` y reemplazar el valor de `EvNetEntities` con tu cadena de conexión:

```xml
<connectionStrings>
  <add name="EvNetEntities"
       connectionString="metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;
         provider=System.Data.SqlClient;
         provider connection string=&quot;
           Data Source=TU_SERVIDOR;
           Initial Catalog=evnet;
           User Id=TU_USUARIO;
           Password=TU_PASSWORD;
         &quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
```

### 4. Restaurar paquetes NuGet y ejecutar

Abrir `EvNet.sln` en Visual Studio, restaurar los paquetes NuGet y presionar **F5**.

La aplicación corre por defecto en `http://localhost:49785/`.

## Usuario de prueba

El script `04 - Inserts.sql` crea un usuario inicial:

| Campo    | Valor        |
|----------|--------------|
| Email    | jp@evnet.com |
| Password | test1234     |
