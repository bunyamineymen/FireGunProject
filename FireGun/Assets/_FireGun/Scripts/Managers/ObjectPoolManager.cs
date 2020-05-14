using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public List<GameObject> playerBulletPool = new List<GameObject>();
    [SerializeField] private GameObject playerBulletPrefab;
    public Transform playerBulletContainerTransform;


    public GameObject RequestPlayerBullet()
    {
        foreach (var playerBullet in playerBulletPool)
        {
            if (!playerBullet.activeInHierarchy)
            {

                playerBullet.SetActive(true);
                return playerBullet;
            }
        }



        GameObject newPlayerBullet = Instantiate(playerBulletPrefab);
        newPlayerBullet.transform.parent = playerBulletContainerTransform;
        playerBulletPool.Add(newPlayerBullet);

        return newPlayerBullet;
    }


}
