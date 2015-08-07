#include <SoftwareSerial.h>

SoftwareSerial btSerial = SoftwareSerial(4,5);
SoftwareSerial btSerial2 = SoftwareSerial(6,7);

void setup() {
  // put your setup code here, to run once:
  btSerial.begin(9600);
  btSerial2.begin(9600);
  pinMode(13,OUTPUT);
}
char inputFromBT;
void loop() {
  // put your main code here, to run repeatedly:
  
//  if(btSerial.available() > 0) {
//    inputFromBT = (char)btSerial.read();
//    if(inputFromBT == 'c') {
//      digitalWrite(13,HIGH);     
//    }
//    else if(inputFromBT == 'd') {
//      digitalWrite(13,LOW);
//    }
//  }

  btSerial.println("I'm bt1");
  btSerial2.println("I'm bt2");

  delay(300);


}
