namespace Informedica.GenOrder.Lib



module Demo =

    open MathNet.Numerics
    open Informedica.Utils.Lib
    open Informedica.Utils.Lib.BCL
    open Informedica.GenForm.Lib
    open Informedica.GenUnits.Lib
    open Informedica.GenSolver.Lib


    let scenarioResult pat =
        let rules = pat |> PrescriptionRule.get
        {
            Indications = rules |> PrescriptionRule.indications
            Generics = rules |> PrescriptionRule.generics
            Routes = rules |> PrescriptionRule.routes
            Shapes= rules |> PrescriptionRule.shapes
            Indication = None
            Generic = None
            Route = None
            Shape = None
            Patient = pat
            Scenarios = [||]
        }


    let filter (sc : ScenarioResult) =
        match sc.Patient.Weight, sc.Patient.Height, sc.Patient.Department with
        | Some w, Some _, d when d |> String.notEmpty ->

            let ind = 
                if sc.Indication.IsSome then sc.Indication
                else sc.Indications |> Array.someIfOne
            let gen =
                if sc.Generic.IsSome then sc.Generic
                else sc.Generics |> Array.someIfOne
            let rte = 
                if sc.Route.IsSome then sc.Route
                else sc.Routes |> Array.someIfOne
            let shp = 
                if sc.Shape.IsSome then sc.Shape
                else sc.Shapes |> Array.someIfOne

            let filter = 
                { Filter.filter with
                    Department = Some d
                    Age = sc.Patient.Age
                    Weight = Some w
                    Indication = ind
                    Generic = gen
                    Route = rte
                    Shape = shp
                }

            let inds = filter |> Api.filterIndictions
            let gens = filter |> Api.filterGenerics
            let rtes = filter |> Api.filterRoutes
            let shps = filter |> Api.filterShapes

            let ind = inds |> Array.someIfOne
            let gen = gens |> Array.someIfOne
            let rte = rtes |> Array.someIfOne
            let shp = shps |> Array.someIfOne

            { sc with
                Indications = inds
                Generics = gens
                Routes = rtes
                Shapes = shps
                Indication = ind
                Generic = gen
                Route = rte
                Shape = shp
                Scenarios = 
                    match ind, gen, rte, shp with
                    | Some _, Some _, Some _, _ 
                    | Some _, Some _, _, Some _ ->
                        { filter with
                            Department = Some d
                            Indication = ind
                            Generic = gen
                            Route = rte
                            Shape = shp
                            Age = sc.Patient.Age
                            Weight = sc.Patient.Weight
                        }
                        |> PrescriptionRule.filter
                        |> Array.collect (fun pr ->
                            pr
                            |> Api.evaluate OrderLogger.logger.Logger
                            |> Array.map (function
                                | Ok (ord, pr) ->
                                    let ns =
                                        pr.DoseRule.DoseLimits
                                        |> Array.map (fun dl -> dl.Substance)
                                    let prs, prp, adm =
                                        ord
                                        |> Order.Markdown.printPrescription ns
                                    [
                                        $"- {pr.DoseRule.Generic}, {pr.DoseRule.Shape}, {pr.DoseRule.DoseType |> DoseType.toString} {pr.DoseRule.Indication}"
                                        $"- Voorschrift: {prs}"
                                        $"- Bereiding: {prp}"
                                        $"- Toediening: {adm}"
                                    ]
                                    |> String.concat "\n"
                                    |> String.replace "[" ""
                                    |> String.replace "]" ""
                                    |> String.replace "<" ""
                                    |> String.replace ">" ""
                                    |> String.replace "|" ""

                                | Error (_, _, errs) -> 
                                    errs
                                    |> List.map string
                                    |> String.concat "\n"
                                    |> printfn "%s"
                                    ""
                            )
                        )

                    | _ -> [||]
            }
        | _ -> sc

