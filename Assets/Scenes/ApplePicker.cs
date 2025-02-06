using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab; // Use camelCase for variable names
    public int numBaskets = 3;
    public float basketBottomY = -14f; // Add 'f' to explicitly define float
    public float basketSpacingY = 2f;

    private List<GameObject> basketList; // Declare basketList

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>(); // Initialize the list
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab); // Simplified Instantiate call
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO); // Fixed syntax error
        }
    }

    public void AppleMissed()
    {
        // Destroy all apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Remove one basket
        if (basketList.Count > 0) // Check if there are baskets left
        {
            int basketIndex = basketList.Count - 1;
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
        }

        // Reload the scene if no baskets are left
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can add update logic here if needed
    }
}