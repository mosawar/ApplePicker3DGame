using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketbSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketbSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }


    public void AppleMissed()
    {
        //destroy all of the falling apples
        GameObject[]  appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        //destroy one of the baskets

        // get the index of the last basket in basketlist
        int basketIndex = basketList.Count - 1;

        //get a reference to that basket gameobject
        GameObject basketGo = basketList[basketIndex];

        //remove basket from the list and destory the gameobkject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGo);

        // if there are no baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }

    }
}
