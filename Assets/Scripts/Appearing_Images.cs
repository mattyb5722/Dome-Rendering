using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Appearing_Images : MonoBehaviour {

    public RawImage img0;               // Image for scene 1a
    public float img0_sec;              // Amount of time Image 0 is displayed
    public RawImage img1;               // Image for scene 1b
    public float img1_sec;              // Amount of time Image 1 is displayed
    public RawImage img2;               // Image for scene 1c
    public RawImage img3;               // Image for scene 1c
    public float img2_3_sec;            // Amount of time Image 2 and 3 is displayed
    public RawImage img4;               // Image for scene 3
    public RawImage img5;               // Image for scene 3
    private List<float> step = new List<float>(); // Incromentation of image's location
    private List<float> step_degree = new List<float>(); // Incromentation of image's degree
    private List<RawImage> images = new List<RawImage>(); // List of Images

    public AudioSource Scene1_a;        // Audio for Scene1_a
    public AudioSource Scene1_b;        // Audio for Scene1_b
    public AudioSource Scene1_c;        // Audio for Scene1_c
    public AudioSource Scene3_a;        // Audio for Scene3_a
    public AudioSource Scene5_a;        // Audio for Scene5_a
    public AudioSource Scene5_b;        // Audio for Scene5_b
    public AudioSource Scene6_b;        // Audio for Scene6_b

    public GameObject Head;

    public VideoPlayer Maya;
    public VideoPlayer LipSyncPro;


    // Use this for initialization
    void Start () {
        Head.active = false;
        Maya.enabled = false;
        LipSyncPro.enabled = false;

        images.Add(img0);               // Add Image 0 to images
        images.Add(img1);               // Add Image 1 to images
        images.Add(img2);               // Add Image 2 to images

        img3.enabled = false;           // Make image invisiible
        img4.enabled = false;           // Make image invisiible
        img5.enabled = false;           // Make image invisiible

        for (int i = 0; i < images.Count; i++)
        {
            images[i].enabled = false;  // Make image invisiible
        }

        step.Add(1 / (img0_sec * 2));   // Sets step of each image
        step.Add(1 / (img1_sec * 2));   // Sets step of each image
        step.Add(1 / (img2_3_sec * 2)); // Sets step of each image

        for (int i = 0; i < images.Count; i++)
        {
            float num_steps = 40 / step[i];  // Number of steps for each image
            step_degree.Add(90 / num_steps); // Set step_degree for each image
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].enabled == true)  // If the Image is visible 
            {
                Vector3 old_loc = images[i].transform.position; // Old location of image

                if (old_loc[0] > 5)         // Image is on the right side of the screen
                {
                    Vector3 new_loc = new Vector3(old_loc[0] - step[i], old_loc[1], old_loc[2] + step[i]);
                    images[i].transform.position = new_loc;     // Change location
                }
                else if (old_loc[0] > -35)  //Image is on the left side of the screen
                {
                    Vector3 new_loc = new Vector3(old_loc[0] - step[i], old_loc[1], old_loc[2] - step[i]);
                    images[i].transform.position = new_loc;     // Change location
                }
                else
                {
                    images[i].enabled = false;  // Image has moved across screen
                    if (i == 2)                 // Image 2
                    {
                        img3.enabled = false;   // Make image 3 invisible
                    }
                }

                Vector3 old_rot = images[i].transform.eulerAngles;  // Old angle of image
                Vector3 new_rot = new Vector3(old_rot[0], old_rot[1] - step_degree[i], old_rot[2]);
                images[i].transform.eulerAngles = new_rot;          // Change angle
            }
        }

        if (Input.GetKeyDown("1"))
        {
            if (images[0].enabled == false)
            {
                images[0].transform.position = new Vector3(45, 20, 10);
                images[0].transform.eulerAngles = new Vector3(-63, 90, 0);
                images[0].enabled = true;
            }
            else
            {
                images[0].enabled = false;
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            if (images[1].enabled == false)
            {
                images[1].transform.position = new Vector3(45, 20, 10);
                images[1].transform.eulerAngles = new Vector3(-63, 90, 0);
                images[1].enabled = true;
            }
            else
            {
                images[1].enabled = false;
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            if (images[2].enabled == false)
            {
                images[2].transform.position = new Vector3(45, 20, 10);
                images[2].transform.eulerAngles = new Vector3(-63, 90, 0);
                images[2].enabled = true;
                img3.enabled = true;
            }
            else
            {
                images[2].enabled = false;
                img3.enabled = false;
            }
        }
        else if (Input.GetKeyDown("4"))
        {
            if (img4.enabled == false)
            {
                img4.enabled = true;
                img5.enabled = true;
            }
            else
            {
                img4.enabled = false;
                img5.enabled = false;
            }
        }
        else if (Input.GetKeyDown("z"))
        {
            Scene1_a.Play(0);
        }
        else if (Input.GetKeyDown("x"))
        {
            Scene1_b.Play(0);
        }
        else if (Input.GetKeyDown("c"))
        {
            Scene1_c.Play(0);
        }
        else if (Input.GetKeyDown("v"))
        {
            Scene3_a.Play(0);
        }
        else if (Input.GetKeyDown("b"))
        {
            Scene5_a.Play(0);
        }
        else if (Input.GetKeyDown("n"))
        {
            Scene5_b.Play(0);
        }
        else if (Input.GetKeyDown("m"))
        {
            if (Maya.enabled == true)
            {
                Maya.enabled = false;
            }
            else
            {
                Maya.enabled = true;
                Maya.Play();
            }
        }
        else if (Input.GetKeyDown("7"))
        {
            if (LipSyncPro.enabled == true)
            {
                LipSyncPro.enabled = false;
            }
            else
            {
                LipSyncPro.enabled = true;
                LipSyncPro.Play();
            }
        }
        else if (Input.GetKeyDown("6"))
        {
            if (Head.active == true)
            {
                Head.active = false;
            }
            else
            {
                Head.active = true;
            }
        }
    }
}
