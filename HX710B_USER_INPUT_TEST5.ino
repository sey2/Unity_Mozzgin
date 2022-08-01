#include "HX710B.h"

const int DOUT = 2;   //sensor data pin
const int SCLK  = 3;   //sensor clock pin

String nameUser = "";


HX710B pressure_sensor; 

void setup() {
  Serial.begin(57600);
  Serial.println("Please enter your name and press ENTER");
   while (Serial.available() == 0) {}
      nameUser = Serial.readString();
      Serial.println("Your Name: " +nameUser);
      Serial.println("");
      Serial.read();
   pressure_sensor.begin(DOUT, SCLK);
}

void loop()
{
    
  if (pressure_sensor.is_ready())
  {
  
    Serial.print("Pascal: ");
    Serial.println(pressure_sensor.pascal());
    Serial.print("ATM: ");
    Serial.println(pressure_sensor.atm());
    Serial.print("mmHg: ");
    Serial.println(pressure_sensor.mmHg());
    Serial.print("PSI: ");
    Serial.println(pressure_sensor.psi());
  }
  else
  {
    Serial.println("Pressure sensor not found.");
  }

  delay(1000);
  
}
