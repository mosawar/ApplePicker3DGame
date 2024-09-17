using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    //prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the appletree moves
    public float speed = 1f;

    //distance where appletree turns around
    public float leftAndRightEdge = 10f;

    //chance that appletree will change direction
    public float changeDirChance = 0.1f;

    //seconds between apples instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        //start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        // changing direction
        if (pos.x < -leftAndRightEdge)
        {
            //move right
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            //move left
            speed = -Mathf.Abs(speed);
        }
        //else if (Random.value < changeDirChance)
        //{
        //    //change direction
        //    speed *= -1;
        //}
    }

    void FixedUpdate()
    {
        // random direction changes are not time based due to fixed update()
        if (Random.value < changeDirChance)
        {
            //change direction
            speed *= -1;
        }
    }

}