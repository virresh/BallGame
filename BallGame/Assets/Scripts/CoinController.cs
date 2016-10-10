using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

	private Rigidbody rb;
	public float RotateSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.Rotate (new Vector3 (0, 0, RotateSpeed) * Time.deltaTime);
	}
}
