using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoSingleton<PlayerController>
{



    protected override void Awake()
    {
        base.Awake();
    }

    public Transform bulletFirstPosition;

    public Transform bulletNormalDirection;
    public Transform bulletSideDirection1;
    public Transform bulletSideDirection2;




    public Animator animatorOfCharacter;





    private void OnEnable()
    {
        FireManager.fireDelegateObject += FireMethod;


    }

    private void OnDisable()
    {
        FireManager.fireDelegateObject -= FireMethod;
    }




    public void Fire()
    {
        // this method must be used for readonly animation event
    }

    IEnumerator FireMethodIEnumerator()
    {

        CoreFireMethod();

        if (GameManager.Instance.diagonalMultipleFireIsActive)
        {
            SecondaryDiagonalFireMethod();
        }

        yield return new WaitForSeconds(0.013f);

        if (GameManager.Instance.doubleFireIsActive)
        {
            CoreFireMethod();

            if (GameManager.Instance.diagonalMultipleFireIsActive)
            {
                SecondaryDiagonalFireMethod();
            }
        }

    }

    public void FireMethod()
    {
        StartCoroutine("FireMethodIEnumerator");
    }

    public GameObject RequestPlayerBullet()
    {
        return ObjectPoolManager.Instance.RequestPlayerBullet();
    }

    public void CoreFireMethod()
    {

        StartCoroutine("CoreFireIEnumerator");

    }

    IEnumerator CoreFireIEnumerator()
    {


        GameObject bulletGO = RequestPlayerBullet();

        animatorOfCharacter.Play("Shooting", -1, 0f);

        yield return new WaitForSeconds(0.03f);


        bulletGO.transform.position = bulletFirstPosition.position;

        Vector3 bulletForce = -bulletNormalDirection.transform.up * GameManager.Instance.velocityOfFire;

        bulletGO.GetComponent<Rigidbody>().AddForce(bulletForce, ForceMode.Force);

        yield return new WaitForSeconds(2f);
        bulletGO.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(0.3f);
        bulletGO.transform.position = new Vector3(1000, 0, 0);
        bulletGO.SetActive(false);


    }

    public void SecondaryDiagonalFireMethod()
    {

        StartCoroutine("SecondaryDiagonalFireMethodIEnumerator");

    }


    public IEnumerator SecondaryDiagonalFireMethodIEnumerator()
    {

        GameObject bulletGO1 = RequestPlayerBullet();
        bulletGO1.transform.position = bulletFirstPosition.position;
        Vector3 bulletForce1 = -bulletSideDirection1.transform.up * GameManager.Instance.velocityOfFire;


        GameObject bulletGO2 = RequestPlayerBullet();
        bulletGO2.transform.position = bulletFirstPosition.position;
        Vector3 bulletForce2 = -bulletSideDirection2.transform.up * GameManager.Instance.velocityOfFire;


        bulletGO1.GetComponent<Rigidbody>().AddForce(bulletForce1, ForceMode.Force);
        bulletGO2.GetComponent<Rigidbody>().AddForce(bulletForce2, ForceMode.Force);

        yield return new WaitForSeconds(2f);
        bulletGO1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bulletGO2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(0.3f);
        bulletGO1.transform.position = new Vector3(1000, 0, 0);
        bulletGO2.transform.position = new Vector3(1000, 0, 0);
        bulletGO1.SetActive(false);
        bulletGO2.SetActive(false);


    }




}






