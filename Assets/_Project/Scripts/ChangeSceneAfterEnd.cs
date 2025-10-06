using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterEnd : MonoBehaviour
{
    public float animationDuration = 3f;
    
    void Start()
    {
        StartCoroutine(LoadSceneAfterAnimation());
    }
    
    IEnumerator LoadSceneAfterAnimation()
    {
        // Ждем завершения анимации
        yield return new WaitForSeconds(animationDuration);
        
        // Загружаем сцену
        SceneManager.LoadScene("MainScene");
    }
}
