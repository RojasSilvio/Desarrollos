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
    public partial class F_Principal : Form
    {
        string nombre;
        Jugador j = new Jugador();
        F_IAJuego f1 = new F_IAJuego();
        F_HostJuego f2 = new F_HostJuego();
        F_ClienteJuego f3 = new F_ClienteJuego();

        public F_Principal()
        {
            InitializeComponent();
        }

        private void B_COMENZAR_Click(object sender, EventArgs e)
        {
            nombre = TB_Nombre.Text;
            if (nombre != (""))
            {
                if (C_Modo.Text == "MODO I.A")
                {
                    
                    Bienvenida();
                    j.Nombre = nombre;
                    f1.Nombre(j.Nombre);
                    //f2.j.Nombre = nombre;
                    this.Hide();
                    this.Dispose();
                    f1.Show();
                    f1.ContFichas(56);


                }
                else if (C_Modo.Text == "MODO HOST")
                {
                    Bienvenida();
                    j.Nombre = nombre;
                    f2.Nombre(j.Nombre);
                    this.Hide();
                    this.Dispose();
                    f2.Show();
                    f2.ContFichas(56);

                }
                else if (C_Modo.Text == "MODO CLIENTE")
                {
                    Bienvenida();
                    j.Nombre = nombre;
                    f3.Nombre(j.Nombre);
                    this.Hide();
                    this.Dispose();
                    f3.Show();
                    f3.ContFichas(56);

                }
                else MessageBox.Show("SELECCIONE UN MODO PARA CONTINUAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else MessageBox.Show("INGRESE UN NOMBRE PARA CONTINUAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Bienvenida()
        {
            MessageBox.Show("JUGADOR " + nombre + " ACEPTE PARA EMPEZAR A JUGAR", "BIENVENIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void F_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
