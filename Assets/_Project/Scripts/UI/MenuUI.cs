using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ludum.UI
{
    public class MenuUI : MonoBehaviour
    {
        void Start()
        {

        }

        /**
         * ���������� ������� �� ������
         */
        public void PlayBtnClick()
        {
            SceneManager.LoadScene("MainScene");
        }
        /**
         * ����� �� ����
         */
        public void QuitBtnClick()
        {
            Application.Quit();
        }
    }
}
