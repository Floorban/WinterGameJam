using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public bool isAwake, isCalling;

    public Image fatigueBar;

    [SerializeField]
    private float currentState;

    public PhoneState phoneState;

    public Volume volume;
    public WhiteBalance wb;
    public ColorAdjustments ca;

    [SerializeField] private GameObject _playerAwake;
    [SerializeField] private GameObject _playerAsleep;

    void Start()
    {
        fatigueBar.fillAmount = 50f;
        volume.profile.TryGet(out wb);
        volume.profile.TryGet(out ca);
        _playerAwake.SetActive(false);
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
            _playerAwake.SetActive(true);
            _playerAsleep.SetActive(false);
            DecreaseFatigueBar();
            wb.temperature.value = 50f;
            ca.colorFilter.value = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            _playerAwake.SetActive(false);
            _playerAsleep.SetActive(true);
            IncreaseFatigueBar();
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

}
