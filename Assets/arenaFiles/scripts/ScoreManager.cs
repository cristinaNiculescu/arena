using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public GameObject player;
    public int scorePoints = 0;
    public Text scoreUpdate;
	// Use this for initialization
	void Start () {

        player = GameObject.FindWithTag(transform.tag);
    }
	
	// Update is called once per frame
	void Update () {

        scoreUpdate.text = player.transform.tag + ": " + scorePoints.ToString();
      }
}
