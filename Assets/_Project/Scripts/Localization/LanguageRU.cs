namespace Ludum.Localization
{
    public class LanguageRU : Language
    {
        public override string GetText(Dialog dialog)
        {
            switch (dialog)
            {
                case Dialog.Test: return "����";
                case Dialog.Test2: return "����2";

                default: return "";
            }
        }
    }
}


