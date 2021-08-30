using System.Collections.Generic;

namespace IfcToolbox.Tools.Configurations
{
    public interface IConfigSplit : IConfigBase
    {
        SplitStrategy SplitStrategy { get; set; }
        IEnumerable<string> SelectedItems { get; set; }

        string BuildingStoreyPlaceholder { get; set; }
        string BuildingPlaceholder { get; set; }
        string SitePlaceholder { get; set; }
    }
}
