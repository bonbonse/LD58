using UnityEngine;

namespace Ludum.Manager
{
    public class GameManager : MonoBehaviour
    {
        // Singleton
        private static GameManager _instance;

        public bool IsFreeMovementState = true;

        // Singleton
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(GameManager).Name;
                        _instance = obj.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        // Methods


    }
}

