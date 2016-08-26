class fraction :

    num = 1
    den = 1

    def __init__(self, numerator, denominator) :
        self.num = numerator
        self.den = denominator
        self.reduce()

    
    def __str__(self) :
        return str(self.num) + "/"+str(self.den)


    def plus(self, other) :
        if (self.den == other.den) :
            return fraction(self.num + other.num, self.den)
        else :
            return fraction(self.num * other.den + other.num*self.den, self.den*other.den)

    def minus(self, other) :
        if (self.den == other.den) :
            return fraction(self.num - other.num, self.den)
        else :
            return fraction(self.num * other.den - other.num*self.den, self.den*other.den)

    def multiplyBy(self, other) :
        return fraction(self.num*other.num, self.den*other.den)

    def divideBy(self, other) :
        return self.multiplyBy(fraction(other.den, other.num))

    def reduce(self) :
        gcd = self.__greatestCommonDivisor(self.num, self.den)
        self.num = int(self.num / gcd)
        self.den = int(self.den / gcd)
        return self

    def __greatestCommonDivisor(self, a, b) :
        return a if b == 0 else self.__greatestCommonDivisor(b, a % b)



                   
