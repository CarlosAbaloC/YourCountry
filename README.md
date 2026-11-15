# Your Country

Prototipo de juego de gestión de países hecho con Godot 4.7 y C#/.NET 8. El proyecto permite probar comandos, crear ciudades y consultar los datos geográficos incluidos.

## Estado actual

- El estado de juego mantiene países y las ciudades que pertenecen a cada país.
- La escena permite avanzar un día, listar las ciudades de España (el país inicial), mostrar todas las ciudades del estado de juego y buscar una ciudad por nombre.
- El formulario permite crear una ciudad en un país ya existente.
- Los botones de la escena leen `data/countries-states-cities-palestina.json`: uno muestra los países y el otro muestra las ciudades del país escrito en el campo «País».
- El lector sigue la estructura `countries` → `states` → `cities`; las localidades conservan sus identificadores, coordenadas y zonas horarias.
- El juego carga y analiza el archivo JSON cada vez que se pulsa uno de esos botones. El archivo ocupa aproximadamente 47 MB; la carga todavía no está optimizada ni cacheada.

## Datos geográficos y atribución

Los archivos JSON de `data/` contienen información geográfica y de juego recopilada de distintas fuentes. La fuente geográfica incluye **Countries States Cities Database**, de [dr5hn](https://github.com/dr5hn/countries-states-cities-database), distribuida bajo la licencia [Open Database License 1.0 (ODbL)](https://opendatacommons.org/licenses/odbl/1-0/).

Al redistribuir esta fuente, conserva la atribución y cumple las condiciones de la ODbL.

## Requisitos

- Godot 4.7 con soporte para C#/.NET.
- .NET 8 SDK.

## Ejecutar

1. Abre `project.godot` con Godot 4.7 .NET.
2. Espera a que Godot importe y compile el proyecto.
3. Ejecuta el proyecto con F6/F5 o desde el botón de ejecución.
4. Escribe `next day`, `list cities`, `all cities` o `help` en el campo de comandos y pulsa Enter.
5. Escribe una ciudad en el campo de búsqueda y pulsa Enter.
6. Para listar países, pulsa «Mostrar países».
7. Para listar ciudades, escribe el nombre de un país en «País» y pulsa «Mostrar ciudades».

Los mensajes de depuración y errores aparecen en el panel Output de Godot. Las listas se muestran en el control de texto de la escena.

## Estructura

```text
core/       Estado, tiempo, comandos y lógica del juego
country/    Modelos de países y ciudades
data/       Datos geográficos JSON y su licencia/fuente
main/       Escena principal, controles e interacción de usuario
```
