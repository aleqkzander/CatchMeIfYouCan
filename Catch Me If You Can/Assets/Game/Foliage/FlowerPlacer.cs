using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlacer : MonoBehaviour
{
    public GameObject FoliageParent;
    public GameObject GameField;
    public GameObject flowerPrefab;
    public int amount;

    private void Start()
    {
        for (int flowerCount = 0; flowerCount < amount; flowerCount++)
        {
            GameObject flower = Instantiate(flowerPrefab, GetRandomPositionOnPlane(), Quaternion.identity);
            flower.transform.SetParent(FoliageParent.transform, false);
        }
    }

    private Vector3 GetRandomPositionOnPlane()
    {
        // Plane GameField has an absolute width and length of 50
        float randomX = Random.Range(-50, 50);
        float randomZ = Random.Range(-50, 50);

        // Plane GameField yPosition is null
        float yPosition = 0f;

        return new Vector3(randomX, yPosition, randomZ);
    }
}
