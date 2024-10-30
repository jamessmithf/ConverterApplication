using Microsoft.UI.Xaml.Controls.Primitives;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;


namespace App
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Currency> ObservableCollectionOfCurrencies { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                var platformTextBox = handler.PlatformView;
                platformTextBox.Style = null;
                platformTextBox.BorderThickness = new Microsoft.UI.Xaml.Thickness(0); 
            });
            
            string json = new WebClient().DownloadString("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchangenew?json");
            List<Currency>? ListOfCurrencies = JsonSerializer.Deserialize<List<Currency>>(json);
            if (ListOfCurrencies != null) 
            {
                foreach (var currency in ListOfCurrencies.ToList())
                {
                    if (currency.cc == "XAU")
                        ListOfCurrencies.Remove(currency);
                    if (currency.cc == "XAG")
                        ListOfCurrencies.Remove(currency);
                    if(currency.cc == "XPT")
                        ListOfCurrencies.Remove(currency);
                    if(currency.cc == "XPD")
                        ListOfCurrencies.Remove(currency);
                }
                ListOfCurrencies.Insert(0, new Currency { cc = "UAH", txt = "Гривня", rate = 1 });
            }
            

            ObservableCollectionOfCurrencies = new ObservableCollection<Currency>(ListOfCurrencies);

            BindingContext = this;
        }
        private void CurrencyPicker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrencyPicker1.SelectedItem is Currency selectedCurrency)
            {
                CurrencyInfo1.Text = $"Опис: {selectedCurrency.txt}";
            }           
        }
        private void CurrencyPicker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrencyPicker2.SelectedItem is Currency selectedCurrency)
            {
                CurrencyInfo2.Text = $"Опис: {selectedCurrency.txt}";
            }
            else
            {
                CurrencyInfo2.Text = string.Empty; // Очистити підказку, якщо нічого не вибрано
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var selectedCurrency1 = CurrencyPicker1.SelectedItem as Currency;
            var selectedCurrency2 = CurrencyPicker2.SelectedItem as Currency;
            bool status = Decimal.TryParse(ValueToConvert.Text, out decimal value);

            if (selectedCurrency1 != null && selectedCurrency2 != null && status && value >= 0)
            {
                Result.Text = String.Format("{0:0.####}", Converter.Convert(value, selectedCurrency1, selectedCurrency2)).ToString();
            }

            if (status == false || value < 0)
            {
                Result.Text = string.Empty;
            }
        }
        private void SwapCurrencies(object sender, EventArgs e)
        {
            var tmp = CurrencyPicker1.SelectedItem;
            CurrencyPicker1.SelectedItem = CurrencyPicker2.SelectedItem;
            CurrencyPicker2.SelectedItem = tmp;

            if (CurrencyPicker1.SelectedItem == null)
                CurrencyInfo1.Text = "Оберіть валюту, щоб побачити опис";
            else if (CurrencyPicker2.SelectedItem == null)
                CurrencyInfo2.Text = "Оберіть валюту, щоб побачити опис";
        }
    }
}
