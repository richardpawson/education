module MergeSort

let rec merge (a: List<'T>) (b: List<'T>) greaterThan =
    if a.IsEmpty then
        b
    else if b.IsEmpty then
        a
    else if greaterThan a.Head b.Head then
        b.Head :: (merge a b.Tail greaterThan)
    else 
        a.Head :: merge a.Tail b greaterThan

let rec sort (list: List<'T>) greaterThan =
    if list |> Seq.length < 2 then
        list
    else 
        let half = (list |> Seq.length) / 2
        merge (sort (list |> List.skip(half)) greaterThan) (sort (list |> List.take(half)) greaterThan) greaterThan


//let rec merge (a: List<string>) (b: List<string>) greaterThan =
//    if a.IsEmpty then
//        b
//    else if b.IsEmpty then
//        a
//    else if greaterThan a.Head  b.Head then
//            b.Head :: (merge a b.Tail greaterThan)
//    else 
//            a.Head :: merge a.Tail b greaterThan
//
//
//let rec sort (list: List<string>) greaterThan =
//    if list |> Seq.length < 2 then
//        list
//    else 
//        let half = (list |> Seq.length) / 2
//        merge (sort (list |> List.skip(half)) greaterThan) (sort (list |> List.take(half)) greaterThan) greaterThan


let rec mergeAlphabetical (a: List<string>) (b: List<string>) =
    if a.IsEmpty then
        b
    else if b.IsEmpty then
        a
    else if a.Head < b.Head then
        a.Head :: mergeAlphabetical a.Tail b
    else 
        b.Head :: mergeAlphabetical a b.Tail

let rec sortAlphabetical (list: List<string>) =
    if list |> Seq.length < 2 then
        list
    else 
        let half = (list |> Seq.length) / 2
        mergeAlphabetical (sortAlphabetical (list |> List.skip(half))) (sortAlphabetical (list |> List.take(half)))



 
