using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Temperatura
{
    [Activity(Label = "Temperatura", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //Declaración de objetos a referenciar de la GUI
        private TextView lblResult;
        private EditText txtTemperatur;
        private Button btnCalcular, btnInformacion;
        private CheckBox cbInfo;
        private Spinner spDe, spA;
        private ProgressBar barra;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Asociar los objetos de la GUI con los de C#

            lblResult = FindViewById<TextView>(Resource.Id.lblResultado);
            txtTemperatur = FindViewById<EditText>(Resource.Id.txtTemperatura);
            cbInfo = FindViewById<CheckBox>(Resource.Id.cbInfo);
            spDe = FindViewById<Spinner>(Resource.Id.spDesde);
            spA = FindViewById<Spinner>(Resource.Id.spHasta);
            barra = FindViewById<ProgressBar>(Resource.Id.progressBar1);

                //para llenar el spinner se requiere crear el array
            string[] temperaturas = new string[3] { "Centigrados", "Fahrenheit", "Kelvin" };
            // string[] temperaturas2 = { "Centigrados", "Fahrenheit", "Kelvin" };
                //y luego crear un adaptador para el spinner
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, temperaturas);
                //luego se le pasa el adaptador al spinner
            spDe.Adapter = adapter;
            spA.Adapter = adapter;

            btnCalcular = FindViewById<Button>(Resource.Id.btnCalcular);
            btnCalcular.Click += btnCalcular_Click;
            btnInformacion = FindViewById<Button>(Resource.Id.btnInformacion);
            btnInformacion.Click += btnInformacion_Click;

        }
        
        private void btnInformacion_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Escala pendiente", ToastLength.Long).Show();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            //
            string de = spDe.SelectedItem.ToString();
            string a = spA.SelectedItem.ToString();
            if (de == a)
            {
                
                Toast.MakeText(this, "Debe seleccionar temperaturas diferentes", ToastLength.Long).Show();
            }
            else
            {
                try
                {
                    int tempera = int.Parse(txtTemperatur.Text);
                    if(de=="Centigrados" && a == "Fahrenheit")
                    {
                        float convertir = (9.0f / 5.0f) * tempera + 32;
                        lblResult.Text = txtTemperatur.Text + "°C equivalen a " + convertir + "°F";
                    }
                    else if (de == "Centigrados" && a == "Kelvin")
                    {
                        float convertir = tempera - 273.7f;
                        lblResult.Text = txtTemperatur.Text + "°C equivalen a " + convertir + "°K";
                    }
                    else if (de == "Fahrenheit" && a == "Centigrados")
                    {
                        float convertir = (5.0f / 9.0f) * tempera - 32;
                        lblResult.Text = txtTemperatur.Text + "°F equivalen a " + convertir + "°C";
                    }
                    else if (de == "Fahrenheit" && a == "Kelvin")
                    {
                        float convertir = (9.0f / 5.0f) * (tempera - 273.7f) + 32;
                        lblResult.Text = txtTemperatur.Text + "°F equivalen a " + convertir + "°K";
                    }
                    else if (de == "Kelvin" && a == "Centigrados")
                    {
                        float convertir = tempera - 273.7f;
                        lblResult.Text = txtTemperatur.Text + "°K equivalen a " + convertir + "°C";
                    }
                    else if (de == "Fahrenheit" && a == "Kelvin")
                    {
                        float convertir = (5.0f / 9.0f) * (tempera - 32) + 273.7f;
                        lblResult.Text = txtTemperatur.Text + "°F equivalen a " + convertir + "°K";
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }
        }
    }
}

