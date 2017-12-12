import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
t = turtle.Turtle()      # create a t named t
t.left(90)
t.pensize(1)
t.pencolor('brown')
t.speed(1)

    
#Main program begins here
length = 200
trunk = length * 0.4
shoot = length - trunk
angle = 30

t.forward(trunk)
t.right(angle)
t.forward(shoot)
t.backward(shoot)
t.left(angle*2)
t.forward(shoot)
t.backward(shoot)
t.right(angle)
t.backward(trunk)
        





