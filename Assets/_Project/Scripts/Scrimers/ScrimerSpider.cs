using UnityEngine;
using System.Collections;

namespace Ludum.Scrimer 
{
    public class ScrimerSpider : MonoBehaviour
    {
        public GameObject scrimerGb;
        [SerializeField] private float moveSpeed = 2f; // Скорость движения
        [SerializeField] private float lifeTime = 5f; // Время жизни

        private bool scrimerOn = false;

        private void Start()
        {
            scrimerOn = false;
            if (scrimerGb == null)
            {
                scrimerGb = GetComponentInChildren<GameObject>();
                if (scrimerGb == null)
                {
                    Debug.LogError("Паук не проинициализирован как скример");
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                gameObject.GetComponent<Collider>().enabled = false;
                scrimerGb.SetActive(true);
                scrimerOn = true;
                StartCoroutine(WaitAndDestroy());
            }
        }
        private void Update()
        {
            if (scrimerOn)
            {
                // Движение вперед по оси X с постоянной скоростью
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(scrimerGb);
        }
    }

}
