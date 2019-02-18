import Data.Char
main = print "OK"

power:: Int -> Int -> String
power m n = powerOfString "1" m n

powerOfString:: String -> Int -> Int -> String
powerOfString s m 0 = s
powerOfString s m n = powerOfString (multWithCarry s m 0) m (n-1)

--numberAsString, multiplier, carryIn -> productAsString
multWithCarry:: String -> Int -> Int -> String
multWithCarry "" m 0 = ""
multWithCarry "" m c = show c
multWithCarry s m c = let d = multDigit (digitToInt (last s)) m c in multWithCarry (init s) m (snd d) ++ (show (fst d))

--digit -> multiplier -> carryIn -> (digit, carryOut)
multDigit:: Int -> Int -> Int -> (Int, Int)
multDigit d m c = let n = d*m + c in (n `mod` 10, n `div` 10)