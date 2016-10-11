using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float Speed;
	private int coinCount;
	public Text Coins;
	public Text win;
	public int MaxCoins;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		coinCount = 0;
		win.text = "";
		setCoinText ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		rb.AddForce (new Vector3 (moveH, 0, moveV) * Speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Coin")) {
			other.gameObject.SetActive (false);
			coinCount += 1;
			setCoinText ();

			if (coinCount >= MaxCoins) {
				win.text = "You Win !!!";
			}
		}
	}

	void setCoinText(){
		Coins.text = "Coins : " + coinCount.ToString ();
	}
}
