using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoliceGroup : MonoBehaviour {

    public GameObject policeObject;
    public int count;

    List<GameObject> list;
  
	void Start () {

        list = new List<GameObject>();

        createChain(count);

      
	}

    void createChain(int c)
    {
        for (int i = 0; i < c; i++)
        {
            GameObject obj = Instantiate(policeObject, transform.position, Quaternion.identity) as GameObject;
            list.Add(obj);
        }

        for (int i = 0; i < list.Count - 1; i++)
        {
            list[i].GetComponent<PoliceEnemy>().toFollow = list[i + 1].transform;
        }

        list[list.Count - 1].GetComponent<PoliceEnemy>().toFollow = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void FixedUpdate()
    {
	


	}
}
