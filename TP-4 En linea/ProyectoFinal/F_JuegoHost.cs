using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class F_JuegoHost : Form
    {
        private int fichas, col0 = 0, col1 = 0, col2 = 0, col3 = 0, col4 = 0, col5 = 0, col6 = 0, col7 = 0;
        private static string lleno = " está completa, mire el tablero y vuelva a ingresar nuevamente otra columna";
        private string Nombres;

        public void Nombre(string n)
        {
            this.Nombres = n;
        }

        private char[,] tabla = new char[7, 8] {{'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},};

        public F_JuegoHost()
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
                MessageBox.Show("JUEGO TERMINADO x", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Salir();
            }
        }

        private void B_A_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col0 += 1; ColocarFicha(0, 'X');
        }

        private void B_B_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col1 += 1; ColocarFicha(1, 'X');
        }

        private void B_C_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col2 += 1; ColocarFicha(2, 'X');
        }

        private void B_D_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col3 += 1; ColocarFicha(3, 'X');
        }

        private void B_E_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col4 += 1; ColocarFicha(4, 'X');
        }

        private void B_F_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col5 += 1; ColocarFicha(5, 'X');
        }

        private void B_G_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col6 += 1; ColocarFicha(6, 'X');
        }

        private void B_H_Click(object sender, EventArgs e)
        {
            fichas -= 1;
            ContFichas(fichas);
            this.col7 += 1; ColocarFicha(7, 'X');
        }

        private void ColocarFicha(int col, char ficha)
        {
            //PARA PROBAR
            tabla[1, 3] = ficha;
            tabla[2, 2] = ficha;
            tabla[3, 1] = ficha;
            tabla[4, 0] = ficha;
            Verificacion(ficha);

        }

        private void Verificacion(char ficha)
        {
            int i, j;
            //Horizontal
            for (i = 6; i >= 0; i--)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((j >= 0 && j <= 3))
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
                                MessageBox.Show("GANADOR -", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    else if ((j >= 4 && j <= 7))
                    {
                        if (tabla[i, j] == ficha && tabla[i, j - 1] == ficha && tabla[i, j - 2] == ficha && tabla[i, j - 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR -", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
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
                                MessageBox.Show("GANADOR+ " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if ((i >= 4 && i <= 6))
                    {
                        if (tabla[i, j] == ficha && tabla[i - 1, j] == ficha && tabla[i - 2, j] == ficha && tabla[i - 3, j] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR- " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("GANADOR izq a der " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if ((i >= 3 && i <= 6) && (j >= 5 && j <= 7))
                    {
                        if (tabla[i, j] == ficha && tabla[i - 1, j - 1] == ficha && tabla[i - 2, j - 2] == ficha && tabla[i - 3, j - 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR- " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    {//
                        if (tabla[i, j] == ficha && tabla[i - 1, j + 1] == ficha && tabla[i - 2, j + 2] == ficha && tabla[i - 3, j + 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADORder a izq+ " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if ((i >= 0 && i <= 2) && (j >= 4 && j <= 7))
                    {
                        if (tabla[i, j] == ficha && tabla[i + 1, j - 1] == ficha && tabla[i + 2, j - 2] == ficha && tabla[i + 3, j - 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR der a izq- " + Nombres, "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
