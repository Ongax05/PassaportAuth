# PassaportAuth
-Passport-Auth es una aplicación web ASP.NET Core que demuestra cómo implementar
 la autenticación de usuarios utilizando cookies y Google como proveedor de autenticación.

## Requisitos previos 

- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado en tu sistema.
- [Visual Studio Code](https://code.visualstudio.com/) o una IDE de tu elección para desarrollar y ejecutar la aplicación.

## Configuración

1. Clona este repositorio en tu máquina local:

   ```bash
   git clone https://github.com/Ongax05/PassaportAuth.git
   cd PassaportAuth

1- Abre la solución en tu IDE favorito.

2- Configura las credenciales de Google para la autenticación:

  -Abre el archivo Startup.cs.
  -Busca la sección donde se configura la autenticación de Google en el método ConfigureServices.
  -Reemplaza options.ClientId y options.ClientSecret con tus propias credenciales de Google. Puedes obtener estas credenciales creando una aplicación en Google Developer Console.
  
3-Configura la cadena de conexión de la base de datos:

  -Abre el archivo appsettings.json.
  -Reemplaza "ConexMysql" con la cadena de conexión correcta para tu base de datos MySQL.

 4-Ejecuta la aplicación:
   abre un terminal en la carpeta Api y ejecuta el comando indicado abajo 
   dotnet run

 5-Abre tu navegador y accede a https://localhost:7030 # O si deseas cambiar el puerto, localhost: y el puerto que elijas # para probar la aplicación.

 - Uso
  La página de inicio permite a los usuarios iniciar sesión con su cuenta de Google.
  Después de la autenticación exitosa, los usuarios son redirigidos a la página de privacidad.
  Puedes personalizar y extender la funcionalidad de autenticación y autorización según tus necesidades en el controlador AccountController y las vistas asociadas.

  Contribución
  Si deseas contribuir a este proyecto, sigue estos pasos:
  
  Haz un fork del repositorio.
  Crea una rama para tus cambios: git checkout -b mi-rama.
  Realiza tus cambios y haz commits: git commit -m "Descripción de los cambios".
  Sube tus cambios a tu fork: git push origin mi-rama.
  Abre un Pull Request en este repositorio.
  Licencia
  Este proyecto está bajo la licencia MIT. Consulta el archivo LICENSE para obtener más detalles.
  
  ¡Esperamos que este proyecto te sea útil! Si tienes alguna pregunta o necesitas ayuda adicional, no dudes en abrir un problema o ponerte en contacto con el equipo de desarrollo
