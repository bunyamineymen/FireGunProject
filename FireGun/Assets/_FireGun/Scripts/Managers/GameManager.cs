using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{

    public float periodOfFire;
    public float velocityOfFire;



    public delegate void StartSessionDelegate();
    public static StartSessionDelegate StartSessionDelegateObject;

    public SessionState sessionState;


    public bool isLowPeriod;
    public bool isHighVelocity;
    public bool isCloneActive;
    public bool diagonalMultipleFireIsActive;
    public bool doubleFireIsActive;

    public GameObject otherPlayerGO;

    public const float defaultPeriofOfFire = 2f;
    public const float lowPeriofOfFire = 1f;
    public const float defaultVelocityOfFire = 1000f;
    public const float highVelocityOfFire = 2000f;




    protected override void Awake()
    {
        base.Awake();

        Application.targetFrameRate = 60;
        sessionState = SessionState.menu;
    }

    public void PrepareSession()
    {

        isLowPeriod = false;
        isHighVelocity = false;
        isCloneActive = false;
        diagonalMultipleFireIsActive = false;
        doubleFireIsActive = false;

        periodOfFire = defaultPeriofOfFire;
        velocityOfFire = defaultVelocityOfFire;

    }

    private void Start()
    {
        PrepareSession();
    }

    public void StartSession()
    {


        GameManager.Instance.sessionState = SessionState.session;


        StartSessionDelegateObject.Invoke();

        UIManager.Instance.SetGOsForSession();

    }

    public void EndSession()
    {

        StopAllCoroutines();
        SceneManager.LoadScene("MainScene");

    }


    public void ActiveClonePlayer()
    {

        otherPlayerGO.gameObject.SetActive(true);
        isCloneActive = true;
    }

    public void CancelClonePlayer()
    {

        otherPlayerGO.gameObject.SetActive(false);
        isCloneActive = false;

    }

}
