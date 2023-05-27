using System.Collections;
using UnityEngine;

public class PlatformsLogic : MonoBehaviour
{
    private float downSpeed = 15f;

    void Start()
    {
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        while (true)
        {
            Ball.isPause = true;
            transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
            yield return new WaitForSeconds(7);
        }
    }
}
