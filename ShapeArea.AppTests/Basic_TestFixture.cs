using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Tech.ShapeArea.AppTests
{
    public class Basic_TestFixture
    {
        public static object[] Source => new object[]
                                  {
                                      new object [] {12.0,    "Rectangle 3 4"},
                                      new object [] {6.0,     "Triangle 3 4 5"},
                                      new object [] {0.0,     "Point"},
                                      new object [] {Math.PI, "Circle 1"},
                                  };

        [Test, TestCaseSource(nameof(Source))]
        public void Test(double expected, string cmdLine)
        {
            var actual = RunApp(cmdLine);

            Assert.That(Math.Abs(actual - expected), Is.LessThan(0.000001));
        }

        private static double RunApp(string arguments)
        {
            var startInfo = new ProcessStartInfo
                     {
                         FileName = "Tech.ShapeArea.App.exe",
                         Arguments = arguments,
                         RedirectStandardOutput = true,
                         UseShellExecute = false
            };

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Directory.GetCurrentDirectory());
            var p = Process.Start(startInfo);
            if (p == null)
                throw new InvalidOperationException($"Can't start application '{startInfo.FileName}'");

            if (! p.WaitForExit(1000))
                throw new InvalidOperationException("");

            var output = p.StandardOutput.ReadToEnd();

            return double.Parse(output);
        }
    }
}
