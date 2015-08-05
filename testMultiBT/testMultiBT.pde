import oscP5.*;
import netP5.*;
import processing.serial.*;


final String[] btPortNames = new String[] {
  "/dev/tty.KT01-DevB",
  "/dev/tty.KT02-DevB"
};

Serial[] btSerial;
OscP5 oscP5;
NetAddress myRemoteLocation;

void setup() {
  println(Serial.list());
  
  oscP5 = new OscP5(this, 8000);
  myRemoteLocation = new NetAddress("127.0.0.1",12000);
  
  int numBTs = btPortNames.length;
  btSerial = new Serial[numBTs];
  for(int i = 0;i < numBTs;i++) {
    btSerial[i] = openSerialConnection(btPortNames[i]);
    btSerial[i].bufferUntil('\n');
  }
  
  size(300,200);
  textSize(24);
  text("bt all connected", 50, 50);
}

void draw() {
  
}

Serial openSerialConnection(String portName) {
  while(true) {
    try {
      return new Serial(this, portName);
    }
    catch(Exception e) {
      //openning Serial connection failed, try again after a delay
      delay(500);
    }
  }
}

void serialEvent(Serial p) {
  String inString = p.readString();
  if(inString != null && inString.length() > 0) {
    println(inString);
    sendValue(p.toString(),inString);
  }
}

void sendValue(String btName,String msg) {
  OscMessage oscMsg = new OscMessage("/btTest");
  //oscMsg.add(btName);
  oscMsg.add(msg);
  oscP5.send(oscMsg, myRemoteLocation); 
}

