//Button
const int buttonPin = 2;

const int leftButton = 4;
const int rightButton = 5;

//JoyStick
const int joystickX = A1;
const int joystickY = A0;

int xValue = 0;
int yValue = 0;

void setup()
{
  Serial.begin(9600);

  //button
  pinMode(buttonPin, INPUT);

  pinMode(leftButton, INPUT);
  pinMode(rightButton, INPUT);

  //Joystick
  pinMode(joystickX, INPUT);
  pinMode(joystickY, INPUT);

}

void loop()
{

  //BUTTON
  if (digitalRead(buttonPin) == HIGH)
  {
    //Serial.print("Button Hit");
    Serial.write(1);
    Serial.write(0);
    Serial.flush();
    delay(1000);
  }

   if (digitalRead(leftButton) == HIGH)
  {
    //Serial.print("Button Hit");
    Serial.write(2);
    Serial.write(0);
    Serial.flush();
    delay(20);
  }

    if (digitalRead(rightButton) == HIGH)
  {
    //Serial.print("Button Hit");
    Serial.write(3);
    Serial.write(0);
    Serial.flush();
    delay(20);
  }

  //JOYSTICK
  xValue = analogRead(joystickX);
  yValue = analogRead(joystickY);

  //Serial.println(xValue);
  //Serial.println(yValue);

  //if ((xValue >=100) && (xValue<= 900))  {
    //Serial.write(8);
    //Serial.flush();
    //delay(1000);
  //}

  //if ((yValue >=100) && (yValue<= 900)) {
    //Serial.write(9);
    //Serial.flush();
    //delay(1000);
  //}

  if (xValue == 0) {
    Serial.write(4);
    Serial.flush();
    delay(100);
  }

   if (xValue == 1023) {
    Serial.write(5);
    Serial.flush();
    delay(100);
  } 

    if (yValue == 0) {
    Serial.write(6);
    Serial.flush();
    delay(100);
  }

   if (yValue == 1023) {
    Serial.write(7);
    Serial.flush();
    delay(100);
  } 

}
