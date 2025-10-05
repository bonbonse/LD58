namespace Ludum.Localization
{
    public class LanguageRU : Language
    {
        public override string GetText(Dialog dialog)
        {
            switch (dialog)
            {
                case Dialog.Test: return "Тест";
                case Dialog.Test2: return "Тест2";

                default: return "";
            }
        }
    }
}


