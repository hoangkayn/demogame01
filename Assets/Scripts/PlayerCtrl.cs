using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : BaseMonoBehaviour
{
    [SerializeField] private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;
    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected virtual void Start()
    {
        currentShip = GameObject.Find("ship").GetComponent<ShipCtrl>();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerPickup();
       
    }

   
   
    protected virtual void LoadPlayerPickup()
    {
        if (playerPickup != null) return;
        playerPickup = transform.GetComponentInChildren<PlayerPickup>();
    }
}
