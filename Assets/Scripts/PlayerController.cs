using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float Speed;
	public float MaxHealth;
	public float DamageAmt;
	private int coinCount;
	private float curHealth;
	public Text Coins;
	public int MaxCoins;
	public int numPricks;
	public GameObject prick;
	public GameObject coinObj;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		coinCount = 0;
		setCoinText ();
		spawnPricks ();
		spawnCoins ();
		curHealth = MaxHealth;

	}
	
	// Update is called once per frame
	void Update(){
		if (rb.transform.position.y < -10) {
			SceneManager.LoadScene ("GameOver");
		}
	}

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
				SceneManager.LoadScene ("GameWon");
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Prick")){
			print ("Prick Encountered");
			if (curHealth - DamageAmt > 0) {
				float decreasedH = (curHealth - DamageAmt) / MaxHealth;
				curHealth -= DamageAmt;
				healthBar.transform.localScale = new Vector3 (decreasedH, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
			} 
			else {
				healthBar.transform.localScale = new Vector3(0, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
				SceneManager.LoadScene ("GameOver");
			}

		}
	}

	void setCoinText(){
		Coins.text = "Coins : " + coinCount.ToString ();
	}
		
	void spawnPricks(){
		float minPos = -250;
		float maxPos = 250;
		for (int i = 0; i < numPricks; i++) {
			float px = Random.Range (minPos, maxPos + 1);
			float pz = Random.Range (minPos, maxPos + 1);
			GameObject nePrick = Instantiate(prick);
			nePrick.transform.position = new Vector3 (px, 2, pz);

		}
	}

	void spawnCoins(){
		float minPos = -230;
		float maxPos = 230;
		for (int i = 0; i < MaxCoins; i++) {
			float px = Random.Range (minPos, maxPos + 1);
			float pz = Random.Range (minPos, maxPos + 1);
			GameObject neCoin = Instantiate(coinObj);
			neCoin.transform.position = new Vector3 (px, 11, pz);

		}
	}
		
}
