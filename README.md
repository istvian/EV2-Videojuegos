# Evaluación 2 - Desarrollo de Videojuegos

<img width="1920" height="1080" alt="Captura desde 2026-10-18 17-53-14" src="https://github.com/user-attachments/assets/22de4d76-7329-4ec0-9baf-4fef6b12b4d4" />

>[!IMPORTANT]
> Se puede probar el juego [aquí](https://istvian.github.io/EV2-Videojuegos/)

## Controles
Flechas izquierda y derecha para movimiento.
Tecla X para saltar.
Tecla R para reiniciar nivel.

## Plataforma
Para el juego actual se definió la plataforma PC. Mi pc actual cuenta con sistema operativo Ubuntu Linux, por lo que la versión del proyecto esta en linux, pero también es compatible con otros sistemas operativos de escritorio.

<img width="1920" height="1080" alt="Captura desde 2026-10-18 17-42-17" src="https://github.com/user-attachments/assets/661515db-9516-4a07-ac08-fd7d418a3b80" />

> [!NOTE]
> Para testear de mejor manera el juego sin tener que convertir el proyecto se adjuntan builds de linux y web


## Motor de renderización
Se utilizó el motor URP 2D, en especifico se aprovecharon el sistema de iluminación 2D + Shadow Catchers y el sistema de Volume (Post procesado).

## Herramientas del motor
Para el sistema de cámara se utilizó una herramienta interna llamada Cinemachine que tiene seguimiento suave por defecto.

## Lógica
### Condición de victoria
El juego es un plataformas simple donde el personaje debe obtener todas las monedas del nivel, mover cajas, recoger una llave para abrir una puerta que lo lleva a la victoria.
<img width="1920" height="1080" alt="Captura desde 2026-10-18 17-53-46" src="https://github.com/user-attachments/assets/37bd3368-6767-4c7b-b933-4a717c18f9c5" />


### Condición de derrota
El jugador puede perder al tocar al enemigo. 

<img width="1920" height="1080" alt="Captura desde 2026-10-18 17-53-31" src="https://github.com/user-attachments/assets/19338ebf-977d-451a-8629-c6c4e2a09987" />
<img width="1920" height="1080" alt="Captura desde 2026-10-18 17-53-56" src="https://github.com/user-attachments/assets/33829f84-b096-4eb4-80db-b6d68157939e" />


### Puntuación
La puntuación es la cantidad de monedas recogidas

### Gestión de escenas / estados

El juego recarga la escena actual al presionar la tecla R. 

Los estados son: jugando, derrota, victoria. Que se reflejan mediante la interfaz de usuario y el uso de Canvas, texto, etc.

## Física
Este proyecto utiliza fisicas para realizar el salto del personaje principal, además de físicas para interactuar con las cajas que son necesarias para acceder a ciertos lugares en altura. El personaje, el tilemap, las monedas, el enemigo, todos tienen colliders, algunos funcionan como triggers (ej: monedas).
Además el personaje utiliza overlapbox para detectar el piso y raycast para detectar paredes y reducir la velocidad al empujar cajas.

<img width="1920" height="1080" alt="Captura desde 2026-10-18 17-53-23" src="https://github.com/user-attachments/assets/99417d42-ee80-4d2a-9c8c-3089c500e95d" />

## Sonido
Se agrego un componente AudioSource con música en loop, además de un script para que cuando se reinicie la escena no se corte. Se utiliza DontDestroyOnLoad + Singleton.

Para los SFX se utiliza un componente SFX que contiene un script que lista los efectos de sonido y proporciona in Singleton para acceso desde cualquier otro script.

## Buenas prácticas
Se utilizaron prefabs en las monedas y cajas. Además de [SerializedField] en los scripts.
