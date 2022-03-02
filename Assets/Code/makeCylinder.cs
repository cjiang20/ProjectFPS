using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class makeCylinder : MonoBehaviour
{
    public bool isFlat = false;
    private bool flatness;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        flatness = isFlat;
        meshFilter.mesh = MakeCyl();
    }
    void Update()
    {
        if (flatness!= isFlat) {
            flatness = isFlat;
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            meshFilter.mesh = MakeCyl();
        }

    }

    Mesh MakeCyl()
    {
        int totalTriangles = 144;
        Vector3[] verts = new Vector3[totalTriangles*3];
        Vector3[] norms = new Vector3[totalTriangles*3];
        int[] tris = new int[totalTriangles*3];
        double theta = (Math.PI)/12;
        if (isFlat == false) {
            for (int x = 0; x < 24; x++) {
                verts[x*2] = new Vector3((float)Math.Cos(x*theta), 1, (float)Math.Sin(x*theta));
                verts[x*2+1] = new Vector3((float)Math.Cos((x+1)*theta), 0, (float)Math.Sin((x+1)*theta));
                norms[x*2] = new Vector3((float)Math.Cos(x*theta), 0, (float)Math.Sin(x*theta));
                norms[x*2+1] = new Vector3((float)Math.Cos((x+1)*theta), 0, (float)Math.Sin((x+1)*theta));
             }
             for (int x = 24; x < 48; x++) {
                verts[x*2] = new Vector3((float)Math.Cos(x*theta), 0, (float)Math.Sin(x*theta));
                verts[x*2+1] = new Vector3((float)Math.Cos((x+1)*theta), 0, (float)Math.Sin((x+1)*theta));
                norms[x*2] = new Vector3(0,-1,0);
                norms[x*2+1] = new Vector3(0,-1,0);
             }
             for (int x = 48; x < 72; x++) {
                verts[x*2] = new Vector3((float)Math.Cos(x*theta), 1, (float)Math.Sin(x*theta));
                verts[x*2+1] = new Vector3((float)Math.Cos((x+1)*theta), 1, (float)Math.Sin((x+1)*theta));
                norms[x*2] = new Vector3(0,1,0);
                norms[x*2+1] = new Vector3(0,1,0);
             }
             verts[144] = new Vector3(0,0,0);
             verts[145] = new Vector3(0,1,0);
             norms[144] = new Vector3(0,-1,0);
             norms[145] = new Vector3(0,1,0);

            for (int x = 0; x < 24; x++) {
                tris[x*3] = x*2+1;
                tris[x*3+1] = x*2;
                tris[x*3+2] = (x*2+2)%48;

            }
            for (int x = 24; x < 48; x++) {
                tris[x*3] = (x*2+1)%48;
                tris[x*3+1] = (x*2+2)%48;
                tris[x*3+2] = (x*2+3)%48;
            }
            
            for (int x = 0; x < 48; x++) {
                tris[x*3 + 144] = 48+x;
                tris[x*3 + 145] = 49+x;
                if (x == 47) {
                    tris[x*3 + 145] = 48;
                }
                tris[x*3 + 146] = 144;
            }
            
            for (int x = 0; x < 48; x++) {
                tris[x*3 + 288] = 97+x;
                tris[x*3 + 289] = 96+x;
                if (x == 47) {
                    tris[x*3 + 288] = 96;
                }
                tris[x*3 + 290] = 145;
            }
        }
        else {
            for (int x = 0; x < 24; x++) {
                verts[x*4] = new Vector3((float)Math.Cos(x*theta), 1, (float)Math.Sin(x*theta));
                verts[x*4+1] = new Vector3((float)Math.Cos(x*theta), 0, (float)Math.Sin(x*theta));
                verts[x*4+2] = new Vector3((float)Math.Cos((x+1)*theta), 1, (float)Math.Sin((x+1)*theta));
                verts[x*4+3] = new Vector3((float)Math.Cos((x+1)*theta), 0, (float)Math.Sin((x+1)*theta));
                norms[x*4] = new Vector3((float)Math.Cos((x+0.5)*theta), 0, (float)Math.Sin((x+0.5)*theta));
                norms[x*4+1] = new Vector3((float)Math.Cos((x+0.5)*theta), 0, (float)Math.Sin((x+0.5)*theta));
                norms[x*4+2] = new Vector3((float)Math.Cos((x+0.5)*theta), 0, (float)Math.Sin((x+0.5)*theta));
                norms[x*4+3] = new Vector3((float)Math.Cos((x+0.5)*theta), 0, (float)Math.Sin((x+0.5)*theta));
             }
             for (int x = 48; x < 72; x++) {
                verts[x*2] = new Vector3((float)Math.Cos(x*theta), 0, (float)Math.Sin(x*theta));
                verts[x*2+1] = new Vector3((float)Math.Cos((x+1)*theta), 0, (float)Math.Sin((x+1)*theta));
                norms[x*2] = new Vector3(0,-1,0);
                norms[x*2+1] = new Vector3(0,-1,0);
             }
             for (int x = 72; x < 96; x++) {
                verts[x*2] = new Vector3((float)Math.Cos(x*theta), 1, (float)Math.Sin(x*theta));
                verts[x*2+1] = new Vector3((float)Math.Cos((x+1)*theta), 1, (float)Math.Sin((x+1)*theta));
                norms[x*2] = new Vector3(0,1,0);
                norms[x*2+1] = new Vector3(0,1,0);
             }
             verts[192] = new Vector3(0,0,0);
             verts[193] = new Vector3(0,1,0);
             norms[192] = new Vector3(0,-1,0);
             norms[193] = new Vector3(0,1,0);

            for (int x = 0; x < 24; x++) {
                tris[x*6] = x*4;
                tris[x*6+1] = x*4+2;
                tris[x*6+2] = x*4+1;
                tris[x*6+3] = x*4+3;
                tris[x*6+4] = x*4+1;
                tris[x*6+5] = x*4+2;
            }
        
            for (int x = 0; x < 48; x++) {
                tris[x*3 + 144] = 96+x;
                tris[x*3 + 145] = 97+x;
                if (x == 47) {
                    tris[x*3 + 145] = 96;
                }
                tris[x*3 + 146] = 192;
            }
            
            for (int x = 0; x < 48; x++) {
                tris[x*3 + 288] = 145+x;
                tris[x*3 + 289] = 144+x;
                if (x == 47) {
                    tris[x*3 + 288] = 144;
                }
                tris[x*3 + 290] = 193;
            }
        }
        Mesh mesh = new Mesh();

        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.normals = norms;

        return mesh;
    }


}
