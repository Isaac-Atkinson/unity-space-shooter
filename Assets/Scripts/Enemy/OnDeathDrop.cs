using System.Collections.Generic;
using UnityEngine;

public class OnDeathDrop : MonoBehaviour
{

    [SerializeField] private List<GameObject> dropPrefabs;
    [SerializeField] private float dropProbability;

    void Start()
    {
        Healthbehaviour healthbehaviour = GetComponent<Healthbehaviour>();
        if (healthbehaviour != null)
        {
            healthbehaviour.onDeath.AddListener(Drop);
        }

    }

    public void Drop(GameObject obj)
    {
        float chance = Random.Range(0f, 1f);
        if (chance <= dropProbability && dropPrefabs.Count > 0)
        {
            int index = Random.Range(0, dropPrefabs.Count);
            Instantiate(dropPrefabs[index], transform.position, transform.rotation);
        }
    }
}
