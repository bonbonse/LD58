using UnityEngine;
using TMPro;
using Ludum.Manager;
using Ludum.Localization;
using Ludum.Scrimer;

public class PickupItem : MonoBehaviour
{
    [Header("Настройки предмета")]
    [SerializeField] ItemType itemType;
	[SerializeField] GameObject pickedUpVersion;
    [SerializeField] string itemName;
	[SerializeField] KeyCode pickupKey = KeyCode.E;
	[SerializeField] AudioSource audioSource;
	[SerializeField] TextMeshProUGUI tmpText;
    public GameObject Scrimer;
    
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
                Scrimer.SetActive(true);
                ScrimerMity mity = Scrimer.GetComponent<ScrimerMity>();
                mity.On();

                pickedUpVersion.SetActive(true);
				audioSource.PlayOneShot(pickupSound);
				//tmpText.text = "";
                SubtitleManager.ShowHelp(false);
                Destroy(this.gameObject);
            }
		}
	}
	
	private void OnTriggerExit(){
        SubtitleManager.ShowHelp(false);
    }
}
