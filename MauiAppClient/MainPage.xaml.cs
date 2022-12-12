using MauiAppClient.Models;
using MauiAppClient.Services;

namespace MauiAppClient;

public partial class MainPage : ContentPage
{
    //int count = 0;
    ProductService serv = new ProductService();

    public MainPage()
    {
        InitializeComponent();
        prodsLst.ItemsSource = serv.GetProducts();
       // App.Current.Resources["myKey"] = "myValue";
    }

    private void prodsLst_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var prod = (Product)e.Item;
        Navigation.PushAsync(new ItemPage(prod.ProductId));
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ItemPage());
    }


    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        prodsLst.ItemsSource = serv.GetProducts();
    }


    //   private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}

