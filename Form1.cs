using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio5
{
    public partial class Form1 : Form
    {
        List<empleado> empleados = new List<empleado>();
        List<asistencia> asistencias = new List<asistencia>();
        List<sueldo> sueld = new List<sueldo>(); 

        public Form1()
        {
            InitializeComponent();
        }
        private void loadEmpleado()
        {
            FileStream stream = new FileStream("persona.txt.txt",FileMode.Open,FileAccess.Read);
            StreamReader reader = new StreamReader(stream); 

            while (reader.Peek() > -1)
            {
                empleado empleado = new empleado();
                empleado.numerodepersona = Convert.ToInt16(reader.ReadLine());
                empleado.nombredepersona = reader.ReadLine();
                empleado.sueldoporhora = Convert.ToDecimal(reader.ReadLine());

                empleados.Add(empleado);
                //listBox1.Items.Add(empleado.nombredepersona);
                //comboBox1.Items.Add(empleado.nombredepersona); 
            }
            reader.Close(); 
        }
        private void LoadAsistencia()
        {
            FileStream stream = new FileStream("tiempo.txt.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                asistencia asistencia = new asistencia();
                asistencia.numdeempleado = Convert.ToInt16(reader.ReadLine());
                asistencia.horadelmes = Convert.ToInt16(reader.ReadLine());
                asistencia.mes = reader.ReadLine();

                asistencias.Add(asistencia);
                 
            }
            reader.Close();
        }
        void LoadGrids()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = empleados;

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = asistencias;

            dataGridView3.DataSource = sueld; 
            dataGridView3.Refresh();
        }
        void calcularsueldo()
        {
            for ( int i = 0; i < empleados.Count; i++)
            {
                for (int j = 0; j < asistencias.Count; j++)
                {
                    if (empleados[i].numerodepersona == asistencias[j].numdeempleado)
                    {
                        sueldo sueldos = new sueldo();
                        sueldos.numerodepersona = empleados[i].numerodepersona;
                        sueldos.nombredepersona = empleados[i].nombredepersona;
                        sueldos.sueldopormes = empleados[i].sueldoporhora * asistencias[i].horadelmes;

                        sueld.Add (sueldos);
                        listBox1.Items.Add(sueldos.numerodepersona + "\t" + sueldos.nombredepersona);
                    } 
                }
            } 
        }
        void mostrardatos()
        {
            //if (listBox1.SelectedItem != null)
            //{
            //  MessageBox.Show(listBox1.SelectedItem.ToString()); 
            //}
            //empleado  sal = empleados.FindIndex(c => c.numerodepersona == );
            //MessageBox.Show(sal.nombredepersona); no me queda muy claro como buscar lso datos 
        }
        private void Mostrar_Click(object sender, EventArgs e)
        {
            LoadAsistencia();
            loadEmpleado();
            calcularsueldo(); 
            LoadGrids(); 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrardatos(); 
        }
    }
}
