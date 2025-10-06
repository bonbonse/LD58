using UnityEngine;

namespace Ludum.Localization
{
    public class LanguageEN : Language
    {
        public override string GetText(Dialog dialog)
        {
            switch (dialog)
            {
                case Dialog.Test: return "TEST";
                case Dialog.Test2: return "TEST2";
                case Dialog.BichDialog1: return "Oh, new guy! It's been a while since I've seen anyone. Let's get acquainted, I'm this... what's his name... a man of peace, in short. It's peaceful here, I'll give you a flashlight now. [Space to continue]";
                case Dialog.BichDialog2: return "Oh, and what the hell is this Panakaka??? I have to go, let's do it somehow, the flashlight is by the trash bin, try to find it, I'm going [Space to continue]";
                case Dialog.PressE: return "Press E";
                case Dialog.PressSpaceForContinue: return "Press Space for continue";

                default: return "";
            }
        }
    }
}


