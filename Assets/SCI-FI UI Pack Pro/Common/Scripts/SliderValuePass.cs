using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValuePass : MonoBehaviour
{

	Text progress;
	void Start () {
		progress = GetComponent<Text>();

	}
	
	public  void UpdateProgress (float content) {
		progress.text = Mathf.Round(content * 100).ToString() +"%" ;
	}


}
