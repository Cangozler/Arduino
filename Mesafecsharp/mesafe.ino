const int trigPin = 5, echoPin = 6;
 long uzaklik;
 long sure;
 char t;
 void setup() {
   pinMode(trigPin, OUTPUT);
   pinMode(echoPin, INPUT);
   Serial.begin(9600);
 }
 void loop() {
   if(Serial.available()>0)
  t=Serial.read();
  if(t=='1')
    {
 digitalWrite(trigPin, LOW);
   delayMicroseconds(5);
   digitalWrite(trigPin, HIGH);
   delayMicroseconds(10);
   digitalWrite(trigPin, LOW);
   sure = pulseIn(echoPin, HIGH);
   uzaklik = sure / 2 / 29.1;
   if(uzaklik > 200)
   uzaklik = 200;
 Serial.println(uzaklik);
   delay(100);
     } 
 }
