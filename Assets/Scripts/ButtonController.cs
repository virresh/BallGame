using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	public void LoadGame(string s){
		SceneManager.LoadScene (s);
	}

	public void quit(){
		Application.Quit ();
	}
}
