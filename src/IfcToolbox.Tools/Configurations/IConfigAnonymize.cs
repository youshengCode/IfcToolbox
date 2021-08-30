using IfcToolbox.Core.Editors;
using System.Collections.Generic;

namespace IfcToolbox.Tools.Configurations
{
    public interface IConfigAnonymize : IConfigBase
    {
        bool AnonymeUserInfo { get; set; }
        bool RemovePostalAddress { get; set; }
        bool RemoveTelecomAddress { get; set; }

        bool RemoveActorRole { get; set; }
        bool RemovePerson { get; set; }
        bool RemoveOrganization { get; set; }
        bool RemovePersonAndOrganization { get; set; }

        bool RemoveApplication { get; set; }
        bool ClearHeaderFileName { get; set; }

        bool AnonymeProductInfo { get; set; }
        IEnumerable<AnonymeRule> Rules { get; set; }
        bool ReplaceInName { get; set; }
        bool ReplaceInObjectType { get; set; }
        bool ReplaceInTypeProps { get; set; }
        bool ReplaceInProductProps { get; set; }

        void ReplaceAllInProductInfo();
        void RemoveAllUserInfo();
    }
}
