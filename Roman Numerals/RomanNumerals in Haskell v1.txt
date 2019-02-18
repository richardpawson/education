roman:: Int -> String
roman d = romanfrom d
        [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1] 
        ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"]
        
romanfrom:: Int -> [Int] -> [String] -> String
romanfrom d [] [] = ""
romanfrom d (n:ns) (x:xs)
  | d >= n = x ++ (romanfrom (d - n) (n:ns) (x:xs))
  | otherwise = romanfrom d ns xs
  
main = print "No errors"
