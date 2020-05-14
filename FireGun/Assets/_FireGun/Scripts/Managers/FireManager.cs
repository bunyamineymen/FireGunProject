using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireManager : MonoSingleton<FireManager>
{

    public delegate void FireDelegate();
    public static FireDelegate fireDelegateObject;





    private void OnEnable()
    {
        GameManager.StartSessionDelegateObject += FireGunMethod;
    }

    private void OnDisable()
    {
        GameManager.StartSessionDelegateObject -= FireGunMethod;

    }

    public void FireGunMethod()
    {

        StartCoroutine("FireGunIEnumerator");


    }

    IEnumerator FireGunIEnumerator()
    {



        while (true)
        {
            yield return new WaitForSeconds(GameManager.Instance.periodOfFire);


            fireDelegateObject.Invoke();

            if (GameManager.Instance.sessionState != SessionState.session)
            {
                break;
            }

        }

    }


}
