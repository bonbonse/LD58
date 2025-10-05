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
                case Dialog.BichDialog1: return "О, новенький! Давно не видел людей. Будем знакомы, я этот.. как там его.. человек мира короче. Тут у нас мирно, ща фанарик тебе дам [Пробел, чтобы продолжить]";
                case Dialog.BichDialog2: return "О, а это че за Панакака??? Мне пора, давай тут сам как-нибудь, фонарик у мусорке, постарайся найти, я пошел[Пробел, чтобы продолжить]";

                default: return "";
            }
        }
    }
}


