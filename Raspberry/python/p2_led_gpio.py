
import RPi.GPIO as GPIO
import time

#configuracion de gpio
GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(18,GPIO.OUT)

i=1
while i<=5: 
     print "LED on",i, " veces"
     GPIO.output(18,GPIO.HIGH)
     time.sleep(1)
     print "LED OFF",i," veces"
     GPIO.output(18,GPIO.LOW)
     time.sleep(1)
     i+=1
     print ""
print "fin del programa"

