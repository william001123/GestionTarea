# Gestión de tareas 
plataforma de gestión de tareas colaborativas

## Importar base de datos
Previamente debe tener creado el usuario prueba con contraseña pruebapass en el servidor
![alt text](image.png)

## Configuración del proyecto
Debe especificar el ConnectionStrings, donde solo modifica el server en el archivo de configuración appsettings.json
![alt text](image-2.png)

## Consumo de la API con Swagger
Utilizar el end point de api/Autenticacion/Validar para la generacion de token, la base de datos ya tiene un usuario por defecto y es el siguiente json
``` json
{
  "usuario": "wtabera",
  "contrasena": "1234"
}
```
Seguir los siguientes pasos para el uso del end point

- Paso 1 
![alt text](image-3.png)

- Paso 2, digitar el json en el cuerpo
![alt text](image-4.png)

- Paso 3, copiar el token devuelto entre las comillas
![alt text](image-5.png)

- Paso 4, presionar el botón Authorize
![alt text](image-6.png)

- Paso 5: en la casilla digitar Bearer seguido del token copiado previamente y presionar el boton Authorize, esto le permitirá ejecutar cualquier end point en la API
![alt text](image-7.png)

## Prueba de ejecución
Si sigue los pasos correctamente, se le debería ver así

![alt text](image-8.png)