using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{

    public Image diagonalMultipleFireButtonImage;  // firstButton
    public Image doubleFireButtonImage; // secondButton
    public Image firePeriodButtonImage; // thirdButton
    public Image changeFireVelocityButtonImage; // fourthButton
    public Image cloneMeButtonImage; // fifthButton

    public GameObject[] sessionGOs;
    public GameObject[] menuGOs;


    public List<SpecialPower> specialPowerList = new List<SpecialPower>();



    protected override void Awake()
    {
        base.Awake();
    }

    public void SetGOsForMenu()
    {
        for (int i = 0; i < menuGOs.Length; i++)
        {
            menuGOs[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < sessionGOs.Length; i++)
        {
            sessionGOs[i].gameObject.SetActive(false);
        }
    }

    public void SetGOsForSession()
    {
        for (int i = 0; i < menuGOs.Length; i++)
        {
            menuGOs[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < sessionGOs.Length; i++)
        {
            sessionGOs[i].gameObject.SetActive(true);
        }
    }


    public void ClickStartButton()
    {
        GameManager.Instance.StartSession();

    }

    public void SetButtonOn(Image _image)
    {


        var _color = _image.color;

        _color.a = 255f / 255f;

        _image.color = _color;
    }

    public void SetButtonOff(Image _image)
    {


        var _color = _image.color;

        _color.a = 90 / 255f;

        _image.color = _color;
    }





    // firstButton
    public void DiagonalMultipleFireButtonClick()
    {



        if (GameManager.Instance.diagonalMultipleFireIsActive)
        {
            CancelDiagonalMultipleFire();
        }
        else
        {

            if (specialPowerList.Count == 3)
            {
                return;
            }
            ActiveDiagonalMultipleFire();
        }
    }

    public void CancelDiagonalMultipleFire()
    {
        SetButtonOff(diagonalMultipleFireButtonImage);
        GameManager.Instance.diagonalMultipleFireIsActive = false;

        specialPowerList.Remove(SpecialPower.diagonalMultipleFire);
    }

    public void ActiveDiagonalMultipleFire()
    {
        SetButtonOn(diagonalMultipleFireButtonImage);
        GameManager.Instance.diagonalMultipleFireIsActive = true;

        specialPowerList.Add(SpecialPower.diagonalMultipleFire);


    }









    // secondButton

    public void DoubleFireButtonClick()
    {


        if (GameManager.Instance.doubleFireIsActive)
        {
            CancelDoubleFire();
        }
        else
        {

            if (specialPowerList.Count == 3)
            {
                return;
            }

            ActiveDoubleFire();
        }
    }

    public void CancelDoubleFire()
    {
        SetButtonOff(doubleFireButtonImage);
        GameManager.Instance.doubleFireIsActive = false;

        specialPowerList.Remove(SpecialPower.doubleFire);
    }

    public void ActiveDoubleFire()
    {
        SetButtonOn(doubleFireButtonImage);
        GameManager.Instance.doubleFireIsActive = true;

        specialPowerList.Add(SpecialPower.doubleFire);


    }







    // thirdButton

    public void ChangeFirePeriodClick()
    {



        if (GameManager.Instance.isLowPeriod)
        {

            CancelLowPeriod();

        }
        else
        {

            if (specialPowerList.Count == 3)
            {
                return;
            }

            ActiveLowPeriod();
        }

    }

    public void CancelLowPeriod()
    {
        SetButtonOff(firePeriodButtonImage);

        GameManager.Instance.isLowPeriod = false;
        GameManager.Instance.periodOfFire = GameManager.defaultPeriofOfFire;

        specialPowerList.Remove(SpecialPower.lowPeriod);
    }

    public void ActiveLowPeriod()
    {
        SetButtonOn(firePeriodButtonImage);

        GameManager.Instance.isLowPeriod = true;
        GameManager.Instance.periodOfFire = GameManager.lowPeriofOfFire;

        specialPowerList.Add(SpecialPower.lowPeriod);



    }







    // fourthButton

    public void ChangeFireVelocityClick()
    {



        if (GameManager.Instance.isHighVelocity)
        {
            CancelHighVelocity();

        }
        else
        {

            if (specialPowerList.Count == 3)
            {
                return;
            }

            ActiveHighVelocity();
        }

    }



    public void CancelHighVelocity()
    {
        SetButtonOff(changeFireVelocityButtonImage);
        GameManager.Instance.isHighVelocity = false;
        GameManager.Instance.velocityOfFire = GameManager.defaultVelocityOfFire;

        specialPowerList.Remove(SpecialPower.highVelocity);
    }

    public void ActiveHighVelocity()
    {
        SetButtonOn(changeFireVelocityButtonImage);
        GameManager.Instance.isHighVelocity = true;
        GameManager.Instance.velocityOfFire = GameManager.highVelocityOfFire;
        specialPowerList.Add(SpecialPower.highVelocity);


    }





    // fifthButton

    public void CloneMeClick()
    {



        if (GameManager.Instance.isCloneActive)
        {
            CancelClone();
        }
        else
        {

            if (specialPowerList.Count == 3)
            {
                return;
            }
            ActiveClone();
        }

    }

    public void CancelClone()
    {

        SetButtonOff(cloneMeButtonImage);
        specialPowerList.Remove(SpecialPower.clone);
        GameManager.Instance.CancelClonePlayer();
    }


    public void ActiveClone()
    {

        SetButtonOn(cloneMeButtonImage);
        specialPowerList.Add(SpecialPower.clone);


        GameManager.Instance.ActiveClonePlayer();

    }


}
