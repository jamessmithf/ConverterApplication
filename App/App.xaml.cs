namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int WIDTH = 500;
            const int HEIGHT = 320;

            window.Width = WIDTH;
            window.Height = HEIGHT;
            window.MaximumWidth = WIDTH;
            window.MaximumHeight = HEIGHT;
            window.MinimumWidth = WIDTH;
            window.MinimumHeight = HEIGHT;

            return window;
        }
    }
}
