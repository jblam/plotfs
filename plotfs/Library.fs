namespace PlotFS

type x = X of double
type y = Y of double

[<Struct>]
type Point = { X: x; Y: y }

type SeriesData =
    | Points of seq<Point>
    | Function of (x -> y)

type Series = {
    Data : SeriesData
    Title : string
    }
type Axis() = class end

type AxisSet = {
    Abcissa: Axis
    Ordinate: Axis
    }

type Plot = {
    Axes: AxisSet
    Series: seq<Series>
    }

module Say =
    let hello name =
        sprintf "Hello %s" name

    let gidday plot =
        let s1 = Seq.head plot.Series
        let t = s1.Title
        let desc = match s1.Data with
                    | Points p -> ("first point", Seq.head p)
                    | Function f -> ("y-intercept", { X = X 0.0; Y = f(X 0.0) })
        sprintf "%s has %s %A" t <|| desc