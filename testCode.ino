void setup() {
  Serial.begin(9600);

}

void loop() {
  int random_int = random(0,11);
  float random_float = random_int / 11.0;
  Serial.println(random_float * 10.0);
  delay(1000);

}