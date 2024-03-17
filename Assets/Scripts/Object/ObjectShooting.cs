 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooting : BaseMonoBehaviour
{
    [SerializeField] protected bool isShooting;
   
    [SerializeField] protected float shootingDelay = 1f;
    [SerializeField] protected float shootTimer;
    // Start is called before the first frame update
    protected virtual void Update()
    {
        IsShooting();
    }
    protected virtual void FixedUpdate()
    {
        Shooting();
    }
    protected virtual void Shooting()
    {
        if (!isShooting) return;
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootingDelay) return;
        shootTimer = 0;
        Transform bullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.BullletOne,transform.parent.position,transform.parent.rotation);
        BulletCtrl bulletCtrl = bullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
        bullet.gameObject.SetActive(true);
       
    }
    protected abstract bool IsShooting();
 
}
