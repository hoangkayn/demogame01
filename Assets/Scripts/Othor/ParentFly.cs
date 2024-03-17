using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentFly : BaseMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2;
    [SerializeField] protected Vector3 direction = Vector3.right;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(direction * moveSpeed * Time.deltaTime);
    }
    protected virtual void OnEnable()
    {

    }
}
