using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class F_HostJuego : Form
    {

        private bool Conectado = false;

        private int fichas, col0 = 8, col1 = 8, col2 = 8, col3 = 8, col4 = 8, col5 = 8, col6 = 8, col7=8;
  
        private static string lleno = " está completa, mire el tablero y vuelva a ingresar nuevamente otra columna";
        private string[] Nombres = new string[2];

        public void Nombre(string n)
        {
            this.Nombres[0] = n;
            nombreJugador.Text = n;
        }

        private char[,] tabla = new char[7, 8] {{'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},
                                                {'O', 'O', 'O', 'O', 'O', 'O', 'O','O'},};

        public F_HostJuego()
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
            if (F != 0) Invoke(new Action(() => TB_ContF.Text = Convert.ToString(F)));
            else
            {
                TB_ContF.Text = "0";
                MessageBox.Show("EMPATE", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Salir();
            }
        }

        private void elegirColumna(int n, char c)
        {
            Invoke(new Action(() => Deshabilitar()));
            fichas -= 1;
            ContFichas(fichas);
            ColocarFicha(n, c);
        }

        private void B_A_Click(object sender, EventArgs e)
        {
            if (col0 != 0)
            {
                col0 -= 1;
                conexionTcp.EnviarPaquete(new Paquete("0"));
                elegirColumna(0, 'X');
                Console.WriteLine(col0);
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_A.Enabled = false;
            }
        }

        private void B_B_Click(object sender, EventArgs e)
        {
            if (col1 != 0)
            {
                col1 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("1"));
                elegirColumna(1, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_B.Enabled = false;
            }
        }

        private void B_C_Click(object sender, EventArgs e)
        {
            if (col2 != 0)
            {
                col2 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("2"));
                elegirColumna(2, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_C.Enabled = false;
            }
        }

        private void B_D_Click(object sender, EventArgs e)
        {
            if (col3 != 0)
            {
                col3 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("3"));
                elegirColumna(3, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_D.Enabled = false;
            }
        }

        private void B_E_Click(object sender, EventArgs e)
        {
            if (col4 != 0)
            {
                col4 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("4"));
                elegirColumna(4, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_E.Enabled = false;
            }
        }

        private void B_F_Click(object sender, EventArgs e)
        {
            if (col5 != 0)
            {
                col5 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("5"));
                elegirColumna(5, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_F.Enabled = false;
            }
        }

        private void B_G_Click(object sender, EventArgs e)
        {
            if (col6 != 0)
            {
                col6 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("6"));
                elegirColumna(6, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA", "ERROR", MessageBoxButtons.OK);
                B_G.Enabled = false;
            }
        }

        private void B_H_Click(object sender, EventArgs e)
        {
            if (col7 != 0)
            {
                col7 -= 2;
                conexionTcp.EnviarPaquete(new Paquete("7"));
                elegirColumna(7, 'X');
            }
            else
            {
                MessageBox.Show("NO HAY LUGAR DISPONIBLE, SELECCIONE OTRA COLUMNA","ERROR",MessageBoxButtons.OK);
                B_H.Enabled = false;
            }
        }

            //private int recorrerMatriz(int col)//Funcion para verificar que la columna no este llena
            //{
            //    int cantO = 0;
            //    for (int i = 0; i < 7; i++)
            //    {

            //        if (tabla[i, col] == 'O')
            //        {
            //            cantO++;//Aca me tira un numero fuera de rango
            //        }

            //    }
            //    return cantO - 1;//la restamos para que entre en el rango de la fila

            //}

            private void ColocarFicha(int col, char ficha)
            {
                int cantO = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (tabla[i, col] == 'O')
                    {
                        cantO++;
                    }

                }
                if (cantO > 0)
                {
                    int fila = cantO - 1;
                    this.tabla[fila, col] = ficha;
                }


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
            for (i = 6; i >= 0; i--)
            {
                for (j = 0; j < 8; j++)
                {
                    if ((j >= 0 && j <= 4))
                    {
                        if (tabla[i, j] == ficha && tabla[i, j + 1] == ficha && tabla[i, j + 2] == ficha && tabla[i, j + 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }

                        }


                    }
                    else if ((j >= 5 && j <= 7))
                    {
                        if (tabla[i, j] == ficha && tabla[i, j - 1] == ficha && tabla[i, j - 2] == ficha && tabla[i, j - 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
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
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    {//
                        if (tabla[i, j] == ficha && tabla[i - 1, j + 1] == ficha && tabla[i - 2, j + 2] == ficha && tabla[i - 3, j + 3] == ficha)
                        {
                            if (ficha == 'X')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("GANADOR: " + Nombres[0], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                            else if (ficha == '#')
                            {
                                MessageBox.Show("GANADOR: " + Nombres[1], "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Salir();
                            }
                        }
                    }
                }
            }
        }


        private void Salir()
        {
            Environment.Exit(0);
        }

        private void F_HostJuego_FormClosing(object sender, FormClosingEventArgs e)
        {
            Salir();
        }
        private void Deshabilitar()
        {

            B_A.Enabled = false;
            B_B.Enabled = false;
            B_C.Enabled = false;
            B_D.Enabled = false;
            B_E.Enabled = false;
            B_F.Enabled = false;
            B_G.Enabled = false;
            B_H.Enabled = false;

        }

        private void Habilitar()
        {
            if (!B_A.Enabled)
            {
                B_A.Enabled = true;
                col0 -= 1;
            }
            if (!B_B.Enabled)
            {
                B_B.Enabled = true;
                col1 -= 1;
            }
            if (!B_C.Enabled)
            {
                B_C.Enabled = true;
                col2 -= 1;
            }
            if (!B_D.Enabled)
            {
                B_D.Enabled = true;
                col3 -= 1;
            }
            if (!B_E.Enabled)
            {
                B_E.Enabled = true;
                col4 -= 1;
            }
            if (!B_F.Enabled)
            {
                B_F.Enabled = true;
                col5 -= 1;
            }
            if (!B_G.Enabled)
            {
                B_G.Enabled = true;
                col6 -= 1;
            }
            if (!B_H.Enabled)
            {
                B_H.Enabled = true;
                col7 -= 1;
            }
            this.Refresh();
        }

        //Necesario para la conexion en modo host
        #region Cosas de la conexion del host

        
        public delegate void ClientCarrier(ConexionTcpHost conexionTcp);
        public event ClientCarrier OnClientConnected;
        public event ClientCarrier OnClientDisconnected;
        public delegate void DataRecieved(ConexionTcpHost conexionTcp, string data);
        public event DataRecieved OnDataRecieved;
        public ConexionTcpHost conexionTcp;

        private TcpListener _tcpListener;
        private Thread _acceptThread;

        private void F_HostJuego_Load(object sender, EventArgs e)
        {

            OnDataRecieved += MensajeRecibido;
            OnClientConnected += ConexionRecibida;
            OnClientDisconnected += ConexionCerrada;

            EscucharClientes("127.0.0.1", 33456);
        }
        
        private void MensajeRecibido(ConexionTcpHost conexionTcp, string datos)
        {

            if (!Conectado)
            {
                this.conexionTcp=conexionTcp;
                Nombres[1] = datos;
                Conectado = true;
                Invoke(new Action(() => label4.Text = Nombres[1]));
                return;
            }

            var paquete = new Paquete(datos);
            int lugar = Convert.ToInt32(paquete.lugar);

            elegirColumna(lugar, '#');
            
            Invoke(new Action(() => Habilitar()));
        }

        private void ConexionRecibida(ConexionTcpHost conexionTcp)
        {
            //MessageBox.Show("CONEXION INICIADA", "JUEGO INICIADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexionTcp.EnviarPaquete(new Paquete(Nombres[0])) ;
        }

        private void ConexionCerrada(ConexionTcpHost conexionTcp)
        {
            MessageBox.Show("CONEXION TERMINADA, EL JUEGO SE CERRARÁ", "JUEGO TERMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Salir();
        }

        private void EscucharClientes(string ipAddress, int port)
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
                _tcpListener.Start();
                _acceptThread = new Thread(AceptarClientes);
                _acceptThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        private void AceptarClientes()
        {
            do
            {
                try
                {
                    var conexion = _tcpListener.AcceptTcpClient();
                    var srvClient = new ConexionTcpHost(conexion)
                    {
                        ReadThread = new Thread(LeerDatos)
                    };
                    srvClient.ReadThread.Start(srvClient);

                    if (OnClientConnected != null)
                        OnClientConnected(srvClient);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }

            } while (true);
        }
        
        private void LeerDatos(object client)
        {
            var cli = client as ConexionTcpHost;
            var charBuffer = new List<int>();

            do
            {
                try
                {
                    if (cli == null)
                        break;
                    if (cli.StreamReader.EndOfStream)
                        break;
                    int charCode = cli.StreamReader.Read();
                    if (charCode == -1)
                        break;
                    if (charCode != 0)
                    {
                        charBuffer.Add(charCode);
                        continue;
                    }
                    if (OnDataRecieved != null)
                    {
                        var chars = new char[charBuffer.Count];
                        //Convert all the character codes to their representable characters
                        for (int i = 0; i < charBuffer.Count; i++)
                        {
                            chars[i] = Convert.ToChar(charBuffer[i]);
                        }
                        //Convert the character array to a string
                        var message = new string(chars);

                        //Invoke our event
                        OnDataRecieved(cli, message);
                    }
                    charBuffer.Clear();
                }
                catch (IOException)
                {
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());

                    break;
                }
            } while (true);

            if (OnClientDisconnected != null)
                OnClientDisconnected(cli);
        }
        #endregion

    }
}
