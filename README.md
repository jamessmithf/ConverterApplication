# ConverterApplication
This project is a Currency Converter Application built using .NET MAUI (Multi-platform App UI), designed for cross-platform functionality on mobile and desktop devices. The app allows users to convert amounts from one currency to another using real-time exchange rates, fetched from an external API (such as the National Bank API in this example).

Key Features
Currency Input and Output:

Users can input the amount they want to convert.
Select both the input and output currencies from dropdown lists (Pickers).
The conversion result is displayed dynamically after calculations.
Real-Time Exchange Rate Fetching:

The app connects to an external exchange rate API to fetch the latest rates.
It parses the data and populates the currency list, ensuring up-to-date conversion.
User-Friendly Interface:

Built with a clean, minimalist design, the interface features intuitive controls for entering amounts, selecting currencies, and viewing results.
Includes tooltips that provide additional details for each currency when hovering over a selection.
Swap Functionality:

An added "⇄" button allows users to swap the selected input and output currencies with a single tap, enhancing usability and saving time.
Technical Highlights
Data Binding with MAUI: The currency data is loaded into an ObservableCollection and bound to the currency pickers, ensuring efficient data handling and UI updates.
API Integration: Utilizes the .NET HttpClient and JSON deserialization to process currency data from the API.
Event Handling: Interactive components like the "Convert" button and the swap feature are managed with event handlers in the MainPage.xaml.cs file.
Cross-Platform Design: Leveraging MAUI, this app is adaptable across platforms, including Android, iOS, and Windows, with a responsive layout.
Potential Extensions
Historical Exchange Rates: Adding a feature to view past rates.
Multi-Language Support: Localizing the app for different languages.
Graphical Analytics: Showing conversion trends or graphs for selected currency pairs.
