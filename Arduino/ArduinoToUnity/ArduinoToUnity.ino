#define X_DIRECTION_NEGATIVE  1
#define X_DIRECTION_NEUTRAL  2
#define X_DIRECTION_POSITIVE  3

#define NEUTRAL 13

#define Y_DIRECTION_NEGATIVE  4
#define Y_DIRECTION_NEUTRAL  5
#define Y_DIRECTION_POSITIVE  6

#define HIT_DOWN  7
#define HIT_UP  8

#define LEFT_DOWN  9
#define LEFT_UP  10

#define RIGHT_DOWN  11
#define RIGHT_UP  12

//Button
const int buttonPin = 2;

const int leftButton = 4;
const int rightButton = 5;

//JoyStick
const int joystickUP = 9;
const int joystickLEFT = 10;
const int joystickDOWN = 11;
const int joystickRIGHT = 8;


//int prevXValue = 0;
//int prevYValue = 0;

bool prevXValueUp = false;
bool prevXValueDown = false;
//int prevYValueRight = HIGH;
//int prevYValueLeft = HIGH;

bool prevHitValue = false;
bool prevLeftValue = false;
bool prevRightValue = false;

void setup()
{
  Serial.begin(9600);

  //button
  pinMode(buttonPin, INPUT);

  pinMode(leftButton, INPUT);
  pinMode(rightButton, INPUT);

  //Joystick
  pinMode(joystickUP, INPUT_PULLUP);
  pinMode(joystickLEFT, INPUT_PULLUP);
  pinMode(joystickDOWN, INPUT_PULLUP);
  pinMode(joystickRIGHT, INPUT_PULLUP);

}

void loop()
{

 
int up = digitalRead(joystickUP);
int down = digitalRead(joystickDOWN);
int left = digitalRead(joystickLEFT);
int right = digitalRead(joystickRIGHT);


  if (up == LOW) {
    Serial.write(Y_DIRECTION_POSITIVE);
    delay(20);
  }
  else if(down == LOW) {
    Serial.write(Y_DIRECTION_NEGATIVE);
    delay(20);
  }else {
    Serial.write(Y_DIRECTION_NEUTRAL);
    delay(20);
  }
  
  
  if(left == LOW) {
    Serial.write(X_DIRECTION_NEGATIVE);
    delay(20);
  }else if(right == LOW) {
    Serial.write(X_DIRECTION_POSITIVE);
    delay(20);
  }else {
    //Serial.write(NEUTRAL)
    Serial.write(X_DIRECTION_NEUTRAL);
    delay(20);
  }




  
    //HIT
  bool hitValue = digitalRead(buttonPin);
  if (hitValue != prevHitValue) {
    // stuur een signaal naar unity
    if (hitValue) {
      Serial.write(HIT_DOWN);
      //Serial.print(HIT_DOWN);
    } else {
      Serial.write(HIT_UP);
      //Serial.print(HIT_UP);
    }
  }
  prevHitValue = hitValue;

    //LEFT
    bool leftValue = digitalRead(leftButton);
    if (leftValue != prevLeftValue) {
      // stuur een signaal naar unity
      if (leftValue) {
        Serial.write(LEFT_DOWN);
        delay(20);
        //Serial.print(LEFT_DOWN);
      } else {
        Serial.write(LEFT_UP);
        delay(10);
        //Serial.print(LEFT_UP);
      }
    }
    prevLeftValue = leftValue;

    //RIGHT
    bool rightValue = digitalRead(rightButton);
    if (rightValue != prevRightValue) {
      // stuur een signaal naar unity
      if (rightValue) {
        Serial.write(RIGHT_DOWN);
        delay(20);
        //Serial.print(RIGHT_DOWN);
      } else {
        Serial.write(RIGHT_UP);
        delay(10);
        //Serial.print(RIGHT_UP);
      }
    }
    prevRightValue = rightValue;

    
    
    //JOYSTICK
    
}
