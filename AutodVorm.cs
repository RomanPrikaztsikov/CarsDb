using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1;

public partial class AutodVorm : Form
{
    private readonly CarsDbContext _db;

    public AutodVorm()
    {
        /*
        using (var db = new CarsDbContext())
        {
            db.Database.Migrate();
        }
        */

        string lang = CarsDb.Properties.Settings.Default.Language;
        if (string.IsNullOrEmpty(lang)) lang = "et";
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

        InitializeComponent();

        // Apply custom styling after InitializeComponent
        // This ensures styling persists even after designer changes
        ApplyCustomStyling();

        _db = new();
        using (var db = new CarsDbContext())
        {
            db.EnsureCreated();
        }

        LoadOwners();
    }

    public void InitializeComponent()
    {
        components = new Container();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(AutodVorm));
        tabControl1 = new TabControl();
        ownersPage = new TabPage();
        language_estonianBtn = new Button();
        language_englishBtn = new Button();
        label3 = new Label();
        owners_searchTxt = new TextBox();
        owner_deleteBtn = new Button();
        owner_updateBtn = new Button();
        owner_lisaBtn = new Button();
        label2 = new Label();
        owner_phone = new TextBox();
        label1 = new Label();
        owner_fullName = new TextBox();
        ownersDataGridView = new DataGridView();
        carsPage = new TabPage();
        carsDataGridView = new DataGridView();
        cars_ownerSearchBtn = new Button();
        imgList = new ImageList(components);
        cars_updateBtn = new Button();
        car_deleteBtn = new Button();
        car_addBtn = new Button();
        cars_owner = new ComboBox();
        label8 = new Label();
        label7 = new Label();
        car_model = new Label();
        label5 = new Label();
        cars_regNumber = new TextBox();
        cars_model = new TextBox();
        cars_brand = new TextBox();
        servicesPage = new TabPage();
        teenused_carSearchBtn = new Button();
        label12 = new Label();
        textBox1 = new TextBox();
        service_deleteBtn = new Button();
        service_insertBtn = new Button();
        service_updateBtn = new Button();
        service_manageBtn = new Button();
        service_dataGrid = new DataGridView();
        service_serviceComboBox = new ComboBox();
        service_carComboBox = new ComboBox();
        label11 = new Label();
        service_mileage = new TextBox();
        label10 = new Label();
        service_date = new DateTimePicker();
        label9 = new Label();
        label6 = new Label();
        tabControl1.SuspendLayout();
        ownersPage.SuspendLayout();
        ((ISupportInitialize)ownersDataGridView).BeginInit();
        carsPage.SuspendLayout();
        ((ISupportInitialize)carsDataGridView).BeginInit();
        servicesPage.SuspendLayout();
        ((ISupportInitialize)service_dataGrid).BeginInit();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(ownersPage);
        tabControl1.Controls.Add(carsPage);
        tabControl1.Controls.Add(servicesPage);
        resources.ApplyResources(tabControl1, "tabControl1");
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        // 
        // ownersPage
        // 
        ownersPage.Controls.Add(language_estonianBtn);
        ownersPage.Controls.Add(language_englishBtn);
        ownersPage.Controls.Add(label3);
        ownersPage.Controls.Add(owners_searchTxt);
        ownersPage.Controls.Add(owner_deleteBtn);
        ownersPage.Controls.Add(owner_updateBtn);
        ownersPage.Controls.Add(owner_lisaBtn);
        ownersPage.Controls.Add(label2);
        ownersPage.Controls.Add(owner_phone);
        ownersPage.Controls.Add(label1);
        ownersPage.Controls.Add(owner_fullName);
        ownersPage.Controls.Add(ownersDataGridView);
        resources.ApplyResources(ownersPage, "ownersPage");
        ownersPage.Name = "ownersPage";
        ownersPage.UseVisualStyleBackColor = true;
        // 
        // language_estonianBtn
        // 
        resources.ApplyResources(language_estonianBtn, "language_estonianBtn");
        language_estonianBtn.Name = "language_estonianBtn";
        language_estonianBtn.UseVisualStyleBackColor = true;
        language_estonianBtn.Click += language_estonianBtn_Click;
        // 
        // language_englishBtn
        // 
        resources.ApplyResources(language_englishBtn, "language_englishBtn");
        language_englishBtn.Name = "language_englishBtn";
        language_englishBtn.UseVisualStyleBackColor = true;
        language_englishBtn.Click += language_englishBtn_Click;
        // 
        // label3
        // 
        resources.ApplyResources(label3, "label3");
        label3.Name = "label3";
        // 
        // owners_searchTxt
        // 
        resources.ApplyResources(owners_searchTxt, "owners_searchTxt");
        owners_searchTxt.Name = "owners_searchTxt";
        owners_searchTxt.TextChanged += cars_searchTxt_TextChanged;
        // 
        // owner_deleteBtn
        // 
        resources.ApplyResources(owner_deleteBtn, "owner_deleteBtn");
        owner_deleteBtn.Name = "owner_deleteBtn";
        owner_deleteBtn.UseVisualStyleBackColor = true;
        owner_deleteBtn.Click += owner_deleteBtn_Click;
        // 
        // owner_updateBtn
        // 
        resources.ApplyResources(owner_updateBtn, "owner_updateBtn");
        owner_updateBtn.Name = "owner_updateBtn";
        owner_updateBtn.UseVisualStyleBackColor = true;
        owner_updateBtn.Click += owner_updateBtn_Click;
        // 
        // owner_lisaBtn
        // 
        resources.ApplyResources(owner_lisaBtn, "owner_lisaBtn");
        owner_lisaBtn.Name = "owner_lisaBtn";
        owner_lisaBtn.UseVisualStyleBackColor = true;
        owner_lisaBtn.Click += owner_lisaBtn_Click;
        // 
        // label2
        // 
        resources.ApplyResources(label2, "label2");
        label2.Name = "label2";
        // 
        // owner_phone
        // 
        resources.ApplyResources(owner_phone, "owner_phone");
        owner_phone.Name = "owner_phone";
        // 
        // label1
        // 
        resources.ApplyResources(label1, "label1");
        label1.Name = "label1";
        // 
        // owner_fullName
        // 
        resources.ApplyResources(owner_fullName, "owner_fullName");
        owner_fullName.Name = "owner_fullName";
        // 
        // ownersDataGridView
        // 
        ownersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        resources.ApplyResources(ownersDataGridView, "ownersDataGridView");
        ownersDataGridView.Name = "ownersDataGridView";
        ownersDataGridView.SelectionChanged += ownersDataGridView_SelectionChanged;
        // 
        // carsPage
        // 
        carsPage.Controls.Add(carsDataGridView);
        carsPage.Controls.Add(cars_ownerSearchBtn);
        carsPage.Controls.Add(cars_updateBtn);
        carsPage.Controls.Add(car_deleteBtn);
        carsPage.Controls.Add(car_addBtn);
        carsPage.Controls.Add(cars_owner);
        carsPage.Controls.Add(label8);
        carsPage.Controls.Add(label7);
        carsPage.Controls.Add(car_model);
        carsPage.Controls.Add(label5);
        carsPage.Controls.Add(cars_regNumber);
        carsPage.Controls.Add(cars_model);
        carsPage.Controls.Add(cars_brand);
        resources.ApplyResources(carsPage, "carsPage");
        carsPage.Name = "carsPage";
        carsPage.UseVisualStyleBackColor = true;
        // 
        // carsDataGridView
        // 
        carsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        resources.ApplyResources(carsDataGridView, "carsDataGridView");
        carsDataGridView.Name = "carsDataGridView";
        carsDataGridView.SelectionChanged += carsDataGridView_SelectionChanged;
        // 
        // cars_ownerSearchBtn
        // 
        resources.ApplyResources(cars_ownerSearchBtn, "cars_ownerSearchBtn");
        cars_ownerSearchBtn.ImageList = imgList;
        cars_ownerSearchBtn.Name = "cars_ownerSearchBtn";
        cars_ownerSearchBtn.UseVisualStyleBackColor = true;
        cars_ownerSearchBtn.Click += cars_ownerSearchBtn_Click;
        // 
        // imgList
        // 
        imgList.ColorDepth = ColorDepth.Depth32Bit;
        imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
        imgList.TransparentColor = Color.Transparent;
        imgList.Images.SetKeyName(0, "search");
        // 
        // cars_updateBtn
        // 
        resources.ApplyResources(cars_updateBtn, "cars_updateBtn");
        cars_updateBtn.Name = "cars_updateBtn";
        cars_updateBtn.UseVisualStyleBackColor = true;
        cars_updateBtn.Click += cars_updateBtn_Click;
        // 
        // car_deleteBtn
        // 
        resources.ApplyResources(car_deleteBtn, "car_deleteBtn");
        car_deleteBtn.Name = "car_deleteBtn";
        car_deleteBtn.UseVisualStyleBackColor = true;
        car_deleteBtn.Click += car_deleteBtn_Click_1;
        // 
        // car_addBtn
        // 
        resources.ApplyResources(car_addBtn, "car_addBtn");
        car_addBtn.Name = "car_addBtn";
        car_addBtn.UseVisualStyleBackColor = true;
        car_addBtn.Click += car_addBtn_Click;
        // 
        // cars_owner
        // 
        resources.ApplyResources(cars_owner, "cars_owner");
        cars_owner.FormattingEnabled = true;
        cars_owner.Name = "cars_owner";
        // 
        // label8
        // 
        resources.ApplyResources(label8, "label8");
        label8.Name = "label8";
        // 
        // label7
        // 
        resources.ApplyResources(label7, "label7");
        label7.Name = "label7";
        // 
        // car_model
        // 
        resources.ApplyResources(car_model, "car_model");
        car_model.Name = "car_model";
        // 
        // label5
        // 
        resources.ApplyResources(label5, "label5");
        label5.Name = "label5";
        // 
        // cars_regNumber
        // 
        resources.ApplyResources(cars_regNumber, "cars_regNumber");
        cars_regNumber.Name = "cars_regNumber";
        // 
        // cars_model
        // 
        resources.ApplyResources(cars_model, "cars_model");
        cars_model.Name = "cars_model";
        // 
        // cars_brand
        // 
        resources.ApplyResources(cars_brand, "cars_brand");
        cars_brand.Name = "cars_brand";
        // 
        // servicesPage
        // 
        servicesPage.Controls.Add(teenused_carSearchBtn);
        servicesPage.Controls.Add(label12);
        servicesPage.Controls.Add(textBox1);
        servicesPage.Controls.Add(service_deleteBtn);
        servicesPage.Controls.Add(service_insertBtn);
        servicesPage.Controls.Add(service_updateBtn);
        servicesPage.Controls.Add(service_manageBtn);
        servicesPage.Controls.Add(service_dataGrid);
        servicesPage.Controls.Add(service_serviceComboBox);
        servicesPage.Controls.Add(service_carComboBox);
        servicesPage.Controls.Add(label11);
        servicesPage.Controls.Add(service_mileage);
        servicesPage.Controls.Add(label10);
        servicesPage.Controls.Add(service_date);
        servicesPage.Controls.Add(label9);
        servicesPage.Controls.Add(label6);
        resources.ApplyResources(servicesPage, "servicesPage");
        servicesPage.Name = "servicesPage";
        servicesPage.UseVisualStyleBackColor = true;
        // 
        // teenused_carSearchBtn
        // 
        resources.ApplyResources(teenused_carSearchBtn, "teenused_carSearchBtn");
        teenused_carSearchBtn.ImageList = imgList;
        teenused_carSearchBtn.Name = "teenused_carSearchBtn";
        teenused_carSearchBtn.UseVisualStyleBackColor = true;
        teenused_carSearchBtn.Click += teenused_carSearchBtn_Click;
        // 
        // label12
        // 
        resources.ApplyResources(label12, "label12");
        label12.Name = "label12";
        // 
        // textBox1
        // 
        resources.ApplyResources(textBox1, "textBox1");
        textBox1.Name = "textBox1";
        textBox1.TextChanged += service_searchTxt_TextChanged;
        // 
        // service_deleteBtn
        // 
        resources.ApplyResources(service_deleteBtn, "service_deleteBtn");
        service_deleteBtn.Name = "service_deleteBtn";
        service_deleteBtn.UseVisualStyleBackColor = true;
        service_deleteBtn.Click += service_deleteBtn_Click;
        // 
        // service_insertBtn
        // 
        resources.ApplyResources(service_insertBtn, "service_insertBtn");
        service_insertBtn.Name = "service_insertBtn";
        service_insertBtn.UseVisualStyleBackColor = true;
        service_insertBtn.Click += service_insertBtn_Click;
        // 
        // service_updateBtn
        // 
        resources.ApplyResources(service_updateBtn, "service_updateBtn");
        service_updateBtn.Name = "service_updateBtn";
        service_updateBtn.UseVisualStyleBackColor = true;
        service_updateBtn.Click += service_updateBtn_Click;
        // 
        // service_manageBtn
        // 
        resources.ApplyResources(service_manageBtn, "service_manageBtn");
        service_manageBtn.Name = "service_manageBtn";
        service_manageBtn.UseVisualStyleBackColor = true;
        service_manageBtn.Click += service_manageBtn_Click;
        // 
        // service_dataGrid
        // 
        service_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        resources.ApplyResources(service_dataGrid, "service_dataGrid");
        service_dataGrid.Name = "service_dataGrid";
        service_dataGrid.SelectionChanged += service_dataGrid_SelectionChanged;
        // 
        // service_serviceComboBox
        // 
        service_serviceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        resources.ApplyResources(service_serviceComboBox, "service_serviceComboBox");
        service_serviceComboBox.FormattingEnabled = true;
        service_serviceComboBox.Name = "service_serviceComboBox";
        // 
        // service_carComboBox
        // 
        resources.ApplyResources(service_carComboBox, "service_carComboBox");
        service_carComboBox.FormattingEnabled = true;
        service_carComboBox.Name = "service_carComboBox";
        // 
        // label11
        // 
        resources.ApplyResources(label11, "label11");
        label11.Name = "label11";
        label11.Click += this.label11_Click;
        // 
        // service_mileage
        // 
        resources.ApplyResources(service_mileage, "service_mileage");
        service_mileage.Name = "service_mileage";
        service_mileage.KeyPress += service_mileage_KeyPress;
        // 
        // label10
        // 
        resources.ApplyResources(label10, "label10");
        label10.Name = "label10";
        label10.Click += this.label10_Click;
        // 
        // service_date
        // 
        resources.ApplyResources(service_date, "service_date");
        service_date.Name = "service_date";
        // 
        // label9
        // 
        resources.ApplyResources(label9, "label9");
        label9.Name = "label9";
        label9.Click += label9_Click;
        // 
        // label6
        // 
        resources.ApplyResources(label6, "label6");
        label6.Name = "label6";
        label6.Click += label6_Click;
        // 
        resources.ApplyResources(this, "$this");
        Controls.Add(tabControl1);
        Name = "AutodVorm";
        tabControl1.ResumeLayout(false);
        ownersPage.ResumeLayout(false);
        ownersPage.PerformLayout();
        ((ISupportInitialize)ownersDataGridView).EndInit();
        carsPage.ResumeLayout(false);
        carsPage.PerformLayout();
        ((ISupportInitialize)carsDataGridView).EndInit();
        servicesPage.ResumeLayout(false);
        servicesPage.PerformLayout();
        ((ISupportInitialize)service_dataGrid).EndInit();
        ResumeLayout(false);
    }

    private void ApplyCustomStyling()
    {
        // Pleasant color palette - Soft Blue/Teal theme
        Color primaryBlue = Color.FromArgb(70, 130, 180);      // Steel Blue
        Color lightBlue = Color.FromArgb(230, 240, 250);        // Light Blue background
        Color accentTeal = Color.FromArgb(64, 224, 208);        // Turquoise accent
        Color successGreen = Color.FromArgb(76, 175, 80);        // Green for Add buttons
        Color warningOrange = Color.FromArgb(255, 152, 0);      // Orange for Update buttons
        Color dangerRed = Color.FromArgb(244, 67, 54);          // Red for Delete buttons
        Color headerBlue = Color.FromArgb(25, 118, 210);        // Darker blue for headers
        Color textDark = Color.FromArgb(33, 33, 33);            // Dark gray text

        // Form background
        this.BackColor = lightBlue;

        // TabControl styling
        tabControl1.BackColor = Color.White;
        tabControl1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

        // Tab pages background
        ownersPage.BackColor = lightBlue;
        carsPage.BackColor = lightBlue;
        servicesPage.BackColor = lightBlue;

        // Style all buttons
        StyleButton(owner_lisaBtn, successGreen, Color.White);
        StyleButton(owner_updateBtn, warningOrange, Color.White);
        StyleButton(owner_deleteBtn, dangerRed, Color.White);
        StyleButton(car_addBtn, successGreen, Color.White);
        StyleButton(cars_updateBtn, warningOrange, Color.White);
        StyleButton(car_deleteBtn, dangerRed, Color.White);
        StyleButton(service_insertBtn, successGreen, Color.White);
        StyleButton(service_updateBtn, warningOrange, Color.White);
        StyleButton(service_deleteBtn, dangerRed, Color.White);
        StyleButton(service_manageBtn, primaryBlue, Color.White);
        StyleButton(language_estonianBtn, accentTeal, Color.White);
        StyleButton(language_englishBtn, accentTeal, Color.White);

        // DataGridView styling
        StyleDataGridView(ownersDataGridView, headerBlue);
        StyleDataGridView(carsDataGridView, headerBlue);
        StyleDataGridView(service_dataGrid, headerBlue);

        // Label text color
        foreach (Control control in this.Controls)
        {
            ApplyLabelStyling(control, textDark);
        }
    }

    private void StyleButton(Button btn, Color backColor, Color foreColor)
    {
        btn.BackColor = backColor;
        btn.ForeColor = foreColor;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(Math.Min(255, backColor.R + 20),
                                                               Math.Min(255, backColor.G + 20),
                                                               Math.Min(255, backColor.B + 20));
        btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;
    }

    private void StyleDataGridView(DataGridView dgv, Color headerColor)
    {
        dgv.BackgroundColor = Color.White;
        dgv.GridColor = Color.FromArgb(240, 240, 240);
        dgv.BorderStyle = BorderStyle.None;
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        dgv.RowsDefaultCellStyle.BackColor = Color.White;
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
        dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgv.DefaultCellStyle.Padding = new Padding(3);
    }

    private void ApplyLabelStyling(Control parent, Color textColor)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is Label label)
            {
                label.ForeColor = textColor;
                label.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
            else if (control.HasChildren)
            {
                ApplyLabelStyling(control, textColor);
            }
        }
    }

    private TabControl tabControl1;
    private TabPage ownersPage;
    private TabPage servicesPage;
    private DataGridView ownersDataGridView;
    private Label label1;
    private TextBox owner_fullName;
    private Label label2;
    private TextBox owner_phone;
    private Button owner_lisaBtn;
    private Button owner_updateBtn;
    private Button owner_deleteBtn;
    private TextBox cars_model;
    private TextBox cars_brand;
    private TextBox cars_regNumber;
    private Label label5;
    private Label label8;
    private Label label7;
    private Label car_model;
    private ComboBox cars_owner;
    private Button car_addBtn;
    private Button car_deleteBtn;
    private Button cars_updateBtn;
    private DataGridView carsDataGridView;
    private Label label3;
    private TextBox owners_searchTxt;
    private Label label9;
    private Label label6;
    private Label label10;
    private DateTimePicker service_date;
    private Label label11;
    private TextBox service_mileage;
    private ComboBox service_carComboBox;
    private ComboBox service_serviceComboBox;
    private DataGridView service_dataGrid;
    private Label label12;
    private TextBox textBox1;
    private Button service_deleteBtn;
    private Button service_insertBtn;
    private Button service_updateBtn;
    private Button service_manageBtn;
    private Button teenused_carSearchBtn;
    private ImageList imgList;
    private System.ComponentModel.IContainer components;
    private Button cars_ownerSearchBtn;
    private Button language_estonianBtn;
    private Button language_englishBtn;
    private TabPage carsPage;

    private void LoadOwners()
    {
        var filter = owners_searchTxt.Text ?? "";

        var owners = _db.Owners.Include(i => i.Cars)
            .Where(i => filter == "" || i.FullName.Contains(filter) || i.Phone.Contains(filter))
            .Select(i => new
            {
                i.Id,
                i.FullName,
                i.Phone,
                Cars = i.Cars.Count == 0 ? "None" : i.Cars.ToCommaSepString(", "),
            }).ToList();

        ownersDataGridView.DataSource = owners;
    }

    private void ownersDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (ownersDataGridView.SelectedRows.Count == 0)
        {
            owner_fullName.Text = "";
            owner_phone.Text = "";
            return;
        }

        var selectedRow = ownersDataGridView.SelectedRows[0];
        var ownerId = (int)selectedRow.Cells["Id"].Value;

        var owner = _db.Owners.FirstOrDefault(o => o.Id == ownerId);
        if (owner != null)
        {
            owner_fullName.Text = owner.FullName;
            owner_phone.Text = owner.Phone;
        }
    }

    private void owner_updateBtn_Click(object sender, EventArgs e)
    {
        if (ownersDataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad uuendada!");
            return;
        }

        if (string.IsNullOrEmpty(owner_fullName.Text))
        {
            MessageBox.Show("Kirjuta õige Täisnimi!");
            return;
        }

        if (string.IsNullOrEmpty(owner_phone.Text))
        {
            MessageBox.Show("Kirjuta õige telefoninumber!");
            return;
        }

        var selectedRow = ownersDataGridView.SelectedRows[0];
        var ownerId = (int)selectedRow.Cells["Id"].Value;

        var owner = _db.Owners.FirstOrDefault(o => o.Id == ownerId);
        if (owner == null)
        {
            MessageBox.Show("Omanikku ei leitud andmebaasist!");
            return;
        }

        owner.FullName = owner_fullName.Text;
        owner.Phone = owner_phone.Text;

        _db.SaveChanges();

        LoadOwners();
        MessageBox.Show("Omanik uuendatud!");
    }

    private void owner_deleteBtn_Click(object sender, EventArgs e)
    {
        if (ownersDataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Vali rida mida tahad kustutada!");
            return;
        }

        var id = (int)ownersDataGridView.SelectedRows[0].Cells["Id"].Value;

        var owner = _db.Owners.FirstOrDefault(o => o.Id == id);
        if (owner == null)
        {
            MessageBox.Show("Omanikku ei leitud andmebaasist!");
            return;
        }

        _db.Owners.Remove(owner);
        _db.SaveChanges();

        LoadOwners();
        MessageBox.Show("Omanik kustutatud!");
    }

    private void owner_lisaBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(owner_fullName.Text))
        {
            MessageBox.Show("Kirjuta õige Täisnimi!");
            return;
        }

        if (string.IsNullOrEmpty(owner_phone.Text))
        {
            MessageBox.Show("Kirjuta õige telefoninumber!");
            return;
        }

        var owner = new Owner()
        {
            FullName = owner_fullName.Text,
            Phone = owner_phone.Text
        };

        _db.Owners.Add(owner);
        _db.SaveChanges();

        // Clear form fields and selection
        owner_fullName.Text = "";
        owner_phone.Text = "";
        ownersDataGridView.ClearSelection();

        LoadOwners();

        MessageBox.Show("Uus omanik lisatud!");
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab == ownersPage)
        {
            LoadOwners();
        }
        if (tabControl1.SelectedTab == carsPage)
        {
            LoadCarTab();
        }
        if (tabControl1.SelectedTab == servicesPage)
        {
            LoadTeenused();
        }
    }

    private void LoadCarTab()
    {
        var owners = _db.Owners.ToList();

        cars_owner.DataSource = owners;
        cars_owner.DisplayMember = "FullName";
        cars_owner.ValueMember = "Id";

        // Load cars into the data grid
        var cars = _db.Cars.Include(c => c.Owner)
            .Select(c => new
            {
                Id = c.Id,
                Automark = c.Brand,
                Mudel = c.Model,
                RegNr = c.RegistrationNumber,
                Omanik = c.Owner != null ? c.Owner.FullName : "N/A",
                OwnerId = c.OwnerId
            })
            .ToList();

        carsDataGridView.DataSource = cars;
    }

    private void carsDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (carsDataGridView.SelectedRows.Count == 0)
        {
            cars_brand.Text = "";
            cars_model.Text = "";
            cars_regNumber.Text = "";
            cars_owner.SelectedIndex = -1;
            return;
        }

        var selectedRow = carsDataGridView.SelectedRows[0];
        var carId = (int)selectedRow.Cells["Id"].Value;

        var car = _db.Cars.Include(c => c.Owner).FirstOrDefault(c => c.Id == carId);
        if (car == null)
            return;

        cars_brand.Text = car.Brand;
        cars_model.Text = car.Model;
        cars_regNumber.Text = car.RegistrationNumber;
        cars_owner.SelectedValue = car.OwnerId;
    }

    private void car_addBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cars_brand.Text))
        {
            MessageBox.Show("Kirjuta õige automark!");
            return;
        }

        if (cars_owner.SelectedIndex == -1)
        {
            MessageBox.Show("Vali omanik!");
            return;
        }

        var car = new Car()
        {
            Brand = cars_brand.Text,
            Model = cars_model.Text,
            RegistrationNumber = cars_regNumber.Text,
            OwnerId = (int)cars_owner.SelectedValue
        };

        _db.Cars.Add(car);
        _db.SaveChanges();

        // Clear form fields
        cars_brand.Text = "";
        cars_model.Text = "";
        cars_regNumber.Text = "";
        cars_owner.SelectedIndex = -1;

        // Reload the grid
        LoadCarTab();

        MessageBox.Show("Auto lisatud!");
    }


    private void car_deleteBtn_Click_1(object sender, EventArgs e)
    {
        if (carsDataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad kustutada!");
            return;
        }

        var selectedRow = carsDataGridView.SelectedRows[0];
        var carId = (int)selectedRow.Cells["Id"].Value;

        var car = _db.Cars.FirstOrDefault(c => c.Id == carId);
        if (car == null)
        {
            MessageBox.Show("Autot ei leitud andmebaasist!");
            return;
        }

        var result = MessageBox.Show(
            "Kas oled kindel, et tahad selle auto kustutada?",
            "Kinnita kustutamine",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _db.Cars.Remove(car);
            _db.SaveChanges();

            LoadCarTab();
            MessageBox.Show("Auto kustutatud!");
        }
    }

    private void cars_updateBtn_Click(object sender, EventArgs e)
    {
        if (carsDataGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad uuendada!");
            return;
        }

        var selectedRow = carsDataGridView.SelectedRows[0];
        var carId = (int)selectedRow.Cells["Id"].Value;

        var car = _db.Cars.FirstOrDefault(c => c.Id == carId);
        if (car == null)
        {
            MessageBox.Show("Autot ei leitud andmebaasist!");
            return;
        }

        if (string.IsNullOrEmpty(cars_brand.Text))
        {
            MessageBox.Show("Kirjuta õige automark!");
            return;
        }

        if (cars_owner.SelectedIndex == -1)
        {
            MessageBox.Show("Vali omanik!");
            return;
        }

        car.Brand = cars_brand.Text;
        car.Model = cars_model.Text;
        car.RegistrationNumber = cars_regNumber.Text;
        car.OwnerId = (int)cars_owner.SelectedValue;

        _db.SaveChanges();

        LoadCarTab();
        MessageBox.Show("Auto uuendatud!");
    }

    private void cars_searchTxt_TextChanged(object sender, EventArgs e)
    {
        LoadOwners();
    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void LoadTeenused()
    {
        var cars = _db.Cars.ToList();
        var services = _db.Services.ToList();

        service_carComboBox.DataSource = null;
        service_carComboBox.Items.Clear();
        service_carComboBox.DataSource = cars;
        service_carComboBox.DisplayMember = "RegistrationNumber";
        service_carComboBox.ValueMember = "Id";
        service_carComboBox.SelectedIndex = -1;

        service_serviceComboBox.DataSource = null;
        service_serviceComboBox.Items.Clear();
        var servicesWithDisplay = services.Select(s => new
        {
            Id = s.Id,
            DisplayName = $"{s.Name}, {s.Price:F2} €",
            Service = s
        }).ToList();
        service_serviceComboBox.DataSource = servicesWithDisplay;
        service_serviceComboBox.DisplayMember = "DisplayName";
        service_serviceComboBox.ValueMember = "Id";
        service_serviceComboBox.SelectedIndex = -1;

        // Load CarServices into the data grid with search filter
        var filter = textBox1.Text ?? "";
        var allCarServices = _db.CarServices
            .Include(cs => cs.Car)
            .Include(cs => cs.Service)
            .ToList();

        var carServices = allCarServices
            .Where(cs =>
                filter == "" ||
                (cs.Car != null && (
                    cs.Car.Brand.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                    cs.Car.Model.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                    cs.Car.RegistrationNumber.Contains(filter, StringComparison.OrdinalIgnoreCase)
                )) ||
                (cs.Service != null && cs.Service.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)) ||
                cs.DateOfService.ToString("dd.MM.yyyy").Contains(filter) ||
                cs.Mileage.ToString().Contains(filter)
            )
            .Select(cs => new
            {
                Auto = cs.Car != null ? $"{cs.Car.Brand} {cs.Car.Model} ({cs.Car.RegistrationNumber})" : "N/A",
                Teenus = cs.Service != null ? cs.Service.Name : "N/A",
                Kuupäev = cs.DateOfService.ToString("dd.MM.yyyy"),
                Läbisõit = cs.Mileage,
                CarId = cs.CarId,
                ServiceId = cs.ServiceId
            })
            .ToList();

        service_dataGrid.DataSource = carServices;
    }

    private void service_searchTxt_TextChanged(object sender, EventArgs e)
    {
        LoadTeenused();
    }

    private void service_manageBtn_Click(object sender, EventArgs e)
    {
        using (var serviceForm = new TeenusedVorm())
        {
            serviceForm.ShowDialog();
        }
        // Refresh services after the form closes
        LoadTeenused();
    }

    private void teenused_carSearchBtn_Click(object sender, EventArgs e)
    {
        using (var searchForm = new AutoOtsing())
        {
            if (searchForm.ShowDialog() != DialogResult.OK)
                return;

            var chosenCar = searchForm.SelectedCar;
            if (chosenCar != null)
            {
                service_carComboBox.SelectedValue = chosenCar.Id;
            }
        }
    }

    private void cars_ownerSearchBtn_Click(object sender, EventArgs e)
    {
        using (var searchForm = new OmanikOtsing())
        {
            if (searchForm.ShowDialog() != DialogResult.OK)
                return;

            var chosenOwner = searchForm.SelectedOwner;
            if (chosenOwner != null)
            {
                cars_owner.SelectedValue = chosenOwner.Id;
            }
        }
    }

    private void service_insertBtn_Click(object sender, EventArgs e)
    {
        if (service_carComboBox.SelectedIndex == -1 || service_serviceComboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Palun vali õige auto ja teenus!");
            return;
        }

        if (string.IsNullOrEmpty(service_mileage.Text))
        {
            MessageBox.Show("Palun sisesta läbisõit!");
            return;
        }

        var selectedServiceItem = service_serviceComboBox.SelectedItem;
        var serviceId = (int)selectedServiceItem.GetType().GetProperty("Id")!.GetValue(selectedServiceItem)!;

        var carService = new CarService()
        {
            CarId = (service_carComboBox.SelectedItem as Car)!.Id,
            ServiceId = serviceId,
            DateOfService = service_date.Value,
            Mileage = int.Parse(service_mileage.Text)
        };

        _db.CarServices.Add(carService);
        _db.SaveChanges();

        // Clear form fields
        service_carComboBox.SelectedIndex = -1;
        service_serviceComboBox.SelectedIndex = -1;
        service_mileage.Text = "";
        service_date.Value = DateTime.Now;

        // Reload to show the new service in the grid
        LoadTeenused();

        MessageBox.Show("Teenus lisatud!");
    }

    private void service_dataGrid_SelectionChanged(object sender, EventArgs e)
    {
        if (service_dataGrid.SelectedRows.Count == 0)
        {
            service_carComboBox.SelectedIndex = -1;
            service_serviceComboBox.SelectedIndex = -1;
            service_mileage.Text = "";
            service_date.Value = DateTime.Now;
            return;
        }

        var selectedRow = service_dataGrid.SelectedRows[0];
        var carId = (int)selectedRow.Cells["CarId"].Value;
        var serviceId = (int)selectedRow.Cells["ServiceId"].Value;

        var carService = _db.CarServices
            .Include(cs => cs.Car)
            .Include(cs => cs.Service)
            .FirstOrDefault(cs => cs.CarId == carId && cs.ServiceId == serviceId);

        if (carService != null)
        {
            service_carComboBox.SelectedValue = carService.CarId;
            service_serviceComboBox.SelectedValue = carService.ServiceId;
            service_date.Value = carService.DateOfService;
            service_mileage.Text = carService.Mileage.ToString();
        }
    }

    private void service_updateBtn_Click(object sender, EventArgs e)
    {
        if (service_dataGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad uuendada!");
            return;
        }

        if (service_carComboBox.SelectedIndex == -1 || service_serviceComboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Palun vali õige auto ja teenus!");
            return;
        }

        if (string.IsNullOrEmpty(service_mileage.Text))
        {
            MessageBox.Show("Palun sisesta läbisõit!");
            return;
        }

        var selectedRow = service_dataGrid.SelectedRows[0];
        var carId = (int)selectedRow.Cells["CarId"].Value;
        var serviceId = (int)selectedRow.Cells["ServiceId"].Value;

        var carService = _db.CarServices
            .FirstOrDefault(cs => cs.CarId == carId && cs.ServiceId == serviceId);

        if (carService == null)
        {
            MessageBox.Show("Teenust ei leitud andmebaasist!");
            return;
        }

        var selectedServiceItem = service_serviceComboBox.SelectedItem;
        var newServiceId = (int)selectedServiceItem.GetType().GetProperty("Id")!.GetValue(selectedServiceItem)!;

        carService.CarId = (service_carComboBox.SelectedItem as Car)!.Id;
        carService.ServiceId = newServiceId;
        carService.DateOfService = service_date.Value;
        carService.Mileage = int.Parse(service_mileage.Text);

        _db.SaveChanges();

        // Clear form fields
        service_carComboBox.SelectedIndex = -1;
        service_serviceComboBox.SelectedIndex = -1;
        service_mileage.Text = "";
        service_date.Value = DateTime.Now;
        service_dataGrid.ClearSelection();

        LoadTeenused();
        MessageBox.Show("Teenus uuendatud!");
    }

    private void service_deleteBtn_Click(object sender, EventArgs e)
    {
        if (service_dataGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("Palun vali rida mida tahad kustutada!");
            return;
        }

        var selectedRow = service_dataGrid.SelectedRows[0];
        var carId = (int)selectedRow.Cells["CarId"].Value;
        var serviceId = (int)selectedRow.Cells["ServiceId"].Value;

        var carService = _db.CarServices
            .FirstOrDefault(cs => cs.CarId == carId && cs.ServiceId == serviceId);

        if (carService == null)
        {
            MessageBox.Show("Teenust ei leitud andmebaasist!");
            return;
        }

        var result = MessageBox.Show(
            "Kas oled kindel, et tahad selle teenuse kustutada?",
            "Kinnita kustutamine",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _db.CarServices.Remove(carService);
            _db.SaveChanges();

            LoadTeenused();
            MessageBox.Show("Teenus kustutatud!");
        }
    }

    private bool _isFlashing;

    private async void service_mileage_KeyPress(object sender, KeyPressEventArgs e)
    {
        HandleNumberOnlyKeyPress(sender, e);
    }

    private async void HandleNumberOnlyKeyPress(object sender, KeyPressEventArgs e)
    {
        var textBox = sender as TextBox;
        if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            return;

        e.Handled = true;

        if (!_isFlashing)
        {
            Color original = textBox.BackColor;
            textBox.BackColor = Color.LightCoral;
            _isFlashing = true;

            await Task.Delay(150);

            textBox.BackColor = original;
            _isFlashing = false;
        }
    }

    private void language_estonianBtn_Click(object sender, EventArgs e)
    {
        SetLanguage("et");
        CarsDb.Properties.Settings.Default.Language = "et";
        CarsDb.Properties.Settings.Default.Save();
    }

    private void language_englishBtn_Click(object sender, EventArgs e)
    {
        SetLanguage("en");
        CarsDb.Properties.Settings.Default.Language = "en";
        CarsDb.Properties.Settings.Default.Save();
    }


    private void SetLanguage(string langCode)
    {
        if (Thread.CurrentThread.CurrentUICulture.Name == langCode)
            return;

        Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

        ApplyResourceToControls(this, new ComponentResourceManager(this.GetType()));
    }

    private void ApplyResourceToControls(Control control, ComponentResourceManager resource)
    {
        Dictionary<Control, ControlLayout> savedLayouts = new Dictionary<Control, ControlLayout>();
        
        void SaveLayout(Control c)
        {
            savedLayouts[c] = new ControlLayout
            {
                Location = c.Location,
                Size = c.Size,
                AutoSize = c.AutoSize,
                Anchor = c.Anchor,
                Dock = c.Dock,
                Margin = c.Margin,
                Padding = c.Padding
            };
        }
        
        void RestoreLayout(Control c)
        {
            if (savedLayouts.ContainsKey(c))
            {
                var layout = savedLayouts[c];
                c.Location = layout.Location;
                c.Size = layout.Size;
                c.AutoSize = layout.AutoSize;
                c.Anchor = layout.Anchor;
                c.Dock = layout.Dock;
                c.Margin = layout.Margin;
                c.Padding = layout.Padding;
            }
        }
        
        void ProcessControl(Control c)
        {
            SaveLayout(c);
            resource.ApplyResources(c, c.Name);
            RestoreLayout(c);
            
            if (c.HasChildren)
            {
                foreach (Control child in c.Controls)
                {
                    ProcessControl(child);
                }
            }
        }
        
        foreach (Control c in control.Controls)
        {
            ProcessControl(c);
        }
        
        SaveLayout(control);
        resource.ApplyResources(control, control.Name);
        RestoreLayout(control);
    }
    
    private class ControlLayout
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool AutoSize { get; set; }
        public AnchorStyles Anchor { get; set; }
        public DockStyle Dock { get; set; }
        public Padding Margin { get; set; }
        public Padding Padding { get; set; }
    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void label10_Click(object sender, EventArgs e)
    {

    }

    private void label11_Click(object sender, EventArgs e)
    {

    }
}
