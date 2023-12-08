
# EmpresaDistribuidora
Se encarga de llevar un registro de productos y los diferentes proveedores que lo surten.

La pagina principal es una lista de todos los productos registrados de la cual podemos hacer una búsqueda por clave de producto y categoría.
![Pagina de inicio](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/db5d4913-4bf5-4c83-bfbb-38149c5e1c01)
Aquí podemos editar los productos que deseemos cambiar ya sea su precio nombre o código de la tienda para ese producto, una vez todo listo damos en aceptar o de lo contrario en volver.
![Pagina Editar](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/c74a4a92-e1cc-4aba-99f8-6e12aa5a04c0)
También podemos eliminar ese producto de la base de datos.
![Pagina Eliminar](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/1f054017-1890-442c-9233-f292e1ec1d0d)
También en la pagina de inicio podemos crear productos nuevos.
![Agregar Producto Página ](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/f26b6e7e-b69a-4594-b44d-43207669c6b2)
Dentro de la pagina de Productos Nuevos podemos agregarle proveedores a este producto.
![Agregar Proveedores Página](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/f8c650af-a3d8-443c-b092-fa9069df7011)
Si no son creados correctamente no podrán guardarse
![Pagina Producto Invalido](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/d4caf515-507f-4c44-ae09-5b2afb9f8729)
También los proveedores tienen que tener sus datos correctos sino no te dejara agregarlos
![Agregar Proveedor Valido](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/46bd3dde-f7fd-4dfd-bb1c-04b6fa0d2c4b)
Si todos los datos son correctos se agregaran a la base de datos de los productos
![Creado con Exito](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/29c23069-f3b4-4afb-8cd3-53907282ad8d)
y te mandara de regreso a la pagina principal actualizada con el nuevo producto
![Pagina Principal Actualizada](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/d52d238b-4b4b-498c-8288-5c64ac05d46f)





# Manual de Instalación sobre IIS 7.5 o superior
Primero asegurarnos si tenemos activado Internet Information Services (IIS), esto lo hacemos solo entrando al navegador y escribir localhost, si aparece una pagina como la siguiente:
![IIS](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/5bfa771f-2678-4796-8c97-69d026116721) Entonces tiene activado ISS, de lo contrario para activarlo nos dirigimos a el Panel de control\Programas
dentro de programas nos vamos a Activar o desactivar las características de Windows, ahí tenemos que asegurarnos que la casilla de Internet Information Services quede marcada completamente das en aceptar y esperas a que se instale todo lo necesario.
![Activar IIS](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/321650da-b302-4cad-bd00-c692f7202991)
Una vez activado tendremos una carpeta en el disco donde tengas instalado Windows llanada inetpub, dentro encontraras algunas carpetas entre ellas estará la carpeta root (wwwroot) dentro de ella crearas una carpeta con el propósito de guardar los archivos publicados de tu app.
![Inetpub](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/5900cc75-1ab5-49ff-a198-24a119c2e5c4)
Una vez que tengas todo preparado te vas a tu proyecto en VS, nos dirigimos a Program.Cs y en el bloque de código donde esta el comentario // Configure the HTTP request pipeline.
cambiamos la extension isDevelopment() a isProduction() guardamos y hacemos lo mismo en el launchSettings.json dentro de la carpeta Properties, en el bloque profiles y guardar.
![qwqe](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/ee9ab6ae-7211-4e6f-a409-84703042efd2)
![gfgfg](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/8b29971e-37d5-4bea-96a5-092acf4fe388)
una vez echo esto das clic derecho en tu proyecto y en publicar, después en agregar un perfil de publicación
![vs](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/5dcf89b6-2e77-43ff-ba30-ee02001929c0)
En los perfiles escoges carpeta y siguiente
![Carpeta](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/9d19516e-5cdc-488a-9cca-5493be0a479a)
luego escoges la ruta en la que guardaras los archivos (por defecto) y das en finalizar
![pub](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/96691df5-55b7-4598-9475-837a65cc7e35)
Dejamos todo por defecto y damos click en el botón publicar, una vez el proceso de publicación finalice tendrás que ir a la ubicación de destino 
![adasdasd](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/e5171b10-1684-4f53-99a8-b474ae230b79)
Copias todo el contenido de la carpeta y nos dirigimos a la carpeta que creamos al principio dentro de C:\inetpub\wwwroot\tucarpetacreada y pegamos todo 
![pega](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/d45b17e0-93e1-497e-8d34-acd0e6acb588)

