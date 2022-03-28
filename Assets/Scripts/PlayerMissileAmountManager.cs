using System;
using UnityEngine;

public class PlayerMissileAmountManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] missileListExample;

    public GameObject[] missileList;

    private void Start()
    {
        CreateMissileList();
    }

    private void CreateMissileList()
    {
        missileList = new GameObject[missileListExample.Length];

        for (int i = 0; i < missileListExample.Length; i++)
        {
            missileList[i] = Instantiate(missileListExample[i], transform) as GameObject;
        }
    }

    public void RemoveMissile()
    {
        if (missileList.Length != 0)
        {
            Destroy(missileList[missileList.Length-1]);
            Array.Resize(ref missileList, missileList.Length - 1);
        }
    }
}
