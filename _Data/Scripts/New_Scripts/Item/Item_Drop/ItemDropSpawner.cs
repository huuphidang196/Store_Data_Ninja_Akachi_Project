using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner m_instance;
    public static ItemDropSpawner Instance => m_instance;

    public static string Name_Gold_Bag = "Gold_Bag";
    public static string Name_Gold_Coin = "Gold_Coin";
    public static string Name_Text_Fly = "Text_Fly";
    public static string Name_Boom = "Boom";

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only ItemDropSpawner has been exist");

        m_instance = this;
    }

}
