namespace IfcToolbox.Core.Editors
{
    public class AnonymeRule
    {
        public AnonymeRule(string expressTypeName, string keyword, string replacement)
        {
            ExpressTypeName = expressTypeName;
            Keyword = keyword;
            Replacement = replacement;
        }

        public string ExpressTypeName { get; set; }
        public string Keyword { get; set; }
        public string Replacement { get; set; }
    }
}
