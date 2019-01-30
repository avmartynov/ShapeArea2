using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using NUnit.Framework;
using Tech.ShapeArea.Core;
using Tech.ShapeArea.CoreShapes;
   

namespace Tech.ShapeArea.CoreTests
{
    public class RightAngled_TestFixture
    {
        [Test]
        public void _61_RightAngled_Test()
        {
            var triangle = _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(3.0, 4.0, 5.0);

            var isTriangleRightAngled = triangle.IsRightAngledTriangle();

            Assert.That(isTriangleRightAngled, Is.True);
        }

        [Test]
        public void _62_RightAngled_Test()
        {
            var triangle = _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(4.0, 3.0, 5.0);

            var isTriangleRightAngled = triangle.IsRightAngledTriangle();

            Assert.That(isTriangleRightAngled, Is.True);
        }

        [Test]
        public void _63_RightAngled_Test()
        {
            var triangle = _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(5.0, 3.0, 4.0 );

            var isTriangleRightAngled = triangle.IsRightAngledTriangle();

            Assert.That(isTriangleRightAngled, Is.True);
        }

        [Test]
        public void _64_RightAngled_Test()
        {
            var triangle = _ioc.Resolve<IShapeFactory>("Triangle").CreateShape(3.0, 3.0, 3.0);

            var isTriangleRightAngled = triangle.IsRightAngledTriangle();

            Assert.That(isTriangleRightAngled, Is.False);
        }

        protected readonly IWindsorContainer _ioc = new WindsorContainer(new XmlInterpreter());
    }
}
