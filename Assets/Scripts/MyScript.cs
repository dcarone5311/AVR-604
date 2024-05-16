using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int number;
    void Start()
    {
        number = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (number >=0)
        {
            ScreenLog.Log("in MyScript Update, count = " + number);
            DoSomething();
            number -= 1;
        }
    }

    private void DoSomething()
    {
        ScreenLog.Log("inside DoSomething");
        number = -1;
    }
}
