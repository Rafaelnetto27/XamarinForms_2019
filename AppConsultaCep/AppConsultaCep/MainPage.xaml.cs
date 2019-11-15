using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppConsultaCep.Serviço.Modelo;
using AppConsultaCep.Serviço;

namespace AppConsultaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCep;
            
        }
        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = TEXTBOXCEP.Text.Trim();
            if (IsValidCep(cep))
            {
                try { 
                Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end.cep != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2},{3},{0} {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else {
                        DisplayAlert("ERRO","O endereço não foi encontrado" +end.cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "Ok");
                }
            }
        }
        private bool IsValidCep(string cep) {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Invalido! O Cep deve conter 8 caracteres","OK");
                valido = false;
            }
            int NovoCep = 0;
            if(!int.TryParse(cep,out NovoCep))
            {

                DisplayAlert("ERRO", "CEP Invalido! O Cep deve ser composto apenas por numeros", "OK");
                valido = false;
            }
            return valido;
        
        }
    }
}
