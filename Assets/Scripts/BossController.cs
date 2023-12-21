using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossController : MonoBehaviour
{

    [SerializeField] private AudioClip _footSteps;
    [SerializeField] private AudioSource _audioSource;

    private float _timeBetweenAction;

 
    // Start is called before the first frame update
    void Start()
    {
        _timeBetweenAction = Random.Range(15f, 35f);
        Debug.Log(_timeBetweenAction);
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
    }
    
    [SerializeField] private GameObject _player;
    IEnumerator BossAction()
    {       
        Debug.Log("Coroutine");
        float _timeToWait = Random.Range(0.5f, 4.0f);
        _timeBetweenAction = Random.Range(15f, 35f) + _timeToWait + 2f;
        _audioSource.PlayOneShot(_footSteps, 0.7F);
        yield return new WaitForSeconds(_timeToWait);
        OpenDoor();
        //_player.GetComponent<PlayerController>().CheckSleep();
        yield return new WaitForSeconds(3f);
        Debug.Log("wait");
        //_player.GetComponent<PlayerController>().CheckSleep();
        CloseDoor();      
    }
    #region DoorHandling
    [SerializeField] private GameObject _door;
    void OpenDoor()
    {
        _door.transform.Rotate(0.0f, -90.0f, 0.0f);
        transform.position += new Vector3(3, 0, 0);
    }

    void CloseDoor()
    {
        _door.transform.Rotate(0.0f, 90.0f, 0.0f);
        transform.position += new Vector3(-3, 0, 0);
    }
    #endregion

}
