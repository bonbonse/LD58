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
                case Dialog.BichDialog1: return "�, ���������! ����� �� ����� �����. ����� �������, � ����.. ��� ��� ���.. ������� ���� ������. ��� � ��� �����, �� ������� ���� ��� [������, ����� ����������]";
                case Dialog.BichDialog2: return "�, � ��� �� �� ��������??? ��� ����, ����� ��� ��� ���-������, ������� � �������, ���������� �����, � �����[������, ����� ����������]";
                case Dialog.PressE: return "������� E";
                case Dialog.PressSpaceForContinue: return "������� ������ ����� ����������";

                default: return "";
            }
        }
    }
}


