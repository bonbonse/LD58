using System.Collections;
using UnityEngine;

namespace Ludum.Scrimer
{
    public class ScrimerMity : MonoBehaviour
    {
        [Header("��������� ��������")]
        [SerializeField] private float moveSpeed = 2f; // �������� ��������
        [SerializeField] private float lifeTime = 5f; // ����� �����
        private bool _run = false;

        // ��������� ��������
        public void On()
        {
            _run = true;

        }
        private void Update()
        {
            if (_run) 
            {
                // �������� ������ �� ��� X � ���������� ���������
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

