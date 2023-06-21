PRUEBA TÉCNICA DESARROLLADOR FULLSTACK F2X

README: 

Instrucciones de descarga: Se debe descargar el código fuente desde el enlace al repositorio de GitHub: https://github.com/eduardoluisgarcia/PruebaTecnicaF2X

Requisitos previos: Para poder ejecutar correctamente el proyecto en el frontend se debe instalar en el computador Node.js Versión 14.17.5, Angular versión 12.2.17 y Angular CLI Versión 12.2.18. Para el proyecto en el backend se debe tener instalado Visual C# con .Net Core 5 o visual Studio Code y el SDK de Visual Studio versión 5.

Configuración del entorno: 	En el backend appsettings se encuentra la cadena de conexión a la base de datos remota que me han entregado para el desarrollo de la prueba. La cual es la siguiente:
"ConnectionStrings": {
"ConexionSql": "Server=23.102.103.53; Database=EduardoGarcia;User ID=egarciaprueba; Password=egarciaprueba; Trusted_Connection=false;MultipleActiveResultSets=true"}.

Cuando se ejecute el backend, nos abrirá una URL en Swagger, por ejemplo https://localhost:44370/swagger/index.html, donde debemos tomar de la ruta el valor de https://localhost:44370 y en el aplicativo frontend de angular ubicamos el archivo environment.ts y colocamos ese valor en la variable base, como el siguiente ejemplo:
	
	api: {
		base: 'https://localhost:44370',
		recaudos: '/api/v1/recaudos',
		reporte: '/api/v1/reporte',
	  }

Ejecución de la aplicación: Se debe ejecutar inicialmente el API desde Visual Studio dede el botón IIS o con la tecla F5 del computador. Luego para ejecutar el frontend se debe abrir una nueva terminal desde el menú superior y ejecutar el comando ng serve -o.

Documentación y Diagramas: Como documentación adicional se entregan archivos PDF de los diagramas del Frontend y Backend con una explicación y documentación de cada una de esta.

Contacto: Si hay alguna duda me podrían contactar a mi celular 322 8990101 o a mi correo electrónico: ing.eduardoluis@gmail.com y estaré disponible.