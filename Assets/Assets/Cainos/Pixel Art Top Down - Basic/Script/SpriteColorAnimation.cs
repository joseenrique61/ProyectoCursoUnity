using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //animate the sprite color base on the gradient and time
    public class SpriteColorAnimation : MonoBehaviour
    {
        public Gradient gradient;
        public float time;

        private SpriteRenderer sr;
        private float timer;

        private bool playerInRange = false;

        private AudioSource audioSource;

        private void Start()
        {
            timer = time * Random.value;
            sr = GetComponent<SpriteRenderer>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (playerInRange)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }

            if (timer > time) return;
			if (timer < 0) timer = 0.0f;

			sr.color = gradient.Evaluate(timer / time);
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
            {
                playerInRange = true;
                audioSource.PlayOneShot(audioSource.clip);
            }
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
            {
                playerInRange = false;
            }
		}
	}
}
