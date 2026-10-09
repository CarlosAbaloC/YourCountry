# The Way

Prototipo de juego de gestión de países desarrollado con Godot 4.7 y C#. La arquitectura busca mantener los datos y la simulación separados de su representación visual. La interfaz actual es una pequeña consola de prueba dentro de la escena de Godot.

## Estado del prototipo

- `Main` crea el nodo `Game` y conecta los campos de texto de la escena.
- `GameState` conserva el país inicial y sus ciudades.
- `GameTime` mantiene el día actual, que comienza en 1.
- `CommandManager` compara el texto de una orden sin distinguir mayúsculas y minúsculas.
- `Game` admite `next day` para avanzar un día y `list cities` para mostrar las ciudades.
- El segundo campo permite buscar una ciudad por nombre y muestra sus datos: población, país, economía, salud, tecnología y educación.

El proyecto está en una fase temprana. Los valores de las estadísticas y los sistemas de economía, población, industria, logística y diplomacia todavía son datos de prueba o están pendientes de implementación.

## Requisitos

- Godot 4.7 con soporte para C#/.NET.
- .NET 8 SDK.

## Ejecutar

1. Abre `project.godot` con Godot 4.7 .NET.
2. Espera a que Godot importe y compile el proyecto.
3. Ejecuta el proyecto con F6/F5 o desde el botón de ejecución.
4. En el campo de órdenes, escribe `next day` o `list cities` y pulsa Enter.
5. En el campo de búsqueda, escribe `Madrid` o `Barcelona` y pulsa Enter para consultar una ciudad.

Las respuestas aparecen en las etiquetas de la interfaz; los mensajes de depuración aparecen en el panel Output de Godot.

## Estructura

```text
core/       Coordinación del juego, estado, tiempo y comandos
country/    Modelos iniciales de país y ciudad
main/       Escena principal y controles de prototipo
```

La interfaz es una representación del juego: los modelos y las reglas de simulación no deberían depender de cómo se muestren.
