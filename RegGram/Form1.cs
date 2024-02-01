using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegGram
{
    public partial class Form1 : Form
    {
        private string input;
        private int state;
        public Form1()
        {
            InitializeComponent();
            richTextBox2.Text += "Исходная грамматика: \r\n";
            richTextBox2.Text += "S -> A⊥ \r\n";
            richTextBox2.Text += "A -> Ab | Bb | b \r\n";
            richTextBox2.Text += "B -> Aa";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Analyze()
        {
            state = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch (state)
                {
                    case 0:
                        if (input[i] == 'b')
                        {
                            state = 1;
                        }
                        else
                        {
                            state = 1000;
                            return;
                        }
                        break;

                    case 1:
                        if (input[i] == 'a')
                        {
                            state = 2;
                        }
                        else if (input[i] == 'b')
                        {
                            state = 1;
                        }
                        else if (input[i] == '⊥' && i == input.Length - 1)
                        {
                            state = 4;
                        }
                        else
                        {
                            state = 1000;
                            return;
                        }
                        break;

                    case 2:
                        if (input[i] == 'b')
                        {
                            state = 1;
                        }
                        else if (input[i] == 'a')
                        {
                            state = 2;
                        }
                        else
                        {
                            state = 1000;
                        }
                        break;
                    default:
                        state = 1000;
                        return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            input = textBox1.Text;
            if(input != "" && input != " ")
            {
                Analyze();
                richTextBox1.Text += "Цепочка " + input;
                if (state == 4)
                {
                    richTextBox1.Text += " принадлежит грамматике.\r\n";
                }
                else
                {
                    richTextBox1.Text += " не принадлежит грамматике.\r\n";
                }
            }
            else
            {
                Info(3);
            }
        }
        private void Info(int choose)
        {
            switch (choose)
            {
                case 1:
                    {
                        MessageBox.Show(
                            "1.Вводите цепочку языка.\r\n" +
                            "2.Нажимаете кнопку 'Старт'.\r\n" +
                            "3.Для повторного использования, повторите пункт 1.\r\n",
                            "Помощь.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show(
                            "Колач Андрей 3221",
                            "Автор",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show(
                            "Пустая цепочка не предусмотрена для данной грамматики.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show(
                            "Скопируйте символ для быстрого использования.",
                            "Спец. символ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Info(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Info(4);
        }
    }
}
