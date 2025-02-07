using System.ComponentModel;

public class OperacionModel : INotifyPropertyChanged
{
    private int _cantidad;
    private decimal _subtotal;
    private int _stock;

    public int ComicId { get; set; }
    public string Nombre { get; set; }
    public decimal PrecioVenta { get; set; }
    // public decimal Descuento { get; set; }

    public int Cantidad
    {
        get { return _cantidad; }
        set
        {
            if (_cantidad != value)
            {
                _cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
                
            }
        }
    }

    public decimal Subtotal
    {
        get { return _subtotal; }
        set
        {
            if (_subtotal != value)
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
            }
        }
    }

    public int Stock
    {
        get { return _stock; }
        set
        {
            if (_stock != value)
            {
                _stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
