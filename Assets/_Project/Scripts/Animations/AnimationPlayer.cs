using System.Collections;
using UnityEngine;

namespace Ludum.Animations 
{
    public class AnimationPlayer : MonoBehaviour
    {
        public float DeltaTime = 0.01f;
        public bool Loop = true;

        protected Material targetMaterial;
        public Texture2D[] sprites;

        public MeshRenderer meshRenderer;

        private int currentIndex = 0;

        void Start()
        {
            if (meshRenderer == null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }
            // ≈сли материал не назначен в инспекторе, берем из рендерера
            if (targetMaterial == null)
            {
                targetMaterial = meshRenderer.materials[0];
            }
            StartAnimation();
        }


        public void StartAnimation()
        {
            currentIndex = 0;
            StartCoroutine(WaitAndNextSprite());
        }

        // ћетод дл€ смены по индексу из массива
        public void ChangeSpriteByIndex(int index)
        {
            if (sprites != null && index >= 0 && index < sprites.Length)
            {
                targetMaterial.mainTexture = sprites[index];
            }
        }

        protected IEnumerator WaitAndNextSprite()
        {
            yield return new WaitForSeconds(DeltaTime);
            if (currentIndex >= sprites.Length)
            {
                if (Loop)
                {
                    currentIndex = 0;
                }
                else
                {
                    ChangeSpriteByIndex(0);
                    yield return null;
                }
            }
            currentIndex++;
            ChangeSpriteByIndex(currentIndex);
            Debug.Log(currentIndex);
            StartCoroutine(WaitAndNextSprite());

        }
    }
}

