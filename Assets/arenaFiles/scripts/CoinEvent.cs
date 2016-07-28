using UnityEngine;
using System.Collections;

public class CoinEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
        {
        if (c.transform.tag == "Player1" || c.transform.tag == "Player2") 
        {
            c.GetComponent<ScoreManager>().scorePoints ++;
            Destroy(gameObject);
        }
    }
}
