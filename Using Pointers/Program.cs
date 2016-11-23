using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe {
                int x = 100;

                int* ptrX = &x; //sets pointer to memory location where x is held
                Console.WriteLine((int)ptrX); // Displays the memory address
                Console.WriteLine(*ptrX);// Displays the value at the memory address. 

                int y = 200;
                int* ptrY = &y;
                Console.WriteLine((int) ptrY); 
                Console.WriteLine(*ptrY);  
            }
            Console.ReadKey();
        }
    }
}
