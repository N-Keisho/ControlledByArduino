#define echoPin 2
#define trigPin 3
#define MAX 350
#define MIN 20
#define YMAX 300
 
double Duration = 0;
double Distance = 0;

void setup() {
Serial.begin( 9600 );
pinMode( echoPin, INPUT );
pinMode( trigPin, OUTPUT );
}

void loop() {
  digitalWrite(trigPin, LOW); 
  delayMicroseconds(2); 
  digitalWrite( trigPin, HIGH );
  digitalWrite( trigPin, LOW );
  Duration = pulseIn( echoPin, HIGH );

  if (Duration > 0) {
    Duration = Duration/2;
    Distance = Duration*340*1000/1000000;

    if (Distance > MAX) Distance = MAX;
    else if (Distance < MIN) Distance = MIN;

    Distance = map(Distance, MIN, MAX, -1 * YMAX, YMAX);

    Serial.println(Distance);
  }
  delay(50);
}