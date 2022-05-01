using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFly : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;

    private float target_x;
    private float target_y;
    private float arrow_x;
    private float arrow_y;
    private float dist;
    private float height;
    private float nextX;
    private float baseY;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        arrow_x = transform.position.x;
        arrow_y = transform.position.y;
        target_x = target.transform.position.x;
        target_y = target.transform.position.y;
        
        dist = arrow_x - target_x;
        nextX = Mathf.MoveTowards(arrow_x, target_x, speed * Time.deltaTime);
        baseY = Mathf.Lerp(arrow_y, target_y, (nextX - arrow_x) / dist);
        height = 2 * (nextX - arrow_x) * (nextX - target_x) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY - height, transform.position.z);
        transform.position = movePosition;
        transform.rotation = LookAtTarget(movePosition - transform.position);
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}
