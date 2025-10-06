using UnityEngine;
using TMPro;
using Ludum.Manager;
using Ludum.Localization;

public class PickupItem : MonoBehaviour
{
    [Header("Настройки предмета")]
    [SerializeField] ItemType itemType;
	[SerializeField] GameObject pickedUpVersion;
    [SerializeField] string itemName;
	[SerializeField] KeyCode pickupKey = KeyCode.E;
	[SerializeField] AudioSource audioSource;
	[SerializeField] TextMeshProUGUI tmpText;
    
    [SerializeField] enum ItemType
    {
        Flashlight,
        Key,
        Battery,
        Document,
        Medkit
    }

    [Header("Визуальные эффекты")]
    [SerializeField] GameObject pickupEffect;
    [SerializeField] AudioClip pickupSound;

    private void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			SubtitleManager.HelpMessage(Dialog.PressE);
			if (Input.GetKey(pickupKey)){
				pickedUpVersion.SetActive(true);
				audioSource.PlayOneShot(pickupSound);
				//tmpText.text = "";
                SubtitleManager.ShowSubtitle(false);
				Destroy(this.gameObject);
            }
		}
	}
	
	private void OnTriggerExit(){
        SubtitleManager.ShowSubtitle(false);
    }
}
