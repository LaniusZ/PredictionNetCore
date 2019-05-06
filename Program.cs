using Microsoft.ML;
using myMLApp.Logics;
using System;

namespace myMLApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MLContext mlContext = new MLContext();

                ReadFileLogic readFileLogic = new ReadFileLogic(mlContext, "data.txt");
                var model = readFileLogic.ReadAndPrepareML();

                ReadUserLogic readUserLogic = new ReadUserLogic(mlContext);
                readUserLogic.ReadKeyboard(model);

                Console.WriteLine("Press any key to exit....");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}