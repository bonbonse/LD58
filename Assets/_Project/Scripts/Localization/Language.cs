namespace Ludum.Localization
{
    public abstract class Language
    {
        public static int LanguageRU { get => 0; }
        public static int LanguageEN { get => 1; }
        public abstract string GetText(Dialog dialog);
    }
}
