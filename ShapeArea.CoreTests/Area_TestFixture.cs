using System;
using NUnit.Framework;
using Tech.ShapeArea.Core;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Tech.ShapeArea.CoreTests
{
    /// <summary>
    /// Тесты-наследники по разному инициализируют ShapeManager
    /// </summary>
    public class Area_TestFixture
    {
        [Test]
        public void _10_Basic_Test()
        {
            var circle = _ioc.Resolve<IShapeFactory>("Circle").CreateShape(2.0);

            var areaOfCircle = circle.CalculateArea();

            Assert.That(Math.Abs(areaOfCircle - Math.PI * 2.0 * 2.0), Is.LessThan(double.Epsilon));
        }

        [Test]
        public void _20_NoMandatoryParameter_Test()
        {
            Assert.Throws<ArgumentException>(
                () => _ioc.Resolve<IShapeFactory>("Circle").CreateShape());
        }

        [Test]
        public void _30_WrongParameterType_Test()
        {
            Assert.Throws<ArgumentException>(
                () => _ioc.Resolve<IShapeFactory>("Circle").CreateShape("3.0"));
        }

        [Test]
        public void _40_Basic_Test()
        {
            var shape = _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(3.0, 4.0, 5.0);

            var areaOfShape = shape.CalculateArea();

            Assert.That(Math.Abs(areaOfShape - 6.0), Is.LessThan(double.Epsilon));
        }

        [Test]
        public void _42_Basic_Test()
        {
            var shape = _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(0.0, 4.0, 5.0);

            var areaOfShape = shape.CalculateArea();

            Assert.That(Math.Abs(areaOfShape - 0.0), Is.LessThan(double.Epsilon));
        }

        [Test]
        public void _43_Basic_Test()
        {
            Assert.Throws<ArgumentException>(()
                => _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(2.0, -4.0, 5.0));
        }

        [Test]
        public void _50_Basic_Test()
        {
            var shape = _ioc.Resolve<IShapeFactory>("Point").CreateShape();

            var areaOfShape = shape.CalculateArea();

            Assert.That(areaOfShape, Is.EqualTo(0.0));
        }

        protected readonly IWindsorContainer _ioc = new WindsorContainer(new XmlInterpreter());
    }
}
