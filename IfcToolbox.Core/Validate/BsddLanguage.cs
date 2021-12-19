using IO.Swagger.Model;

namespace IfcToolbox.Core.Validate
{
    public class BsddLanguage
    {
        public BsddLanguage() { }
        public BsddLanguage(string displayName)
        {
            DisplayName = displayName;
        }
        public BsddLanguage(LanguageContractV1 language)
        {
            Name = language.Name;
            IsoCode = language.IsoCode;
            DisplayName = $"{language.Name} ({language.IsoCode})";
        }

        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string DisplayName { get; set; }
    }
}
