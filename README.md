# GhostApocalypse

Crear en Unity un videojuego en 2D llamado GhostApocalypse. El objetivo del juego es impedir
una invasión de fantasmas deteniendo su avance con una barrera móvil.

La pantalla en modo play de Unity debe ajustarse a Full HD (1920x1080) para la correcta
visualización de la acción del juego.

## Fantasmas
Los fantasmas aparecen por la parte izquierda de la pantalla, en cinco puntos predefinidos. A partir
de ellos se mueven horizontalmente hacia la derecha a una velocidad constate de 6 m/s.

Los puntos predefinidos donde se espanean los fantasmas están en las posiciones (-10, 2.45, 0),
(-10, 1.66, 0), (-10, 0, 0), (-10, -1.24, 0) y (-10, -3.14, 0).

Los fantasmas ejecutarán la animación de avance que presenta una oscilación de su sábana y sus
ojos. Esta animación se crea a partir del sprite fantasmas.png, usando los 6 primeros frames, los
de la fila superior con el fantasma en color rojo.

En cada frame se decidirá aleatoriamente, con una probabilidad 0.001 si se debe espanear un
fantasma. Si la decisión es positiva se escogerá de forma aleatoria equiprobable entre los cinco
puntos de espaneo, en cual de ellos se espaneará el fantasma. Cuando se espanea un fantasma se
reproducirá el sonido GhostSpawn.wav.

Cada fantasma espaneado podrá decidir moverse oblicuamente en lugar de horizontalmente. La
decisión de moverse oblicuamente tendrá una probabilidad de 0.1.

Si un fantasma se mueve oblicuamente deberá decidir la dirección de su movimiento de tal forma
que llegue a la altura de la barrera dentro de su alcance. Esto es, el pivote del fantasma debe de estar
entre los límites inferior y superior alcanzables por el cuerpo de la barrera. Su velocidad de
desplazamiento seguirá siendo la misma, por lo que tardará más en atravesar la pantalla que si se
moviera horizontalmente.

El fantasma deberá destruirse a si mismo una vez superado el valor 20 en la coordenada X.

## Barrera
En la parte derecha de la pantalla se mostrará la barrera, que será el objeto manejado por el jugador.
La barrera consiste en un cuadrado escalado a (0.5, 2, 1) y que deberá iniciar el juego situada
en (8.5, 0, 0). El jugador podrá mover verticalmente la barrera usando las teclas del cursor
arriba y abajo. La barrera se moverá en el sentido indicado mientras el jugador mantenga la
correspondiente tecla pulsada, deteniéndose a ser liberada. La velocidad de desplazamiento de la
barrera será de 8 m/s. El recorrido vertical tendrá como límites superior e inferior las coordenadas
(8.5, 4, 0) y (8.5, -4, 0), respectivamente.

Cuando un fantasma choque contra la barrera, detendrá su movimiento y ejecutará la animación de
destrucción del mismo, que representa una pequeña explosión. También en este momento se
reproducirá el sonido GhostHit.wav. Al terminar la animación de destrucción se destruirá el
GameObject correspondiente al fantasma.

Deberá contarse el número de fantasmas destruidos por el jugador y cada vez que esta cuenta
cambie deberá mostrarse un mensaje en consola con el nuevo valor.

Se debe evitar que los fantasmas puedan chocar entre si mediante un mecanismo de capas.

Cuando un fantasma alcance la coordenada X 10 se considerará que ha superado los intentos del
jugador por detenerlo y restará vida del jugador. Cuando cambie el valor de vida del jugador, deberá
mostrase el nuevo valor en consola. El valor de vida comenzará en 4 y una vez que alcance 0
terminará el juego. En ese momento se detendrá el espaneo de fantasmas, los fantasmas existentes
dejarán de moverse y la barrera dejará de responder a las órdenes del jugador. Además deberá
aparecer en la pantalla el cartel con el texto “GAME OVER”, creado con el sprite game_over.png.
El cartel deberá mostrarse en las coordenadas (0, 0, 0).

Se mostrará también un marcador de vidas restantes en la parte central superior de la pantalla. Este
consistirá en 4 imágenes procedentes del primer frame del sprite del fantasma, situadas en las
posiciones (-0.75, 4.5, 0), (-0.25, 4.5, 0), (0.25, 4.5, 0) y (0.75, 4.5, 0). Las
imágenes estarán escaladas a 0.6 en sus tres dimensiones. Cada vez que se reste una vida al jugador se
hará desaparecer el correspondiente fantasma, comenzando por el situado más a la derecha.

## Puntuaciones
Al golpear contra la barrera, cada fantasma anunciará la puntuación que le da al jugador, haciendo
aparecer un cartel con el valor correspondiente. Este valor será de 100 puntos en los fantasmas con
comportamiento normal y de 150 en los que se mueven en diagonal.

El cartel se deberá hacer aparecer a un metro por encima de la posición del fantasma y se desplazará
hacia arriba a una velocidad de 2.5 m/s. Al mismo tiempo que se desplaza, se irá desvaneciendo, de
forma paulatina, hasta desaparecer completamente al cabo de 1.2 segundos. Tras desaparecer
deberá destruirse el objeto.

Se llevará una cuenta de los puntos totalizados, que se mostrarán en un marcador de cinco dígitos en
la parte superior derecha de la pantalla. El marcador debe estar situado en la posición (7, 4.5, 0),
y los dígitos deben estar colocados de forma simétrica respecto a esa misma posición, separados
horizontalmente por 0.35 metros.

## Reinicio del juego
Tras haber llegado al fin del juego, al pulsar la tecla F1 se iniciará una nueva partida
