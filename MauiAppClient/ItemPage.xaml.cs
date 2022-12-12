using MauiAppClient.Models;
using MauiAppClient.Services;

namespace MauiAppClient;

public partial class ItemPage : ContentPage
{
	ProductService serv = new ProductService();
    private int _prodId;
	public ItemPage()
	{
		InitializeComponent();
        _prodId = -1;
        BindingContext = new Product();
    }

    public ItemPage(int id)
    {
        InitializeComponent();
		var prod = serv.GetProduct(id);
		BindingContext = prod;
        _prodId = id;
    }

   

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        var prod = (Product)BindingContext;
        if(_prodId == -1) 
           serv.AddProduct(prod);
        else
           serv.EditProduct(_prodId, prod);
        Navigation.PopAsync();
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        var prod = (Product)BindingContext;
        bool answer = await DisplayAlert("Answer",$"Are sure to delete {prod.Name}?", "Yes", "No");
        if (answer)
        {
            serv.DeleteProduct(_prodId);
            await Navigation.PopAsync();
        }

    }
}