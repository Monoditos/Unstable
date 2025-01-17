using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switches : MonoBehaviour
{
    public GameObject on, off;
    public AudioController audioController;
    public int counter;
    public bool isOn;
    public float randomValue, randomChange;

    void Start(){
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
    }

    private void OnEnable()
    {

        randomValue = Random.value;
        if (randomValue < 0.30)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
        counter = EventController.GetSwitches;
        on.SetActive(isOn);
        off.SetActive(!isOn);
        if (isOn)
        {
            EventController.AddSwitch(1);
        }
    }

    private void Update()
    {
        if (isOn && EventController.GetFusebox)
        {
            StartCoroutine(RandomlySelectFalseEachSecond());
        }

        counter = EventController.GetSwitches;
        if (counter == 8 || (!EventController.GetFusebox && isOn))
        {
            EventController.GetFuseboxCompleted = true;
            EventController.GetFusebox = false;
            isOn = !isOn;
            on.SetActive(isOn);
            off.SetActive(!isOn);
            EventController.GetSwitches = 0;
            EventController.AddSwitch(-1);
        }
    }
    public void OnMouseUp()
    {
        audioController.PlaySoundEffect("switch_toggle");
        isOn = !isOn;
        on.SetActive(isOn);
        off.SetActive(!isOn);
        if (isOn)
        {
            EventController.AddSwitch(1);
        }
        else
        {
            EventController.AddSwitch(-1);
        }
    }

    IEnumerator RandomlySelectFalseEachSecond()
    {
        randomChange = Random.value;
        if (randomChange <= 0.0005 && isOn == true)
        {
            isOn = false;
            on.SetActive(isOn);
            off.SetActive(!isOn);
            EventController.AddSwitch(-1);
            yield return new WaitForSeconds(Random.value * 2f);
        }
        yield return new WaitForSeconds(2f);
    }
}












/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switches : MonoBehaviour
{
    public SpriteRenderer on, off;
    public int counter;
    public bool isOn;
    public float randomValue, randomChange;

    void Start()
    {
        randomValue = Random.value;
        if (randomValue < 0.40)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
        counter = EventController.GetSwitches;
        on.enabled = isOn;
        off.enabled = !isOn;
        if (isOn)
        {
            EventController.AddSwitch(1);
        }
    }

    private void Update()
    {
        StartCoroutine(RandomlySelectFalseEachSecond());
        counter = EventController.GetSwitches;
    }
    private void OnMouseUp()
    {
        isOn = !isOn;
        on.enabled = isOn;
        off.enabled = !isOn;
        if (isOn)
        {
            EventController.AddSwitch(1);
        }
        else
        {
            EventController.AddSwitch(-1);
        }
    }

    IEnumerator RandomlySelectFalseEachSecond()
    {
        randomChange = Random.value;
        Debug.Log(randomChange);
        if (randomChange <= 0.001 && isOn == true)
        {
            isOn = false;
            on.enabled = isOn;
            off.enabled = !isOn;
            EventController.AddSwitch(-1);
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(1.5f);
    }
}*/