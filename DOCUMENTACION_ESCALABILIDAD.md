# Documentación de Escalabilidad - Proyecto Excursionistas

#Arquitectura General
La solución fue desarrollada utilizando ASP.NET Web Forms con C#, adoptando una arquitectura en 
capas que separa la lógica de presentación, lógica de negocio y acceso a datos. Este enfoque 
permite un mantenimiento más sencillo y habilita futuras migraciones a tecnologías más modernas 
como ASP.NET MVC o ASP.NET Core Web API.

##Lógica de Negocio y Manejo de Datos
El núcleo de la lógica se basa en la evaluación de múltiples combinaciones de elementos para 
cumplir dos condiciones simultáneamente:

Superar el mínimo de calorías requerido.

Mantenerse por debajo o igual al peso máximo permitido.

Se utilizaron listas (List<T>) para representar los elementos.

La comparación de combinaciones se realiza en memoria sin operaciones costosas de base de datos.

###Escalabilidad y Rendimiento
La solución fue diseñada para poder adaptarse a distintos volúmenes de datos. Se realizaron pruebas 
con listas de hasta 50 elementos y el tiempo de respuesta se mantuvo por debajo de los 3 segundos, 
lo que sugiere que puede manejarse eficientemente en escenarios reales con más datos.