Una vez echo esto iremos a menú principal y buscaremos el administrador de Internet Information Services (IIS). Una vez dentro desplegamos donde aparece el nombre de nuestra PC, y en carpeta Sitios damos click derecho y seleccionamos agregar sitio web, dentro ponemos el nombre a nuestro sitio
y agregamos la ruta física, esta es la ruta de nuestra carpeta que se se encuentra C:\inetpub\wwwroot\tucarpetacreada y seleccionas tucarpetacreada, 
![rasd](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/85a223fb-46f0-4133-a30b-3c89c3261b13)

luego de esto click en el botón Conectar como y seleccionamos usuario especifico, botón establecer y ponemos en nombre de usuario 
el nombre de tu pc que si no sabes cual es, esta al final del nombre la carpeta principal y la contraseña es con la que entras a tu pc, aceptamos 
![qeqw](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/399a6b05-d4a4-4959-a55f-95aad8d6dfa3)
y damos en Probar configuración y todo tiene que quedar en verde
![aq](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/69b9afd4-8d71-49f6-96c5-af38d346293e)
una vez comprobado que todo este bien dejamos lo demás como esta (En el puerto lo puedes dejar en 80 pero al momento de entrar te dirá que no porque el puerto esta siendo usado esto es porque la pagina azul que nos mostro IIS al principio esta usando ese puerto, solo tienes que desactivar esa pagina que es la 
Default Web Site y listo o puedes cambiar el puerto uno mayor a 80 y al momento de querer entrar poner la extensión del puerto localhost:numdepueto).
nos iremos a donde dice grupo de aplicaciones y veremos que nuestro grupo recién creado es te con las configuraciones básicas correctas estas son: en versión de .NET CLR tiene que ser sin código administrado y en modo de canalización administrada es Integrada
![dsg](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/35009f55-d06b-4b73-8f0d-939a50a35ff6)

Luego de esto comprobamos que tengamos instalado el web Hosting de .net, esto seleccionamos nuestro localhost y doble click Módulos dentro de módulos buscamos AspNetCoreModuleV2 si lo tienes perfecto, si no lo descargas el la pagina oficial https://dotnet.microsoft.com/en-us/download/dotnet ten encuenta que tiens que
descargar el que sea para la versión de .net que estas usando sino te dará problemas de incompatibilidad
![net](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/3012deee-05f9-4eb7-9cbc-e473cb8c47de)
una vez instalado compruebas que el archivo este em los módulos, si todo esta echo ya deberías ser capas de visualizar tu app en el localhost.

Si tienes una base de datos entonces no podrás acceder a ella, para poder acceder tendremos que crear un nuevo usuario en nuestra base de datos en este caso SQLServer 2019.

Nos iremos a nuestra base de datos que estemos usando ampliaremos, luego a Security y a New User
![Captura de pantalla 2023-12-08 155438](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/0543f170-5a9c-41e0-a839-1814e9c6e284)
Ya dentro en la pestaña General casilla username escribimos IIS APPPOOL\El nombre de tu grupo de aplicaciones en IIS y en Login name lo mismo IIS APPPOOL\El nombre de tu grupo de aplicaciones en IIS
![Captura de pantalla 2023-12-08 155919](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/ece36c21-8523-4ae9-a99f-1fb94a786015)
Ahora en la pestaña Membreship seleccionamos la casilla que diga db_owner y damos en listo
![Captura de pantalla 2023-12-08 160134](https://github.com/brandonvalenzuela/EmpresaDistribuidora/assets/43163308/2ad234a1-6c96-48e5-bfd0-4ee401a79621)
Con eso ya estaría todo funcionado en conjunto con la base de datos

