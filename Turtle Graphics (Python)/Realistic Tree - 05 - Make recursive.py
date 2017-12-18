import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
t = turtle.Turtle()      # create a t named t
t.left(90)
t.pensize(1)
t.pencolor('brown')
t.speed(0)

size = 150
trunkPercent = 0.30
angle = 45
maxLevel = 6


def Draw(length):
    if length <= 10 :
        return
    else :
        trunk = length * trunkPercent
        shoot = length - trunk
        t.forward(trunk)
        t.right(angle)
        Draw(shoot)
        t.left(angle*2)
        Draw(shoot)
        t.right(angle)
        t.backward(trunk)
        


#Main program begins here

Draw(size)




