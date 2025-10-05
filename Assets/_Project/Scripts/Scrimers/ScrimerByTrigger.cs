using Ludum.Animations;
using UnityEngine;

namespace Ludum.Scrimer
{
    public class ScrimerByTrigger : MonoBehaviour
    {
        public AnimationPlayer anim = null;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                anim.gameObject.SetActive(true);
                anim.StartAnimation();
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }

}
