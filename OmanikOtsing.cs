using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1;

public partial class OmanikOtsing : Form
{
    public OmanikOtsing()
    {
        _db = new CarsDbContext();
        InitializeComponent();
        ApplyCustomStyling();
        LoadOwners();
    }

    private CarsDbContext _db;
    public Owner SelectedOwner;

    private void LoadOwners()
    {
        var filter = searchTxt.Text ?? "";
        var owners = _db.Owners.Include(i => i.Cars)
            .Where(i => filter == "" || i.FullName.Contains(filter) || i.Phone.Contains(filter))
            .Select(i => new
            {
                Owner = i,
                Id = i.Id,
                FullName = i.FullName,
                Phone = i.Phone,
                Cars = i.Cars.Count == 0 ? "None" : i.Cars.ToCommaSepString(", "),
            }).ToList();

        dataGridView1.DataSource = owners;
        dataGridView1.Columns["Owner"].Visible = false;
        // Reapply styling after DataSource is set
        ApplyDataGridViewStyling();
    }

    private void ApplyDataGridViewStyling()
    {
        Color headerBlue = Color.FromArgb(25, 118, 210);
        dataGridView1.BackgroundColor = Color.White;
        dataGridView1.GridColor = Color.FromArgb(240, 240, 240);
        dataGridView1.BorderStyle = BorderStyle.None;
        dataGridView1.EnableHeadersVisualStyles = false;
        dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = headerBlue;
        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
        dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dataGridView1.DefaultCellStyle.Padding = new Padding(3);
    }

    private void confirmBtn_Click(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow != null)
        {
            SelectedOwner = dataGridView1.CurrentRow.Cells["Owner"].Value as Owner;
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Palun vali omanik.");
        }
    }

    private void searchTxt_TextChanged(object sender, EventArgs e)
    {
        LoadOwners();
    }

    private void ApplyCustomStyling()
    {
        // Same color palette as main form
        Color primaryBlue = Color.FromArgb(70, 130, 180);      // Steel Blue
        Color lightBlue = Color.FromArgb(230, 240, 250);        // Light Blue background
        Color successGreen = Color.FromArgb(76, 175, 80);        // Green for confirm button
        Color headerBlue = Color.FromArgb(25, 118, 210);        // Darker blue for headers
        Color textDark = Color.FromArgb(33, 33, 33);            // Dark gray text

        // Form background
        this.BackColor = lightBlue;

        // Style button
        confirmBtn.BackColor = successGreen;
        confirmBtn.ForeColor = Color.White;
        confirmBtn.FlatStyle = FlatStyle.Flat;
        confirmBtn.FlatAppearance.BorderSize = 0;
        confirmBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(Math.Min(255, successGreen.R + 20),
                                                                      Math.Min(255, successGreen.G + 20),
                                                                      Math.Min(255, successGreen.B + 20));
        confirmBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        confirmBtn.Cursor = Cursors.Hand;

        // Style DataGridView
        dataGridView1.BackgroundColor = Color.White;
        dataGridView1.GridColor = Color.FromArgb(240, 240, 240);
        dataGridView1.BorderStyle = BorderStyle.None;
        dataGridView1.EnableHeadersVisualStyles = false;
        dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = headerBlue;
        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
        dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dataGridView1.DefaultCellStyle.Padding = new Padding(3);

        // Style labels
        label1.ForeColor = textDark;
        label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        label3.ForeColor = textDark;
        label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
    }
}
