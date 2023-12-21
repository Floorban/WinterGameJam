using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool isAwake, isCalling;
  
    public GameObject sleepMask;
    public Image fatigueBar;

    [SerializeField]
    private float currentState;

    public PhoneState phoneState;
    void Start()
    {
        fatigueBar.fillAmount = 50f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCalling)
        {
            isAwake = !isAwake;
        }

        if (Input.GetMouseButtonDown(0) && isAwake)
        {
            if (phoneState.canPickup)
            {
                isCalling = !isCalling;
            }else
            {
                isCalling = false;
            }
        }

        FillFatigueBar();

        if (isAwake)
        {
            IncreaseFatigueBar();
            sleepMask.SetActive(true);
        }
        else
        {
            DecreaseFatigueBar();
            sleepMask.SetActive(false);
        }
    }
    void FillFatigueBar()
    {
        fatigueBar.fillAmount = currentState / 100;
    }
    void IncreaseFatigueBar()
    {
        currentState += 1f * Time.deltaTime;
    }
    void DecreaseFatigueBar()
    {
        currentState -= 2f * Time.deltaTime;
    }

    public void CheckSleep() 
    {
        if (!isAwake) AddStrike();
    }

    private float _strike;
    void AddStrike()
    {
        _strike += 1;
        if (_strike >= 3) GameOver();
    }

    void GameOver()
    {
        Application.Quit();
    }
}
