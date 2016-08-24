using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

[TestFixture]
public class RoslynExampleTests
{
    [Test]
    public void RoslynExample()
    {
        var _sources = @"   using System.Collections.Generic;
                            using System.Linq;
                            namespace DynamicIsNotMagic.Examples
                            {
                                public class ExamStack<T>
                                {
                                    private readonly List<T> _data = new List<T>();
                                    public void Push(T item) => _data.Add(item);
                                    public T Pop()
                                    {
                                        var item = _data.Last();
                                        _data.Remove(item);
                                        return item;
                                    }}}";
    var compiledAssembly = CompileAssembly(_sources);

        var testClass = compiledAssembly.GetType("DynamicIsNotMagic.Examples.ExamStack`1" + "[[System.Int32, mscorlib]]");
        dynamic instance = Activator.CreateInstance(testClass);
        instance.Push(4);
        instance.Push(5);
        var res1 = instance.Pop();
        var res2 = instance.Pop();
        Assert.AreEqual(5, res1);
        Assert.AreEqual(4, res2);
    }

    private Assembly CompileAssembly(string text)
    {
        var tree = SyntaxFactory.ParseSyntaxTree(text);
        var compilation = CSharpCompilation.Create("calc.dll",
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary),
            syntaxTrees: new[] { tree },
            references: new[]
            {
                MetadataReference.CreateFromFile(typeof (object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof (System.Collections.Generic.List<>).Assembly.Location),
                MetadataReference.CreateFromFile(typeof (System.Linq.Enumerable).Assembly.Location)

            });

        Assembly compiledAssembly;
        using (var stream = new MemoryStream())
        {
            var compileResult = compilation.Emit(stream);
            compiledAssembly = Assembly.Load(stream.GetBuffer());
        }
        return compiledAssembly;
    }
}