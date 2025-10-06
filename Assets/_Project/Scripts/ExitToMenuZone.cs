using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
            hintText.text = "[Press E to exit]";
            // Можно добавить UI подсказку
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInExitZone = false;
            hintText.text = "";
            // Убрать UI подсказку
        }
    }
    
    void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
		SceneManager.LoadScene(menuSceneName);
    }
}
