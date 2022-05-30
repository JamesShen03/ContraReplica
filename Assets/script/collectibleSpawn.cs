using UnityEngine;
using System.Collections;

public class collectibleSpawn : MonoBehaviour {

    public bool spawned=false;

    public Transform collectibleSpawnPoint;

    public  Collectible Collectible;


    // Use this for initialization
    void Start () {
        spawned = false;
        if (!spawned)
        {
            Collectible pTemp = Instantiate(Collectible, collectibleSpawnPoint.position, collectibleSpawnPoint.rotation) as Collectible;
            spawned = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
    
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Bullet" & !spawned)
        {
            spawned = true;

            Collectible pTemp = Instantiate(Collectible, collectibleSpawnPoint.position, collectibleSpawnPoint.rotation) as Collectible;

           
        }
    }
}
