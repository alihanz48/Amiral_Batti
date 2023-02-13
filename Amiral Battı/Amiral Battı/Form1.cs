using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiral_Battı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int oyndrm = 0;
        //oyndrm=0 Gemiler yerleştirilme aşamasında-oyun başlamadı
        //oyndrm=1 Gemiler yerleştirildi,üst üste gelen gemi yok oyun başladı.
        void kalibrasyon()
        {
            panel1.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.02);
            panel4.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.02);
            panel3.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.02);
            panel5.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.02);
            panel2.Width = panel2.Height;
            int p2h = panel2.Height;
            for (int i = 10; i > 0; i--)
            {
                if (p2h % 10 != 0)
                {
                    p2h--;
                }
                else if (p2h % 10 == 0)
                {
                    break;
                }
            }
            panel2.Width = p2h;
            panel4.Height = panel4.Height + (panel2.Height - panel2.Width);
        }

        Panel pnl;
        ListBox lst1 = new ListBox();
        ListBox lst2 = new ListBox();
        int karebyt;
        int x;
        int y;

        string[,] gemiler = new string[4, 10];
        //0. sütun Amiral
        //1. sütun Kruvazör1
        //2. sütun Kruvazör2
        //3. sütun Muhrip1
        //4. sütun Muhrip2
        //5. sütun Muhrip3
        //6. sütun Denizaltı1
        //7. sütun Denizaltı2
        //8. sütun Denizaltı3
        //9. sütun Denizaltı4
        //satırlar gemilerin bulunduğu lokasyonları belirtir (x,y)

        private void Form1_Load(object sender, EventArgs e)
        {
            x = panel2.Location.X;
            y = panel2.Location.Y;
            karebyt = panel2.Width / 10;
            kalibrasyon();
            for (int i = 0; i < 10; i++)
            {
                for (int a = 0; a < 10; a++)
                {
                    pnl = new Panel();
                    pnl.Size = new Size(karebyt, karebyt);
                    if (a % 2 == 0)
                    {
                        if (i % 2 == 0)
                        {
                            pnl.BackColor = Color.Black;
                        }
                        else
                        {
                            pnl.BackColor = Color.White;
                        }

                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            pnl.BackColor = Color.White;
                        }
                        else
                        {
                            pnl.BackColor = Color.Black;
                        }
                    }
                    pnl.Name = (a + 1) + "," + (i + 1);
                    lst1.Items.Add(pnl.Name);
                    lst2.Items.Add(pnl.BackColor.ToString());
                    pnl.Location = new Point(x + a * pnl.Width, y + i * pnl.Height);
                    this.Controls.Add(pnl);
                    pnl.BringToFront();
                    pnl.Click += Pnl_Click;
                }
            }




        }

        private void Pnl_Click(object sender, EventArgs e)
        {
            if (oyndrm == 1)
            {
                click();
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            kalibrasyon();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "Amiral")
            {
                comboBox2.Items.Add("1");
            }
            else if (comboBox1.SelectedItem.ToString() == "Kruvazör")
            {
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("2");
            }
            else if (comboBox1.SelectedItem.ToString() == "Muhrip")
            {
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("2");
                comboBox2.Items.Add("3");
            }
            else
            {
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("2");
                comboBox2.Items.Add("3");
                comboBox2.Items.Add("4");
            }
            this.ActiveControl = pnlgemi;
        }

        int gemibyt;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (oyndrm == 0)
            {
                gemibyt = (comboBox1.Text == "Amiral") ? (4) : (gemibyt);
                gemibyt = (comboBox1.Text == "Kruvazör") ? (3) : (gemibyt);
                gemibyt = (comboBox1.Text == "Muhrip") ? (2) : (gemibyt);
                gemibyt = (comboBox1.Text == "Denizaltı") ? (1) : (gemibyt);

                foreach (Control ite in this.Controls)
                {
                    if (ite.Name == comboBox1.Text + comboBox2.Text)
                    {
                        if (e.KeyCode == Keys.Up)
                        {
                            if (ite.Location.Y != panel2.Location.Y)
                            {

                                ite.Top -= karebyt;
                            }
                        }
                        else if (e.KeyCode == Keys.Down)
                        {
                            if (ite.Location.Y + ite.Size.Height != panel2.Location.Y + panel2.Size.Height)
                            {
                                ite.Top += karebyt;
                            }
                        }
                        else if (e.KeyCode == Keys.Right)
                        {
                            if (ite.Location.X + ite.Size.Width != panel2.Location.X + panel2.Size.Width)
                            {

                                ite.Left += karebyt;
                            }
                        }
                        else if (e.KeyCode == Keys.Left)
                        {
                            if (ite.Location.X != panel2.Location.X)
                            {
                                ite.Left -= karebyt;
                            }
                        }
                        gemikaydet();
                    }
                }
            }
        }

        void gemikaydet()
        {
            gemibyt = (comboBox1.Text == "Amiral") ? (4) : (gemibyt);
            gemibyt = (comboBox1.Text == "Kruvazör") ? (3) : (gemibyt);
            gemibyt = (comboBox1.Text == "Muhrip") ? (2) : (gemibyt);
            gemibyt = (comboBox1.Text == "Denizaltı") ? (1) : (gemibyt);
            foreach (Control ite in this.Controls)
            {
                if (ite.Name == comboBox1.Text + comboBox2.Text)
                {
                    int gmy = ((ite.Location.Y - panel2.Location.Y) / karebyt) + 1;
                    int gmx = ((ite.Location.X - panel2.Location.X) / karebyt) + 1;
                    string gemiyon;
                    gemiyon = (ite.Width > ite.Height) ? ("yan") : ("dik");
                    int prc = 0;
                    if (ite.Name.Contains("Amiral"))
                    {
                        prc = 0;
                        for (int i = 0; i < gemibyt; i++)
                        {
                            if (gemiyon == "yan")
                            {
                                gemiler[i, 0] = (gmx + prc) + "," + gmy;
                            }
                            else
                            {
                                gemiler[i, 0] = gmx + "," + (gmy + prc);
                            }
                            prc += 1;
                        }
                        prc = 0;
                    }
                    else if (ite.Name.Contains("Kruvazör"))
                    {
                        prc = 0;
                        for (int i = 0; i < gemibyt; i++)
                        {
                            if (gemiyon == "yan")
                            {
                                gemiler[i, Convert.ToInt32(comboBox2.Text)] = (gmx + prc) + "," + gmy;
                            }
                            else
                            {
                                gemiler[i, Convert.ToInt32(comboBox2.Text)] = gmx + "," + (gmy + prc);
                            }
                            prc += 1;
                        }
                        prc = 0;

                    }
                    else if (ite.Name.Contains("Muhrip"))
                    {
                        prc = 0;
                        for (int i = 0; i < gemibyt; i++)
                        {
                            if (gemiyon == "yan")
                            {
                                gemiler[i, 2 + Convert.ToInt32(comboBox2.Text)] = (gmx + prc).ToString() + "," + gmy.ToString();
                            }
                            else
                            {
                                gemiler[i, 2 + Convert.ToInt32(comboBox2.Text)] = gmx + "," + (gmy + prc);
                            }
                            prc += 1;
                        }
                        prc = 0;
                    }
                    else if (ite.Name.Contains("Denizaltı"))
                    {
                        if (gemiyon == "yan")
                        {
                            gemiler[0, 5 + Convert.ToInt32(comboBox2.Text)] = gmx + "," + gmy;
                        }
                        else
                        {
                            gemiler[0, 5 + Convert.ToInt32(comboBox2.Text)] = (gmx + prc) + "," + gmy;
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ite in this.Controls)
            {
                if (ite.Name == comboBox1.Text + comboBox2.Text)
                {
                    if (ite.Height > ite.Width)
                    {
                        ite.Size = new Size(ite.Height, ite.Width);
                        if (ite.Location.X + ite.Size.Width > panel2.Location.X + panel2.Size.Width)
                        {
                            int yky = ((ite.Location.X + ite.Size.Width) - (panel2.Location.X + panel2.Size.Width)) / karebyt;
                            ite.Left -= yky * karebyt;
                        }
                    }
                    else if (ite.Width > ite.Height)
                    {
                        ite.Size = new Size(ite.Height, ite.Width);
                        if (ite.Location.Y + ite.Height > panel2.Location.Y + panel2.Size.Height)
                        {
                            int dky = ((ite.Location.Y + ite.Size.Height) - (panel2.Location.Y + panel2.Size.Height)) / karebyt;
                            ite.Top -= dky * karebyt;
                        }
                    }
                    gemikaydet();
                }

            }
            this.ActiveControl = pnlgemi;
        }

        Panel pnlgemi;

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" || comboBox2.Text != "")
            {
                if (comboBox1.Text == "Amiral" || comboBox1.Text == "Kruvazör" || comboBox1.Text == "Muhrip" || comboBox1.Text == "Denizaltı")
                {
                    if (comboBox1.Text == "Amiral")
                    {
                        if (gemiler[3, 0] == null)
                        {
                            pnlgemi = new Panel();
                            pnlgemi.Name = "Amiral1";
                            pnlgemi.Location = new Point(x, y);
                            pnlgemi.Size = new Size(karebyt, 4 * (karebyt));
                            pnlgemi.BackColor = Color.Blue;
                            this.Controls.Add(pnlgemi);
                            pnlgemi.BringToFront();
                            this.ActiveControl = pnlgemi;
                        }

                    }
                    else if (comboBox1.Text == "Kruvazör")
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            if (comboBox2.Text == i.ToString() && gemiler[2, i] == null)
                            {
                                pnlgemi = new Panel();
                                pnlgemi.Name = "Kruvazör" + comboBox2.Text;
                                pnlgemi.Location = new Point(x, y);
                                pnlgemi.Size = new Size(karebyt, 3 * (karebyt));
                                pnlgemi.BackColor = Color.Blue;
                                this.Controls.Add(pnlgemi);
                                pnlgemi.BringToFront();
                                this.ActiveControl = pnlgemi;
                            }
                        }

                    }
                    else if (comboBox1.Text == "Muhrip")
                    {
                        for (int i = 3; i < 6; i++)
                        {
                            if (comboBox2.Text == (i - 2).ToString() && gemiler[1, i] == null)
                            {
                                pnlgemi = new Panel();
                                pnlgemi.Name = "Muhrip" + comboBox2.Text;
                                pnlgemi.Location = new Point(x, y);
                                pnlgemi.Size = new Size(karebyt, 2 * (karebyt));
                                pnlgemi.BackColor = Color.Blue;
                                this.Controls.Add(pnlgemi);
                                pnlgemi.BringToFront();
                                this.ActiveControl = pnlgemi;
                            }
                        }
                    }
                    else if (comboBox1.Text == "Denizaltı")
                    {
                        for (int i = 6; i < 10; i++)
                        {
                            if (comboBox2.Text == (i - 5).ToString() && gemiler[0, i] == null)
                            {
                                pnlgemi = new Panel();
                                pnlgemi.Name = "Denizaltı" + comboBox2.Text;
                                pnlgemi.Location = new Point(x, y);
                                pnlgemi.Size = new Size(karebyt, 1 * (karebyt));
                                pnlgemi.BackColor = Color.Blue;
                                this.Controls.Add(pnlgemi);
                                pnlgemi.BringToFront();
                                this.ActiveControl = pnlgemi;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Araç seçimi yapınız.");
                }
                this.ActiveControl = pnlgemi;
                gemikaydet();
                pnlgemi.Click += Pnlgemi_Click;
            }
        }

        private void Pnlgemi_Click(object sender, EventArgs e)
        {
            if (oyndrm == 1)
            {
                click();
            }
        }



        bool ynlm;
        private void button3_Click(object sender, EventArgs e)
        {
            ListBox knmlr = new ListBox();
            ynlm = false;
            for (int i = 0; i < 10; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    if (gemiler[a, i] != null)
                    {
                        if (knmlr.Items.Contains(gemiler[a, i]))
                        {
                            ynlm = true;
                            break;
                        }
                        else
                        {
                            knmlr.Items.Add(gemiler[a, i]);
                        }
                    }

                }
                if (ynlm == true)
                {
                    break;
                }
            }

            if (ynlm == true)
            {
                MessageBox.Show("Üst üste denk gelen araçlar olamaz.");
            }
            else if (gemiler[3, 0] == null)
            {
                MessageBox.Show("Amiral gemisini yerleştiriniz.");
            }
            else if (gemiler[2, 1] == null)
            {
                MessageBox.Show("1. Kruvazör gemisini yerleştiriniz.");
            }
            else if (gemiler[2, 2] == null)
            {
                MessageBox.Show("2. Kruvazör gemisini yerleştiriniz.");
            }
            else if (gemiler[1, 3] == null)
            {
                MessageBox.Show("1. Muhribi yerleştiriniz.");
            }
            else if (gemiler[1, 4] == null)
            {
                MessageBox.Show("2.Muhribi yerleştiriniz.");
            }
            else if (gemiler[1, 5] == null)
            {
                MessageBox.Show("3.Muhribi yerleştiriniz.");
            }
            else if (gemiler[0, 6] == null)
            {
                MessageBox.Show("1.Denizaltını yerleştiriniz.");
            }
            else if (gemiler[0, 7] == null)
            {
                MessageBox.Show("2. Denizaltını yerleştiriniz.");
            }
            else if (gemiler[0, 8] == null)
            {
                MessageBox.Show("3.denizaltını yerleştiriniz.");
            }
            else if (gemiler[0, 9] == null)
            {
                MessageBox.Show("4.Denizaltını yerleştiriniz.");
            }
            else
            {
                panel9.Visible = false;
                oyndrm = 1;
                button3.Visible = false;
                panel10.Visible = true;
                baslamapchazirlik();
            }
            this.ActiveControl = pnlgemi;
            baslamapchazirlik();
        }

        ListBox pcgmlr = new ListBox();
        int lctnx;
        int lctny;
        int a = 0;
        void baslamapchazirlik()
        {
            pcgmlr.Items.Clear();
            lctnx = 0;
            lctny = 0;

            int yon;
            Random pcgmlctn = new Random();

            //Amiral konum belirleme
            yon = pcgmlctn.Next(1, 10);
            //yon>5 gemi yan -----> else : gemi dik
            if (yon > 5)
            {
                lctnx = pcgmlctn.Next(1, 7);
                lctny = pcgmlctn.Next(1, 10);

            }
            else if (yon < 5)
            {
                lctnx = pcgmlctn.Next(1, 10);
                lctny = pcgmlctn.Next(1, 7);
            }

            for (int i = 0; i < 4; i++)
            {
                if (yon > 5)
                {
                    pcgmlr.Items.Add((lctnx + i).ToString() + "," + lctny);
                }
                else
                {
                    pcgmlr.Items.Add(lctnx.ToString() + "," + (lctny + i).ToString());
                }
            }
            //-------------------------------------------------------------------------


            //Kruvazör 2 adet
            for (int i = 0; i < 2; i++)
            {
                a = 0;

                //yon>5 gemi yan -----> else : gemi dik
                while (a == 0)
                {
                    yon = pcgmlctn.Next(1, 10);
                    if (yon > 5)
                    {
                        lctnx = pcgmlctn.Next(1, 8);
                        lctny = pcgmlctn.Next(1, 10);

                        for (int b = 0; b < 2; b++)
                        {
                            if (pcgmlr.Items.Contains((lctnx + b).ToString() + "," + lctny))
                            {
                                a = 0;
                                break;
                            }
                            else
                            {
                                a = 1;
                            }
                        }

                    }
                    else if (yon < 5)
                    {
                        lctnx = pcgmlctn.Next(1, 10);
                        lctny = pcgmlctn.Next(1, 8);

                        for (int b = 0; b < 2; b++)
                        {
                            if (pcgmlr.Items.Contains((lctnx + b).ToString() + "," + lctny))
                            {
                                a = 0;
                                break;
                            }
                            else
                            {
                                a = 1;
                            }
                        }
                    }

                    if (a == 1)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (yon > 5)
                            {
                                pcgmlr.Items.Add((lctnx + c).ToString() + "," + lctny);
                            }
                            else
                            {
                                pcgmlr.Items.Add(lctnx.ToString() + "," + (lctny + c).ToString());
                            }
                        }
                    }

                }
            }
            //---------------------------------------------------------------------------------------

            //Muhrip 3 adet
            for (int i = 0; i < 3; i++)
            {
                a = 0;

                //yon>5 gemi yan -----> else : gemi dik
                while (a == 0)
                {
                    yon = pcgmlctn.Next(1, 10);
                    if (yon > 5)
                    {
                        lctnx = pcgmlctn.Next(1, 9);
                        lctny = pcgmlctn.Next(1, 10);

                        for (int b = 0; b < 3; b++)
                        {
                            if (pcgmlr.Items.Contains((lctnx + b).ToString() + "," + lctny))
                            {
                                a = 0;
                                break;
                            }
                            else
                            {
                                a = 1;
                            }
                        }

                    }
                    else if (yon < 5)
                    {
                        lctnx = pcgmlctn.Next(1, 10);
                        lctny = pcgmlctn.Next(1, 9);

                        for (int b = 0; b < 3; b++)
                        {
                            if (pcgmlr.Items.Contains((lctnx + b).ToString() + "," + lctny))
                            {
                                a = 0;
                                break;
                            }
                            else
                            {
                                a = 1;
                            }
                        }
                    }

                    if (a == 1)
                    {
                        for (int c = 0; c < 2; c++)
                        {
                            if (yon > 5)
                            {
                                pcgmlr.Items.Add((lctnx + c).ToString() + "," + lctny);
                            }
                            else
                            {
                                pcgmlr.Items.Add(lctnx.ToString() + "," + (lctny + c).ToString());
                            }
                        }
                    }

                }
            }
            //---------------------------------------------------------------------------------------

            //Denizaltı 4 adet
            for (int i = 0; i < 4; i++)
            {
                a = 0;

                //yon>5 gemi yan -----> else : gemi dik
                while (a == 0)
                {
                    yon = pcgmlctn.Next(1, 10);
                    if (yon > 5)
                    {
                        lctnx = pcgmlctn.Next(1, 8);
                        lctny = pcgmlctn.Next(1, 10);

                        for (int b = 0; b < 4; b++)
                        {
                            if (pcgmlr.Items.Contains((lctnx + b).ToString() + "," + lctny))
                            {
                                a = 0;
                                break;
                            }
                            else
                            {
                                a = 1;
                            }
                        }

                    }
                    else if (yon < 5)
                    {
                        lctnx = pcgmlctn.Next(1, 10);
                        lctny = pcgmlctn.Next(1, 8);

                        for (int b = 0; b < 4; b++)
                        {
                            if (pcgmlr.Items.Contains((lctnx + b).ToString() + "," + lctny))
                            {
                                a = 0;
                                break;
                            }
                            else
                            {
                                a = 1;
                            }
                        }
                    }

                    if (a == 1)
                    {
                        for (int c = 0; c < 1; c++)
                        {
                            if (yon > 5)
                            {
                                pcgmlr.Items.Add((lctnx + c).ToString() + "," + lctny);
                            }
                            else
                            {
                                pcgmlr.Items.Add(lctnx.ToString() + "," + (lctny + c).ToString());
                            }
                        }
                    }

                }
            }
            //---------------------------------------------------------------------------------------
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
        }

        string atiskoordinat;
        ListBox vurulanlctn = new ListBox();
        int pc = 0;
        int plyr = 0;
        Control atisy;

        private void button4_Click(object sender, EventArgs e)
        {
            label9.Text = "Sıra Oyuncuda";
            foreach (Control item in this.Controls)
            {
                if (item.BackColor == Color.Red)
                {
                    atiskoordinat = item.Name;
                    atisy = item;
                }
            }

            if (vurulanlctn.Items.Contains(atiskoordinat))
            {
                MessageBox.Show("Bu lokasyonda daha önceden başarılı bir atış mevcut.");
            }
            else if (pcgmlr.Items.Contains(atiskoordinat))
            {
                label4.Text = "Atış başarılı !";
                vurulanlctn.Items.Add(atiskoordinat);
                Panel batis = new Panel();
                batis.Location = atisy.Location;
                batis.BackColor = Color.Yellow;
                batis.Size = atisy.Size;
                this.Controls.Add(batis);
                batis.BringToFront();
                plyr++;
                label8.Text = plyr.ToString();
                if (plyr == 20)
                {
                    oyunbitis();
                }
            }
            else
            {
                label4.Text = "Atış başarısız !";
            }

            label9.Text = "Sıra Bilgisayarda";
            pcatis();
            label9.Text = "Sıra Oyuncuda";
        }

        ListBox batisy = new ListBox();
        void pcatis()
        {
            Random rndknm = new Random();
            int rndx = rndknm.Next(0, 10);
            int rndy = rndknm.Next(0, 10);
            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 10; a++)
                {
                    if (gemiler[i, a] != null)
                    {
                        if (gemiler[i, a] == rndx.ToString() + "," + rndy.ToString())
                        {
                            if (batisy.Items.Contains(rndx.ToString() + "," + rndy.ToString()))
                            {
                                break;
                            }
                            else
                            {
                                pc++;
                                if (pc == 20)
                                {
                                    oyunbitis();
                                }
                                label6.Text = pc.ToString();
                                label4.Text = "Bilgisayar başarılı bir atış yaptı";
                                batisy.Items.Add(rndx.ToString() + "," + rndy.ToString());
                                Panel pcatis = new Panel();
                                pcatis.Location = new Point(panel1.Size.Width + (rndx - 1) * karebyt, panel3.Size.Height + (rndy - 1) * karebyt);
                                pcatis.Size = new Size(karebyt, karebyt);
                                pcatis.BackColor = Color.Pink;
                                this.Controls.Add(pcatis);
                                pcatis.BringToFront();
                                pcatis.Click += Pcatis_Click;
                            }
                        }
                    }
                }
                if (batisy.Items.Contains(rndx.ToString() + "," + rndy.ToString()))
                {
                    break;
                }
            }
            if (batisy.Items.Contains(rndx.ToString() + "," + rndy.ToString()))
            {
                pcatis();
            }
        }

        void oyunbitis(){
            string kazanan = (pc==20) ? ("PC"):("Oyuncu");
            MessageBox.Show("Oyunu "+kazanan+" kazandı");
            Application.Restart();
        }

        private void Pcatis_Click(object sender, EventArgs e)
        {
            click();
        }

        Panel agemi = new Panel();
        public void click()
        {
            int cx = ((Cursor.Position.X - panel1.Size.Width) / karebyt) + 1;
            int cy = Cursor.Position.Y - panel3.Size.Height;
            for (int i = 68; i > 0; i--)
            {
            if ((cy - i) % karebyt == 0)
            {
                 cy = (((cy - i) / karebyt) + 1);
                     break;
            }
            }
            foreach (Control item in this.Controls)
            {
            if (item.Name == (cx + "," + cy))
            {
                agemi.Name = cx + "," + cy;
                agemi.Size = item.Size;
                agemi.Location = item.Location;
                agemi.BackColor = Color.Red;
                this.Controls.Add(agemi);
                agemi.BringToFront();
            }
            }
         }
    }
}



