using System.Collections.Generic;

namespace SolarisRec.UI.UIModels
{
    public class ValidationResult
    {
        public List<string> Reasons { get; set; } = new List<string>();

        public bool IsDeckInvalid => Reasons.Count > 0;
    }
}