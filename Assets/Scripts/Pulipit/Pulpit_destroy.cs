using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulpit_destroy : MonoBehaviour
{
    public float min_pulpit_destroy_time = 4f;
    public float max_pulpit_destroy_time = 5f;
    private float destroyDelay = 3f;

    void Start()
    {
        StartCoroutine(DestroyBox());
    }

    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(destroyDelay);

        float remainingTime = Random.Range(min_pulpit_destroy_time - destroyDelay, max_pulpit_destroy_time - destroyDelay);

        yield return new WaitForSeconds(Mathf.Max(remainingTime, 5f));

        GameObject.Find("Pulpit").GetComponent<PuplitReplacement>().count--;

        Destroy(gameObject);
    }
}
