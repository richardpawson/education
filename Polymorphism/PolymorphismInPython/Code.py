class Rectangle :
    height = 0
    width = 0

    #Constructor
    def __init__(self, h, w) :
          self.height = h
          self.width = w

    # Provides a string representation of the object
    # All methods need 'self' to be passed in...
    def summary(self) :
        #... and we use self to access properties or other methods
        return "Rectangle, H: "+str(self.height)+" W: "+str(self.width)
    
    def growBy(self, percent) :
        self.height = self.height * (1 + percent/100)
        self.width = self.width *(1 + percent/100)

# Provides same methods as Rectangle, but different implementations
class Circle :
    radius = 0

    def __init__(self, r) :
          self.radius = r
    
    def growBy(self, percent) :
        self.radius = self.radius * (1 + percent/100)

    def summary(self) :
        return "Circle, radius: "+str(self.radius)

#An array can contain different kinds of objects
drawing1 = [Circle(3), Circle(4), Rectangle(2,7), Circle(10)]

def growAll(shapes, percent) :
    #iterate (loop) over array and delegate to equivalent method on each
    for shape in shapes:
        shape.growBy(percent)

def summariseAll(shapes) :
    for shape in shapes:
        print(shape.summary())

def Main() :
    summariseAll(drawing1)
    growAll(drawing1, 50)
    summariseAll(drawing1)

Main()