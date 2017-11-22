import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
turtle = turtle.Turtle()      # create a turtle named turtle
turtle.left(90)
turtle.pensize(1)
turtle.pencolor('brown')
turtle.speed(0)

size = 200
branchMin = 20
branchMax = 80
angleMin = 30
angleMax = 40
maxLevel = 6

def Leaf():
    restoreColor = turtle.pencolor()
    restoreSize = turtle.pensize()
    turtle.color('green')
    turtle.pensize(5)
    turtle.forward(5)
    turtle.backward(5)
    turtle.pencolor(restoreColor)
    turtle.pensize(restoreSize)

def Draw(length, level):
    if level <= 0 :
        Leaf()
        return
    else :
        maxLength = int(length * branchMax/100)
        minLength = int(length * branchMin/100)
        trunk = randrange(minLength, maxLength)
        girth = size/30 * (level/maxLevel)
        turtle.pensize(girth)
        shoot = length - trunk
        turtle.forward(trunk)
        angle = randrange(angleMin, angleMax)
        turtle.right(angle)
        Draw(shoot, level - 1)
        turtle.left(angle)
        angle = randrange(angleMin, angleMax)
        turtle.left(angle)
        Draw(shoot, level - 1)
        turtle.right(angle)
        turtle.backward(trunk)
        
def ShiftRight(amount) :
    turtle.penup()
    turtle.right(90)
    turtle.forward(amount)
    turtle.left(90)
    turtle.pendown()

#Main program begins here
for n in range(0,5):
    Draw(size, maxLevel)
    shift = randrange(10,50)
    ShiftRight(shift)



