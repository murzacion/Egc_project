using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
 

	void ButtonInteractable(){

		Debug.Log ("You have clicked the button!");
		Application.Quit();

	}
}
