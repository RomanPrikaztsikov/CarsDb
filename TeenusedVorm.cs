using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1;

public partial class TeenusedVorm : Form
{
    private readonly CarsDbContext _db;
    private DataGridView teenusteGrid;
    private TextBox otsingTextBox;
    private TextBox nimiTextBox;
    private TextBox hindTextBox;
    private Button lisaNupp;
    private Button uuendaNupp;
    private Button kustutaNupp;
    private Label silt1;
    private Label silt2;
    private Label silt3;

    public TeenusedVorm()
    {
        _db = new CarsDbContext();
        InitializeComponent();
        ApplyCustomStyling();
        LoadServices();
    }

    private void InitializeComponent()
    {
        this.Text = "Teenuste haldamine";
        this.Size = new Size(800, 600);
        this.StartPosition = FormStartPosition.CenterParent;

        silt1 = new Label();
        silt1.Text = "Otsing:";
        silt1.Location = new Point(10, 10);
        silt1.Size = new Size(50, 20);

        otsingTextBox = new TextBox();
        otsingTextBox.Location = new Point(70, 10);
        otsingTextBox.Size = new Size(200, 20);
        otsingTextBox.TextChanged += OtsingTextBox_TextChanged;

        teenusteGrid = new DataGridView();
        teenusteGrid.Location = new Point(10, 40);
        teenusteGrid.Size = new Size(760, 400);
        teenusteGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        teenusteGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        teenusteGrid.MultiSelect = false;
        teenusteGrid.SelectionChanged += TeenusteGrid_SelectionChanged;

        silt2 = new Label();
        silt2.Text = "Nimi:";
        silt2.Location = new Point(10, 450);
        silt2.Size = new Size(50, 20);

        nimiTextBox = new TextBox();
        nimiTextBox.Location = new Point(70, 450);
        nimiTextBox.Size = new Size(200, 20);

        silt3 = new Label();
        silt3.Text = "Hind:";
        silt3.Location = new Point(280, 450);
        silt3.Size = new Size(50, 20);

        hindTextBox = new TextBox();
        hindTextBox.Location = new Point(340, 450);
        hindTextBox.Size = new Size(100, 20);
        hindTextBox.KeyPress += HindTextBox_KeyPress;

        lisaNupp = new Button();
        lisaNupp.Text = "Lisa";
        lisaNupp.Location = new Point(450, 450);
        lisaNupp.Size = new Size(80, 30);
        lisaNupp.Click += LisaNupp_Click;

        uuendaNupp = new Button();
        uuendaNupp.Text = "Uuenda";
        uuendaNupp.Location = new Point(540, 450);
        uuendaNupp.Size = new Size(80, 30);
        uuendaNupp.Click += UuendaNupp_Click;

        kustutaNupp = new Button();
        kustutaNupp.Text = "Kustuta";
        kustutaNupp.Location = new Point(630, 450);
        kustutaNupp.Size = new Size(80, 30);
        kustutaNupp.Click += KustutaNupp_Click;

        this.Controls.Add(silt1);
        this.Controls.Add(otsingTextBox);
        this.Controls.Add(teenusteGrid);
        this.Controls.Add(silt2);
        this.Controls.Add(nimiTextBox);
        this.Controls.Add(silt3);
        this.Controls.Add(hindTextBox);
        this.Controls.Add(lisaNupp);
        this.Controls.Add(uuendaNupp);
        this.Controls.Add(kustutaNupp);
    }

    private void LoadServices()
    {
        var filter = otsingTextBox.Text ?? "";
        
        var koguTeenused = _db.Services
            .Select(s => new
            {
                Id = s.Id,
                Nimi = s.Name,
                Hind = s.Price.ToString("F2") + " €",
                Price = s.Price
            })
            .ToList();

        var teenused = koguTeenused
            .Where(s => filter == "" || 
                s.Nimi.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                s.Price.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                s.Hind.Contains(filter, StringComparison.OrdinalIgnoreCase))
            .Select(s => new
            {
                s.Id,
                s.Nimi,
                s.Hind
            })
            .ToList();

        teenusteGrid.DataSource = teenused;
        StyleDataGridView(teenusteGrid, Color.FromArgb(25, 118, 210));
        
        ClearForm();
    }

    private void OtsingTextBox_TextChanged(object sender, EventArgs e)
    {
        LoadServices();
    }

    private void TeenusteGrid_SelectionChanged(object sender, EventArgs e)
    {
        if (teenusteGrid.SelectedRows.Count == 0)
        {
            ClearForm();
            return;
        }

        var valitudRida = teenusteGrid.SelectedRows[0];
        var teenuseId = (int)valitudRida.Cells["Id"].Value;

        var teenus = _db.Services.FirstOrDefault(s => s.Id == teenuseId);
        if (teenus != null)
        {
            nimiTextBox.Text = teenus.Name;
            hindTextBox.Text = teenus.Price.ToString("F2");
        }
    }

