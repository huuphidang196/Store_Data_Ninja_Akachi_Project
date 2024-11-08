using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUICenter : GamePlayUIOverallAbstract
{
    [SerializeField] protected Transform _pnl_UI_Pause_Panel;
    public Transform PNL_UI_Pause_Panel => this._pnl_UI_Pause_Panel;

    [SerializeField] protected SliderTimePlayerHiden _SliderTimePlayerHiden;
    public SliderTimePlayerHiden SliderTimePlayerHiden => this._SliderTimePlayerHiden;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPanelUIPause();
        this.LoadSliderTimePlayerHiden();
    }

    protected virtual void LoadPanelUIPause()
    {
        if (this._pnl_UI_Pause_Panel != null) return;

        this._pnl_UI_Pause_Panel = transform.Find("pnlPausePanel").transform;
        this._pnl_UI_Pause_Panel.gameObject.SetActive(false);
    }

    protected virtual void LoadSliderTimePlayerHiden()
    {
        if (this._SliderTimePlayerHiden != null) return;

        this._SliderTimePlayerHiden = transform.GetComponentInChildren<SliderTimePlayerHiden>();
        this._SliderTimePlayerHiden.gameObject.SetActive(false);
    }
  
    protected virtual void FixedUpdate()
    {
        this.ToggleUIPausePanel();
        this.IsHidenALlChildUIBelow();

    }

    protected virtual void Update()
    {
        this.ToggleUISliderTimeHidenPlayer();
    }    
    protected virtual void ToggleUIPausePanel()
    {
        if (GamePlayUIManager.Instance.IsToggle == this._pnl_UI_Pause_Panel.gameObject.activeInHierarchy) return;

        this._pnl_UI_Pause_Panel.gameObject.SetActive(GamePlayUIManager.Instance.IsToggle);
    }

    protected virtual void IsHidenALlChildUIBelow()
    {
        if (GamePlayUIManager.Instance.IsHidenUI != GamePlayUIManager.Instance.IsToggle) return;

        if (GamePlayUIManager.Instance.IsHidenUI == transform.GetChild(0).gameObject.activeInHierarchy) return;

        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(GamePlayUIManager.Instance.IsHidenUI);
        }

        //Inactive Panel Pause at the same time
        GamePlayUIManager.Instance.TogglePanelPause();

    }

    protected virtual void ToggleUISliderTimeHidenPlayer()
    {
        if (InputManager.Instance.Press_Hiden_Mode == this._SliderTimePlayerHiden.gameObject.activeInHierarchy) return;

        this._SliderTimePlayerHiden.ResetValueSliderBegin();
        this._SliderTimePlayerHiden.gameObject.SetActive(InputManager.Instance.Press_Hiden_Mode);

    }
}
