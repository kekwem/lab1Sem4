using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zdarzenia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            textBox.Text = $"X:{e.X} Y:{e.Y} B:{e.Button}";
        }

        List<Wspolrzedne> tablica_elementow = new List<Wspolrzedne>();

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel.CreateGraphics();
            foreach (var element in tablica_elementow)
            {
                if (element.kolo)
                {
                    g.FillEllipse(Brushes.Red, element.x, element.y, 100, 100);
                }
                else
                {
                    g.FillRectangle(Brushes.Blue, element.x, element.y, 100, 100);
                }
                
            }
        }

        bool przeniose = false;
        bool kolo = false;

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                int liczba = tablica_elementow.Count;
                for (int i = liczba - 1; i >= 0; i--)
                {
                    if (e.X >= tablica_elementow[i].x && e.X <= tablica_elementow[i].x + 100
                        && e.Y >= tablica_elementow[i].y && e.Y <= tablica_elementow[i].y + 100)
                    {
                        if (tablica_elementow[i].kolo)
                        {
                            kolo = true;
                        }
                        else
                        {
                            kolo = false;
                        }
                        przeniose = true;
                        tablica_elementow.Remove(tablica_elementow[i]);
                        break;
                    }
                }
            }
            panel_MouseMove(sender, e);
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {

            if (przeniose)
            {
                tablica_elementow.Add(new Wspolrzedne(e.X - 50, e.Y - 50, kolo));
                przeniose = false;
            }
            else
            {
                Graphics g = panel.CreateGraphics();
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    g.FillEllipse(Brushes.Red, e.X - 50, e.Y - 50, 100, 100);
                    tablica_elementow.Add(new Wspolrzedne(e.X - 50, e.Y - 50, true));
                }
                else if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
                {
                    g.FillRectangle(Brushes.Blue, e.X - 50, e.Y - 50, 100, 100);
                    tablica_elementow.Add(new Wspolrzedne(e.X - 50, e.Y - 50, false));
                }
            }
            
            panel.Refresh();
            panel_MouseMove(sender, e);
        }
    }
}
