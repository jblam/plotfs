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
        
    [<Fact>]
    let CanGetFirstDataPoint() =
        let axes = {
                Abcissa = Axis()
                Ordinate = Axis()
            }
        let plot = {
            Axes = {
                   Abcissa = Axis()
                   Ordinate = Axis()
                   }            
            Series =
            [
                {
                    Title = "demo"
                    Data = Points [{ X = X 0.0; Y = Y 0.0}]
                }
            ]
        }
        let actual = Say.gidday plot
        Assert.Contains("wut", actual)

    [<Fact>]
    let CanGetFunctionZero() =
        let axes = {
                Abcissa = Axis()
                Ordinate = Axis()
            }
        let plot = {
            Axes = {
                   Abcissa = Axis()
                   Ordinate = Axis()
                   }            
            Series =
            [
                {
                    Title = "demo"
                    Data = Function (fun x -> Y 14.0)
                }
            ]
        }
        let actual = Say.gidday plot
        Assert.Contains("wut", actual)