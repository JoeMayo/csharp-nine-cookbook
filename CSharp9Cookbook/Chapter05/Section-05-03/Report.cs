using System;
using System.Collections.Generic;

namespace Section_05_03
{
    public class Report<TData>
    {
        public string Generate(List<TData> items, ReportType reportType)
        {
            GeneratorBase<TData> generator = CreateGenerator(reportType);

            string report = generator.Generate(items);

            return report;
        }

        GeneratorBase<TData> CreateGenerator(ReportType reportType)
        {
            Type generatorType;

            switch (reportType)
            {
                case ReportType.Html:
                    generatorType = typeof(HtmlGenerator<>);
                    break;
                case ReportType.Markdown:
                    generatorType = typeof(MarkdownGenerator<>);
                    break;
                default:
                    throw new ArgumentException(
                        $"Unexpected ReportType: '{reportType}'");
            }

            Type dataType = typeof(TData);
            Type genericType = generatorType.MakeGenericType(dataType);

            object generator = Activator.CreateInstance(genericType);

            return (GeneratorBase<TData>)generator;
        }

        //GeneratorBase<TData> CreateGenerator(ReportType reportType)
        //{
        //    Type dataType = typeof(TData);

        //    string generatorNamespace = "Section_05_03.";
        //    string generatorTypeName = $"{reportType}Generator`1";
        //    string typeParameterName = $"[[{dataType.FullName}]]";

        //    string fullyQualifiedTypeName =
        //        generatorNamespace +
        //        generatorTypeName +
        //        typeParameterName;

        //    Type generatorType = Type.GetType(fullyQualifiedTypeName);

        //    object generator = Activator.CreateInstance(generatorType);

        //    return (GeneratorBase<TData>) generator;
        //}
    }
}
