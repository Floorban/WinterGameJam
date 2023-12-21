using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

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
            } else
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

    #region Striking
    public void CheckSleep()
    {
        if (!isAwake) AddStrike();
    }

    private float _strike = 0;
    [SerializeField] private Text _strikeText;
    void AddStrike()
    {
        _strike += 1;
        _strikeText.text = "Strikes: " + _strike;
        Debug.Log(_strike);
        if (_strike >= 3) GameOver();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
    #endregion
}
