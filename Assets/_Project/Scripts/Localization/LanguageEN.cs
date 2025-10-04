using UnityEngine;

namespace Ludum.Localization
{
    public class LanguageEN : Language
    {
        public override string GetText(Dialog dialog)
        {
            switch (dialog)
            {
                case Dialog.Test: return "Test";

                default: return "";
            }
        }
    }
}


