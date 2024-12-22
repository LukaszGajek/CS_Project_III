namespace statki
{
    public partial class Form1 : Form
    {
        const int N = 10;

        int[,] Board = new int[N, N];

        List<ship> ships = new();

        Random rnd = new();
        //ship statek = new ship(0, 0, 3, 2);


        public Form1()
        {
            InitializeComponent();

            //ships.Add(new ship(0, 0, 3, 2));
            //ships.Add(new ship(200, 200, 3, 2));
            //ships.Add(new ship(120, 80, 5, 1));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i <= N; i++)
            {
                g.DrawLine(Pens.Black, i * 40, 0, i * 40, 400);

            }
            for (int j = 0; j <= N; j++)
            {
                g.DrawLine(Pens.Black, 0, j * 40, 400, j * 40);
            }

            foreach (ship ship in ships)
            {
                ship.draw(g);
            }
        }
        private bool Collision(ship s)
        {

            foreach (ship ship in ships)
            {


                if (Math.Abs(s.y - ship.y) <= 1 && s.direction == 2 && ship.direction == 2)
                {
                    if (ship.x <= s.x && ship.x + ship.lenght > s.x - 1)
                    {
                        return true;
                    }
                    else if (s.x <= ship.x && s.x + s.lenght > ship.x - 1)
                    {
                        return true;
                    }
                }


                else if (Math.Abs(s.x - ship.x) <= 1 && s.direction == 1 && ship.direction == 1)
                {
                    if (ship.y <= s.y && ship.y + ship.lenght > s.y - 1)
                    {
                        return true;
                    }

                    else if (s.y <= ship.y && s.y + s.lenght > ship.y - 1)
                    {
                        return true;
                    }

                }
                else if (s.x == ship.x && s.y == ship.y)
                {
                    return true;
                }
                else if (s.direction == 1 && ship.direction == 2)
                {
                    if (s.y <= ship.y && s.y + s.lenght - 1 >= ship.y && s.x >= ship.x -1 && s.x <= ship.x + ship.lenght)
                    {
                        return true;
                    }
                    else if (ship.y <= s.y && ship.y + ship.lenght - 1 >= s.y && ship.x >= s.x - 1 && ship.x <= s.x + s.lenght)
                    {
                        return true;
                    }

                }
                else if (s.direction == 2 && ship.direction == 1)
                {
                    if (s.x <= ship.x && s.x + s.lenght - 1 >= ship.x -1 && s.y >= ship.y - 1 && s.y -1 <= ship.y + ship.lenght)
                    {
                        return true;
                    }
                    else if (ship.x <= s.x && ship.x + ship.lenght - 1 >= s.x -1 && ship.y >= s.y - 1 && ship.y -1 <= s.y + s.lenght)
                    {
                        return true;
                    }

                }
                //else if (s.direction == 2 && ship.direction == 1)
                //{
                //    if (s.y <= ship.y && s.y + s.lenght - 1 >= ship.y && s.x >= ship.x && s.x <= ship.x + ship.lenght - 1)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }

            }
            return false;

        }


        private bool Validate(ship s)
        {
            if (s.direction == 2 && s.lenght >= 11 - s.x)
            {
                return false;
            }

            else if (s.direction == 1 && s.lenght >= 11 - s.y)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        private void gen()
        {
            ship s = new ship(rnd.Next(0, 10), rnd.Next(0, 10), rnd.Next(1, 5), rnd.Next(1, 3));
            //ship s = new ship(0, 5, 1, 2);
            if (Validate(s) == true && Collision(s) == false)
            {
                ships.Add(s);
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

            gen();


            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            gen();


            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
