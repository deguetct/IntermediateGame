using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolThing : MonoBehaviour
{

    [SerializeField] private GameObject buttonOne;
    [SerializeField] private GameObject buttonTwo;
    [SerializeField] private GameObject scary;
    // Start is called before the first frame update
    void Start()
    {
        scary.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void remove()
    {
        buttonOne.SetActive(false);
    }

    public void shockAndHorror()
    {
        buttonTwo.SetActive(false);
        scary.SetActive(true);
    }
}
