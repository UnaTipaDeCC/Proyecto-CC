# Proyecto-CC
Funcionamiento del juego:
Al iniciar el juego aparecerá en pantalla un menú inicial con dos opciones: jugar ( que da paso a la escena del juego) e indicaciones(con una serie de indicaciones básicas para el jugador)
Cada jugador cuenta con un mazo que contiene:
-Cartas de unidad que pueden ser de plata u oro(estas no son afectadas por las cartas especiales) y además pueden tener efectos o no(en caso de tenerlos se activan una sola vez, cuando la carta es jugada)
-Cartas especiales: las señuelo (son cambiadas por la carta de plata del campo que más poder tenga y en caso de que no hayan cartas de plata o el campo esté vacío, se mueven a una fila en específico), las clima (que afectan a las cartas de plata de una zona en específico de ambos jugadores que están en el campo en el momento en el que se juega y a todas aquellas que se van agregando) , las despeje (envían al cementerio las cartas clima de una zona  en específico y revierte el daño provocado por la misma), las aumento (afectan a una fila en específico y solo a aquellas cartas que estén en el campo en el momento en el que fue jugada)
Una vez  en la escena del juego, cada jugador debe hacer click sobre su respectivo deck y aparecerán en su mano las 10 cartas con las que jugará, teniendo la opción de hacer click derecho sobre dos de ellas para cambiarlas por otras aleatorias de su deck (una vez jugada una carta perderá la opurtunidad de hacerlo)
Siempre el primer turno le corresponde al jugador de la facción Hormigas Bravas (jugador uno)
Cada turno consiste en jugar una de las cartas de la mano, invocar la carta lÍder (puede ser invocada una vez durante toda la partida y su efecto se activa en caso necesario en cualquier momento de la misma, no precisamente en la misma ronda en la que es activada la carta) o pasarse
Una vez ambos jugadores se hayan pasado termina la ronda, se comparan los contadores de ambos jugadores y se actualiza el contador de  partidas ganadas, sumándole un punto al del ganador, en caso de empate ambos reciben un punto
El juego culmina cuando uno de los jugadores haya ganado al menos dos partidas


Aspetos generales acerca de la estructura del código:
GameManager: controla algunos aspectos generales de la lógica del juego como los turnos, los cambios de ronda, el final del juego y la restauración de las variables modificadas a sus valores iniciales, que sean activadas o no las cartas líderes, que se hayan cambiado o no las cartas al iniciar el juego 
Cartas: su funcionamiento esta dividido en varios scripts que se encaragan de controlar el movimiento de las mismas hacia las zonas que les corresponde, los efectos en caso de que los tengan y la forma en que se muestran en el display. Están divididas en dos clases principales (Card en el caso de las de unidad y SpecialCards en el caso de las especiales), de manera general se trabaja con ellas por separado puesto que presentan propiedades diferentes
Tablero, Cementery, SpecialZones: Contienen las listas que le corresponden a cada zona del tablero y con las cuales se trabaja en diferentes scripts. En el caso de la clase Tablero también controla una suma parcial de los puntos de cada zona, la cual es utilizada en el contador de cada jugador.
Otros scripts: controlan aspectos menos generales como los contadores de puntos y de partidas ganadas, los botones para pasar turno, el funcionamiento del menú principal  

