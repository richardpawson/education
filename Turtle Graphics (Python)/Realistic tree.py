import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
p = turtle.Turtle()      # create a turtle named turtle


def fork(p, size, minTrunk,maxTrunk,minAngle,maxAngle,minTwigLength):
    if size > minTwigLength :
        p.color('brown')
        trunk = randrange(size * minTrunk, size * maxTrunk)
        width = (trunk / 10) + 1
        #p.pensize(width)
        shoot = size - trunk
        p.forward(trunk)
        angle = randrange(minAngle, maxAngle)
        p.right(angle)
        #fork(shoot, minTrunk, maxTrunk, minAngle, maxAngle, minTwigLength, p)
        p.left(angle)
        angle = randRange(minAngle, maxAngle)
        p.left(angle)
        #fork(shoot, minTrunk, maxTrunk, minAngle, maxAngle, minTwigLength, p)
        p.right(angle)
        p.back(trunk)
    else :
        p.color('green')
        p.pensize(5)
        p.go(5)
        p.back(5)
        p.draw()
        p.penstyle('blue')
        p.penstyle('brown')



fork(p, 100, 40, 60, 30,40,50)
