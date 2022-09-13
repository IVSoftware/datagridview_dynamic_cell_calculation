Rather than interact with the `DataGridView` directly (which can be complex) you could instead make a class that implements `INotifyPropertyChanged` and keeps all of its internal calculations up-to-date at all times. Here is a simplified version of such a class that responds to changes of `Descricao`, `Medida` and `_precoFilhoSemIva`.

***
**A class that represents a row of data**
```
class Articulo : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    string _descricao = string.Empty;
    public string Descricao
    {
        get => _descricao;
        set
        {
            if (!Equals(_descricao, value))
            {
                _descricao = value;
                OnPropertyChanged();
            }
        }
    }
    public string Descricao_Pai => $"{Descricao} {Medida_1}@{_precoFilhoSemIva.ToString("F2")}";
    public decimal PrecoFilhoComIva => _precoFilhoSemIva * (1.0m + MainForm.Iva);

    decimal _medida = 0;
    public decimal Medida
    {
        get => _medida;
        set
        {
            if (!Equals(_medida, value))
            {
                _medida = value;
                OnPropertyChanged();
            }
        }
    }

    decimal _precoFilhoSemIva = 0;
    public decimal PrecoFilhoSemIva
    {
        get => _precoFilhoSemIva;
        set
        {
            if (!Equals(_precoFilhoSemIva, value))
            {
                _precoFilhoSemIva = value;
                OnPropertyChanged();
            }
        }
    }
    string _codigoArtigo = System.Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
    public string CodigoArtigo
    {
        get => _codigoArtigo;
        set
        {
            if (!Equals(_codigoArtigo, value))
            {
                _codigoArtigo = value;
                OnPropertyChanged();
            }
        }
    }
}
```
Instances of this class are placed in a `BindingList` which is assigned to the `DataSource` property of `dgv_Filho` and caused the DGV to update whenever the Refresh method is called.

![Change Iva](https://github.com/IVSoftware/datagridview_dynamic_cell_calculation/blob/master/datagridview_dynamic_cell_calculation/Screenshots/ss1.png)

![Change Descricao](https://github.com/IVSoftware/datagridview_dynamic_cell_calculation/blob/master/datagridview_dynamic_cell_calculation/Screenshots/ss2.png)

![Change Preco](https://github.com/IVSoftware/datagridview_dynamic_cell_calculation/blob/master/datagridview_dynamic_cell_calculation/Screenshots/ss3.png)

***
**Initializations**
The only interaction that should be necessary with the DGV is to initialize the columns and bindings properly in the `MainForm` override for the `Load` event. This is also where we bind the combo box to a static value for Iva that can be used by the calculation for the row items.

```
protected override void OnLoad(EventArgs e)
{
    base.OnLoad(e);
    initDataGridView();
    initComboBox();
}
```
```
private void initDataGridView()
{
    dgv_Filho.DataSource = DataSource;
    DataSource.ListChanged += (sender, e) =>
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            dgv_Filho.Refresh();
        }
    };
    // Add one or more items to autogenerate the columns.
    Random randomPriceGen = new Random(1);
    for (int i = 1; i <= 3; i++)
    {
        var preco = i == 1 ? 1.0m : (decimal)randomPriceGen.NextDouble() * 100;
        DataSource.Add(new Articulo
        {
            Descricao = $"Articulo {(char)('A' + (i - 1))}",
            Medida = i,
            PrecoFilhoSemIva = preco,
        }); ;
    }
    foreach (DataGridViewColumn column in dgv_Filho.Columns)
    {
        switch (column.Name)
        {
            case nameof(Articulo.Descricao):
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.MinimumWidth = 120;
                break;
            case nameof(Articulo.Medida):
            case nameof(Articulo.PrecoFilhoSemIva):
            case nameof(Articulo.PrecoFilhoComIva):
                column.DefaultCellStyle.Format = "F2";
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                break;
            default:
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                break;
        }
    }
}
```

```
private void initComboBox()
{
    cb_Iva.SelectedIndex = 0;
    cb_Iva.SelectedIndexChanged += onIvaSelected;
    cb_Iva.KeyDown += (sender, e) =>
    {
        if( e.KeyData == Keys.Enter)
        {
            e.Handled = e.SuppressKeyPress = true;
        }
        onIvaSelected(sender, e);
    };
    onIvaSelected(cb_Iva, EventArgs.Empty);

    void onIvaSelected(object sender, EventArgs e)
    {
        if (decimal.TryParse(cb_Iva.Text.Replace("%", string.Empty), out decimal iva))
        {
            Iva = iva / 100m;
            dgv_Filho.Refresh();
            cb_Iva.BackColor = SystemColors.Window;
        }
        else cb_Iva.BackColor = Color.LightSalmon;
    }
}
```





