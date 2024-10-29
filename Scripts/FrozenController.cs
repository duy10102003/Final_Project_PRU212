using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float frozenTime = 2;
    float activeTime = 0;
    float timer = 0;
    KeyCode KeyCode;
    bool isEnable = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode) && isEnable)
        {
            activeTime = Time.deltaTime;
            GameObject[] otherPlayer = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in otherPlayer)
            {
                player.GetComponent<MovementController>().SetDisable();

            }
            gameObject.GetComponent<MovementController>().SetEnable();


            isEnable = false;
        }
        timer += activeTime;
        if (timer > frozenTime)
        {
            GameObject[] otherPlayer = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in otherPlayer)
            {
                player.GetComponent<MovementController>().SetEnable();

            }
            Destroy(this);
        }
        
    }
    public void SetKey(KeyCode key)
    {
        KeyCode = key;
    }
}
