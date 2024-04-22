# Gestión de tareas 
plataforma de gestión de tareas colaborativas

## Importar base de datos
Previamente debe tener creado el usuario prueba con contraseña pruebapass en el servidor
![image](https://github.com/william001123/GestionTarea/assets/124921315/8c857399-5473-474b-8410-7db64484ba36)

## Configuración del proyecto
Debe especificar el ConnectionStrings, donde solo modifica el server en el archivo de configuración appsettings.json

![image-2](https://github.com/william001123/GestionTarea/assets/124921315/d61bf4ba-5632-4ead-a950-3337257613f6)

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
![image-3](https://github.com/william001123/GestionTarea/assets/124921315/47556021-67af-4fa9-922c-25f9446163d2)


- Paso 2: digitar el json en el cuerpo
![image-4](https://github.com/william001123/GestionTarea/assets/124921315/9ffef80b-3450-49ad-bdfd-9a50ef40b708)


- Paso 3: copiar el token devuelto entre las comillas
![image-5](https://github.com/william001123/GestionTarea/assets/124921315/d322fbc7-ba9f-426b-810a-b593eb82e91e)


- Paso 4: presionar el botón Authorize
![image-6](https://github.com/william001123/GestionTarea/assets/124921315/8a953083-01b5-44a9-93e7-849b01ef2b73)


- Paso 5: en la casilla digitar Bearer seguido del token copiado previamente y presionar el boton Authorize, esto le permitirá ejecutar cualquier end point en la API
![image-7](https://github.com/william001123/GestionTarea/assets/124921315/109608bf-ca4e-48af-8b10-00742fc773e6)


## Prueba de ejecución
Si sigue los pasos correctamente, se le debería ver así
![image-8](https://github.com/william001123/GestionTarea/assets/124921315/e1e6b768-f81d-40c3-9610-f7d6091168a5)
