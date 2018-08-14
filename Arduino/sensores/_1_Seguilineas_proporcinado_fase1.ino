#include <Servo.h>
Servo servos[13];
/***   Variables globales  ***/

int _white=800;
int _black=30;
/***   Function declaration   ***/
void move_base(int l, int r, int speed, int advance, int turn);
int follow(int light, int gain);

/***   Configuracion: Configuro en parada: Velocidad 0, calibrando sensor seguilineas con blanco 40 y negro 730 */
void setup()
{
  servos[(5)].attach((5));
  servos[(9)].attach((9));
    move_base((5),(9),0,0,0);
  _white=40;
  _black=730;

}
/* moviendo con proporcion de la velocidad angular de nuestro robot (follow(analogRead((A0)),10))) parametro de turn de movimiento base */
/* OJO la velocidad es negativa porque tengo fisicamente el servo en la otra dirección"
void loop()
{
    move_base((5),(9),-28,28,follow(analogRead((A0)),10));
}

/***   Funcion de movimiento base: manda movimiento a los servos (left/rigth) desde la avance lineal y velocidad angular. ***/
/***  Entradas:  int l -> left pin 9 ***/
/***  Entradas:  int r -> rigth pin 5 ***/
/***  Entradas:  int speed -> velocidad del robot ***/
/***  Entradas:  int advance -> avance lineal ***/
/***  Entradas:  int turn ->  avance angular ***/
void move_base(int l, int r, int speed, int advance, int turn)
{
servos[l].write(90+(int)(65.0*(float)(speed*(advance-turn))/10000.0));
servos[r].write(90-(int)(65.0*(float)(speed*(advance+turn))/10000.0));
};
int follow(int light, int gain)
{
  return (int)(((float)(gain)/100.0)*((float)((_white-_black)/2+_black)-(float)(light)));
}
