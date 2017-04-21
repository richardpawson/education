// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open MergeSort
open System

let alphabetical s1  s2 = s1 > s2
let reverse s1  s2 = s1 < s2

[<EntryPoint>]
let main argv = 
    let list = ["Flag";"Nest";"Cup";"Burg"; "Yacht";"Next"]
    let sorted = sortAlphabetical list 
    printfn "%A" sorted
    let alpha = sort list alphabetical
    printfn "%A" alpha
    let rev = sort list reverse
    printfn "%A" rev
//
//            var alpha = MergeSort.Sort(list, alphabetical);
//            Console.WriteLine(alpha.ToString());
//            var rev = MergeSort.Sort(list, reverse);
//            Console.WriteLine(rev.ToString());
//            var len = MergeSort.Sort(list, length);
//            Console.WriteLine(len.ToString());
//
//            var iList = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7);
//            var up = MergeSort.Sort(iList, greaterThan);
//            Console.WriteLine(up.ToString());
//            var down = MergeSort.Sort(iList, reverse);
//            Console.WriteLine(down.ToString());
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code