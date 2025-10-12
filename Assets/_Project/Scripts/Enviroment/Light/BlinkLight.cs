using System.Collections;
using UnityEngine;

namespace Ludum.Enviroment.LightEnv
{
    public class BlinkLight : MonoBehaviour
    {
        [SerializeField] private float maxTime = 3f;
        private Light _light = null;
        private bool isActive = true;
        private void Start()
        {
            _light = GetComponent<Light>();
            StartCoroutine(WaitAndTurn());
        }
        
        IEnumerator WaitAndTurn()
        {
            yield return new WaitForSeconds(GetRandomTime());
            _light.enabled = isActive;
            isActive = !isActive;
            StartCoroutine(WaitAndTurn());
        }

        private float GetRandomTime()
        {
            return Random.Range(0.0f, maxTime);
        }
    }

}
