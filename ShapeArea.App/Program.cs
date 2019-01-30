using System;
using System.Linq;
using System.Threading;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Tech.ShapeArea.Core;
using Tech.ShapeArea.View;


namespace Tech.ShapeArea.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var ioc = new WindsorContainer(new XmlInterpreter()))
                {
                    var shapeName  = args[0];
                    var origParams = args.Skip(1).ToArray();
                    var shapeView  = ioc.Resolve<IShapeView>(shapeName + "View");
                    var parameters = shapeView.GetShapeParameters(origParams, Thread.CurrentThread.CurrentCulture);
                    var shape      = ioc.Resolve<IShapeFactory>(shapeName).CreateShape(parameters);
                    var area       = shape.CalculateArea();

                    Console.WriteLine(area);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
