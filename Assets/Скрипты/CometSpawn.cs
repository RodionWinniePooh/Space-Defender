using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawn : MonoBehaviour
{
    public GameObject[] comets;
    List<GameObject> cometList = new List<GameObject>();
    public float timeBetweenComets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CometCreation());
    }
    IEnumerator CometCreation()
    {
        //Create a new list copying the arrey
        for (int i = 0; i < comets.Length; i++)
        {
            cometList.Add(comets[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            ////choose random object from the list, generate and delete it
            int randomIndex = Random.Range(0, cometList.Count);
            Instantiate(cometList[randomIndex]);
            cometList.RemoveAt(randomIndex);
            //if the list decreased to zero, reinstall it
            if (cometList.Count == 0)
            {
                for (int i = 0; i < comets.Length; i++)
                {
                    cometList.Add(comets[i]);
                }
            }
            yield return new WaitForSeconds(timeBetweenComets);
        }
    }
}
