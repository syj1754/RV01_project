using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Types;
    public GameObject[] Fortifications;
    public int difficulty = 1;
    void Awake(){
    	Instantiate(Fortifications[difficulty-1], new Vector3(0,0,0), Quaternion.identity);
    	int x=4*difficulty+2;
    	int[,] porte = new int[x, x];
    	for(int i=0;i<x;i++){
    		for(int j=0;j<x;j++){
    			porte[i,j]=0;
    			if(i==0){
    				porte[i,j]+=1;
    			}else if(i==x-1 && j!=x/2-1 && j!=x/2){
    				porte[i,j]+=100;
    			}else if(i==x/2 && (j==x/2-1 || j==x/2)){
    				porte[i,j]+=100;
    			}else if(i==x/2+1 && (j==x/2-1 || j==x/2)){
    				porte[i,j]+=1;
    			}
    			if(j==0){
    				porte[i,j]+=10;
    			}else if(j==x-1){
    				porte[i,j]+=1000;
    			}else if(j==x/2-2 && (i==x/2-1 || i==x/2)){
    				porte[i,j]+=10;
    			}else if(j==x/2-1 && (i==x/2-1 || i==x/2)){
    				porte[i,j]+=1000;
    			}else if(j==x/2 && (i==x/2-1 || i==x/2)){
    				porte[i,j]+=10;
    			}else if(j==x/2+1 && (i==x/2-1 || i==x/2)){
    				porte[i,j]+=1000;
    			}
    		}
    	}
    	int[,] blocks = new int[,] { { 100, 110 , 1, 11 } ,
    	{ 1100, 100 , 1001, 1 } ,{ 100, 100 , 1, 1 } , 
    	{ 100, 110 , 1001, 1 } , { 1100, 100 , 1, 11 } ,
		{ 1100, 100 , 1, 1 } ,{ 100, 100 , 1, 11 } ,
		{ 100, 100 , 1001, 1 } , { 100, 110 , 1, 1 } , 
		{ 100, 100 , 11, 1001 } , { 0, 100 , 10, 1001 } ,
		{ 0, 100 , 0, 1 } , { 110, 1100 , 11, 1001 } };
    	for(int i=0;i<4;i++){
    		for(int j=0;j<difficulty*difficulty;j++){
    			float pos=(7-i%4*7f)*(j/difficulty+1);
    			float pos2=(14-i%4*7f)*(j/difficulty+1);
    			if(i==3){
    				pos=0;
    			}else if(i==0){
    				pos2=0;
    			}
    			int seed = (int)System.DateTime.Now.Ticks+j;
    			Random.InitState(seed);
    			int ram = Random.Range(0, 9);
    			if(j%difficulty==0){
    				
    				Instantiate(Types[ram], new Vector3(pos,0f,pos2), Quaternion.Euler(0, 90*((i+1)%2), 0));
    			}
    			pos=7-i%2*14f;
    			pos2=7-i/2*14f;
    			seed = (int)System.DateTime.Now.Ticks+j;
    			Random.InitState(seed);
    			ram = Random.Range(9, 13);
    			Instantiate(Types[ram], new Vector3((j%difficulty+1)*pos,0f,(j/difficulty+1)*pos2), Quaternion.Euler(0, 90*Random.Range(0,4), 0));
    		}
    	}
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
