using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : SurMonoBehaviour
{
    [Header("ObjectCtrl")]

    [SerializeField] protected ObjDamageReceiver _ObjDamageReceiver;
    public ObjDamageReceiver ObjDamageReceiver => _ObjDamageReceiver;

    [SerializeField] protected ObjDamageSender _ObjDamageSender;
    public ObjDamageSender ObjDamageSender => _ObjDamageSender;

    [SerializeField] protected ObjImpactOverall _ObjImpact_Overall;
    public ObjImpactOverall ObjImpactOverall => _ObjImpact_Overall;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjDamageReceiver();
        this.LoadObjDamageSender();
        this.LoadObjImpact();
    }

    protected virtual void LoadObjDamageReceiver()
    {
        if (this._ObjDamageReceiver != null) return;

        this._ObjDamageReceiver = transform.GetComponentInChildren<ObjDamageReceiver>();
    }

    protected virtual void LoadObjDamageSender()
    {
        if (this._ObjDamageSender != null) return;

        this._ObjDamageSender = transform.GetComponentInChildren<ObjDamageSender>();
    }

    protected virtual void LoadObjImpact()
    {
        if (this._ObjImpact_Overall != null) return;

        this._ObjImpact_Overall = transform.GetComponentInChildren<ObjImpactOverall>();
    }

}
