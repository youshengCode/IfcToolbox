using IfcToolbox.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IfcToolbox.Core.Convert
{
    public class ConvertOptionService
    {
        public static string GeneratePrompt(IConvertOptionsWrap config, ConvertTargetFormat format, string logFilePath = null, bool autoYes = true)
        {
            var valueDic = ReflectionUtility.DictionaryFromType(config);
            var filtedValueDic = new Dictionary<string, object>();
            foreach (var item in valueDic)
            {
                if (item.Value == null)
                    continue;
                if (bool.TryParse(item.Value.ToString(), out bool value))
                {
                    if (value)
                        filtedValueDic.Add(item.Key, item.Value);
                }
                else
                {
                    if (item.Value.ToString() != null)
                        filtedValueDic.Add(item.Key, item.Value);
                }
            }
            valueDic = filtedValueDic;

            if (!valueDic.Any())
                return string.Empty;

            List<string> prompts = new List<string>();
            var supportedOptions = SupportedOptions();
            AddOptions(supportedOptions);
            if (!string.IsNullOrEmpty(logFilePath))
            {
                prompts.Add("--log-file");
                prompts.Add($"\"{logFilePath}\"");
            }
            if (autoYes)
                prompts.Add("-y");
            AddPostOptions(supportedOptions);

            var result = string.Join(" ", prompts.ToArray());
            return result;

            void AddOptions(IList<IConvertOption> options)
            {
                foreach (var item in options)
                    if (valueDic.Keys.Contains(item.Name))
                    {
                        if (item.IsFormatRelated && !item.RelatedFormats.Contains(format))
                            continue;
                        if (item.IsPostOption)
                            continue;
                        if (!item.HasArgs)
                            prompts.Add(item.CItext);
                        else
                            prompts.Add($"{item.CItext} {valueDic[item.Name]}");
                    }
            }
            void AddPostOptions(IList<IConvertOption> options)
            {
                foreach (var item in options)
                    if (valueDic.Keys.Contains(item.Name))
                    {
                        if (item.IsFormatRelated && !item.RelatedFormats.Contains(format))
                            continue;
                        if (item.IsPostOption)
                        {
                            if (!item.HasArgs)
                                prompts.Add(item.CItext);
                            else
                                prompts.Add($"{item.CItext} {valueDic[item.Name]}");
                        }
                    }
            }
        }

        public static List<IConvertOption> SupportedOptions()
        {
            List<IConvertOption> options = new List<IConvertOption>();

            // General 
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("Plan", "--plan"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("Model", "--model"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("WeldVertices", "--weld-vertices"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("UseWorldCoords", "--use-world-coords"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("ConvertBackUnits", "--convert-back-units"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("OrientShells", "--orient-shells"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("CenterModel", "--center-model"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("CenterModelGeometry", "--center-model-geometry"));

            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("DisableOpeningSubtractions", "--disable-opening-subtractions"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("DisableBooleanResults", "--disable-boolean-results"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("EnableLayersetSlicing", "--enable-layerset-slicing"));
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("LayersetFirst", "--layerset-first"));

            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("IncludeEntities", "--include entities", true).RegistAsPostOption());
            options.Add(ConvertOptionFactory.CreateGeneralConvertOption("ExcludeEntities", "--exclude entities", true).RegistAsPostOption());

            // Format specific
            options.Add(ConvertOptionFactory.CreateConvertOption("UseElementHierarchy", "--use-element-hierarchy", ConvertTargetFormat.DAE)); // Root
            options.Add(ConvertOptionFactory.CreateConvertOption("UseElementTypes", "--use-element-types", ConvertTargetFormat.DAE)); // Order0
            options.Add(ConvertOptionFactory.CreateConvertOption("UseElementGuids", "--use-element-guids", ConvertTargetFormat.OBJ, ConvertTargetFormat.DAE, ConvertTargetFormat.SVG)); // Order1
            options.Add(ConvertOptionFactory.CreateConvertOption("UseElementNames", "--use-element-names", ConvertTargetFormat.OBJ, ConvertTargetFormat.DAE, ConvertTargetFormat.SVG)); // Order2
            options.Add(ConvertOptionFactory.CreateConvertOption("UseElementNumericIds", "--use-element-numeric-ids", ConvertTargetFormat.OBJ, ConvertTargetFormat.DAE, ConvertTargetFormat.SVG)); // Order3
            options.Add(ConvertOptionFactory.CreateConvertOption("UseMaterialNames", "--use-material-names", ConvertTargetFormat.OBJ, ConvertTargetFormat.DAE)); // Order4
            options.Add(ConvertOptionFactory.CreateConvertOption("SiteLocalPlacement", "--site-local-placement", ConvertTargetFormat.OBJ, ConvertTargetFormat.DAE));
            options.Add(ConvertOptionFactory.CreateConvertOption("BuildingLocalPlacement", "--building-local-placement", ConvertTargetFormat.OBJ, ConvertTargetFormat.DAE));
            options.Add(ConvertOptionFactory.CreateConvertOption("YUp", "--y-up", ConvertTargetFormat.OBJ));

            options.Add(ConvertOptionFactory.CreateConvertOption("AutoSection", "--auto-section", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("AutoElevation", "--auto-elevation", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("SectionHeightFromStorey", "--section-height-from-storeys", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("SvgXmlns", "--svg-xmlns", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("SvgPoly", "--svg-poly", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("SvgProject", "--svg-project", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("DoorArcs", "--door-arcs", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("PrintSpaceNames", "--print-space-names", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("PrintSpaceAreas", "--print-space-areas", ConvertTargetFormat.SVG));
            options.Add(ConvertOptionFactory.CreateConvertOption("Bounds", "--bounds", ConvertTargetFormat.SVG, true));
            return options;
        }
    }
}
