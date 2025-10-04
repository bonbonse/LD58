using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ludum.UI
{
    public class MenuUI : MonoBehaviour
    {

        /**
         * Обработчик нажатия на Играть
         */
        public void PlayBtnClick()
        {
            SceneManager.LoadScene("MainScene");
        }
        /**
         * Выход из игры
         */
        public void QuitBtnClick()
        {
            Application.Quit();
        }
    }
}
