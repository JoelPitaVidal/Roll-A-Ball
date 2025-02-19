# Explicación de los Scripts

## 1. CameraControler.cs
Este script controla la cámara para que siga al jugador con un desplazamiento constante.

### **Explicación**
- **player**: Referencia al objeto jugador.
- **offset**: Vector que almacena la distancia inicial entre la cámara y el jugador.
- **Start()**: Calcula el desplazamiento inicial entre la cámara y el jugador.
- **LateUpdate()**: Ajusta la posición de la cámara para que siga al jugador manteniendo la distancia inicial.

---

## 2. EnemyMovement.cs
Este script maneja el movimiento del enemigo hacia el jugador utilizando un NavMeshAgent.

### **Explicación**
- **player**: Referencia al objeto del jugador.
- **navMeshAgent**: Componente NavMeshAgent que se encarga del movimiento.
- **loseTextObject**: Objeto UI que muestra el mensaje de derrota.
- **Start()**: Obtiene la referencia del NavMeshAgent.
- **Update()**: Si el jugador existe, actualiza la posición de destino del enemigo.
- **OnCollisionEnter()**: Si el enemigo colisiona con el jugador, lo destruye, muestra el mensaje de derrota y pausa el juego.

---

## 3. FlyingPowerUp.cs
Este script activa la habilidad de vuelo cuando el jugador recoge un potenciador.

### **Explicación**
- **OnTriggerEnter(Collider other)**: 
  - Si el jugador entra en el área del objeto, obtiene su componente `PlayerController`.
  - Si el `PlayerController` existe, activa la habilidad de vuelo y destruye el potenciador.
  - Si el `PlayerController` no se encuentra, muestra una advertencia en la consola.

---

## 4. RotateObstacle.cs
Este script rota un obstáculo alrededor del eje Y con una velocidad configurable.

### **Explicación**
- **rotationSpeed**: Velocidad de rotación en grados por segundo.
- **Update()**: En cada fotograma, el objeto rota alrededor del eje Y con la velocidad establecida.

---

## 5. CameraSwitcher.cs
Este script permite cambiar entre diferentes cámaras presionando una tecla.

### **Explicación**
- **cameras**: Array que contiene todas las cámaras disponibles.
- **currentCameraIndex**: Índice de la cámara actualmente activa.
- **Start()**: Activa solo una cámara al inicio.
- **Update()**: Al presionar la tecla 'C', cambia a la siguiente cámara en la lista.
- **ActivateCamera(int index)**: Activa la cámara correspondiente y desactiva las demás.

---

## 6. FirstPersonCameraControler.cs
Este script controla la cámara en primera persona permitiendo rotación y seguimiento del jugador.

### **Explicación**
- **mouseSensitivity**: Sensibilidad del movimiento del ratón.
- **playerBody**: Referencia al cuerpo del jugador.
- **distanceFromPlayer**: Distancia de la cámara con respecto al jugador.
- **xRotation / yRotation**: Controlan la rotación de la cámara.
- **Update()**: Captura el movimiento del ratón y ajusta la rotación de la cámara.
- **FollowPlayer()**: Mantiene la cámara a una distancia fija del jugador.

---

## 7. PlayerController.cs
Este script maneja el movimiento del jugador, la recolección de objetos y el vuelo.

### **Explicación**
- **rb**: Referencia al Rigidbody del jugador.
- **count**: Número de objetos recolectados.
- **speed**: Velocidad del jugador.
- **jumpForce**: Fuerza del salto.
- **countText**: Texto en la UI que muestra la cantidad de objetos recolectados.
- **winTextObject**: Texto que indica la victoria.
- **canFly**: Indica si el jugador puede volar.
- **OnMove()**: Controla el movimiento del jugador.
- **OnJump()**: Permite que el jugador salte si está en el suelo.
- **IsGrounded()**: Verifica si el jugador está en el suelo.
- **FixedUpdate()**: Aplica fuerza al jugador para moverlo.
- **OnTriggerEnter()**: Maneja la recolección de objetos y activa la habilidad de vuelo.
- **EnableFlying()**: Activa la capacidad de vuelo.
- **SetCountText()**: Actualiza la UI con el conteo de objetos recolectados.
- **OnCollisionEnter()**: Maneja la colisión con enemigos y muestra el mensaje de derrota.

---

## 8. SpeedBoost.cs
Este script aplica un impulso al jugador cuando entra en contacto con un potenciador de velocidad.

### **Explicación**
- **pushForce**: Fuerza con la que se empuja al jugador.
- **OnTriggerEnter(Collider other)**:
  - Verifica si el objeto con el que colisiona es el jugador.
  - Obtiene el `Rigidbody` del jugador y aplica una fuerza en la dirección de la rampa.
  - Evita que el empuje afecte la dirección vertical del jugador.

 ### Enlace a la APK:
  '''
https://drive.google.com/drive/folders/1Q-MPBIEaA70ndIZyGn_yTwwDIp8A8s4Y?usp=drive_link
  '''
