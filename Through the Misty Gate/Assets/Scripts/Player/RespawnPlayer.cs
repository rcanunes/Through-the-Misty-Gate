using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject respawnCanvas;
    private GameObject spawnPoint;
    private PlayerController player;
    private GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponent<PlayerController>();
        spawnPoint = GameObject.Find("Respawn Point");
    }
    

    public void Respawn()
    {
        player.SetIgnoreInput(true);
        canvas = Instantiate(respawnCanvas) as GameObject;
        StartCoroutine(StartRespawn());

    }

    private IEnumerator StartRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = spawnPoint.transform.position;
        player.SetIgnoreInput(false);
        Destroy(canvas);
    }
}
