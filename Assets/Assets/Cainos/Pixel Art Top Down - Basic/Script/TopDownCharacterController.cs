using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private AudioSource audioSource;

        [SerializeField] private AudioClip[] audioClips;

        private void Start()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                PlaySound();
			}
			else if (Input.GetKey(KeyCode.D))
			{
				dir.x = 1;
				animator.SetInteger("Direction", 2);
                PlaySound();
			}

			if (Input.GetKey(KeyCode.W))
			{
				dir.y = 1;
				animator.SetInteger("Direction", 1);
                PlaySound();
			}
			else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                PlaySound();
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        private void PlaySound()
        {
            if (!audioSource.isPlaying)
				audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
        }
    }
}
