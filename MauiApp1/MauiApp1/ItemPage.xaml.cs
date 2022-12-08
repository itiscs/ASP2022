using MauiApp1.Services;

namespace MauiApp1;

public partial class ItemPage : ContentPage
{
	ProductService serv = new ProductService();
	public ItemPage()
	{
		InitializeComponent();		
	}

    public ItemPage(int id)
    {
        InitializeComponent();
		var prod = serv.GetProduct(id);
		BindingContext = prod;

    }
}