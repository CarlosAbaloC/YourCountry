# Your Country

Prototipo de juego de gestión de países desarrollado con Godot 4.7 y C#. El proyecto separa los datos del mundo y la simulación de su representación. La interfaz actual es una prueba de interacción dentro de la escena de Godot.

## Estado actual

- `GameState` conserva una colección de países; cada `Country` conserva su propia lista de ciudades.
- Los datos de ejemplo de España y Francia se crean en código.
- La interfaz acepta los comandos `next day`, `list cities`, `all cities` y `help`.
- Hay un campo para consultar una ciudad por nombre en todos los países registrados; la búsqueda no distingue mayúsculas y minúsculas.
- El formulario de creación de ciudades permite asignar la ciudad a un país existente escribiendo su nombre; la búsqueda no distingue mayúsculas y minúsculas. Si el país no existe, no se crea la ciudad y se muestra un error en Output.
- La validación del resto de datos del formulario sigue en desarrollo.
- Los datos todavía no se cargan desde JSON. Economía, población y otros sistemas de simulación siguen en desarrollo.

## Requisitos

- Godot 4.7 con soporte para C#/.NET.
- .NET 8 SDK.

## Ejecutar

1. Abre `project.godot` con Godot 4.7 .NET.
2. Espera a que Godot importe y compile el proyecto.
3. Ejecuta el proyecto con F6/F5 o desde el botón de ejecución.
4. En el campo de órdenes, escribe `next day`, `list cities`, `all cities` o `help` y pulsa Enter.
5. En el campo de búsqueda, escribe una ciudad de cualquier país registrado y pulsa Enter.

Las respuestas aparecen en las etiquetas de la interfaz; los mensajes de depuración aparecen en el panel Output de Godot.

## Datos de países

La lista de países y ciudades se inicializa actualmente con datos de prueba escritos en código. La carga desde JSON está prevista: un único archivo podrá contener un array de países y sus ciudades, y el juego recorrerá esos datos para construir los objetos, sin una llamada manual por cada país.

## Estructura

```text
core/       Coordinación del juego, estado, tiempo y comandos
country/    Modelos iniciales de país y ciudad
main/       Escena principal y controles de prototipo
```

La interfaz es una representación del juego: los modelos y las reglas de simulación no deberían depender de cómo se muestren.
