using Ludum.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ludum.UI
{
    public class MenuUI : MonoBehaviour
    {
        int currentLanguageNumber = Language.LanguageEN;
        public TMPro.TextMeshProUGUI PlayTMPro;
        public TMPro.TextMeshProUGUI ExitTMPro;
        public TMPro.TextMeshProUGUI LanguageTMPro;
        /**
         * ���������� ������� �� ������
         */
        public void PlayBtnClick()
        {
            SceneManager.LoadScene("FirstScene");
        }
        /**
         * ����� �� ����
         */
        public void QuitBtnClick()
        {
            Application.Quit();
        }
        /**
         * ������ ��������� �����
         */
        public void ChangeLanguage()
        {
            if (currentLanguageNumber == 0)
            {
                // en
                currentLanguageNumber = Language.LanguageEN;
                PlayTMPro.SetText("Play");
                ExitTMPro.SetText("Exit");
                LanguageTMPro.SetText("Language: English");
            }
            else
            {
                // ru
                currentLanguageNumber = Language.LanguageRU;
                PlayTMPro.SetText("������");
                ExitTMPro.SetText("�����");
                LanguageTMPro.SetText("Language: �������");
            }
            PlayerPrefs.SetInt("language_number", currentLanguageNumber);
        }

    }
}
