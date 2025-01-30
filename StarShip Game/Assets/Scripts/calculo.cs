using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum SinalMat {somar,subtrair,multiplicar,dividir, potenciar}

public class calculo : MonoBehaviour
{

    // Variaveis

    public int value = 10;  // valores inteiros 0,1,2,3
    float fValue;   // valores fracionados 0.1, 0.2

    public bool isBooleana;

    string texto;
    char c = 'f';

    // tipos no Unity

    Transform trans;
    Camera cam;

    // array e lista
    public int [] arrayDeInts;      // array de int 1,2,3,4,5

    public List<int> listaDeInts;   // lista de int 1,2,3,4,5
    
    void Awake() {
        print("Valor: " + value);
        print("Valor Fracionado: " + fValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        // print("Valor:" + value);

        // fValue = 108.95f;
        // print("Valor fracionado: " + fValue);

        //listaDeInts = new int[7];

        print("Resultado da lista: " + subtrair(listaDeInts));

    }

    // Update is called once per frame
    void Update(){

        // && =  condicao1 E condicao2
        // || = condicao1 OU condicao2
        // condicao1 E (condicao2 OU condicao3)
        
        // if(isBooleana || value >= 2){
        //     somar(1,1);
        // }else if(!isBooleana || value > 2){
        //     print("Subtração: " + subtrair(10,1));
        // }else{
        //     print("Resultado: " + value);
        // }

        //print("Resultado do calculo: " + calc(5,5, SinalMat.potenciar));
        
        //print("Resultado usando array: " + somar(arrayDeInts));
        
    }

    void somar(){
        value = 10 + 1;
        print("Resultado: " + value);
    }

    float somar(int[] ai){
        float r = 0f;

        // p1 = 0, p2 = 1

        foreach (int arrayDeNumeros in ai){
            r += arrayDeNumeros;
        }

        return r;
    }

    void somar(int v1, int v2){
        value = v1 + v2;
        print("Soma: " + value);
    }

    void subtrair(){
        value = 10 - 1;
        print("Resultado: " + value);
    }

    float subtrair(List<int> lt){
        int r = 0;

        listaDeInts[0] = 100;

        listaDeInts.Add(20);

        foreach (int listaDeNumeros in lt){
            r -= listaDeNumeros;
        }

        //listaDeInts.Remove(listaDeInts[3]);

        return r;
    }

    int subtrair(int v1, int v2){
        value = v1 - v2;
        return value;
    }

    

    float calc(float v1, float v2, string c){
        float r = 0f;

        if(c.Equals("+") || c.Equals("soma")){
            r = v1 + v2;
        }else if(c.Equals("-") || c.Equals("subtrai")){
            r = v1 - v2;
        }else if(c.Equals("*") || c.Equals("multiplica")){
            r = v1 * v2;
        }else if(c.Equals("/") || c.Equals("divide")){
            r = v1 / v2;
        }else{
            r = 0f;
        }

        return r;
    }

    float calc(float v1, float v2, SinalMat sm){
        float r = 0f;
        switch (sm)
        {
            case SinalMat.somar:
                r = v1 + v2;
            break;
            case SinalMat.subtrair:
                r = v1 - v2;
            break;
            case SinalMat.multiplicar:
                r = v1 * v2;
            break;
            case SinalMat.dividir:
                r = v1 / v2;
            break;
            case SinalMat.potenciar:
                // v1 = base | v2 = expoente
                r = 1f;
                for(int i = 0;  i < v2; i++){
                    r *= v1;
                    // 5x1 = r=5
                    // 5x5 = r=25
                    // 25x5 = r=125
                    // 125x5 = r=625
                    // 625x5 = r=3125
                }

                
            break;
            default:
                r = 0f;
            break;
            
        }

        return r;
    }

}
