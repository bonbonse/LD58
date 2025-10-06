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
         * Обработчик нажатия на Играть
         */
        public void PlayBtnClick()
        {
            SceneManager.LoadScene("FirstScene");
        }
        /**
         * Выход из игры
         */
        public void QuitBtnClick()
        {
            Application.Quit();
        }
        /**
         * Кнопка изменения языка
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
                PlayTMPro.SetText("Играть");
                ExitTMPro.SetText("Выйти");
                LanguageTMPro.SetText("Language: Русский");
            }
            PlayerPrefs.SetInt("language_number", currentLanguageNumber);
        }

    }
}
