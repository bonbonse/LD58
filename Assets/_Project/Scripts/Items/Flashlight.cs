using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] KeyCode turnOnOffKey = KeyCode.F;
	[SerializeField] GameObject spotLight;
	
	bool isActive = true;
	
    void Update()
    {
        if (Input.GetKeyDown(turnOnOffKey)){
			if (isActive){
				spotLight.SetActive(false);
				isActive = false;
			}
			else
			{
				spotLight.SetActive(true);
				isActive = true;
			}
		}
    }
}
