using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ludum.Animations
{
    public class AnimationBySprites : MonoBehaviour
    {
        public float DeltaTime = 0;

        public Material targetMaterial;
        public Texture2D[] sprites;

        public MeshRenderer meshRenderer;

        private int currentIndex = 0;

        void Start()
        {
            //if (meshRenderer == null)
            //{
            //    meshRenderer = GetComponent<MeshRenderer>();
            //}
            //// ≈сли материал не назначен в инспекторе, берем из рендерера
            //if (targetMaterial == null)
            //{
            //    targetMaterial = meshRenderer.materials[0];
            //}
            //StartAnimation();
        }


        public void StartAnimation()
        {
            //StartCoroutine(WaitAndNextSprite());
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
                currentIndex = 0;
            }
            ChangeSpriteByIndex(currentIndex);
            currentIndex++;
        }
    }
}

