using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using myMLApp.Entities;

namespace myMLApp.Logics
{
    public class ReadUserLogic
    {
        protected MLContext mlContext;
        public ReadUserLogic(MLContext context)
        {
            this.mlContext = context;
        }

        public void ReadKeyboard(TransformerChain<KeyToValueMappingTransformer> model)
        {
            Console.WriteLine("Ingrese la letra s para salir...");
            bool cicle = true;
            while (cicle)
            {
                var option = ValidateInput();
                if (option.ToUpper() == "S")
                {
                    cicle = false;
                }
                else
                {
                    float valueUser = float.Parse(option);


                    var prediction = mlContext.Model.CreatePredictionEngine<DataEntity, DataPredictionEntity>(model).Predict(
                        new DataEntity()
                        {
                            Num = valueUser
                        });

                    Console.WriteLine($"Tipo predecido: {prediction.PredictedLabels}");
                }
            }
        }

        private string ValidateInput()
        {
            var option = string.Empty;
            bool cicle = true;
            while (cicle)
            {
                Console.WriteLine("Ingrese valor");
                option = Console.ReadLine().ToUpper();

                if (option.Equals("S"))
                {
                    cicle = false;
                }
                else
                {
                    try
                    {
                        float.Parse(option);
                        cicle = false;
                    }
                    catch
                    {
                        Console.WriteLine("Parametro ingresado incorrecto");
                    }
                }
            }

            return option;
        }
    }
}