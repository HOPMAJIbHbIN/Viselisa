using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Viselisa.Manage
{
    class DrawVis
    {
        //Конструктор
        #region
        private Grid _drawGrid;
        private Canvas _drawCanvas;
        private Grid _dashGrid;
        private Canvas _dashCanvas;
        public DrawVis(Grid DrawGrid, Canvas CanvEllips, Grid DashGrid, Canvas DashCanvas)
        {
            _drawGrid = DrawGrid;
            _drawCanvas = CanvEllips;
            _dashGrid = DashGrid;
            _dashCanvas = DashCanvas;
        }
        #endregion

        //Рисовать висилицу
        #region
        public void DrawLineEl(double x1, double x2, double y1,double y2)
        {
            var drawline = new Line();
            var drawline1 = new Line();
            var drawelipse = new Ellipse();

            drawline.Stroke = System.Windows.Media.Brushes.Black;
            drawline.X1 = x1;
            drawline.X2 = x2;
            drawline.Y1 = y1;
            drawline.Y2 = y2;
            drawline.StrokeThickness = 4;
            _drawGrid.Children.Add(drawline);
        }
        public void DrawViselica(int count)
        {
            var drawelipse = new Ellipse();
            switch (count)
            {
                
                case 1:
                    {
                        DrawLineEl(100, 50, 500, 550);
                    }
                    break;
                case 2:
                    {
                        DrawLineEl(100, 150, 500 ,550);
                    }
                    break;
                case 3:
                    {
                        DrawLineEl(50, 150, 550, 550);
                    }
                    break;
                case 4:
                    {
                        DrawLineEl(100, 100, 550, 175);
                    }
                    break;
                case 5:
                    {
                        DrawLineEl(100, 275, 175, 175);
                    }
                    break;
                case 6:
                    {
                        DrawLineEl(100, 150, 225, 175);
                    }
                    break;
                case 7:
                    {
                        DrawLineEl(265, 265, 175, 200);
                    }
                    break;
                case 8:
                    {
                        drawelipse.Stroke = System.Windows.Media.Brushes.Black;
                        drawelipse.Width = 50;
                        drawelipse.Height = 50;
                        drawelipse.StrokeThickness = 4;
                        _drawCanvas.Children.Add(drawelipse);
                    }
                    break;
                case 9:
                    {
                        DrawLineEl(265, 265, 250, 350);
                    }
                    break;
                case 10:
                    {
                        DrawLineEl(265, 230, 350, 425);
                    }
                    break;
                case 11:
                    {
                        DrawLineEl(265, 300, 350, 425);
                    }
                    break;
                case 12:
                    {
                        DrawLineEl(265, 230, 255, 325);
                    }
                    break;
                case 13:
                    {
                        DrawLineEl(265, 300, 255, 325);
                    }
                    break;
                case 14:
                    {
                        DrawLineEl(250, 260, 215, 225);
                        DrawLineEl(260, 250, 215, 225);
                    }
                    break;
                case 15:
                    {
                        DrawLineEl(270, 280, 215, 225);
                        DrawLineEl(280, 270, 215, 225);
                    }
                    break;
            }
        }
        #endregion

        //Рисовать буквы
        #region
        public void DrawDash(double x, double y, double h)
        {
            Line dash = new Line();
            dash.Stroke = System.Windows.Media.Brushes.Black;
            dash.X1 = x;
            dash.X2 = x + h;
            dash.Y1 = y;
            dash.Y2 = y;
            dash.StrokeThickness = 3;
            _dashCanvas.Children.Add(dash);
        }
        public void DrawLetters(int WordLength)
        {
            double x, y, h;
            x = 5;
            y = 0;
            h = 40;
            double h0, h2 = h0 = h + 10;
            DrawDash(x, y, h);
            for (int i = WordLength; i > 1; i--)
            {
                DrawDash(x + h2, y, h);
                if (WordLength > 4 && h2 >= 4 * h0)
                    _dashGrid.Width += h0;
                h2 += h0;
            }
        }
        #endregion
    }
}
