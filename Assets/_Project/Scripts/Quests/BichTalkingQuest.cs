using Ludum.Animations;
using Ludum.Localization;
using Ludum.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Ludum.Quest
{
    public class BichTalkingQuest : MonoBehaviour
    {
        private static BichTalkingQuest _instance;
        public static BichTalkingQuest Instance => _instance;

        public List<Dialog> dialogs = new List<Dialog>();
        public Texture2D[] sprites1 = null;
        public Texture2D[] sprites2 = null;
        public MeshRenderer bichMeshRenderer = null;

        private int currentSceneCount = 0;
        private int maxSceneCount = 1;

        private AnimationPlayer animPlayer = null;

        private List<Texture2D[]> allSprites = new List<Texture2D[]>();
        private float defaultTime = 150f;

        private void Start()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            if (bichMeshRenderer == null)
            {
                Debug.LogError("Ошибка: нету бомжа в квесте");
            }
            animPlayer = bichMeshRenderer.GetComponent<AnimationPlayer>();

            allSprites.Add(sprites1);
            allSprites.Add(sprites2);
        }
        // Точка входа
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                SphereCollider collider = GetComponent<SphereCollider>();
                collider.enabled = false;
                currentSceneCount = 0;
                CutSceneManager.StartBichTalkQuest();
            }
        }
        // return false, if this is last scene
        public bool NextScene()
        {
            if (currentSceneCount >= allSprites.Count)
            {
                return false;
            }
            SubtitleManager.Say(dialogs[currentSceneCount], defaultTime);
            animPlayer.StartAnimationWithNewSprites(allSprites[currentSceneCount]);
            currentSceneCount++;
            if (currentSceneCount > maxSceneCount)
            {
                return false;
            }

            return true;
        }
        public void DestroyBich()
        {
            animPlayer.gameObject.SetActive(false);
        }
    }

}
