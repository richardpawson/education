import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
t = turtle.Turtle()      # create a t named t
t.left(90)
t.pensize(1)
t.pencolor('brown')
t.speed(0)

size = 200
branchMin = 20
branchMax = 80
angleMin = 30
angleMax = 40
maxLevel = 6


def Draw(length, level):
    if level <= 0 :
        return
    else :
        maxLength = int(length * branchMax/100)
        minLength = int(length * branchMin/100)
        trunk = randrange(minLength, maxLength)
        shoot = length - trunk
        t.forward(trunk)
        angle = randrange(angleMin, angleMax)
        t.right(angle)
        Draw(shoot, level - 1)
        t.left(angle)
        angle = randrange(angleMin, angleMax)
        t.left(angle)
        Draw(shoot, level - 1)
        t.right(angle)
        t.backward(trunk)
        


#Main program begins here

Draw(size, maxLevel)




