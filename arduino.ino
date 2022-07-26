#include "HX710B.h"

const int DOUT = 3;   //sensor data pin
const int SCLK  = 2;   //sensor clock pin
float scaledatm = 0;

HX710B pressure_sensor; 

void setup() {
  Serial.begin(57600);
  pressure_sensor.begin(DOUT, SCLK);
}

void loop() {

  if (pressure_sensor.is_ready()) {
    /*
    Serial.print("Pascal: ");
    Serial.println(pressure_sensor.pascal());       // 100000 ~ 50000
    */
    scaledatm = 10 - (pressure_sensor.atm() *10);      //to go from lower to higher value when blowing into apparatus
    Serial.println(scaledatm);
    /*
    Serial.print("mmHg: ");
    Serial.println(pressure_sensor.mmHg());
    Serial.print("PSI: ");
    Serial.println(pressure_sensor.psi());
    */
  } else {
    Serial.println("Pressure sensor not found.");
  }

  delay(1000);

}
