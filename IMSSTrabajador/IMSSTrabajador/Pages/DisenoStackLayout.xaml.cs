using IMSSTrabajador.Model;

namespace IMSSTrabajador.Pages;

public partial class DisenoStackLayout : ContentPage
{
    Sueldo sueldo;
	public DisenoStackLayout()
	{
		InitializeComponent();
        Categoria.Items.Add("2");
        Categoria.Items.Add("4");
        Categoria.Items.Add("5");
        Categoria.Items.Add("7");
        sueldo = new Sueldo();
	}

    private void Principal_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Calcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            sueldo.P_Sueldo = Convert.ToDouble(SueldoT.Text);
            if(Categoria.SelectedIndex != -1)
            {
                sueldo.RdbAntiguedad_5 = cinco.IsChecked;
                sueldo.RdbAntiguedad_10 = diez.IsChecked;
                sueldo.ChkCertificacion2001 = ISO2001.IsChecked;
                sueldo.ChkCertificacion9001 = ISO9001.IsChecked;
                Resultado.Text = sueldo.Calcula_NuevoSueldo().ToString();
            }
        }
        catch(FormatException)
        {
            DisplayAlert("Alerta", "Sueldo no valido!", "Aceptar");
        }
        catch (Exception ex)
        {
            string error;
            error = ex.Message;
            DisplayAlert("Alerta", error, "Aceptar");
        }
    }

    private void Categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        sueldo.Categoria =Convert.ToInt16(Categoria.SelectedItem);
    }
}