import turtle
from random import randrange
wn =turtle.Screen()        # creates a graphics window
t = turtle.Turtle()      # create a t named t
t.left(90)
t.pensize(1)
t.pencolor('brown')
t.speed(1)



def DrawShoot(shoot) :
        t.forward(shoot)
        t.backward(shoot)
    
def Draw(length):
        trunk = length * 0.4
        shoot = length - trunk
        t.forward(trunk)
        t.right(30)
        DrawShoot(shoot)
        t.left(60)
        DrawShoot(shoot)
        t.right(30)
        t.backward(trunk)
        


#Main program begins here

Draw(200)




