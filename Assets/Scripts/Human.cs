using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basic human class that does the PerformAction
public class Human : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void PerformAction() {
        // idk you'll probably have some more complicated AI stuff here, but for now it just prints a statement
        StartCoroutine(DummyTurnBehavior());

    }

    IEnumerator DummyTurnBehavior() {
        Debug.Log("human turn! :D");
        yield return new WaitForSeconds(2.0f);
        TurnSystem.Instance.SwitchTurn();
    }
}
