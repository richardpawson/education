namespace OOPDraw
{
    public class House : Shape
    {
        private float Width { get; set; }
        private float WallHeight { get; set; }
        private Rectangle Walls { get; set; }
        private EquilateralTriangle Roof { get; set; }

        public House(float originX, float originY, float width, float wallHeight) : base(originX, originY)
        {
            Width = width;
            WallHeight = wallHeight;
            Walls = new Rectangle(originX, originY, width, wallHeight);
            Roof = new EquilateralTriangle(originX, originY + wallHeight, width);
        }

        public override void Draw()
        {
            Walls.Draw();
            Roof.Draw();
        }

        public override void Resize(float x, float y)
        {
            Width = x;
            var yDiff = y - WallHeight;
            WallHeight = y;
            Walls.Resize(x, y);
            Roof.Resize(x, 0);
            Roof.MoveBy(0, yDiff);
        }

        public override void Select()
        {
            Walls.Select();
            Roof.Select();
        }

        public override void Unselect()
        {
            Walls.Unselect();
            Roof.Unselect();
        }

        public override void MoveTo(float x, float y)
        {
            base.MoveTo(x, y);
            Walls.MoveTo(x, y);
            Roof.MoveTo(x, y + WallHeight);
        }


    }
}
