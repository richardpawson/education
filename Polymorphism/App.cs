using System.Collections.Generic;

namespace Polymorphism
{
    class App
    {
        private List<Shape> shapes = new List<Shape>();
        public void SetUp()
        {
            var house = new Rectangle(0, 0, 300, 200);
            var door = new Rectangle(100, 0, 40, 100);
            var window = new Rectangle(200, 40, 40, 60);
            var roof = new Triangle(0, 200, 300, 250);

            shapes.Add(house);
            shapes.Add(door);
            shapes.Add(window);

            house.Draw();
            door.Draw();
            window.Draw();
            roof.Draw();
        }

        public void MoveAllBy(int x, int y)
        {
            foreach (var shape in shapes)
            {
                shape.MoveBy(x, y);
            }
        }
        public void StretchWidthAll(int percent)
        {
            foreach (var shape in shapes)

                shape.StretchWidth(percent);
        }

        public void DrawAll()
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }

        public IHasSize FindLargest(IHasSize[] input)
        {
            IHasSize largestSoFar = input[0];
            foreach (var item in input)
            {
                if (item.IsLargerThan(largestSoFar))
                {
                    largestSoFar = item;
                }
            }
            return largestSoFar;
        }
    }
}
