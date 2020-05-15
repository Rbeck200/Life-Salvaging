using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    //player unit
    private UnitStats _player;
    //enemy unit
    private UnitStats _enemy;
    //amount to add to weight each time
    private int skipamt;
    //was an action picked
    private bool actnPicked = false;

    //priority queue
    PriorityQueue<Turn> turns = new PriorityQueue<Turn>();

    //buttons
    [SerializeField]
    private Button mainBtn, scndBtn;

    void Start()
    {
        //creates a new player and assigns it to the private variable.
        UnitStats player = new UnitStats(2, true);
        _player = player;
      
        //creates a new enemy and assigns it to the private variable
        UnitStats newEnemy = new UnitStats(player.lvl, false);
        _enemy = newEnemy;

        //establishes turn order
        UnitStats First = _player;
        UnitStats Second = _enemy;

        //change turn order if enemy is faster
        if(_player.spd < _enemy.spd)
        {
            UnitStats Temp = First;
            First = Second;
            Second = Temp;
            
        }

        // put turns into priority queue
        Turn playerTurn = new Turn(First, Second, turns.GetSize() + 1);
        turns.enqueue(playerTurn);
        Turn enemyTurn = new Turn(Second, First, turns.GetSize() + 1);
        turns.enqueue(enemyTurn);

        //set skip amount
        skipamt = turns.GetSize();

        //keep progessing until death
        while(_player.isDead() == false && _enemy.isDead() == false)
        {
            nextTurn();
        }

    }

    //next turn
    void nextTurn()
    {
        //dequeue turn
        Turn current = turns.Dequeue();
        //pick rand number to see if action succeeds 
        int rand;
        while (!actnPicked)
        {
            //attack ation
            mainBtn.onClick.AddListener(delegate
            {
                rand = UnityEngine.Random.Range(1, 11);
                current.attackTurn(rand);
                actnPicked = true;
            });

            //run action
            scndBtn.onClick.AddListener(delegate
            {
                rand = UnityEngine.Random.Range(1, 11);
                current.runTurn(rand);
                actnPicked = true;
            });
            break;
        }
        //add skip amount to weight 
        current.turnOrder += skipamt;
        //enqueue turn
        turns.enqueue(current);

    }

    //create buttons not finshed
    public void createButtons()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
