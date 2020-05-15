using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Turn : MonoBehaviour, IComparable<Turn>
{
    //turn taker
    private UnitStats _turnTaker { get; set;}

    //target for the turns actions
	private UnitStats _turnTarget { get; set; }

    //what action picked
    private bool actnPicked = false;

    //buttons for scene
    private Button attackBtn, runBtn;

    //weight to be used by priority queue
    private int _turnOrder = 0;
	public int turnOrder {
        get {return _turnOrder; }
        set {_turnOrder = turnOrder; } 
    }

    //basic constructor
	public Turn(UnitStats turnTaker, UnitStats turntarget, int TurnOrder)
	{
        _turnTaker = turnTaker;
        _turnTarget = turntarget;
        _turnOrder = TurnOrder;
       
	}

    //attack type of turn 
    //not finished
    public void attackTurn(int num)
    {

    }

    //run type of turn
    //not finished
    public void runTurn(int num)
    {

    }

    //compareer to use priority queue
    public int CompareTo(Turn other)
    {
        if (other == null)
        {
            throw new Exception("Incompatable compare types.");
        }
        return turnOrder.CompareTo(other.turnOrder);
    }


}
