using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstract, IObjectAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjectAppearing objAppearing;

    protected virtual void OnEnable()
    {
     //   base.OnEnable();
        this.RegisterAppearEvent();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjAppearing();
    }

    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = GetComponent<ObjectAppearing>();
        Debug.LogWarning(transform.name + ": LoadObjAppearing", gameObject);
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjectShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjectShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}