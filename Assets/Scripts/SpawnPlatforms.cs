using System.Collections;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform parent;
    
    private float spawnDistance = 0.6f;
    private GameObject firstPaltform;
    private Vector2 lastPosition;

    void Start()
    {
        SpawnFirstPlatforms();
        StartCoroutine(Spawn());
    }

    void SpawnFirstPlatforms()
    {
        firstPaltform = Instantiate(spawnObject,parent);
        lastPosition = firstPaltform.transform.position;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            Vector2 nextPosition = lastPosition + new Vector2(0f, spawnDistance); 
            Instantiate(spawnObject, nextPosition, Quaternion.identity,parent);
            lastPosition = nextPosition;
            yield return new WaitForSeconds(7);
        }
    }
    
}
