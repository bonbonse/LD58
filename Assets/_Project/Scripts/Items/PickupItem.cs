using UnityEngine;
using TMPro;

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
			tmpText.text = "[Press E to pick up Flashlight]";
			if (Input.GetKey(pickupKey)){
				Debug.Log("Picked Up!");
				pickedUpVersion.SetActive(true);
				audioSource.PlayOneShot(pickupSound);
				tmpText.text = "";
				Destroy(this.gameObject);
				
			}
		}
	}
	
	private void OnTriggerExit(){
		tmpText.text = "";
	}
}
