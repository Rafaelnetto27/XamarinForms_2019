using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppConsultaCep.Serviço.Modelo;
using Newtonsoft.Json;

namespace AppConsultaCep.Serviço
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep (string Cep) {
            string NovoEnderecoURL = string.Format(EnderecoURL,Cep);

            WebClient wc = new WebClient();
           string Conteudo = wc.DownloadString(NovoEnderecoURL);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.cep == null) {
                return null;
            }
            return end;

        }
    }
}
