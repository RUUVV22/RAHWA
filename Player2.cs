using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject painkillerss;
    public GameObject collect;
    public Image sprite;
    public GameObject panel;
    public List<Image> items= new List<Image>();
    public List<GameObject> painkillers= new List<GameObject>();
    bool istalk = false;
    bool isPainKillers = false;
    public static bool isHeal = false;
    //game over
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Talk")
        {
            Debug.Log("talk");
            gameObject1.SetActive(true);
            istalk = true;
        }
        if (other.gameObject.tag == "painkillers")
        {
            Debug.Log("painkillers");
            collect.gameObject.SetActive(true);
            isPainKillers = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Talk")
        {
            Debug.Log("Out");
            gameObject1.SetActive(false);
            istalk = false;
        }
        if (other.gameObject.tag == "painkillers")
        {
            collect.gameObject.SetActive(false);
            isPainKillers = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E)&&istalk)
        {
            gameObject2.SetActive(true);
            gameObject1.SetActive(false);
        }
        if (!istalk)
        {
            gameObject2.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.E)&&isPainKillers)
        {
            Debug.Log("painkillers");
            items.Add(sprite);
            painkillerss.gameObject.SetActive(false);
            for (int i = 0; i < painkillers.Count; i++)
            {
                painkillers[i].SetActive(false);
                collect.gameObject.SetActive(false);
            }
            //painkillers.Push(painkillerss);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isPainKillers=false;
        }
        if (istalk && Input.GetKeyDown(KeyCode.F))
        {
            items.Remove(sprite);
            isHeal = true;
            //painkillers.Pop();
        }
        if (Input.GetKeyUp(KeyCode.F)&&!istalk)
        {
            isHeal = false;
        }
    }
    public void showpanel()
    {
        panel.SetActive(true);
    }
}
