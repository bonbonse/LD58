using UnityEngine;

namespace Ludum.Manager
{
    public class SubtitleManager : MonoBehaviour
    {
        // Singleton
        private static SubtitleManager _instance;

        [SerializeField]
        private TMPro.TextMeshProUGUI _subtitleTMPro;

        // Singleton
        public static SubtitleManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindGameObjectWithTag("SubtitleManager").GetComponent<SubtitleManager>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(SubtitleManager).Name;
                        _instance = obj.AddComponent<SubtitleManager>();
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

        /**
         * Show Subtitle
         */
        public static void ShowSubtitle(bool show)
        {
            Instance._subtitleTMPro.gameObject.SetActive(show);
        }
        /**
         * Change subtitle text and show
         */
    }
}

