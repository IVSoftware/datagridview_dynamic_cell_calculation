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

![Change Iva]()

![Change Descricao]()

![Change Preco]()

***

Instances of this class are placed in a `BindingList` which is assigned to the `DataSource` property of `dgv_Filho`. The only interaction that should be necessary with the DGV is to initialize the columns and bindings properly in the `MainForm` override for the `Load` event. This is also where we bind the combo box to a static value for Iva that can be used by the calculation for the row items.





