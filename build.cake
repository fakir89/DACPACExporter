var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
string artifactsDirectory = "./artifacts";
string solutionName = "./DacPacExporter.sln";

Task("Clean")
.Does(() =>
{
    EnsureDirectoryExists(artifactsDirectory);
    CleanDirectory(artifactsDirectory);
    Information("Cleaning completed.");
});

Task("NuGet-Restore")
.IsDependentOn("Clean")
.Does(() =>
{
    NuGetRestore(solutionName);
    Information("Restoring completed.");
});

Task("Build")
.IsDependentOn("NuGet-Restore")
.Does(() =>
{
    DotNetBuild(solutionName, x => x
        .SetConfiguration(configuration)
        .SetVerbosity(Verbosity.Minimal)
        .WithTarget("build")
        .WithProperty("TreatWarningsAsErrors", "false")
    );

    Information("Building completed.");
});

Task("CopyArtifacts")
.IsDependentOn("Build")
.Does(() =>
{
    string sorucePath = @"DacPac Exporter\bin\" + configuration;
    CopyDirectory(sorucePath, artifactsDirectory);
    Information("Artifact copying completed.");
});

Task("Default")
.IsDependentOn("CopyArtifacts");

RunTarget(target);