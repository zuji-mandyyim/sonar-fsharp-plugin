﻿namespace FsSonarRunnerCore.Test

open System.IO
open NUnit.Framework
open FsSonarRunnerCore
open System.Reflection

[<TestFixture>]
type TestLintRunner() =
    
    let runningPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "")).ToString()).ToString()).ToString()
    let fileToAnalyse = @"E:\Development\SonarQube\dotnet\sonar-fsharp\FsSonarRunner\FsSonarRunnerCore\SQAnalyser.fs"

    [<Test>]
    member this.RunLintInSource() = 
        let lintRunner = new FsLintRunner(fileToAnalyse, new SonarRules(), FSharpLint.Framework.Configuration.defaultConfiguration)
        Assert.That(lintRunner.ExecuteAnalysis().Length, Is.EqualTo(4))