merge a b greaterThan = 
  if a == [] 
    then b
    else if b == [] 
      then a
      else if greaterThan a b 
        then head a : merge (tail a) b greaterThan
        else head b : merge a (tail b) greaterThan

sort list greaterThan =
  if length list < 2 
    then list
    else merge (sort (drop (div (length list)  2) list ) greaterThan ) (sort (take (div (length list) 2) list) greaterThan) greaterThan

mergeAlphabetical a b = 
  if a == [] 
    then b
    else if b == [] 
      then a
      else if head a < head b 
        then head a : mergeAlphabetical (tail a) b
        else head b : mergeAlphabetical a (tail b)

sortAlphabetical list =
  if length list < 2 
    then list
    else mergeAlphabetical (sortAlphabetical (drop (div (length list)  2) list)) (sortAlphabetical (take (div (length list) 2) list))

alphabetical a b =  a < b
reverseOrder a b =  a > b
longer a b = (length a) > (length b)

assertEqual a b =
   if a == b then "Passed" 
   else "Expected: " ++ (show a) ++ " Actual: " ++ (show b)
     

testSortAlphabeticalHappyCase =
  assertEqual ["Burg","Cup","Flag","Nest", "Next","Yacht"] 
  (sortAlphabetical ["Flag","Nest","Cup","Burg", "Yacht","Next"])

testSortWithAlphabeticalFunction =
  assertEqual ["Burg","Cup","Flag","Nest", "Next","Yacht"] 
  (sort ["Flag","Nest","Cup","Burg", "Yacht","Next"] alphabetical)

testSortWithReverseFunction =
  assertEqual ["Yacht", "Next", "Nest", "Flag", "Cup","Burg"] 
  (sort ["Flag","Nest","Cup","Burg", "Yacht","Next"] reverseOrder)

testSortIntegers =
  assertEqual [2,3,4,7,7,9,12,88] 
  (sort [4,7,12,3,88,9,2,7] alphabetical) 

testSortIntegersInReverse =
  assertEqual [88,12,9,7,7,4,3,2] 
  (sort [4,7,12,3,88,9,2,7] reverseOrder)

allTests = [
  testSortAlphabeticalHappyCase,
  testSortWithAlphabeticalFunction,
  testSortWithReverseFunction,
  testSortIntegers,
  testSortIntegersInReverse]

run tests = mapM_ print  tests
