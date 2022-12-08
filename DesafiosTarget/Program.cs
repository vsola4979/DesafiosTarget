using DesafiosTarget.Dto;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace DesafiosTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Challenges challenges = new Challenges();
            Utils utils = new Utils();

            Console.WriteLine($"Aperte enter para começar");
            utils.pulaLinha();
            Console.ReadLine();

            //Questão - 1
            primeiroDesafio(challenges, utils);

            //Questão - 2
            segundoDesafio(challenges, utils);

            //Questão - 3
            terceiroDesafio(challenges, utils);

            //Questão - 4
            quartoDesafio(challenges, utils);

            //Questão - 5
            quintoDesafio(challenges, utils);


            Console.WriteLine("Estou aberto a críticas e sugestões");
            Console.WriteLine("FIM Aperte enter para fechar");
        }

        private static void quintoDesafio(Challenges challenges, Utils utils)
        {
            string palavraFixa = "UmaPalavraTeste";
            string resultado = "";

            Console.WriteLine($"Questão 5");
            utils.pulaLinha();

            Console.WriteLine($"Gostaria de passar alguma frase para inverter ?  S ou N");
            utils.pulaLinha();
            string resposta = Console.ReadLine();


            if (resposta.ToUpper() == "S")
            {
                Console.WriteLine("Digite a palavra para ocorrer a inversão");
                var palavra = Console.ReadLine();

                resultado = challenges.inverteCaracteres(palavra);

                utils.pulaLinha();
                Console.WriteLine($"A palavra usada foi {palavra} e o retorno foi {resultado}");
            }
            else if (resposta.ToUpper() == "N")
            {

                utils.pulaLinha();
                Console.WriteLine($"Ok, Vou usar ' UmaPalavraTeste ' como exemplo");

                resultado = challenges.inverteCaracteres(palavraFixa);

                utils.pulaLinha();
                Console.WriteLine($"A palavra usada foi {palavraFixa} e o retorno foi {resultado}");
            }
            else
            {
                Console.WriteLine("Eita, acho que você errou, tenta de novo por favor!");
            }
        }

        private static void quartoDesafio(Challenges challenges, Utils utils)
        {
            Console.WriteLine($"Questão 4");
            utils.pulaLinha();

            List<DadosDistribuidoraPorEstadoDTO> dadosDistribuidoraPorEstadoDTO = challenges.percentualEstados();

            int count = dadosDistribuidoraPorEstadoDTO.Count;

            Console.WriteLine("Segue analise do faturamento por estados");
            utils.pulaLinha();

            foreach (var item in dadosDistribuidoraPorEstadoDTO.OrderByDescending(x => x.Porcentagem))
            {
                if (count > 1)
                {
                    Console.WriteLine($"O Estado de {item.Estado} tem um percetual de {item.Porcentagem} no valor mensal da distribuidora");
                    utils.pulaLinha();
                    count--;
                }
                else
                {
                    Console.WriteLine($"{item.Estado} Estados tem um percetual de {item.Porcentagem} no valor mensal da distribuidora");
                    count--;
                }
            }

            utils.pulaLinha();
            Console.WriteLine("Aperte enter para o proximo desafio");

            utils.pulaLinha();
            Console.ReadLine();
        }

        private static void terceiroDesafio(Challenges challenges, Utils utils)
        {
            Console.WriteLine($"Questão 3");
            utils.pulaLinha();

            FaturamentoDistribuidoraDTO faturamento = challenges.faturamentoDiarioDistribuidora();

            Console.WriteLine($"Apos analisar o arquivo segue dados");
            Console.WriteLine($"Maior Faturamento : {faturamento.MaiorFatumento}");
            Console.WriteLine($"Menor Faturamento : {faturamento.MenorFaturamento}");
            Console.WriteLine($"Quantidade de dias que o faturamento diário foi superior à média mensal : {faturamento.DiasAcimaDaMedia}");

            utils.pulaLinha();
            Console.WriteLine("Aperte enter para o proximo desafio");

            utils.pulaLinha();
            Console.ReadLine();
        }

        private static void segundoDesafio(Challenges challenges, Utils utils)
        {
            bool fibonacci = false;
            int valorFib = 13;
            RetornoFibbonacciDTO resultado = new();

            Console.WriteLine($"Questão 2");
            Console.WriteLine($"Gostaria de passar algum valor para a sequencia Fibonnaci?  S ou N");
            utils.pulaLinha();

            string respostaFib = Console.ReadLine();

            while (fibonacci != true)
            {
                if (respostaFib.ToUpper() == "S")
                {
                    Console.WriteLine("Digite o valor para validar se pertence a sequencia de Fibonacci");
                    var valorFibString = Console.ReadLine();
                    bool tryParse = int.TryParse(valorFibString, out valorFib);
                    bool igualMaiorZero = valorFib >= 0 ? true : false;

                    if (tryParse == true && igualMaiorZero == true)
                    {
                        resultado = challenges.sequenciaFibonacci(valorFib);
                        fibonacci = true;
                    }
                    else
                    {
                        Console.WriteLine("Eita, acho que voce passou um valor que não é um int ou é menor que 0!! tenta de novo");
                    }
                }
                else if (respostaFib.ToUpper() == "N")
                {

                    utils.pulaLinha();
                    Console.WriteLine($"Ok, Vou usar o valor 13 como exemplo");

                    resultado = challenges.sequenciaFibonacci(valorFib);
                    fibonacci = true;
                }
                else
                {
                    Console.WriteLine("Eita, acho que você errou, tenta de novo por favor!");
                }
            }

            if (resultado.Resultado == true)
            {
                utils.pulaLinha();
                Console.WriteLine($"A partir do valor inicial 1 o valor {valorFib} pertence a sequencia de Fibbonacci apos ser calculado {resultado.qtdExecutado} vezes!!");
                utils.pulaLinha();
            }
            else
            {
                utils.pulaLinha();
                Console.WriteLine($"Valor não pertence a Fibonacci");
            }

            Console.WriteLine("Aperte enter para o proximo desafio");
            utils.pulaLinha();
            Console.ReadLine();

        }

        private static void primeiroDesafio(Challenges challenges, Utils utils)
        {

            Console.WriteLine($"Questão 1");
            utils.pulaLinha();

            int SomaK = challenges.retornoSomaK();

            Console.WriteLine($"Resultado de SomaK é {SomaK}");
            Console.WriteLine("Aperte enter para o proximo desafio");
            utils.pulaLinha();
            Console.ReadLine();
        }
    }
}