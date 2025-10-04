namespace Ludum.Localization
{
    public class LanguageRU : Language
    {
        public override string GetText(Dialog dialog)
        {
            switch (dialog)
            {
                case Dialog.Test: return "Тест";

                default: return "";
            }
        }
    }
}


