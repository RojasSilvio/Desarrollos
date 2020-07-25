using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

//Integrantes Grupo 6
//Mansur, Edgardo Manuel
//Rojas, Silvio Ruben
//Fumez, Elias Nataniel

namespace ProyectoFinal
{

    public partial class F_IAJuego : Form
    {
        private int fichas,col0 = 6, col1 = 6, col2 = 6, col3 = 6, col4 = 6, col5 = 6, col6 = 6, col7 = 6, colRan = 0;
        private static string lleno = " está completa, mire el tablero y vuelva a ingresar nuevamente otra columna";
        private string Nombres;
        private Random Rand = new Random();
        public void Nombre(string n)
        {
            this.Nombres = n;
            nombreJugador.Text = this.Nombres;
        }

        private char[,] tabla = new char[7, 8] {{'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},};

        public F_IAJuego()
        {
            InitializeComponent();

        }

        private void B_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        public void ContFichas(int F)
        {
            fichas = F;
            if (F != 0) TB_ContF.Text = Convert.ToString(F);
            else
            {
                TB_ContF.Text = "0";
                MessageBox.Show("EMPATE ", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Salir();
            }
        }

        private void B_A_Click(object sender, EventArgs e)
        {
            //fichas -= 1;
            //ContFichas(fichas);
            //this.col0 += 1;
            int fin = 0;

            //fin = recorrerMatriz(0);
            if (col0 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(0, 'X');
                this.col0 -= 1;
                turnoPC();

            }
            else
            {
                B_A.Enabled = false;
            }
        }

        private void B_B_Click(object sender, EventArgs e)
        {
            //fichas -= 1;
            //ContFichas(fichas);
            //this.col1 += 1;
            int fin = 0;
            //fin = recorrerMatriz(1);
            if (col1 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(1, 'X');
                this.col1 -= 1;
                turnoPC();

            }
            else
            {
                B_B.Enabled = false;
            }
        }

        private void B_C_Click(object sender, EventArgs e)
        {
            //this.col2 += 1;
            int fin = 0;
            //fin = recorrerMatriz(2);
            if (col2 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(2, 'X');
                this.col2 -= 1;
                turnoPC();

            }
            else
            {
                B_C.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F_IAJuego_FormClosing(object sender, FormClosingEventArgs e)
        {
            Salir();
        }

        private void B_D_Click(object sender, EventArgs e)
        {
            //this.col3 += 1;
            int fin = 0;
            //fin = recorrerMatriz(3);
            if (col3 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(3, 'X');
                this.col3 -= 1;
                turnoPC();

            }
            else
            {
                B_D.Enabled = false;
            }
        }

        private void B_E_Click(object sender, EventArgs e)
        {
            //this.col4 += 1;
            int fin = 0;
            //fin = recorrerMatriz(4);
            if (col4 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(4, 'X');
                this.col4 -= 1;
                turnoPC();

            }
            else
            {
                B_E.Enabled = false;
            }
        }

        private void B_F_Click(object sender, EventArgs e)
        {
            //this.col5 += 1;
            int fin = 0;
            //fin = recorrerMatriz(5);
            if (col5 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(5, 'X');
                this.col5 -= 1;
                turnoPC();

            }
            else
            {
                B_F.Enabled = false;
            }
        }

        private void B_G_Click(object sender, EventArgs e)
        {
            int fin = 0;
            //fin = recorrerMatriz(6);
            if (col6 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(6, 'X');
                this.col6 -= 1;
                turnoPC();

            }
            else
            {
                B_G.Enabled = false;
            }
        }

        private void B_H_Click(object sender, EventArgs e)
        {
            //int fin = recorrerMatriz(7);
            //if (fin >= 0)//COndicion para que no siga poniendo fichas una ves que se llene la columna
            //{
            //    fichas -= 1;
            //    ContFichas(fichas);
            //    ColocarFicha(7, 'X');

            //    turnoPC();

            //}
            //else
            //{
            //    B_H.Enabled = false;//Desabilitamos el boton, para que no ingrese mas fichas.
            //}
            if (col7 >= 0)
            {
                fichas -= 1;
                ContFichas(fichas);
                ColocarFicha(7, 'X');
                this.col7 -= 1;
                turnoPC();

            }
            else
            {
                B_H.Enabled = false;
            }
        }

        private void turnoPC()//Turno pc
        {
            int numeroran = Rand.Next(0, 8);//Obtengo un numero rrandom PAra la columna
            int fin = 0;
            ///fin = recorrerMatriz(numeroran);//Recorremos la columna para verificar que no este llena

            //if ( >= 0)
            //{
            //    fichas -= 1;
            //    ContFichas(fichas);
            //    ColocarFicha(fin, '#');
            //}
            //else if(fin < 0)
            //{
            //    //fichas -= 1;
            //    //ContFichas(fichas);
            //    //ColocarFicha(fin+1, '#');
            //    turnoPC();//volvemos a tirar la ficha.
            //}
            switch (numeroran)
            {
                case 0:

                    if (col0 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);

                        ColocarFicha(numeroran, '#');
                        col0 -= 1;
                    }

                    break;
                case 1:

                    if (col1 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col1 -= 1;
                    }

                    break;
                case 2:

                    if (col2 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col2 -= 1;
                    }

                    break;
                case 3:

                    if (col3 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col3 -= 1;
                    }

                    break;
                case 4:

                    if (col4 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col4 -= 1;
                    }

                    break;
                case 5:

                    if (col5 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col5 -= 1;
                    }

                    break;
                case 6:

                    if (col6 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col6 -= 1;
                    }

                    break;
                case 7:

                    if (col7 <= 0)
                    {
                        turnoPC();
                    }
                    else
                    {
                        fichas -= 1;
                        ContFichas(fichas);
                        ColocarFicha(numeroran, '#');
                        col7 -= 1;
                    }

                    break;

                default:
                    break;
            }
        }

        private int recorrerMatriz(int col)//Funcion para verificar que la columna no este llena
        {
            int cantO = 0;
            for (int i = 0; i < 7; i++)
            {

                if (tabla[i, col] == 'O')
                {
                    cantO++;//Aca me tira un numero fuera de rango
                }

            }
            return cantO - 1;//la restamos para que entre en el rango de la fila

        }

        private void ColocarFicha(int c, char ficha)
        {
            int cantO = 0;
            //for (int i = 0; i < 7; i++)
            //{
            //    if (tabla[i, c] == 'O')
            //    {
            //        cantO++;//Aca me tira un numero fuera de rango
            //    }

            //}
            cantO = recorrerMatriz(c);
            if (cantO >= 0)
            {
                //int fila = cantO - 1;//aca lo resto para que este dentro del Rango.
                int fila = cantO;
                this.tabla[fila, c] = ficha;
            }
            //this.tabla[fila, c] = ficha;


            Console.WriteLine("--------------------------");
            for (int i = 6; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(tabla[i, j] + " ");
                    if (tabla[i, j] == 'X')
                    {
                        int bola = j + ((i) * 10);
                        switch (bola)
                        {
                            case 0:
                                button1.BackColor = Color.Red;
                                break;
                            case 1:
                                button2.BackColor = Color.Red;
                                break;
                            case 2:
                                button3.BackColor = Color.Red;
                                break;
                            case 3:
                                button4.BackColor = Color.Red;
                                break;
                            case 4:
                                button5.BackColor = Color.Red;
                                break;
                            case 5:
                                button6.BackColor = Color.Red;
                                break;
                            case 6:
                                button7.BackColor = Color.Red;
                                break;
                            case 7:
                                button8.BackColor = Color.Red;
                                break;
                            //////////////////////////////
                            case 10:
                                button9.BackColor = Color.Red;
                                break;
                            case 11:
                                button10.BackColor = Color.Red;
                                break;
                            case 12:
                                button11.BackColor = Color.Red;
                                break;
                            case 13:
                                button12.BackColor = Color.Red;
                                break;
                            case 14:
                                button13.BackColor = Color.Red;
                                break;
                            case 15:
                                button14.BackColor = Color.Red;
                                break;
                            case 16:
                                button15.BackColor = Color.Red;
                                break;
                            case 17:
                                button16.BackColor = Color.Red;
                                break;
                            ////////////////////////////
                            case 20:
                                button17.BackColor = Color.Red;
                                break;
                            case 21:
                                button18.BackColor = Color.Red;
                                break;
                            case 22:
                                button19.BackColor = Color.Red;
                                break;
                            case 23:
                                button20.BackColor = Color.Red;
                                break;
                            case 24:
                                button21.BackColor = Color.Red;
                                break;
                            case 25:
                                button22.BackColor = Color.Red;
                                break;
                            case 26:
                                button23.BackColor = Color.Red;
                                break;
                            case 27:
                                button24.BackColor = Color.Red;
                                break;
                            /////////////////////////////
                            case 30:
                                button25.BackColor = Color.Red;
                                break;
                            case 31:
                                button26.BackColor = Color.Red;
                                break;
                            case 32:
                                button27.BackColor = Color.Red;
                                break;
                            case 33:
                                button28.BackColor = Color.Red;
                                break;
                            case 34:
                                button29.BackColor = Color.Red;
                                break;
                            case 35:
                                button30.BackColor = Color.Red;
                                break;
                            case 36:
                                button31.BackColor = Color.Red;
                                break;
                            case 37:
                                button32.BackColor = Color.Red;
                                break;
                            //////////////////////////
                            case 40:
                                button33.BackColor = Color.Red;
                                break;
                            case 41:
                                button34.BackColor = Color.Red;
                                break;
                            case 42:
                                button35.BackColor = Color.Red;
                                break;
                            case 43:
                                button36.BackColor = Color.Red;
                                break;
                            case 44:
                                button37.BackColor = Color.Red;
                                break;
                            case 45:
                                button38.BackColor = Color.Red;
                                break;
                            case 46:
                                button39.BackColor = Color.Red;
                                break;
                            case 47:
                                button40.BackColor = Color.Red;
                                break;
                            /////////////////////////
                            case 50:
                                button41.BackColor = Color.Red;
                                break;
                            case 51:
                                button42.BackColor = Color.Red;
                                break;
                            case 52:
                                button43.BackColor = Color.Red;
                                break;
                            case 53:
                                button44.BackColor = Color.Red;
                                break;
                            case 54:
                                button45.BackColor = Color.Red;
                                break;
                            case 55:
                                button46.BackColor = Color.Red;
                                break;
                            case 56:
                                button47.BackColor = Color.Red;
                                break;
                            case 57:
                                button48.BackColor = Color.Red;
                                break;
                            //////////////////////////
                            case 60:
                                button49.BackColor = Color.Red;
                                break;
                            case 61:
                                button50.BackColor = Color.Red;
                                break;
                            case 62:
                                button51.BackColor = Color.Red;
                                break;
                            case 63:
                                button52.BackColor = Color.Red;
                                break;
                            case 64:
                                button53.BackColor = Color.Red;
                                break;
                            case 65:
                                button54.BackColor = Color.Red;
                                break;
                            case 66:
                                button55.BackColor = Color.Red;
                                break;
                            case 67:
                                button56.BackColor = Color.Red;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (tabla[i, j] == '#')
                    {
                        int bola2 = j + ((i) * 10);
                        switch (bola2)
                        {
                            case 0:
                                button1.BackColor = Color.Blue;
                                break;
                            case 1:
                                button2.BackColor = Color.Blue;
                                break;
                            case 2:
                                button3.BackColor = Color.Blue;
                                break;
                            case 3:
                                button4.BackColor = Color.Blue;
                                break;
                            case 4:
                                button5.BackColor = Color.Blue;
                                break;
                            case 5:
                                button6.BackColor = Color.Blue;
                                break;
                            case 6:
                                button7.BackColor = Color.Blue;
                                break;
                            case 7:
                                button8.BackColor = Color.Blue;
                                break;
                            //////////////////////////////
                            case 10:
                                button9.BackColor = Color.Blue;
                                break;
                            case 11:
                                button10.BackColor = Color.Blue;
                                break;
                            case 12:
                                button11.BackColor = Color.Blue;
                                break;
                            case 13:
                                button12.BackColor = Color.Blue;
                                break;
                            case 14:
                                button13.BackColor = Color.Blue;
                                break;
                            case 15:
                                button14.BackColor = Color.Blue;
                                break;
                            case 16:
                                button15.BackColor = Color.Blue;
                                break;
                            case 17:
                                button16.BackColor = Color.Blue;
                                break;
                            ////////////////////////////
                            case 20:
                                button17.BackColor = Color.Blue;
                                break;
                            case 21:
                                button18.BackColor = Color.Blue;
                                break;
                            case 22:
                                button19.BackColor = Color.Blue;
                                break;
                            case 23:
                                button20.BackColor = Color.Blue;
                                break;
                            case 24:
                                button21.BackColor = Color.Blue;
                                break;
                            case 25:
                                button22.BackColor = Color.Blue;
                                break;
                            case 26:
                                button23.BackColor = Color.Blue;
                                break;
                            case 27:
                                button24.BackColor = Color.Blue;
                                break;
                            /////////////////////////////
                            case 30:
                                button25.BackColor = Color.Blue;
                                break;
                            case 31:
                                button26.BackColor = Color.Blue;
                                break;
                            case 32:
                                button27.BackColor = Color.Blue;
                                break;
                            case 33:
                                button28.BackColor = Color.Blue;
                                break;
                            case 34:
                                button29.BackColor = Color.Blue;
                                break;
                            case 35:
                                button30.BackColor = Color.Blue;
                                break;
                            case 36:
                                button31.BackColor = Color.Blue;
                                break;
                            case 37:
                                button32.BackColor = Color.Blue;
                                break;
                            //////////////////////////
                            case 40:
                                button33.BackColor = Color.Blue;
                                break;
                            case 41:
                                button34.BackColor = Color.Blue;
                                break;
                            case 42:
                                button35.BackColor = Color.Blue;
                                break;
                            case 43:
                                button36.BackColor = Color.Blue;
                                break;
                            case 44:
                                button37.BackColor = Color.Blue;
                                break;
                            case 45:
                                button38.BackColor = Color.Blue;
                                break;
                            case 46:
                                button39.BackColor = Color.Blue;
                                break;
                            case 47:
                                button40.BackColor = Color.Blue;
                                break;
                            /////////////////////////
                            case 50:
                                button41.BackColor = Color.Blue;
                                break;
                            case 51:
                                button42.BackColor = Color.Blue;
                                break;
                            case 52:
                                button43.BackColor = Color.Blue;
                                break;
                            case 53:
                                button44.BackColor = Color.Blue;
                                break;
                            case 54:
                                button45.BackColor = Color.Blue;
                                break;
                            case 55:
                                button46.BackColor = Color.Blue;
                                break;
                            case 56:
                                button47.BackColor = Color.Blue;
                                break;
                            case 57:
                                button48.BackColor = Color.Blue;
                                break;
                            //////////////////////////
                            case 60:
                                button49.BackColor = Color.Blue;
                                break;
                            case 61:
                                button50.BackColor = Color.Blue;
                                break;
                            case 62:
                                button51.BackColor = Color.Blue;
                                break;
                            case 63:
                                button52.BackColor = Color.Blue;
                                break;
                            case 64:
                                button53.BackColor = Color.Blue;
                                break;
                            case 65:
                                button54.BackColor = Color.Blue;
                                break;
                            case 66:
                                button55.BackColor = Color.Blue;
                                break;
                            case 67:
                                button56.BackColor = Color.Blue;
                                break;
                            default:
                                break;
                        }
                    }

                }
                Console.WriteLine();
            }
            Verificacion(ficha);
        }

        private void Verificacion(char ficha)
        {
            int i, j;
            //Horizontal
            for (i = 6; i >= 0; i--)//6-5-4-3-2-1-0
            {
                for (j = 0; j < 5; j++)//0-3-5-7//0-
                {
                    if ((j >= 0 && j <= 4))//0-3
                    {
                        if (tabla[i, j] == ficha && tabla[i, j + 1] == ficha && tabla[i, j + 2] == ficha && tabla[i, j + 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR +" + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }

                        }


                    }
                    //else if ((j >= 5 && j <= 7))
                    //{
                    //    if (tabla[i, j] == ficha && tabla[i, j - 1] == ficha && tabla[i, j - 2] == ficha && tabla[i, j - 3] == ficha)
                    //    {
                    //        if (ficha == 'X')
                    //        {
                    //            MessageBox.Show("GANADOR -", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            Salir();
                    //        }
                    //        else if (ficha == '#')
                    //        {
                    //            MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //    }
                    //}
                }
            }
            //Vertical
            for (i = 6; i >= 0; i--)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((i >= 0 && i <= 3))
                    {
                        if (tabla[i, j] == ficha && tabla[i + 1, j] == ficha && tabla[i + 2, j] == ficha && tabla[i + 3, j] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR " + Nombres, " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC ", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                    else if ((i >= 4 && i <= 6))
                    {
                        if (tabla[i, j] == ficha && tabla[i - 1, j] == ficha && tabla[i - 2, j] == ficha && tabla[i - 3, j] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR " + Nombres, " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC", " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                }
            }
            //Diagonal 1 (Izq a Der)
            for (i = 6; i >= 0; i--)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((i >= 0 && i <= 2) && (j >= 1 && j <= 4))
                    {
                        if (tabla[i, j] == ficha && tabla[i + 1, j + 1] == ficha && tabla[i + 2, j + 2] == ficha && tabla[i + 3, j + 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR " + Nombres, " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC", " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                    else if ((i >= 3 && i <= 6) && (j >= 5 && j <= 7))
                    {
                        if (tabla[i, j] == ficha && tabla[i - 1, j - 1] == ficha && tabla[i - 2, j - 2] == ficha && tabla[i - 3, j - 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR " + Nombres, " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC", " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                }
            }
            //Diagonal 2 (Der a Izq)
            for (i = 6; i >= 0; i--)
            {
                for (j = 0; j < 7; j++)
                {
                    if ((i >= 3 && i <= 6) && (j >= 0 && j <= 3))
                    {
                        if (tabla[i, j] == ficha && tabla[i - 1, j + 1] == ficha && tabla[i - 2, j + 2] == ficha && tabla[i - 3, j + 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC", " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                    else if ((i >= 0 && i <= 2) && (j >= 4 && j <= 7))
                    {
                        if (tabla[i, j] == ficha && tabla[i + 1, j - 1] == ficha && tabla[i + 2, j - 2] == ficha && tabla[i + 3, j - 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR " + Nombres, " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR PC", " JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                }
            }
        }
        private void Salir()
        {
            Application.Exit();
        }
    }
}

