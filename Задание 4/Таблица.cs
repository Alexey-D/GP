using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_4
{
    public partial class Таблица : Form
    {
        public Таблица()
        {
            InitializeComponent();
            T_D.Checked = true;
            Year.Enabled = false;
            Table.Rows.Add("Самолёт", "Аэродинамика", "Воздушное судно, предназначенное для полётов в атмосфере", "17.12.1903");
            Table.Rows.Add("Пеннициллин", "Фармакология", "Препараты, применяемые для лечения бактериальных инфекций", "1928");
            Table.Rows.Add("Транзистор", "Радиоэлектроника", "Радиоэлектронный компонент из полупроводникового материала, способный от небольшого входного сигнала управлять значительным током в выходной цепи", "1938");
            Table.Rows.Add("Интернет", "Информатика", "Всемирная система объединённых компьютерных сетей для хранения и передачи информации", "29.10.1969");
        }
        public void T_D_Click(object sender, System.EventArgs e)
        {
            Date.Enabled = true;
            Year.Enabled = false;
        }
        public void T_Y_Click(object sender, System.EventArgs e)
        {
            Date.Enabled = false;
            Year.Enabled = true;
        }
        public void Add_Click(object sender, System.EventArgs e)
        {
            int year;
            if (Title.Text != "" && Section.Text != "" && Description.Text != "" && (Date.MaskCompleted == true || Year.Text != ""))
            {
                if (Date.Enabled == true)
                    year = Int32.Parse(Date.Text.Substring(Date.Text.Length - 4));
                else
                    year = Int32.Parse(Year.Text);
                if (year < 1900 || year > 1999)
                {
                    MessageBox.Show("Неверная дата");
                    return;
                }
                Table.Rows.Add(Title.Text, Section.Text, Description.Text);
                if (Date.Enabled == true)
                    Table.Rows[Table.Rows.Count - 1].Cells[3].Value = Date.Text;
                else
                    Table.Rows[Table.Rows.Count - 1].Cells[3].Value = Year.Text;
                Title.Text = "";
                Section.Text = "";
                Description.Text = "";
                Date.Text = "";
                Year.Text = "";
            }
            else
                MessageBox.Show("Введиете все данные");
        }
        public void Filter_Click(object sender, System.EventArgs e)
        {
            Group.Visible = true;
            Ok.Visible = true;
            Q1.Checked = true;
        }
        public void Ok_Click(object sender, System.EventArgs e)
        {
            Отфильрованная_таблица f = new Отфильрованная_таблица();
            int year;
            string sub;
            if (Q1.Checked == true)
            {
                f.Show();
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    sub = (string)Table.Rows[i].Cells[3].Value;
                    sub = sub.Substring(sub.Length - 2);
                    year = Int32.Parse(sub);
                    if (year <= 25)
                        f.Filtered.Rows.Add(Table.Rows[i].Cells[0].Value, Table.Rows[i].Cells[1].Value, Table.Rows[i].Cells[2].Value, Table.Rows[i].Cells[3].Value);
                }
            }
            else if (Q2.Checked == true)
            {
                f.Show();
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    sub = (string)Table.Rows[i].Cells[3].Value;
                    sub = sub.Substring(sub.Length - 2);
                    year = Int32.Parse(sub);
                    if (year <= 50 && year > 25)
                        f.Filtered.Rows.Add(Table.Rows[i].Cells[0].Value, Table.Rows[i].Cells[1].Value, Table.Rows[i].Cells[2].Value, Table.Rows[i].Cells[3].Value);
                }
            }
            else if (Q3.Checked == true)
            {
                f.Show();
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    sub = (string)Table.Rows[i].Cells[3].Value;
                    sub = sub.Substring(sub.Length - 2);
                    year = Int32.Parse(sub);
                    if (year <= 75 && year > 50)
                        f.Filtered.Rows.Add(Table.Rows[i].Cells[0].Value, Table.Rows[i].Cells[1].Value, Table.Rows[i].Cells[2].Value, Table.Rows[i].Cells[3].Value);
                }
            }
            else
            {
                f.Show();
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    sub = (string)Table.Rows[i].Cells[3].Value;
                    sub = sub.Substring(sub.Length - 2);
                    year = Int32.Parse(sub);
                    if (year > 75)
                        f.Filtered.Rows.Add(Table.Rows[i].Cells[0].Value, Table.Rows[i].Cells[1].Value, Table.Rows[i].Cells[2].Value, Table.Rows[i].Cells[3].Value);
                }
            }    
        }
    }
    
}
