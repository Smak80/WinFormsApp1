using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Painter
    {
        private Image mainImg;
        private Size imageSize;
        public Size ImageSize
        {
            get => imageSize;
            set
            {
                imageSize = value;
                var img = new Bitmap(imageSize.Width, imageSize.Height);
                var ig = Graphics.FromImage(img);
                ig.Clear(Color.White);
                if (mainImg != null)
                {
                    ig.DrawImage(mainImg, 0, 0);
                }

                mainImg = img;
            }
        }
        public Point StartPoint = new Point(0, 0);
        public Point EndPoint = new Point(0, 0);

        public Painter(Size sz)
        {
            ImageSize = sz;
        }

        private void Paint(Graphics g)
        {
            Pen p = new Pen(Color.BlueViolet, 5);
            g.DrawRectangle(p,
                StartPoint.X,
                StartPoint.Y,
                EndPoint.X - StartPoint.X,
                EndPoint.Y - StartPoint.Y);
        }

        public void Paint()
        {
            var g = Graphics.FromImage(mainImg);
            Paint(g);
        }

        public void Preview(Graphics g)
        {
            BufferedGraphics bg = BufferedGraphicsManager.Current.Allocate(g, Rectangle.Round(g.VisibleClipBounds));
            bg.Graphics.DrawImage(mainImg, 0, 0);
            Paint(bg.Graphics);
            bg.Render(g);
        }

        public void Show(Graphics g)
        {
            g.DrawImage(mainImg, 0, 0);
        }

    }
}
