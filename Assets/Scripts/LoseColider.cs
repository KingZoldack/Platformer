using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour
{
    Player _player;
    CharacterController _controller;

    [SerializeField]
    GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player.LoseLife();
            _controller.enabled = false;
            _player.transform.position = respawnPoint.transform.position;
            StartCoroutine(CharacterControllerEnableRoutine(_controller));
        }
    }

    IEnumerator CharacterControllerEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.10f);
        controller.enabled = true;
    }
}
