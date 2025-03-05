using System;

namespace PracticeWork2
{
    public partial class MainForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        private TabControl tabControl;
        private TabPage tabPhotos;
        private TabPage tabAlbums;
        private FlowLayoutPanel flowLayoutPanel;
        private Button btnOrder;
        private Button btnCancel;
        private Button btnExit;
        private NumericUpDown numQty9x12;
        private NumericUpDown numQty12x15;
        private NumericUpDown numQty18x24;
        private NumericUpDown numQtyAlbum;
        private TextBox txtPrice9x12;
        private TextBox txtPrice12x15;
        private TextBox txtPrice18x24;
        private TextBox txtPriceAlbum;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tabControl = new TabControl();
            this.tabPhotos = new TabPage("Фотографії");
            this.tabAlbums = new TabPage("Альбоми");
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.btnOrder = new Button();
            this.btnCancel = new Button();
            this.btnExit = new Button();

            this.numQty9x12 = new NumericUpDown();
            this.numQty12x15 = new NumericUpDown();
            this.numQty18x24 = new NumericUpDown();
            this.numQtyAlbum = new NumericUpDown();

            this.txtPrice9x12 = new TextBox();
            this.txtPrice12x15 = new TextBox();
            this.txtPrice18x24 = new TextBox();
            this.txtPriceAlbum = new TextBox();

            this.SuspendLayout();

            this.tabControl.Controls.Add(this.tabPhotos);
            this.tabControl.Controls.Add(this.tabAlbums);
            this.tabControl.Dock = DockStyle.Top;
            this.tabControl.Height = 200;

            this.tabPhotos.Controls.Add(new Label { Text = "9x12", Left = 10, Top = 10 });
            this.numQty9x12.SetBounds(60, 10, 50, 20);
            this.tabPhotos.Controls.Add(this.numQty9x12);
            this.txtPrice9x12.SetBounds(120, 10, 50, 20);
            this.tabPhotos.Controls.Add(this.txtPrice9x12);

            this.tabPhotos.Controls.Add(new Label { Text = "12x15", Left = 10, Top = 40 });
            this.numQty12x15.SetBounds(60, 40, 50, 20);
            this.tabPhotos.Controls.Add(this.numQty12x15);
            this.txtPrice12x15.SetBounds(120, 40, 50, 20);
            this.tabPhotos.Controls.Add(this.txtPrice12x15);

            this.tabPhotos.Controls.Add(new Label { Text = "18x24", Left = 10, Top = 70 });
            this.numQty18x24.SetBounds(60, 70, 50, 20);
            this.tabPhotos.Controls.Add(this.numQty18x24);
            this.txtPrice18x24.SetBounds(120, 70, 50, 20);
            this.tabPhotos.Controls.Add(this.txtPrice18x24);

            this.tabAlbums.Controls.Add(new Label { Text = "Альбом", Left = 10, Top = 10 });
            this.numQtyAlbum.SetBounds(60, 10, 50, 20);
            this.tabAlbums.Controls.Add(this.numQtyAlbum);
            this.txtPriceAlbum.SetBounds(120, 10, 50, 20);
            this.tabAlbums.Controls.Add(this.txtPriceAlbum);

            this.flowLayoutPanel.Dock = DockStyle.Bottom;
            this.flowLayoutPanel.Height = 50;

            this.btnOrder.Text = "Замовити";
            this.btnOrder.Click += new EventHandler(this.btnOrder_Click);
            this.flowLayoutPanel.Controls.Add(this.btnOrder);

            this.btnCancel.Text = "Відмінити";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.flowLayoutPanel.Controls.Add(this.btnCancel);

            this.btnExit.Text = "Вихід";
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.flowLayoutPanel.Controls.Add(this.btnExit);

            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel);
            this.Text = "Розрахунок вартості замовлення";
            this.ClientSize = new System.Drawing.Size(300, 250);

            this.ResumeLayout(false);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            decimal totalCost = CalculateTotalCost();
            if (totalCost > 200)
            {
                totalCost *= 0.9m;
            }
            MessageBox.Show($"Загальна вартість замовлення: {totalCost:F2} грн", "Розрахунок вартості", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private decimal CalculateTotalCost()
        {
            decimal cost = 0;

            cost += numQty9x12.Value * GetPrice(txtPrice9x12);
            cost += numQty12x15.Value * GetPrice(txtPrice12x15);
            cost += numQty18x24.Value * GetPrice(txtPrice18x24);
            cost += numQtyAlbum.Value * GetPrice(txtPriceAlbum);

            return cost;
        }

        private decimal GetPrice(TextBox textBox)
        {
            if (decimal.TryParse(textBox.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price))
            {
                return price;
            }
            return 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            numQty9x12.Value = 0;
            numQty12x15.Value = 0;
            numQty18x24.Value = 0;
            numQtyAlbum.Value = 0;

            txtPrice9x12.Text = "";
            txtPrice12x15.Text = "";
            txtPrice18x24.Text = "";
            txtPriceAlbum.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}