using UnityEngine;


public class Enemy : MonoBehaviour
{
	protected int Health = 3;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void Hit()
	{
		Health--;
		if (Health == 0)
			Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "food")
		{
			Hit();
			Destroy(collider.gameObject);
		}
	}
}
