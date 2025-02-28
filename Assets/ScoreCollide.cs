using Unity.VisualScripting;
using UnityEngine;

public class ScoreCollide : MonoBehaviour
{
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
    logic.addScore(1);
    }
}
