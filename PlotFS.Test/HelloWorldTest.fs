namespace PlotFS.Test

open Xunit
open PlotFS

module HelloWorldTest =
    let doesMathsWork = 1 = 1
    [<Fact>]
    let MathsDoesWork() =
        Assert.True doesMathsWork

    [<Fact>]
    let ReferenceDoesWork() =
        let expected = "test"
        let actual = Say.hello "test"
        Assert.Contains(expected, actual)
        
