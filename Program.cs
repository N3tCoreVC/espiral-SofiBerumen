using System;

namespace espiral_SofiBerumen
{
    class Program
    {
        static void imprimirEspi(char[,] arreglo){
            for (int contY = 0; arreglo.GetLength(0) > contY; contY++ )  {
                for (int contX = 0; arreglo.GetLength(1) > contX; contX++ ){
                    Console.Write(arreglo[contX,contY].ToString());
                }   
                Console.Write("\n");             
            }            
        }

        static char[,] crearArreglo(int tam){
            char[,] mat = new char[tam,tam]; 
             for (int contY = 0; mat.GetLength(0) > contY; contY++ )  {
                for (int contX = 0; mat.GetLength(1) > contX; contX++ ){
                    mat[contX,contY] = ' ';
                }                
            }
            return mat;
        }

        static char[,] generarEspi(int tot){
            int X = 0;
            int Y = 0;
            int tamX = tot;
            int tamY = tot;
            int vue = tot; 
            char direc = 'L';
            char[,] espi = crearArreglo(tot);
            // pinto derecha uno y abajo dos 
            for(int i=0; i<tamX; i++){
                espi[X,Y]=('|');
                X++;
            }
            X--;
            for(int j=0; j<tamY; j++){
                espi[X,Y]=('|');
                Y++;
            }
            tamX--;
            tamY--;            
            Y--;

            for (int contVueltas = 1; contVueltas <= vue-2; contVueltas++) {
                if (direc == 'R') {
                    for (int i = 0; i < tamX; i++ ) {
                        espi[X,Y]='|';
                        X++;
                    }
                    X--;
                    tamX--;
                    tamY--;
                    direc = 'D';                   
                } else if (direc == 'D') {
                    for (int i = 0; i < tamY; i++ ) {
                        espi[X,Y]='|';
                        Y++;
                    }
                    Y--;
                    tamX--;
                    tamY--;                    
                    direc = 'L';                      
                } else if (direc == 'L') {  
                    for (int i = 0; i < tamX; i++ ) {
                        espi[X,Y]='|';
                        X--;
                    }
                    X++;
                    tamX--;
                    tamY--;
                    direc = 'U';  
                } else if (direc == 'U') {  
                    for (int i = 0; i < tamY; i++ ) {
                        espi[X,Y]='|';
                        Y--;
                    }
                    Y++;
                    tamX--;
                    tamY--;
                    direc = 'R';                    
                } 
            }
            return espi;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Dame base espiral: ");
            int n = 0;
            int.TryParse(Console.ReadLine(), out n);
            
            imprimirEspi(generarEspi(n));
        }
    }
}
