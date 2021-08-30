using IfcToolbox.Core.Convert;

namespace IfcToolbox.Tools.Configurations
{
    public static class ConfigFactory
    {
        /// <summary>
        ///  keepLabel - Conserve old entity label.
        ///  DeleteOld - Reorder all entity label and remove unused entity. (Performance related)
        ///  LogDetail - Log process details in console mode (Performance related)
        /// </summary>
        public static IConfigBase CreateConfigBase(bool keepLabel = false, bool deleteOld = true, bool logDetail = false)
        {
            var config = new ConfigBase();
            config.KeepLabel = keepLabel;
            config.DeleteOld = deleteOld;
            config.LogDetail = logDetail;
            return config;
        }

        public static IConfigOptimize CreateConfigOptimize()
        {
            return new ConfigOptimize();
        }

        public static IConfigRelocate CreateConfigRelocate()
        {
            return new ConfigRelocate();
        }

        public static IConfigSplit CreateConfigSplit()
        {
            return new ConfigSplit();
        }

        public static IConfigConvert CreateConfigConvert(IConvertOptionsWrap convertOptions, ConvertTargetFormat targetFormat)
        {
            var config = new ConfigConvert();
            config.ConvertOptions = convertOptions;
            config.TargetFormat = targetFormat;
            return config;
        }

        public static IConfigAnonymize CreateConfigAnonymize()
        {
            return new ConfigAnonymize();
        }
    }
}
