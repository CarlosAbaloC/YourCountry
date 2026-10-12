# The Way

Prototipo de juego de gestión de países desarrollado con Godot 4.7 y C#. La arquitectura busca mantener los datos y la simulación separados de su representación visual. La interfaz actual es una pequeña consola de prueba dentro de la escena de Godot.

## Estado del prototipo

- `Main` crea el nodo `Game` y conecta los campos de texto de la escena.
- `GameState` conserva una colección de países; cada `Country` conserva sus ciudades.
- `GameTime` mantiene el día actual, que comienza en 1.
- `CommandManager` compara el texto de una orden sin distinguir mayúsculas y minúsculas.
- `Game` admite `next day`, `list cities`, `all cities` y `help`.
- El campo de búsqueda permite consultar una ciudad por nombre.
- La escena tiene controles para el formulario de creación de ciudades; su acción todavía está en desarrollo.

España y Francia, con unas pocas ciudades de ejemplo, se crean actualmente en el código. No se cargan aún desde un archivo JSON. Los valores de las estadísticas son datos de prueba y los sistemas de economía, población, industria, logística y diplomacia están pendientes.

## Requisitos

- Godot 4.7 con soporte para C#/.NET.
- .NET 8 SDK.

## Ejecutar

1. Abre `project.godot` con Godot 4.7 .NET.
2. Espera a que Godot importe y compile el proyecto.
3. Ejecuta el proyecto con F6/F5 o desde el botón de ejecución.
4. En el campo de órdenes, escribe `next day`, `list cities`, `all cities` o `help` y pulsa Enter.
5. En el campo de búsqueda, escribe el nombre de una ciudad de ejemplo y pulsa Enter.

Las respuestas aparecen en las etiquetas de la interfaz; los mensajes de depuración aparecen en el panel Output de Godot.

## Datos de países

La lista de países y sus ciudades se inicializa con unos pocos datos de prueba escritos en código. Cuando se añadan datos externos, se podrán guardar en un único JSON con un array de países y sus ciudades. El programa leerá ese archivo y recorrerá sus registros con un bucle para construir los objetos; no hará falta escribir una llamada `AddCountry` por cada país.

## Estructura

```text
core/       Coordinación del juego, estado, tiempo y comandos
country/    Modelos iniciales de país y ciudad
main/       Escena principal y controles de prototipo
```

La interfaz es una representación del juego: los modelos y las reglas de simulación no deberían depender de cómo se muestren.
