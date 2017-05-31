using UnityEngine;

public class EnemyIA2 : MonoBehaviour
{
    private new Collider collider;
    private float uTurn = 180;
    public float maxDistance = 3;
    public float movespeed = 10;
    public float maxHP = 100;
    public float currentHP = 100;
    public float armor = 15;		//Reduces N of damage

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<Collider>();

        //Fixes currentHP with maxHP if needed
        currentHP = currentHP > maxHP ? maxHP : currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        RaycastHit hit;
        Physics.Raycast(collider.transform.position, transform.right, out hit);

        //Will flip his own direction when next to an obstacle, unless it's facing the Player
        if (hit.distance > maxDistance
            || hit.transform.tag.Equals("Player")
            || hit.transform.tag.Equals("Floor"))

            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        else
            transform.eulerAngles += new Vector3(0, uTurn, 0);
    }

    private void OnColliderEnter(Collision col)
    {
        if (col.transform.tag.Equals("Player"))
            GameManager.ResetStage();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag.Equals("Bullet"))
        {
            float damage = col.transform.GetComponent<Bullet>().damage;

            TakeDamage(damage);

            if (currentHP <= 0)
                Destroy(gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHP = currentHP - (damage - armor);
    }
}
