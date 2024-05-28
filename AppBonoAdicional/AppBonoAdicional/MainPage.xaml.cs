using AppBonoAdicional.Model;

namespace AppBonoAdicional
{
    public partial class MainPage : ContentPage
    {
        Bono bono;
        public MainPage()
        {
            InitializeComponent();
            bono = new Bono();
            Sexo.Items.Add("Masculino");
            Sexo.Items.Add("Femenino");
            Nacionalidad.Items.Add("Nacional");
            Nacionalidad.Items.Add("Extranjero");
        }

        private void Sexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sexo.SelectedItem != null)
            {
                bono.Sexo = Sexo.SelectedItem.ToString();
            }
            else
            {
                bono.Sexo = null;
            }
        }

        private void Nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Sexo.SelectedItem != null)
            {
                bono.Nacionalidad = Nacionalidad.SelectedItem.ToString();
            }
            else
            {
                bono.Nacionalidad = null;
            }
        }

        private void Calcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                bono.Sueldo = Convert.ToDouble(Sueldo.Text);
                bono.Edad = Convert.ToInt32(Edad.Text);
                if (Sexo.SelectedIndex != -1 && Nacionalidad.SelectedIndex != -1)
                {
                    bono.RB1a5 = cinco.IsChecked;
                    bono.RB6a10 = diez.IsChecked;
                    bono.ChckPHP = PHPCheckBox.IsChecked;
                    bono.ChckJAVA = JAVACheckBox.IsChecked;
                    bono.ChckASP = ASPNETCheckBox.IsChecked;
                    bono.ChckORACLE = ORACLECheckBox.IsChecked;
                    Bono.Text = "El bono es de: $"+ bono.CalcularBono().ToString();
                }
            }
            catch (FormatException)
            {
                DisplayAlert("Alerta", "No valido!", "Aceptar");
            }
            catch (Exception ex)
            {
                string Error;
                Error = ex.Message;
                DisplayAlert("Alerta", Error, "Aceptar");
            }
        }

        private void Nuevo_Calculo_Clicked(object sender, EventArgs e)
        {
            bono = new Bono();

            Sexo.SelectedItem = null; // Limpiar combobox Sexo
            Nacionalidad.SelectedItem = null; // Limpiar combobox Nacionalidad
            Sueldo.Text = string.Empty;
            Edad.Text = string.Empty;

            cinco.IsChecked = false;
            diez.IsChecked = false;
            PHPCheckBox.IsChecked = false;
            JAVACheckBox.IsChecked = false;
            ASPNETCheckBox.IsChecked = false;
            ORACLECheckBox.IsChecked = false;

            Bono.Text = string.Empty;
        }
    }

}
