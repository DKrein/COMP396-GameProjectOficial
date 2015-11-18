using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameManager manager;

    public float moveSpeed;
    public float rotationSpeed = 60f;
    public GameObject deathParticles;
    

    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;

	// Use this for initialization
	void Start () {

        spawn = this.transform.position;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (GetComponent<NetworkView>().isMine)
        {
            GetComponentInChildren<Camera>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<NetworkView>().isMine)
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (this.transform.GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
            {
                this.transform.GetComponent<Rigidbody>().AddRelativeForce(input * moveSpeed);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                this.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0.0f);
            }

            else if (Input.GetKey(KeyCode.E))
            {
                this.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0.0f);
            }

            if (transform.position.y < -5)
            {
                Death();
            }
        }
	
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Death();
        }
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Goal")
        {
			if (manager.keyCount == 4) {
				manager.CompleteLevel();
			}            
        }

		if (other.transform.tag == "Key")
        {
            manager.keyCount += 1; ;
			Destroy(other.gameObject);
        }

		if (other.transform.tag == "Bullet")
        {
            Death();
        }

        if (other.transform.tag == "Enemy")
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
        manager.deathCount += 1;
    }

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = transform.GetComponent<Rigidbody>().position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            transform.GetComponent<Rigidbody>().position = syncPosition;
        }
    }
}
