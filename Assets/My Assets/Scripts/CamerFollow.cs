using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = target.TransformPoint(offsetPosition);
        transform.rotation = target.rotation;
    }
}
