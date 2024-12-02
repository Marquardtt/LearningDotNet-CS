using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TelaInicial(object sender, EventArgs e)
        {
            double cliques = 0;
            double pesoClique = 1;
            double preco = 10;

            Panel centro = new Panel();
            Panel botoesCompra = new Panel();
            this.Controls.Add(centro);
            this.Controls.Add(botoesCompra);

            centro.BackColor = Color.Black;
            centro.Dock = DockStyle.Fill;

            botoesCompra.BackColor = Color.Black;
            botoesCompra.Dock = DockStyle.Bottom;
            botoesCompra.Height = 100;

            Label label = new Label();
            label.ForeColor = Color.White;
            label.Text = cliques.ToString();
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point((centro.ClientSize.Width - label.Width) / 2, (centro.ClientSize.Height - label.Height) / 4);
            centro.Controls.Add(label);

            Button button = new Button();
            button.Text = "Clique em mim!";
            button.Size = new Size(100, 50);
            button.BackColor = Color.White;
            button.Anchor = AnchorStyles.None;
            button.Location = new Point((centro.ClientSize.Width - button.Width) / 2, (centro.ClientSize.Height - button.Height) / 2);
            button.Click += new EventHandler((object s, EventArgs et) =>
            {
                cliques += pesoClique;
                label.Text = cliques.ToString();
            });
            centro.Controls.Add(button);

            Button buttonComprarMelhoria = new Button();
            buttonComprarMelhoria.Text = "Melhorar clique" + preco;
            buttonComprarMelhoria.Size = new Size(100, 50);
            buttonComprarMelhoria.BackColor = Color.White;
            buttonComprarMelhoria.Anchor = AnchorStyles.None;
            buttonComprarMelhoria.Location = new Point(50, 30);
            botoesCompra.Controls.Add(buttonComprarMelhoria);
            buttonComprarMelhoria.Click += new EventHandler((object s, EventArgs et) =>
            {
                if (cliques >= preco)
                {
                    cliques -= preco;
                    pesoClique += 1;
                    label.Text = cliques.ToString();
                }
                else
                {
                    MessageBox.Show("Você não tem dinheiro pra fazer isso..");
                }
            });

            centro.Resize += (sen, eve) =>
            {
                button.Location = new Point((centro.ClientSize.Width - button.Width) / 2, (centro.ClientSize.Height - button.Height) / 2);
                label.Location = new Point((centro.ClientSize.Width - label.Width) / 2, (centro.ClientSize.Height - label.Height) / 4);
            };
        }
    }
}
