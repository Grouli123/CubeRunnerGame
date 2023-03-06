using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1;
    private float timer = 0;
    [SerializeField] private GameObject pipe;
    [SerializeField] private float height;

    private void Start()
    {
        GameObject newpipe = Instantiate(pipe);
        newpipe.transform.position = transform.position + new Vector3(8.5f, Random.Range(-height, height), 0);
    }

    private void Update()
    {
        if(timer > maxTime)
        {
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position + new Vector3(8.5f, Random.Range(-height, height), 0);
            Destroy(newpipe, 15);
            timer = 0;
        }    

        timer += Time.deltaTime;
    }
}
