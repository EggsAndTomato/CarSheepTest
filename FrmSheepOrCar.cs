using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSheepTest
{
    public partial class FrmSheepOrCar : Form
    {
        public FrmSheepOrCar()
        {
            InitializeComponent();
        }

        private Random rd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int loop = (int)this.numericUpDown1.Value;
            int getCars = 0;
            for (int i = 0; i < loop; i++)
            {
                getCars += GetCar();
            }

            this.label1.Text = $"played {loop} times, get {getCars} cars, win percent: {Math.Round((decimal)getCars / loop, 6) * 100}%";
        }


        private int GetCar()
        {
            //set sheep and car
            int[] door = new int[3] { 0, 0, 0 };
            int carIdx = rd.Next(0, 3);
            door[carIdx] = 1;

            //choose one door
            int chooseIdx = rd.Next(0, 3);

            //open a sheep door
            int fromLeftOrRight = rd.Next(0, 2);
            int openIdx = 0;
            if (fromLeftOrRight == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == chooseIdx)
                        continue;

                    if (door[i] == 0)
                    {
                        openIdx = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 3 - 1; i >= 0; i--)
                {
                    if (i == chooseIdx)
                        continue;

                    if (door[i] == 0)
                    {
                        openIdx = i;
                        break;
                    }
                }
            }

            //change
            if (this.checkBox1.Checked)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == openIdx)
                        continue;
                    if (i == chooseIdx)
                        continue;
                    chooseIdx = i;
                    break;
                }
            }

            return door[chooseIdx];
        }
    }
}
