using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

Lines linesOfCode = new Lines();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    string input = Console.ReadLine().Trim();
    // Opening / Closing
    if (input == "{")
    {
        linesOfCode.lines.Add("{");
    }
    if (input == "}")
    {
        linesOfCode.lines.Add("}");
    }
    // Include namespaces
    if (input == "Namespace {")
    {
        while (true)
        {
            string library = Console.ReadLine().Trim();
            if (library == "}")
            {
                break;
            }
            else
            {
                linesOfCode.lines.Add($"using {library};");
            }
        }
    }
    // System.Output method
    if (input == "System.Output {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string outputContent = Console.ReadLine().Trim();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Output method requires closing argument");
        linesOfCode.lines.Add($"Console.Write({outputContent});");
    }
    if (input == "System.Output.line {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string outputContent = Console.ReadLine().Trim();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Output method requires closing argument");
        linesOfCode.lines.Add($"Console.WriteLine({outputContent});");
    }
    // System.Input method
    if (input == "System.Input.line {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string inputVariable = Console.ReadLine().Trim();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Input method requires closing argument");
        linesOfCode.lines.Add($"string {inputVariable} = Console.ReadLine();");
    }
    // System.Variable method
    if (input == "System.Variable.string {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string variableData = Console.ReadLine().Trim();
        if (variableData == "") Error("Error: System.Variable method must have a named variable and assigned a value.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Variable method requires closing argument.");
        linesOfCode.lines.Add($"string {variableData};");
    }
    if (input == "System.Variable.integer {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string variableData = Console.ReadLine().Trim();
        if (variableData == "") Error("Error: System.Variable method must have a named variable and assigned a value.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Variable method requires closing argument.");
        linesOfCode.lines.Add($"int {variableData};");
    }
    if (input == "System.Variable.float {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string variableData = Console.ReadLine().Trim();
        if (variableData == "") Error("Error: System.Variable method must have a named variable and assigned a value.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Variable method requires closing argument.");
        linesOfCode.lines.Add($"float {variableData};");
    }
    if (input == "System.Variable.boolean {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string variableData = Console.ReadLine().Trim();
        if (variableData == "") Error("Error: System.Variable method must have a named variable and assigned a value.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Variable method requires closing argument.");
        linesOfCode.lines.Add($"bool {variableData};");
    }
    if (input == "System.Variable.modify {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string variableData = Console.ReadLine().Trim();
        if (variableData == "") Error("Error: System.Variable method must have a named variable and an argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Variable method requires a closing argument.");
        linesOfCode.lines.Add($"{variableData};");
    }
    // Methods
    if (input == "System.Method.void {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string methodName = Console.ReadLine().Trim();
        if (methodName == "") Error("Error: System.Method method must have a named Method and argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        linesOfCode.lines.Add($"void {methodName}");
    }
    if (input == "System.Method.string {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string methodName = Console.ReadLine().Trim();
        if (methodName == "") Error("Error: System.Method method must have a named Method and argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        linesOfCode.lines.Add($"string {methodName}");
    }
    if (input == "System.Method.integer {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string methodName = Console.ReadLine().Trim();
        if (methodName == "") Error("Error: System.Method method must have a named Method and argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        linesOfCode.lines.Add($"int {methodName}");
    }
    if (input == "System.Method.boolean {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string methodName = Console.ReadLine().Trim();
        if (methodName == "") Error("Error: System.Method method must have a named Method and argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        linesOfCode.lines.Add($"bool {methodName}");
    }
    if (input == "System.Method.float {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string methodName = Console.ReadLine().Trim();
        if (methodName == "") Error("Error: System.Method method must have a named Method and argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        linesOfCode.lines.Add($"float {methodName}");
    }
    if (input == "System.Method.call {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string methodName = Console.ReadLine().Trim();
        if (methodName == "") Error("Error: System.Method.call argument must include a method to be called");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Method.call must include a closing argument");
        linesOfCode.lines.Add($"{methodName};");
    }
    if (input == "System.Method.return {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string returnValue = Console.ReadLine().Trim();
        if (returnValue == "") Error("Error: System.Method.return cannot be null.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Method.return must have closing argument.");
        linesOfCode.lines.Add($"return {returnValue};");
    }
    // Collection classes
    if (input == "System.Collections.list {")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string collectionName = Console.ReadLine().Trim();
        if (collectionName == "") Error("Error: Systems.Collections method must have a name.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string collectionType = Console.ReadLine().Trim();
        string listType = "";
        if (collectionType == "System.Variable.string {") listType = "string";
        else if (collectionType == "System.Variable.integer {") listType = "int";
        else if (collectionType == "System.Variable.boolean {") listType = "bool";
        else if (collectionType == "System.Variable.float {") listType = "float";
        else if (collectionType == "") Error("Error: Collection class must be provided with a System.Variable type.");
        Console.ForegroundColor = ConsoleColor.Red;
        string collectionData = Console.ReadLine().Trim();
        if (collectionData == "") Error("Error: Collection class must be provided data.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string collectionTypeEnding = Console.ReadLine().Trim();
        if (collectionTypeEnding != "}") Error("System.Variable method must have closing argument.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string endingArgument = Console.ReadLine().Trim();
        if (endingArgument != "}") Error("Error: System.Collections method must have a closing argument");
        linesOfCode.lines.Add($"List<{listType}> {collectionName} = new List<{listType}> {collectionData};");
    }
    // If statements 
    if (input == "System.If {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string statement = Console.ReadLine().Trim();
        linesOfCode.lines.Add($"if {statement}");
    }
    if (input == "System.If.else {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        linesOfCode.lines.Add("else");
        linesOfCode.lines.Add("{");
    }
    if (input == "System.If.elseif {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string statement = Console.ReadLine().Trim();
        linesOfCode.lines.Add($"else if {statement}");
    }
    // While Method
    if (input == "System.While {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string statement = Console.ReadLine().Trim();
        linesOfCode.lines.Add($"while {statement}");
    }
    // For Method
    if (input == "System.For {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string statement = Console.ReadLine().Trim();
        linesOfCode.lines.Add($"foreach {statement}");
    } 
    if (input == "System.For.each {")
    {
        if (!linesOfCode.lines.Contains("using System;")) Error("Error: System namespace must be invoked.");
        Console.ForegroundColor = ConsoleColor.Red;
        string statement = Console.ReadLine().Trim();
        linesOfCode.lines.Add($"foreach {statement}");
    }
    // Debug
    if (input == "Debug{}") Debug();
    // Build
    if (input == "Build{}") Build();
}


// Debug
void Debug()
{
    linesOfCode.lines.ForEach(i => Console.Write("{0}\t", i));
    Console.WriteLine();
}
// Build to .CS file
void Build()
{
    Console.Write("Type output directory: ");
    string buildDir = Console.ReadLine();
    string build = $"{buildDir}/build.cs";
    linesOfCode.lines.ForEach(i => Console.Write("{0}\t", i));
    File.WriteAllLines(build, linesOfCode.lines);
    Environment.Exit(0);
}
// Error handling
void Error(string prompt)
{
    Console.WriteLine(prompt);
    Environment.Exit(0);
}
