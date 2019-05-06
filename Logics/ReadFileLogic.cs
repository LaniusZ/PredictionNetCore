using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using myMLApp.Entities;

namespace myMLApp.Logics
{
    public class ReadFileLogic
    {
        protected MLContext mlContext;
        protected string fileName;
        public ReadFileLogic(MLContext context, string fileName)
        {
            this.mlContext = context;
            this.fileName = fileName;
        }

        /*
         * Metodo que lee, y prepara el modelo de aprendimiento
         */
        public TransformerChain<KeyToValueMappingTransformer> ReadAndPrepareML()
        {
            var trainingData = ReadFile();

            var pipeline = TransformDataToLearn();

            return TrainModel(pipeline, trainingData);
        }

        /*
         * Verificar si el archivo existe y se puede leer
         */ 
        private void FileExist()
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("Error File not Exist: " + fileName);
            }
        }

        /*
         * Leer el archivo y cargar el diccionario dento del modelo de entrenamiento
         */
        private IDataView ReadFile()
        {
            FileExist();
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<DataEntity>(path: fileName, hasHeader: false, separatorChar: ',');
            return trainingDataView;
        }

        /*
         * Transforma tus datos y agrega un aprendiz
         * Asignar valores numéricos al texto en la columna "LAbel", porque solo
         * Los números pueden ser procesados durante el entrenamiento modelo.
         */
        private EstimatorChain<KeyToValueMappingTransformer> TransformDataToLearn()
        {
            return mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Concatenate("Features", "Num"))
                .AppendCacheCheckpoint(mlContext)
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
        }


        /*
         * Entrenar el modelo en base al diccionario
         */
        private TransformerChain<KeyToValueMappingTransformer> TrainModel(EstimatorChain<KeyToValueMappingTransformer> pipeline, IDataView trainingDataView)
        {
            return pipeline.Fit(trainingDataView);
        }

    }
}
