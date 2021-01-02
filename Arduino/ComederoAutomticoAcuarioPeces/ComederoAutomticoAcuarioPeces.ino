/*
 * Programa: Servo temporizado de rotacion en dos direcciones
 * uso: Se usará para comedor de peces automatico
 * Realiza: cada ciclo por dia el servo gira 3 veces en dos direcciones para 
 * que le de tiempo a que caiga la comida de pez
*/

#include <Servo.h>


unsigned long CICLO_INTERVAL_DIA = 86400000; // 1 dia (tiempo en milisegundos)
unsigned long CICLO_INTERVAL_POR_CICLO = 4; // 4 veces por CICLO_INTERVAL_DIA
unsigned long TiempoDeLaUltimaVezQueMovioServo; // ultimo movimiento de servo en milisegundos
unsigned long TiempoEntreComida; // tiempo de cada comida
Servo myservo;  // objeto servo
int pos = 0;    // variable que almacena posicion del servo

int i; 



void setup() {
  myservo.attach(9,1000,2000);  // Analogica. engancho con pin 9 al servo para que reciba los datos de movimiento
  pinMode(13, OUTPUT); // Digital. pin 13 para salida de corriente para LED
  setupTimers(); // Establecimiento de ciclos de comida 
  myservo.write(90); // Se reinicia a 90º
  i=0 ;
}


/**
 * Mover el servo
 */

 void MoverServoComidaPeces(){
  
 for (i = 0; i <= 2; i+= 1){
  
   for (pos = 0; pos <= 180; pos += 1) { // va desde 0 a 180º en pasos de 1 grado.
      myservo.write(pos);              // le indica al servo que vaya a la posicion "pos"
      delay(15);                       // espera 15 ms antes de acabar.
    }
    for (pos = 180; pos >= 0; pos -= 1) { // // va desde 180º a 0º en pasos de 1 grado.
      myservo.write(pos);              // le indica al servo que vaya a la posicion "pos"
      delay(15);                       // espera 15 ms antes de acabar.
    }
  }
  
 }


/*
* Define los tiempos de comida
*/
void setupTimers() {
  TiempoDeLaUltimaVezQueMovioServo = millis();
  TiempoEntreComida = CICLO_INTERVAL_DIA / CICLO_INTERVAL_POR_CICLO;
}

/**
* Ha alcanzado el tiempo para dar de comer
*/
bool esTiempoAlcanzadoParaComer() {
// Espera a la siguiente alimentación
  if(millis() - TiempoDeLaUltimaVezQueMovioServo >= TiempoEntreComida) {
    TiempoDeLaUltimaVezQueMovioServo = TiempoDeLaUltimaVezQueMovioServo + TiempoEntreComida;
    return true;
  } else {
    return false;
  } 
}
 
/**
 * Arduino loop
 */
void loop() {
  if(esTiempoAlcanzadoParaComer()) { 
   MoverServoComidaPeces();
    myservo.write(90);
  }
}

