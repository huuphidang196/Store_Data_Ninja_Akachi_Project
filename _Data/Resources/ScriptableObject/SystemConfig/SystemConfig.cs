using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SystemConfig", menuName = "ScriptableObject/Configuration/SystemConfig", order = 0)]
public class SystemConfig : ScriptableObject
{
    public int Level_Unlock = 1;
    public int Current_Level;
    public float Total_Golds;
    public float Total_Diamonds;

    [SerializeField] protected GameConfigController _GameConfigController;
    public GameConfigController GameConfigController => this._GameConfigController;

    [SerializeField] protected GamePlayConfigUIOverall _GamePlayConfigUIOverall;
    public GamePlayConfigUIOverall GamePlayConfigUIOverall => this._GamePlayConfigUIOverall;

    [SerializeField] protected PlayerSO _PlayerSO;
    public PlayerSO PlayerSO => this._PlayerSO;

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        this.LoadGameConfigController();
        this.LoadGamePlayConfigUIOverall();
        this.LoadPlayerSO();
    }

    protected virtual void LoadGameConfigController()
    {
        if (this._GameConfigController != null) return;

        this._GameConfigController = Resources.Load<GameConfigController>("ScriptableObject/SystemConfig/GameController/GameConfigController");
    }

    protected virtual void LoadGamePlayConfigUIOverall()
    {
        if (this._GamePlayConfigUIOverall != null) return;

        this._GamePlayConfigUIOverall = Resources.Load<GamePlayConfigUIOverall>("ScriptableObject/SystemConfig/GameController/GamePlayConfigUIOverall");
    }

    protected virtual void LoadPlayerSO()
    {
        if (this._PlayerSO != null) return;

        this._PlayerSO = Resources.Load<PlayerSO>("ScriptableObject/MovableObjScriptableObject/Character/Player/PlayerSO");
    }
}

public class SystemConfigCtrl : ScriptableObject
{
    [SerializeField] protected SystemConfig _SystemConfig;
    public SystemConfig SystemConfig => this._SystemConfig;

    protected virtual void Reset()
    {
        this._SystemConfig = Resources.Load<SystemConfig>("ScriptableObject/SystemConfig/SystemConfig");
    }
}

[CreateAssetMenu(fileName = "GameConfigController", menuName = "ScriptableObject/Configuration/GameConfigController", order = 1)]
public class GameConfigController : SystemConfigCtrl
{
    public float Distance_Active_Enemies;
}

[CreateAssetMenu(fileName = "GamePlayConfigUIOverall", menuName = "ScriptableObject/Configuration/GamePlayConfigUIOverall", order = 2)]
public class GamePlayConfigUIOverall : SystemConfigCtrl
{
    public float Time_Delay_Button_Hiden = 5f;
    public float Time_Delay_Active_Button_Hiden = 12f;
    public float Time_Delay_Active_Button_Attack_Throw = 0.5f;
    public float Time_Delay_Active_Button_Attack_Dashing = 5f;
}