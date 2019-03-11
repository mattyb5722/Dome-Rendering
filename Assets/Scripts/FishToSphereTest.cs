using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FishToSphereTest : MonoBehaviour {

    Vector3[] verts;
    Vector2[] uvs;
    int[] triangles;
    Mesh mesh;

    float PID2 = Mathf.PI / 2;
    int NX = 100;
    int NY = 60;

	// Use this for initialization
	void Start () {
        verts = new Vector3[6000];
        uvs = new Vector2[6000];
        Generate();
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate(){
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();


        //string file = System.IO.File.ReadAllText(Application.dataPath + "/Resources/standard_16x9.data");

        string file = Resources.Load<TextAsset>("standard_16x9").text;
        string[] lines = file.Split('\n');
        // 6003 lines long, 2 intro, 6000 meaningful, one blank
        for (int i = 0; i < 6000; i++)
        {
            string[] lineData = lines[i + 2].Trim().Split();
            verts[i].x = float.Parse(lineData[0]);
            verts[i].y = float.Parse(lineData[1]);
            verts[i].z = 0f;
            uvs[i].x = float.Parse(lineData[2]);
            uvs[i].y = float.Parse(lineData[3]);
            //yield return null;
        }
        mesh.vertices = verts;
        mesh.uv = uvs;

        int xSize = 99;
        int ySize = 59;

        triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }

        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.black;
    //    for (int i = 0; i < verts.Length; i++)
    //    {
    //        Gizmos.DrawSphere(verts[i], 0.005f);
    //    }
    //}



    //int i, j;
    //float x, y, u, v;
    //Vector3 p;
    //float theta, phi, r;

    //for (j = 0; j <= NY; j++)
    //{
    //    for (i = 0; i <= NX; i++)
    //    {
    //        x = -1 + 2 * i / (float)NX;
    //        y = -1 + 2 * j / (float)NY;
    //        theta = PID2 + x * PID2;
    //        phi = y * PID2;
    //        p.x = Mathf.Cos(phi) * Mathf.Cos(theta);
    //        p.y = Mathf.Cos(phi) * Mathf.Sin(theta);
    //        p.z = Mathf.Sin(phi);
    //        theta = Mathf.Atan2(p.z, p.x);
    //        phi = Mathf.Atan2(Mathf.Sqrt(p.x * p.x + p.z * p.z), p.y);
    //        r = phi / PID2;
    //        u = (1 + r * Mathf.Cos(theta)) / 2;
    //        v = (1 + r * Mathf.Sin(theta)) / 2;
    //        //print(string.Format("{0} {1} {2} {3} 1\n", x, y, u, v));
    //    }
    //}
}
