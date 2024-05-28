using IMSSTrabajador.Pages;

namespace IMSSTrabajador
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void IMMSStack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisenoStackLayout());
        }

        private void IMMSGrid_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisenoGridLayout());
        }
    }

}
