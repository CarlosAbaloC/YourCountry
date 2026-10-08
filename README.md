# The Way

Prototipo de juego de gestión de países hecho con Godot 4.7 y C#. La idea es separar la simulación y los datos del mundo de la interfaz: el proyecto empieza con una interfaz de texto dentro de Godot y podrá crecer hacia mapas y editores 2D o 3D.

## Estado actual

- La escena principal crea el nodo `Game`.
- `GameState` conserva el país inicial y sus ciudades.
- `GameTime` mantiene el día actual de la partida.
- El campo de texto de la escena principal acepta el comando `next day` al pulsar Enter.
- El día comienza en 1 y avanza cuando se envía ese comando.

Este proyecto está en una fase temprana de prototipado. Sistemas como economía, población, industria, logística y diplomacia todavía no están implementados.

## Requisitos

- Godot 4.7 con soporte para C#/.NET.
- .NET 8 SDK.

## Ejecutar

1. Abre `project.godot` con Godot 4.7 .NET.
2. Espera a que Godot importe y compile el proyecto.
3. Ejecuta el proyecto con F6/F5 o desde el botón de ejecución.
4. Escribe `next day` en el campo de texto de la escena y pulsa Enter.

El día actualizado se muestra en la etiqueta de la interfaz. Los mensajes de depuración aparecen en el panel Output de Godot.

## Estructura

```text
core/       Coordinación del juego, estado, tiempo y comandos
country/    Modelos iniciales de país y ciudad
main/       Escena principal y su interfaz de prototipo
```

La interfaz es una representación del juego; los datos y la simulación no deberían depender de cómo se dibujen.
