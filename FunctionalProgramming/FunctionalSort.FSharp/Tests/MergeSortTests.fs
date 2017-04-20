namespace Tests
open Microsoft.VisualStudio.TestTools.UnitTesting
open MergeSort

[<TestClass>]
type  MergeSortTests() =

    member this.alphabetical s1  s2 = s1 > s2

    member this.reverse s1  s2 = s1 < s2

    member this.length (s1:string) (s2: string) = s1.Length > s2.Length

    member this.greaterThan s1  s2 = s1 > s2

    [<TestMethod>]
    member  this.TestSortAlphabeticalHappyCase() =
        let list = ["Flag";"Nest";"Cup";"Burg"; "Yatch";"Next"]
        let sorted = sortAlphabetical list 
        let expected = ["Burg";"Cup";"Flag";"Nest"; "Next";"Yatch"]
        Assert.AreEqual(expected, sorted)

    [<TestMethod>]
    member  this.TestSortAlphabeticalWithDuplicates() =
        let list = ["Flag"; "Cup"; "Cup"; "Burg"; "Cup"; "Next"]
        let sorted = sortAlphabetical list
        let expected = ["Burg"; "Cup"; "Cup"; "Cup"; "Flag"; "Next"]
        Assert.AreEqual(expected, sorted)

    [<TestMethod>]
    member  this.TestSortAlphabeticalWithOne() =
            let list = ["Flag"]
            let sorted = sortAlphabetical list 
            let expected = ["Flag"]
            Assert.AreEqual(expected, sorted)

    [<TestMethod>]
    member  this.TestSortAlphabeticalEmpty() =
        let list = []
        let sorted = sortAlphabetical list
        Assert.IsTrue(sorted.IsEmpty);

    [<TestMethod>]
    member  this.TestSortWithAlphabeticalFunction() =
        let list = ["Flag";"Nest";"Cup";"Burg"; "Yatch";"Next"]
        let sorted = sort list this.alphabetical
        let expected = ["Burg";"Cup";"Flag";"Nest"; "Next";"Yatch"]
        Assert.AreEqual(expected, sorted);

    [<TestMethod>]
    member  this.TestSortWithReverseFunction() =
        let list = ["Flag";"Nest";"Cup";"Burg"; "Yatch";"Next"]
        let sorted = sort list this.reverse
        let expected = ["Yatch"; "Next"; "Nest"; "Flag"; "Cup";"Burg"]
        Assert.AreEqual(expected, sorted)

    [<TestMethod>]
    member  this.TestSortByLengthDecreasing() =
        let list = ["Flag";"Yachting";"Cup";"Burger"; ]
        let sorted = sort list this.length
        let expected = ["Cup"; "Flag"; "Burger";"Yachting"]
        Assert.AreEqual(expected, sorted);

    [<TestMethod>]
    member  this.TestSortIntegers() =
            let list = [4; 7; 12; 3; 88; 9; 2; 7]
            let sorted = sort list this.greaterThan
            let expected = [2;3;4;7;7;9;12;88]
            Assert.AreEqual(expected, sorted);

    [<TestMethod>]
    member  this.TestSortIntegersInReverse() =
            let list = [4; 7; 12; 3; 88; 9; 2; 7]
            let sorted = sort list this.reverse
            let expected = [88;12;9;7;7;4;3;2]
            Assert.AreEqual(expected, sorted);

