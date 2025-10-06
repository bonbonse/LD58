using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ludum.Manager;
using Ludum.Localization;

public class ExitToMenuZone : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    private bool isInExitZone = false;
	[SerializeField] TextMeshProUGUI hintText;
    
    void Update()
    {
        // Проверяем, находится ли игрок в зоне и нажата ли E
        if (isInExitZone && Input.GetKeyDown(KeyCode.E))
        {
            LoadMenu();
			
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Проверяем, что вошел игрок
        if (other.CompareTag("Player"))
        {
            isInExitZone = true;
            // Можно добавить UI подсказку
            SubtitleManager.HelpMessage(Dialog.PressE);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInExitZone = false;
            // Убрать UI подсказку
            SubtitleManager.ShowHelp(false);
        }
    }
    
    void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
		SceneManager.LoadScene(menuSceneName);
    }
}
