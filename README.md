# Spawn System

Sistema de Spawn // Montserrat Godinez Núñez - Parcial 03

Este es un sistema de spawn, cuyos spawners , de área o puntos de spawn, crean objetos después de cierto tiempo, con variaciones de tamaño. También se crean en posiciones aleatorias un determinado número de spawners creados previamente, así como crear con parámetros aleatorios (dentro de los rangos definidos por el usuario) spawners de área.

El proyecto está listo para solo agregar los scripts y prefabs en los objetos de tu proyecto y desde el mismo editor configurarlos para brindarte una mayor comodidad sin que tengas que sufrir por saber qué código hace qué cosa.

# Índice

- [Contenido](https://www.notion.so/Contenido-25a8aeec1d4f42398efa824d50b00e01)
- [Instalación](https://www.notion.so/Instalaci-n-6bb5ded3e6ad42fb8128bd3a18b56533)
    - [Configurar una Nueva Escena o Nuevos Objetos](https://www.notion.so/Configurar-una-Nueva-Escena-o-Nuevos-Objetos-d4f1ae38573f4ce49ca4d7fdd4b13776)
        - [SpawnManager](https://www.notion.so/SpawnManager-5ebc6a8d40774d34a37d55ff2b2bfd1f)
        - [](https://www.notion.so/e3713a4f79a74cdfb79c44ac987cad52)
        - [UI](https://www.notion.so/UI-4738ead3cfa44da386d43b6cb2792587)
            - [](https://www.notion.so/716bfa7e03f0489581a707e51c0c7481)
- [Funcionalidades de Modificar el Código](https://www.notion.so/Funcionalidades-de-Modificar-el-C-digo-c4f071b2bce1416aacfedb61738a0dbc)
    - [SpawnedStats](https://www.notion.so/SpawnedStats-615f8bc97d464faebe98a914b8886660)
- [Recomendaciones](https://www.notion.so/Recomendaciones-72b56cd3b3f340769686e9b993bad04e)
    - [Usa traductor para los errores si no sabes inglés](https://www.notion.so/Usa-traductor-para-los-errores-si-no-sabes-ingl-s-a7d1a15dccaa4828adb8302ae549440c)
    - [No modifiques los scripts!](https://www.notion.so/No-modifiques-los-scripts-275236a2d896489f928703662dafa4d6)
- [Contacto](https://www.notion.so/Contacto-6b6bee9db20f45e28a7cd7dcda8ea805)

---

# Contenido

- Administrador de Spawners (SpawnManager).
- Spawners que crean objetos dentro de áreas (SpawnType.AREA).
- Spawners que crean objetos en puntos específicos (SpawnType.POINTS).
- UI que muestra los estatus del SpawnManager, el Spawner seleccionado, y los objetos creados. Las teclas utilizadas para cambiar el objeto del que vemos el estatus se pueden modificar desde el inspector.
    - Tecla F para ocultar y mostrar el UI.
    - Teclas I y K para cambiar entre los Spawners.
    - Teclas J y L para cambiar entre los Objetos.
    - Teclas U y O para cambiar entre los Puntos de Spawn.
- Script sencillo para mover a los objetos cuando colisionan con otro objeto.
- Paquete de movimiento de personaje por JeCase (****Modular First Person Controller).****
    - Teclas WASD para moverse por la escena.
    - Mouse para girar la cámara.
    - Tecla Shift para correr.
    - Tecla Ctrl para agacharse.

[Modular First Person Controller](https://assetstore.unity.com/packages/3d/characters/modular-first-person-controller-189884)

- Paquete de Fantasmas de colores por SR Studios Kerala (Little Ghost (Free)), utilizados como objetos prueba de spawn.

[Little Ghost (Free)](https://assetstore.unity.com/packages/3d/characters/little-ghost-free-229325)

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8) 

---

# Instalación

- Descarga el paquete de Assets “HomingMissileSystemAssets”, el cual lo encontrarás en el repositorio Parcial3-ProgramacionII_Sistema-de-Spawn.

[https://github.com/MGN-MK/Parcial3-ProgramacionII_Sistema-de-Respawn](https://github.com/MGN-MK/Parcial3-ProgramacionII_Sistema-de-Respawn)

<aside>
⚠️ En caso de que el acceso directo no funcione, copia y pega el siguiente link en un buscador: [MGN-MK/Parcial3-ProgramacionII_Sistema-de-Spawn](https://github.com/MGN-MK/Parcial3-ProgramacionII_Sistema-de-Respawn)

</aside>

- Dentro de tu proyecto importa el paquete de Assets “SpawnSystemAssets”, este generará los archivos necesarios para poder utilizarlo, incluyendo los scripts organizados en carpetas, algunos prefabs de prueba, y unos efectos de partículas de prueba.
    - Si no tienes un proyecto de unity, solo haz doble click sobre el archivo del paquete
    - Puedes simplemente arrastrar el archivo del paquete dentro de tu proyecto
    - Puedes hacer click derecho en la carpeta del proyecto y seleccionar (Import Package > Custom Package), para después elegir el archivo del paquete.
- Puedes utilizar y personalizar la escena “SpawnSystem” que viene precargada, o crea una nueva escena donde personalizarás tus spawners que necesites.

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8) 

# Configurar una Nueva Escena o Nuevos Objetos

Si estás utilizando la escena que viene por defecto o los prefabs de prueba puedes saltarte estos pasos.

### SpawnManager

1. Con el prefab de prueba:
    1. Agrega a la escena el prefab “SpawnManager” (Prefabs > SpawnManager).
2. Configurando uno propio:
    1. Al objeto que será tu SpawnManager agregale el script “SpawnManager” (Scripts > SpawnManager), y rellena los campos con sus respectivos componentes. 
    - Already Created SpawnPoints (Spawner ya creados)
        - Spawn Created. Actívalo si tienes en tu escena spawners ya creados.
        - Spawn Tag. Agrega a la lista los tags de tus spawners.
        
        **AL ESCRIBIR LOS TAGS CUIDA LA ORTOGRAFÍA, ESPACIOS Y MAYÚSCULAS**
        
        - Spawn Points Created. Esta lista guarda los spawners cuyos tags coinciden con alguno que hayas agregado a la lista. Se rellena en automático al iniciar el juego.
    - Create Random Spawn Already Made (Crear spawners aleatorios a partir de unos ya hechos)
        - Spawn Random Made. Actívalo si quieres que en tu escena se creen spawners que ya hayas creado en posiciones aleatorias.
        - Spawn Count. Escribe el número de spawners que se crearán.
        - Spawn Area. Escribe las coordenadas límite del área dentro de la cual se crearán los nuevos spawners. Se marca en la escena con un prisma cuadrangular de color cyan.
        - Prfbs Spawn. Agrega a la lista los prefabs de tus spawners ya creados.
        - Seed Spawns Maded. Escribe la semilla para la generación de los spawners para obtener el mismo resultado cada vez. Deja el espacio vacío para tener una generación diferente cada vez.
        - Current Seed Spawns Maded. Guarda la semilla numérica. Se rellena de forma automática al comenzar el juego.
        - Spawn Points Random. Esta lista guarda los spawners creados. Se rellena en automático al iniciar el juego.
- Create Random SpawnAreas (Crear spawners de área aleatorios con parámetros aleatorios dentro del rango especificado)
    - Spawn Random. Actívalo si quieres que en tu escena se creen spawners completamente aleatorios (dentro del rango que designes).
    - Spawn Random Count. Escribe el número de spawners que se crearán.
    - Obj Spawn Max. Escribe el número máximo de objetos que pueden crear los spawners.
    - Obj Spawn Min. Escribe el número mínimo de objetos que pueden crear los spawners.
    - Spawn Time Max. Escribe el tiempo limite máximo para el intervalo máximo entre la creación de objetos.
    - Spawn Time Min. Escribe el tiempo límite mínimo para el intervalo máximo entre la creación de objetos.
    - Off Size Max. Escribe el porcentaje límite máximo para el porcentaje máximo de variación del tamaño de los objetos.
    - Off Size Min. Escribe el porcentaje límite mínimo para el porcentaje máximo de variación del tamaño de los objetos.
    - Spawn Random Area. Escribe las coordenadas límite para el área de spawn de los spawners.
    - Spawn Random Pos. Escribe las coordenadas límite del área dentro de la cual se crearán los nuevos spawners.
    - Spawners Base. Agrega a la lista los prefabs de tus spawners base sobre los cuales variar los parámetros.
    - Seed Random Spawns. Escribe la semilla para la generación de los spawners para obtener el mismo resultado cada vez. Deja el espacio vacío para tener una generación diferente cada vez.
    - Current Seed Random Spawns. Guarda la semilla numérica. Se rellena de forma automática al comenzar el juego.
    - Spawn Points Generated. Esta lista guarda los spawners creados. Se rellena en automático al iniciar el juego.

### Spawners

1. Con el prefab de prueba.
    1. Agrega el prefab “SpawnArea” (Prefabs > SpawnArea).
    2. Agrega el prefab “SpawnPoints” (Prefabs > SpawnPoints).
2. Configurando uno propio.
    1. Al objeto que será tu spawner agregale el script “SpawnPointsBase” (Scripts > SpawnPointsBase), y rellena los campos con sus respectivos componentes. 
    - Spawn Type. Selecciona el tipo de spawnere según a cómo quieres que cree los objetos.
        - AREA. Crea los objetos en posiciones aleatorias dentro del árrea designada.
        - POINTS. Crea los objetos en las posiciones de una lista de objetos (Spawn Points), de los que escoge aleatoriamente.
    - Prfbs. Agrega los prefabs de los objetos que el spawner creará.
    - Objects. Escribe el número límite de objetos que el spawner creará.
    - Time Min. Escribe el tiempo mínimo de espera para crear un nuevo objeto.
    - Time Max. Escribe el tiempo máximo de espera para crear un nuevo objeto.
    - Size Offset Percentage. Escribe el porcentaje de variación del tamaño de los objetos creados.
    - Spawned. Esta lista guarda los objetos creados. Se rellena en automático al iniciar el juego.
    - Spawn Points. Esta lista guarda los puntos de spawn. Se rellena en automático al iniciar el juego. Para que los reconozca estos puntos de spawn deben ser hijos del objeto con el script.
    - Range for AreaSpawn (Area de Spawn)
        - Range Spawn.  Escribe las coordenadas límite para el área de spawn de los spawners. Solo se aplica cuando el tipo de spawn es de AREA.
    - Seed Management (Manejo de la Semilla)
        - Seed. Escribe la semilla para la generación de los spawners para obtener el mismo resultado cada vez. Deja el espacio vacío para tener una generación diferente cada vez.
        - Current Seed. Guarda la semilla numérica. Se rellena de forma automática al comenzar el juego.

### Código para mover objetos cuando chocan con otro objeto

1. A tu objeto  agregale el script “CheckPosition” (Scripts > CheckPosition), y rellena los campos con sus respectivos componentes. 
- Offset. Escribe la distancia que se moverá el objeto para dejar de chocar con otro objeto.
- FloorTag. Escribe el tag del suelo para que no se mueva por solo tocarlo.

**AL ESCRIBIR LOS TAGS CUIDA LA ORTOGRAFÍA, ESPACIOS Y MAYÚSCULAS**

- Pos Spawn. Guarda las coordenadas dónde apareció el objeto. Se rellena de forma automática cuando se crea el objeto.

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8) 

## UI

Necesitas tener un canvas en Escena, utiliza el que tengas o crea uno nuevo.

1. Con los prefabs de prueba.
    1. Agrega a la escena el prefab “SpawnedStats” (Prefabs > SpawnedStats), es un canvas predeterminado para la interfaz de estatus del Spawn Manager, los Spawners, los Puntos de Spawn, y los Objetos.
2. Configurando uno propio.
    1. Al objeto padre que contiene lo que muestran tus estadísticas agrégale el script “SpawnedStats” (Scripts > SpawnedStats), y rellena los campos con sus respectivos componentes.
        - Arrow. Toma el objeto que señalará el objeto mostrado en los stats y arrástralo para agregarlo.
        - Player Tag. Escribe el tag del jugador para que el objeto Arrow mire hacia él en todo momento.
            
            **AL ESCRIBIR LOS TAGS CUIDA LA ORTOGRAFÍA, ESPACIOS Y MAYÚSCULAS**
            
        - Buttons (Botones para interactuar con el UI)
            - Show And Hide. Selecciona la tecla con la que se mostrará y ocultará el interfaz de estatus.
            - Next Spawner. Selecciona la tecla con la que se pasará al siguiente Spawner en la lista.
            - Previous Spawner. Selecciona la tecla con la que se pasará al Spawner previo en la lista.
            - Next Spawn Point. Selecciona la tecla con la que se pasará al siguiente Spawn Point en la lista.
            - Previous Spawn Point. Selecciona la tecla con la que se pasará al Spawn Point previo en la lista.
            - Next Obj. Selecciona la tecla con la que se pasará al siguiente Objeto en la lista.
            - Previous Obj. Selecciona la tecla con la que se pasará al Objeto previo en la lista.
        - Texts (Textos)
            - Random Made Seed. Toma el objeto TextMeshPro que corresponda a la semilla de la creación aleatoria de Spawners ya creados y arrástralo para agregarlo. Se muestra como un número.
            - Random Generated Seed. Toma el objeto TextMeshPro que corresponda a la semilla de la creación aleatoria de Spawners con parámetros aleatorios y arrástralo para agregarlo. Se muestra como un número.
            - Spawners Num. Toma el objeto TextMeshPro que corresponda al número de Spawners creados y arrástralo para agregarlo. Se muestra como un número.
            - Id Spawn. Toma el objeto TextMeshPro que corresponda al nombre del Spawner y arrástralo para agregarlo. Se muestra como un texto.
            - Id Number Spawn. Toma el objeto TextMeshPro que corresponda al número de identificación del Spawner y arrástralo para agregarlo. Se muestra como un número.
            - Spawn Type. Toma el objeto TextMeshPro que corresponda al tipo de spawn del Spawner y arrástralo para agregarlo. Se muestra como un texto.
            - Spawning Time. Toma el objeto TextMeshPro que corresponda al tiempo de creación de los objetos y arrástralo para agregarlo. Se muestra como un número compuesto de “TiempoMínimo - TiempoMáximo (TiempoUtilizado)”.
            - Spawned Obj Number. Toma el objeto TextMeshPro que corresponda al número de objetos que el Spawner ha creado y arrástralo para agregarlo. Se muestra como un número.
            - Spawner Size. Toma el objeto TextMeshPro que corresponda al tamaño del área del Spawner y arrástralo para agregarlo. Se muestra como unas coordenadas x, y, z. Solo se muestra cuando el Spawner es de tipo AREA. En caso contrario muestra el mensaje "Doesn't apply.” (No aplica).
            - Spawner Points Number. Toma el objeto TextMeshPro que corresponda al número de puntos de spawn del Spawner y arrástralo para agregarlo. Se muestra como un número. Solo se muestra cuando el Spawner es de tipo POINTS. En caso contrario muestra el mensaje "Doesn't apply.” (No aplica).
            - Spawner Seed. Toma el objeto TextMeshPro que corresponda la semilla de la selección de posición aleatoria del Spawner y arrástralo para agregarlo. Se muestra como un número.
            - Spawner Point Name. Toma el objeto TextMeshPro que corresponda al nombre del Spawn Point y arrástralo para agregarlo. Se muestra como un texto. Solo se muestra cuando el Spawner es de tipo POINTS. En caso contrario muestra el mensaje "Doesn't apply.” (No aplica).
            - Spawner Point ID. Toma el objeto TextMeshPro que corresponda al número de identidficación del Spawn Point y arrástralo para agregarlo. Se muestra como un número. Solo se muestra cuando el Spawner es de tipo POINTS. En caso contrario muestra el mensaje "Doesn't apply.” (No aplica).
            - Spawner Point Pos. Toma el objeto TextMeshPro que corresponda a la posición del Spawn Point y arrástralo para agregarlo. Se muestra como unas coordenadas x, y, z. Solo se muestra cuando el Spawner es de tipo POINTS. En caso contrario muestra el mensaje "Doesn't apply.” (No aplica).
            - Id Obj. Toma el objeto TextMeshPro que corresponda al nombre del objeto seleccionado y arrástralo para agregarlo. Se muestra como un texto.
            - Id Number Obj. Toma el objeto TextMeshPro que corresponda al número de identificación del objeto seleccionado y arrástralo para agregarlo. Se muestra como un número.
            - Obj Spawn Pos. Toma el objeto TextMeshPro que corresponda a la posición donde se creó el objeto seleccionado y arrástralo para agregarlo. Se muestra como unas coordenadas x, y, z.
            - Obj Pos Toma el objeto TextMeshPro que corresponda a la posición actual del objeto seleccionado y arrástralo para agregarlo. Se muestra como unas coordenadas x, y, z.
            - Obj Size. Toma el objeto TextMeshPro que corresponda a la escala del objeto seleccionado y arrástralo para agregarlo. Se muestra como unas coordenadas x, y, z.

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8) 

---

# Funcionalidades de Modificar el Código

## SpawnedStats

Dentro del script “SpawnedStats” (Scripts > SpawnedStats), tal vez requieras acceder a la información de estatus para utilizarlo en tus propios códigos. Estos datos se encuentran declarando el contenido de los TextMeshProUGUI, como en el siguiente bloque:

```csharp
private void SetStats()
    {
        randomMadeSeed.text = randomMadeSeedtext + spawnManager.currentSeedSpawnsMaded;
        randomGeneratedSeed.text = randomGeneratedSeedtext + spawnManager.currentSeedRandomSpawns;
        spawnersNum.text = spawnersNumtext + spawnManager.allSpawnsGet.Length;
    }
```

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8) 

---

# Recomendaciones

## Usa traductor para los errores si no sabes inglés

Los códigos y mensajes de error se encuentran en inglés debido a que es el lenguaje universal para estos. Sin embargo, el contenido es fácil de entender incluso traduciéndolo con algún traductor en línea, úsalo si así lo requieres.

## No modifiques los scripts!

Esto debido a que estos están relacionados entre sí. El sistema de  misiles auto-dirigidos  está diseñado para solo agregar los scripts y prefabs en los objetos de tu proyecto y desde el mismo editor configurarlos para brindarte una mayor comodidad.

 Solo modifícalos para integrar el sistema a los sistemas que ya tienes en el proyecto (Sistemas de progresión, de movimiento, de inventario, etc.), o hacer las modificaciones sugeridas en [Funcionalidades de Modificar el Código](https://www.notion.so/Funcionalidades-de-Modificar-el-C-digo-c4f071b2bce1416aacfedb61738a0dbc) .

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8) 

# Contacto

Dudas, comentarios y sugerencias las puedes enviar al siguiente correo con el asunto “GitHub SpawnSystem”:

MontseG700@gmail.com

[Índice](https://www.notion.so/ndice-3044ed0853e24eaa8309a3ec0fc84df8)