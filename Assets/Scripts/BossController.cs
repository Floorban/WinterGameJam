using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [SerializeField] private AudioClip _footSteps;
    [SerializeField] private AudioSource _audioSource;

    private float _timeBetweenAction;
    [SerializeField] private PlayerController _player;
    public UnityEvent GiveStrike;
    void Start()
    {
        _timeBetweenAction = Random.Range(3f, 5f);
        Debug.Log(_timeBetweenAction);
        _strike.angryBoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _timeBetweenAction -= Time.deltaTime;
        if (_timeBetweenAction <= 0 )
        {
            Debug.Log("time hit 0");
            StartCoroutine(BossAction());
        }
        
        if (_isSleepChecking)
        { 
            if (!_player.isAwake) GiveStrike.Invoke();        
        }
    }

    private bool _isSleepChecking;
    [SerializeField] private StrikeCount _strike;
    IEnumerator BossAction()
    {       
        Debug.Log("Coroutine");
        float _timeToWait = Random.Range(0.5f, 4.0f);
        _timeBetweenAction = Random.Range(3f, 5f) + _timeToWait + 2f;
        _audioSource.PlayOneShot(_footSteps, 0.7F);
        yield return new WaitForSeconds(_timeToWait);
        OpenDoor();        
        yield return new WaitForSeconds(3f);
        Debug.Log("wait");
        CloseDoor();      
    }
    #region DoorHandling
    [SerializeField] private GameObject _door;
    void OpenDoor()
    {
        _strike.angryBoss.SetActive(false);
        _isSleepChecking = true;
        _door.transform.Rotate(0.0f, -90.0f, 0.0f);
        transform.position += new Vector3(5, 0, 0);
    }

    void CloseDoor()
    {
        _isSleepChecking = false;
        _strike.canStrike = true;
        _strike.angryBoss.SetActive(false);
        _strike.Boss.SetActive(true);
        _door.transform.Rotate(0.0f, 90.0f, 0.0f);
        transform.position += new Vector3(-5, 0, 0);
    }
    #endregion

}
