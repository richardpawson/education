import unittest
import Fractions

class FractionsTests(unittest.TestCase):
    #First, without reduction'''

    def test_1(self):
        a = Fractions.fraction(2,3) # 2/3
        b = Fractions.fraction(1,4) # 1/4
        self.assertEqual(str(a.plus(b)), "11/12")

    def test_2(self):
        a = Fractions.fraction(2,3) # 2/3
        b = Fractions.fraction(1,4) # 1/4
        self.assertEqual(str(a.minus(b)), "5/12")
  
    def test_3(self):
        a = Fractions.fraction(2,3) # 2/3
        b = Fractions.fraction(1,4) # 1/4
        self.assertEqual(str(a.multiplyBy(b)), "2/12") 

    def test_4(self):
        a = Fractions.fraction(2,3) # 2/3
        b = Fractions.fraction(1,4) # 1/4
        self.assertEqual(str(a.divideBy(b)), "8/3")
        

#Test your implementation with lots of other examples including complex fractions, negative numbers, zeros.'''
#Print out all the results'''

#Now add an internal function to reduce the answer (or any newly created fraction)
#such that the third answer above comes out as 1/6 instead of 2/12.
#Add more test examples and include tests and results in your submission'''

#Finally, change the __str__ function so that the fourth answer is presented as '2 & 2/3'
#instead of '8/3'.  Test with other examples where the resulting fraction is > 1
