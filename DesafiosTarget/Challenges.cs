using DesafiosTarget.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafiosTarget
{
    public class Challenges
    {
        public int retornoSomaK()
        {
            int INDICE = 13;
            int SOMA = 0;
            int K = 0;

            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            return SOMA;
        }


        public RetornoFibbonacciDTO sequenciaFibonacci(int valorFib)
        {
            RetornoFibbonacciDTO result = new();

            if (valorFib >= 0)
            {
                result = validaRealFib(valorFib);
            }

            return result;
        }

        public RetornoFibbonacciDTO validaRealFib(int valorFib)
        {
            int count = 0;
            bool validado = false;
            bool resultado = false;

            int valorInicial = 1;
            int proximoValor = 1;
            int valorAtual = 0;

            while (validado != true)
            {
                valorAtual = valorInicial + proximoValor;
                proximoValor = valorInicial;
                valorInicial = valorAtual;

                count++;

                if (valorFib == valorAtual)
                {
                    validado = true;
                    resultado = true;
                }
                else if (valorAtual > valorFib)
                {
                    validado = true;
                    resultado = false;
                }

            }

            RetornoFibbonacciDTO retornoFibbonacciDTO = new RetornoFibbonacciDTO()
            {
                qtdExecutado = count,
                Resultado = resultado
            };

            return retornoFibbonacciDTO;
        }

        public FaturamentoDistribuidoraDTO faturamentoDiarioDistribuidora()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            using (StreamReader r = new StreamReader(projectDirectory + @".\Arquivos\dados.json"))
            {
                FaturamentoDistribuidoraDTO faturamentoDistribuidoraDTO = new();
                int diasAcimaDaMediaMensal = 0;

                string json = r.ReadToEnd();
                List<DadosDistribuidoraDTO> dadosDistribuidora = JsonConvert.DeserializeObject<List<DadosDistribuidoraDTO>>(json).Where(x => x.Valor > 0).OrderBy(x => x.Valor).ToList();

                faturamentoDistribuidoraDTO.MenorFaturamento = dadosDistribuidora.FirstOrDefault().Valor;
                faturamentoDistribuidoraDTO.MaiorFatumento = dadosDistribuidora.LastOrDefault().Valor;

                int media = dadosDistribuidora.Count();
                decimal valorTotal = dadosDistribuidora.Sum(x => x.Valor);

                decimal mediaFaturamentoMensal = valorTotal / media;

                foreach (var item in dadosDistribuidora)
                {
                    if (item.Valor > mediaFaturamentoMensal)
                    {
                        diasAcimaDaMediaMensal++;
                    }
                }

                faturamentoDistribuidoraDTO.DiasAcimaDaMedia = diasAcimaDaMediaMensal;

                return faturamentoDistribuidoraDTO;

            }
        }

        public List<DadosDistribuidoraPorEstadoDTO> percentualEstados()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            List<DadosDistribuidoraPorEstadoDTO> dadosDistribuidoraPorEstadoDTO = new();

            using (StreamReader r = new StreamReader(projectDirectory + @".\Arquivos\desafioQuatro.json"))
            {
                string json = r.ReadToEnd();
                List<FaturamentoPorEstadoDTO> dadosDistribuidora = JsonConvert.DeserializeObject<List<FaturamentoPorEstadoDTO>>(json);

                decimal valorTotal = dadosDistribuidora.Sum(x => x.Faturamento);

                foreach (var item in dadosDistribuidora)
                {

                    decimal porcentagemEstado = Math.Round((item.Faturamento * 100) / valorTotal, 1);


                    dadosDistribuidoraPorEstadoDTO.Add(new DadosDistribuidoraPorEstadoDTO()
                    {
                        Estado = item.Estado,
                        Porcentagem = porcentagemEstado
                    });

                }

                return dadosDistribuidoraPorEstadoDTO;

            }
        }

        public string inverteCaracteres(string palavraInverter)
        {

            string palavraNova = "";
            int tamanhoPalavra;

            tamanhoPalavra = palavraInverter.Length - 1;

            while (tamanhoPalavra >= 0)
            {
                palavraNova = palavraNova + palavraInverter[tamanhoPalavra];
                tamanhoPalavra--;
            }

            return palavraNova;
        }

    }
}
