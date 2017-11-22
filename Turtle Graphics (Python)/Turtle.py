import turtle

def DrawSquare(turtle, size):
    for side in range(0,4):
        turtle.forward(size)
        turtle.left(90)

def DrawRow(turtle, size, number):
    for side in range(0,number):
        DrawSquare(turtle, size)
        joe.forward(size)

def Spiral(turtle, number):    
    for side in range(0,size,5):
        joe.forward(side)
        joe.left(120)

# allows us to use the turtles library
wn =turtle.Screen()        # creates a graphics window
turtle = turtle.Turtle()      # create a turtle named alex

DrawSquare(turtle, 50)

