using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private float uTurn = 180;
    public float maxDistance = 3;
    public float movespeed = 10;
    public GameObject collider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        RaycastHit hit;
        Physics.Raycast(collider.transform.position, transform.right , out hit);

        //Will flip his own direction when next to an obstacle, unless it's facing the Player
        if (hit.distance > maxDistance
            || hit.transform.tag.Equals("Player")
            || hit.transform.tag.Equals("ShieldOrc")
            || hit.transform.tag.Equals("Floor"))
          //  || hit.transform.tag.Equals("Inimigo"))
           // || hit.transform.tag.Equals("Nothing"))

            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        else
            transform.eulerAngles += new Vector3(0, uTurn, 0);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag.Equals("Player"))
            GameManager.ResetStage();
    }


}
