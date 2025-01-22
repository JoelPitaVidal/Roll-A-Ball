# Roll-A-Ball

## Script de cámaras

### CameraControler:
Este script calcula la posicion offset entre la camara y el jugador,
luego calcula el vector entre la camara y el jugador con las posiciones iniciales, lo actualíza y con la siguiente línea se mantiene la posición de la camara con respecto al jugador.

-`transform.position = player.transform.position + offset;`

### CameraSwitcher:
Este script crea un array con las diferéntes cámaras, y cuando 
el usuário pulsa la tecla "C" se suma uno al array y se activa
la siguiente cámara en la lista de arrays

### FirstPersonCameraControler:
Este scrípt controla la visión de la cámara en primera persona
a través del mouse, con un Offset mantenemos la cámara a una distancia fija del jugador 

Utilizando los Ejes "x" e "y" capturamos el movimiento del ratón, así como su sensibilidad  en las diferentes direcciones y con
transform.position hacemos que la cámara siga al jugador con la misma distancia y offset que calculamos inicialmente
