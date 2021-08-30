using IfcToolbox.Core.Editors;
using System.Collections.Generic;

namespace IfcToolbox.Tools.Configurations
{
    public class ConfigAnonymize : IConfigAnonymize
    {
        public bool KeepLabel { get; set; }
        public bool DeleteOld { get; set; } = true;
        public bool LogDetail { get; set; }

        public bool AnonymeUserInfo { get; set; }
        public bool RemovePostalAddress { get; set; }
        public bool RemoveTelecomAddress { get; set; }

        public bool RemoveActorRole { get; set; }
        public bool RemovePerson { get; set; }
        public bool RemoveOrganization { get; set; }
        public bool RemovePersonAndOrganization { get; set; }

        public bool RemoveApplication { get; set; }
        public bool ClearHeaderFileName { get; set; }

        public bool AnonymeProductInfo { get; set; }
        public IEnumerable<AnonymeRule> Rules { get; set; }
        public bool ReplaceInName { get; set; } = true;
        public bool ReplaceInObjectType { get; set; } = true;
        public bool ReplaceInTypeProps { get; set; } = true;
        public bool ReplaceInProductProps { get; set; } = true;

        public string Suffix { get; set; } = "Anonymized";

        public void ReplaceAllInProductInfo()
        {
            ReplaceInName = true;
            ReplaceInObjectType = true;
            ReplaceInTypeProps = true;
            ReplaceInProductProps = true;
        }
        public void RemoveAllUserInfo()
        {
            RemovePostalAddress = true;
            RemoveTelecomAddress = true;
            RemoveActorRole = true;
            RemovePerson = true;
            RemoveOrganization = true;
            RemovePersonAndOrganization = true;
            RemoveApplication = true;
            ClearHeaderFileName = true;
        }
    }
}
