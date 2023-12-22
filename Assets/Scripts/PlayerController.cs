using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool isAwake, isCalling;

    public Image fatigueBar;

    [SerializeField]
    private float currentState;

    public PhoneState phoneState;

    public Volume volume;
    public WhiteBalance wb;
    public ColorAdjustments ca;
    void Start()
    {
        fatigueBar.fillAmount = 50f;
        volume.profile.TryGet(out wb);
        volume.profile.TryGet(out ca);
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
            wb.temperature.value = 50f;
            ca.colorFilter.value = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            DecreaseFatigueBar();
            wb.temperature.value = -100f;
            ca.colorFilter.value = new Color(0.4f, 0.4f, 0.4f, 0.4f);
        }
    }
    void FillFatigueBar()
    {
        fatigueBar.fillAmount = currentState / 100f;
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
    [SerializeField] private TextMeshProUGUI _strikeText;
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
