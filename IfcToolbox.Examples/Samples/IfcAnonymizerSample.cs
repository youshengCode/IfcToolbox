using IfcToolbox.Core.Editors;
using IfcToolbox.Tools.Configurations;
using IfcToolbox.Tools.Processors;
using Serilog;
using System.Collections.Generic;

namespace IfcToolbox.Examples.Samples
{
    public class IfcAnonymizerSample
    {
        public static void AnonymizeUserInfo(string filePath)
        {
            Log.Information($"IfcAnonymizer - Start");
            IConfigAnonymize config = ConfigFactory.CreateConfigAnonymize();
            config.LogDetail = true;
            config.AnonymeUserInfo = true;
            config.RemoveAllUserInfo();
            AnonymizerProcessor.Process(filePath, config, true);
        }

        public static void AnonymizeProductInfoWithRules(string filePath)
        {
            Log.Information($"IfcAnonymizer - Start");
            IConfigAnonymize config = ConfigFactory.CreateConfigAnonymize();
            config.LogDetail = true;
            config.AnonymeProductInfo = true;
            config.ReplaceAllInProductInfo();
            List<AnonymeRule> rules = new List<AnonymeRule>();
            rules.Add(new AnonymeRule("IfcFurniture", "Furniture_Couch_Viper", "Unknown"));
            rules.Add(new AnonymeRule("IfcFurniture", "Furniture_Table_Dining_w", "Unknown"));
            config.Rules = rules;
            AnonymizerProcessor.Process(filePath, config, true);
        }
    }
}