    private void LisaNupp_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nimiTextBox.Text))
        {
            MessageBox.Show("Palun sisesta teenuse nimi!");
            return;
        }

        if (string.IsNullOrWhiteSpace(hindTextBox.Text) || !float.TryParse(hindTextBox.Text, out float hind))
        {
            MessageBox.Show("Palun sisesta õige hind!");
            return;
        }

        var teenus = new Service
        {
            Name = nimiTextBox.Text.Trim(),
            Price = hind
        };

        _db.Services.Add(teenus);
        _db.SaveChanges();

        LoadServices();
        MessageBox.Show("Teenus lisatud!");
    }

    private void UuendaNupp_Click(object sender, EventArgs e)
    {
        if (teenusteGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad uuendada!");
            return;
        }

        if (string.IsNullOrWhiteSpace(nimiTextBox.Text))
        {
            MessageBox.Show("Palun sisesta teenuse nimi!");
            return;
        }

        if (string.IsNullOrWhiteSpace(hindTextBox.Text) || !float.TryParse(hindTextBox.Text, out float hind))
        {
            MessageBox.Show("Palun sisesta õige hind!");
            return;
        }

        var valitudRida = teenusteGrid.SelectedRows[0];
        var teenuseId = (int)valitudRida.Cells["Id"].Value;

        var teenus = _db.Services.FirstOrDefault(s => s.Id == teenuseId);
        if (teenus == null)
        {
            MessageBox.Show("Teenust ei leitud!");
            return;
        }

        teenus.Name = nimiTextBox.Text.Trim();
        teenus.Price = hind;

        _db.SaveChanges();
        LoadServices();
        MessageBox.Show("Teenus uuendatud!");
    }

    private void KustutaNupp_Click(object sender, EventArgs e)
    {
        if (teenusteGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad kustutada!");
            return;
        }

        var valitudRida = teenusteGrid.SelectedRows[0];
        var teenuseId = (int)valitudRida.Cells["Id"].Value;

        var teenus = _db.Services
            .Include(s => s.CarServices)
            .FirstOrDefault(s => s.Id == teenuseId);

        if (teenus == null)
        {
            MessageBox.Show("Teenust ei leitud!");
            return;
        }

        if (teenus.CarServices != null && teenus.CarServices.Any())
        {
            MessageBox.Show("Seda teenust ei saa kustutada, kuna see on kasutusel hoolduskirjetes!");
            return;
        }

        var tulemus = MessageBox.Show(
            "Kas oled kindel, et tahad selle teenuse kustutada?",
            "Kinnita kustutamine",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tulemus == DialogResult.Yes)
        {
            _db.Services.Remove(teenus);
            _db.SaveChanges();
            LoadServices();
            MessageBox.Show("Teenus kustutatud!");
        }
    }

    private void HindTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var tekstKast = sender as TextBox;
        if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || 
            (e.KeyChar == '.' || e.KeyChar == ',') && !tekstKast.Text.Contains('.') && !tekstKast.Text.Contains(','))
            return;

        e.Handled = true;
    }

    private void ClearForm()
    {
        nimiTextBox.Text = "";
        hindTextBox.Text = "";
    }

    private void ApplyCustomStyling()
    {
        Color primaryBlue = Color.FromArgb(70, 130, 180);
        Color lightBlue = Color.FromArgb(230, 240, 250);
        Color successGreen = Color.FromArgb(76, 175, 80);
        Color warningOrange = Color.FromArgb(255, 152, 0);
        Color dangerRed = Color.FromArgb(244, 67, 54);
        Color headerBlue = Color.FromArgb(25, 118, 210);
        Color textDark = Color.FromArgb(33, 33, 33);

        this.BackColor = lightBlue;

        StyleButton(lisaNupp, successGreen, Color.White);
        StyleButton(uuendaNupp, warningOrange, Color.White);
        StyleButton(kustutaNupp, dangerRed, Color.White);

        StyleDataGridView(teenusteGrid, headerBlue);

        silt1.ForeColor = textDark;
        silt1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        silt2.ForeColor = textDark;
        silt2.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        silt3.ForeColor = textDark;
        silt3.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
    }

    private void StyleButton(Button nupp, Color tagavarv, Color esivarv)
    {
        nupp.BackColor = tagavarv;
        nupp.ForeColor = esivarv;
        nupp.FlatStyle = FlatStyle.Flat;
        nupp.FlatAppearance.BorderSize = 0;
        nupp.FlatAppearance.MouseOverBackColor = Color.FromArgb(Math.Min(255, tagavarv.R + 20),
                                                               Math.Min(255, tagavarv.G + 20),
                                                               Math.Min(255, tagavarv.B + 20));
        nupp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        nupp.Cursor = Cursors.Hand;
    }

    private void StyleDataGridView(DataGridView grid, Color pealiseVarv)
    {
        grid.BackgroundColor = Color.White;
        grid.GridColor = Color.FromArgb(240, 240, 240);
        grid.BorderStyle = BorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = pealiseVarv;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        grid.RowsDefaultCellStyle.BackColor = Color.White;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
        grid.DefaultCellStyle.SelectionForeColor = Color.White;
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        grid.DefaultCellStyle.Padding = new Padding(3);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _db.Dispose();
        base.OnFormClosing(e);
    }
}

