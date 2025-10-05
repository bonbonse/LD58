using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ludum.UI
{
    public class MenuUI : MonoBehaviour
    {

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
    }
}
