using Galatasaray.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace Galatasaray
{
    public partial class MainPage : ContentPage
    {
        private readonly SensorViewModel vm;

        public MainPage(SensorViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            BindingContext = vm;

            // Detectar cambios de orientación
            SizeChanged += OnSizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();

            // Verificar orientación al aparecer la página
            UpdateOrientation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            vm.OnDisappearing();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            UpdateOrientation();
        }

        private void UpdateOrientation()
        {
            bool isLandscape = Width > Height;

            // Cambiar visibilidad de los layouts según orientación
            PortraitLayout.IsVisible = !isLandscape;
            LandscapeLayout.IsVisible = isLandscape;
        }
    }
}