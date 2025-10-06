using Ludum.Localization;
using System.Collections;
using UnityEngine;

namespace Ludum.Manager
{
    public class SubtitleManager : MonoBehaviour
    {
        // Singleton
        private static SubtitleManager _instance;
        // default time to wait and clear subtitle
        private float _defaultLifeTimeSubtitle = 4f;

        private Language _language = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _subtitleTMPro;
        [SerializeField]
        private TMPro.TextMeshProUGUI _helpTMPro;

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
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            int languageNumber = PlayerPrefs.GetInt("language_number");
            if (languageNumber == Language.LanguageEN)
            {
                // English
                _language = new LanguageEN();
            }
            else
            {
                // Rus
                _language = new LanguageRU();
            }
            ShowHelp(false);
            ShowSubtitle(false);
        }

        /**
         * Show Subtitle
         */
        public static void ShowSubtitle(bool show)
        {
            Instance._subtitleTMPro.gameObject.SetActive(show);
        }
        /**
         * Show Subtitle
         */
        public static void HelpMessage(Dialog dialog)
        {
            ShowHelp(true);
            string text = Instance._language.GetText(dialog);
            Instance._helpTMPro.SetText(text);
        }
        /**
         * Add subtitle
         * Change subtitle text and show
         * @TODO когда сделаем в меню кнопку смены языков - добавить здесь код на смену
         */
        public static void Say(Dialog dialog)
        {
            string text = Instance._language.GetText(dialog);
            Instance._subtitleTMPro.SetText(text);
            Instance.StopAllCoroutines();
            ShowSubtitle(true);
            Instance.StartCoroutine(Instance.WaitAndHideSubtitle(Instance._defaultLifeTimeSubtitle));
        }
        /**
        * Add subtitle
        * Change subtitle text and show
        * @TODO когда сделаем в меню кнопку смены языков - добавить здесь код на смену
        */
        public static void Say(Dialog dialog, float time)
        {
            string text = Instance._language.GetText(dialog);
            Instance._subtitleTMPro.SetText(text);
            Instance.StopAllCoroutines();
            ShowSubtitle(true);
            Instance.StartCoroutine(Instance.WaitAndHideSubtitle(time));
        }

        /**
         * Wait and Delete Subtitle
         */
        private IEnumerator WaitAndHideSubtitle(float time)
        {
            yield return new WaitForSeconds(time);
            ShowSubtitle(false);
        }
        /**
         * show help or hide
         */
        public static void ShowHelp(bool show)
        {
            Instance._helpTMPro.gameObject.SetActive(show);
        }
    }
}

