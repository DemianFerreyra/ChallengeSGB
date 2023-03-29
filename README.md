# Challenge SGB information services
&nbsp;

## Descripcion
 Proyecyo realizado como challenge para la segunda etapa del proceso de reclutamiento de [SGB information services S.A](https://www.linkedin.com/company/sgb-information-services-s-a/)
 Proyecto realizado en C# con visual studio 2022 como IDE, entity framework y base de datos Microsoft SQL server.
 (Al agregar la query "?json=true" en ciertas rutas como por ejemplo la ruta de encuestas o encuestas/promedy, en lugar de recibir la vista en HTML, recibiremos un Json en caso de querer usarlo para trabajar con el en un front separado)

## Algunos problemas encontrados durante el proceso
- Dato "periodo" y la forma en que se lo guardaba:
 el problema con el dato periodo era que se guardaba y se cortaba automaticamente en una string de (5) caracteres maximos. Mi idea era poder elegir el periodo con un selector de fechas de html y transformar el dato de fecha a numero. Pero por temas de tiempo decidi dejarlo asi como estaba (lo que tambien genero el problema de no poder ordenar correctamente los promedios en la grafica de "promedio de peliculas vistas por periodo")

## Tecnologias

- [C#](https://learn.microsoft.com/es-es/dotnet/csharp/) - Lenguaje usado
- [SQL server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) - Base de datos
- [Entity Framework](https://learn.microsoft.com/es-es/ef/) - ORM
- [Github](https://github.com) - Manejo de repositorios