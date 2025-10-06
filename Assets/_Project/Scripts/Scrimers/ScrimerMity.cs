using System.Collections;
using UnityEngine;

namespace Ludum.Scrimer
{
    public class ScrimerMity : MonoBehaviour
    {
        [Header("Настройки движения")]
        [SerializeField] private float moveSpeed = 2f; // Скорость движения
        [SerializeField] private float lifeTime = 5f; // Время жизни
        private bool _run = false;

        // Включение скримера
        public void On()
        {
            _run = true;

        }
        private void Update()
        {
            if (_run) 
            {
                // Движение вперед по оси X с постоянной скоростью
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }


    }
}

