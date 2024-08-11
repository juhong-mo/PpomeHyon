using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle = 0,
    Move
}

public enum Action
{
    Tail = 0,
    Smile,
    Smell,
    Observe,
    Curly,
    Nothing
}

public class Hyon : MonoBehaviour
{
    private State state;
    private Action action;

    private float spd;

    private float delay = 1f;
    private Vector3 offset;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        action = Action.Nothing;

        spd = 0.17f;

        offset = transform.position - cam.position;

        transform.Translate(transform.position.x, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FollowCameraWithDelay());
    }

    private void OnMouseDown()
    {
        if (state == State.Idle)
        {
            int rand = Random.Range(0, (int)Action.Nothing);
            action = (Action)rand;
        }
    }
    IEnumerator FollowCameraWithDelay()
    {
        if (state == State.Idle)
        {
            yield return new WaitForSeconds(delay);

            while(true)
            {
                var cameraPos = cam.position;
                var targetPos = new Vector3(cameraPos.x + offset.x, transform.position.y, 0f);

                if(Vector3.Distance(transform.position, targetPos) <= 0.01f)
                {
                    yield break;
                }

                transform.position = Vector3.MoveTowards(transform.position, targetPos, spd * Time.deltaTime / 2);

                yield return null;
            }
        }

    }


    public State getState()
    {
        return state;
    }

    public Action GetAction()
    {
        return action;
    }
}
