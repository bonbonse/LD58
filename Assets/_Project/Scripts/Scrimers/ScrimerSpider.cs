using UnityEngine;
using System.Collections;

namespace Ludum.Scrimer 
{
    public class ScrimerSpider : MonoBehaviour
    {
        public GameObject scrimerGb;
        [SerializeField] private float moveSpeed = 2f; // �������� ��������
        [SerializeField] private float lifeTime = 5f; // ����� �����

        private bool scrimerOn = false;

        private void Start()
        {
            scrimerOn = false;
            if (scrimerGb == null)
            {
                scrimerGb = GetComponentInChildren<GameObject>();
                if (scrimerGb == null)
                {
                    Debug.LogError("���� �� ������������������ ��� �������");
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
                // �������� ������ �� ��� X � ���������� ���������
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
