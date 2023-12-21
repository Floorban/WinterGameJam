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
    {;
        _timeBetweenAction = Random.Range(15f, 35f);
    }

    // Update is called once per frame
    void Update()
    {
        _timeBetweenAction -= Time.deltaTime;
        if (_timeBetweenAction <= 0 )
        {
            StartCoroutine(BossAction());
        }
    }
    
    [SerializeField] private GameObject _player;
    IEnumerator BossAction()
    {
        float _timeToWait = Random.Range(0.5f, 4.0f);
        _audioSource.PlayOneShot(_footSteps, 0.7F);
        yield return new WaitForSeconds(_timeToWait);
        OpenDoor();
        transform.position += new Vector3(10, 0, 0);
        _player.GetComponent<PlayerController>().CheckSleep();
        yield return new WaitForSeconds(2f);
        _player.GetComponent<PlayerController>().CheckSleep();
        CloseDoor();
        _timeBetweenAction = Random.Range(15f, 35f);


    }
    #region DoorHandling
    [SerializeField] private GameObject _door;
    void OpenDoor()
    {
        _door.transform.Rotate(90.0f, 0.0f, 0.0f);
        transform.position += new Vector3(2, 0, 0);
    }

    void CloseDoor()
    {
        _door.transform.Rotate(0.0f, 0.0f, 0.0f);
        transform.position += new Vector3(-2, 0, 0);
    }
    #endregion

}
