using UnityEngine;

public class fsm2d : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    public State currentState;
    public Transform player;
    public float chaseDistance = 3f;
    public float speed = 2f;
    public float attackDistance = 2f;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Idle:

                if (distance < chaseDistance)
                {
                    currentState = State.Chase;
                }

                break;

            case State.Chase:

                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                if (distance < attackDistance)
                {
                    currentState = State.Attack;
                }

                break;

            case State.Attack:

                Debug.Log("Enemy Attack On");

                if (distance > attackDistance)
                {
                    currentState = State.Chase;
                }

                break;
        }
    }
}