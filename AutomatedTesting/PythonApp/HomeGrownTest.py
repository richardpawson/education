import Conversions

def TestConversion(testDescription, actual, expected) :
    if( actual == expected) :
        print("Test "+str(testDescription)+" passed")
    else :
        print("Test "+str(testDescription)+" failed, Expected: "+str(expected)+", was: "+str(actual))

TestConversion("Room Temperature", Conversions.ToCelcius(68), 20)

TestConversion("Boiling Point", Conversions.ToCelcius(212), 100)

TestConversion("Freezing Point", Conversions.ToCelcius(32), 0)

TestConversion("Body Temperature", Conversions.ToCelcius(98.4), 36.9)