import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
t = turtle.Turtle()      # create a t named t
t.left(90)
t.pensize(1)
t.pencolor('brown')
t.speed(0)

size = 200
trunkPercent = 0.40
angle = 30
maxLevel = 6


def Draw(length, level):
    if level <= 0 :
        return
    else :
        trunk = length * trunkPercent
        shoot = length - trunk
        t.forward(trunk)
        t.right(angle)
        Draw(shoot, level - 1)
        t.left(angle*2)
        Draw(shoot, level - 1)
        t.right(angle)
        t.backward(trunk)
        


#Main program begins here

Draw(size, maxLevel)




