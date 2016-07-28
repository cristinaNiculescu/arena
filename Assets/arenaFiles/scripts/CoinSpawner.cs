using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

    public GameObject coin;
    public float numberOfCoins;
    public float secondsBetweenCoins=10;
    public float coinsAvailable;
    public GameObject coinMaster;
    public float minimumPositionValue=0;
    public float maximumPositionValue=10;


    // Use this for initialization
	void Start () {
        StartCoroutine(coinRespawn(secondsBetweenCoins));
        coinMaster = GameObject.FindGameObjectWithTag("CoinMaster");
	}

    IEnumerator coinRespawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (secondsBetweenCoins>0.3) secondsBetweenCoins -= 0.3f;
        SpawnCoins();
        StartCoroutine(coinRespawn(secondsBetweenCoins));
    }
	// Update is called once per frame
	void Update () {
        coinsAvailable = coinMaster.transform.childCount;
	}

    void SpawnCoins()
    { float coinsToPlace = numberOfCoins - coinsAvailable;
       while (coinsToPlace>0)
        {
            Vector3 randPosition = new Vector3(Random.Range(minimumPositionValue, maximumPositionValue), 0.5f, Random.Range(minimumPositionValue, maximumPositionValue));
            GameObject newCoin= Instantiate(coin, randPosition, Quaternion.identity) as GameObject;
            newCoin.transform.parent = coinMaster.transform;
            coinsToPlace--;
        }
        
    }
}
