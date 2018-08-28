using crud_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace crud_console
{
    class Program
    {
        static void Main(string[] args)
        {
            int pil;
            Console.WriteLine("==============================================");
            Console.WriteLine("|                   MENU                     |");
            Console.WriteLine("==============================================");
            Console.WriteLine("| 1. Mahasiswa                               |");
            Console.WriteLine("| 2. Jurusan                                 |");
            Console.WriteLine("==============================================");
            Console.WriteLine("\n");
            Console.Write("Tentukan Pilihanmu : ");pil = Convert.ToInt32(Console.ReadLine());
            
            switch (pil)
            {
                case 1:
                    MahasiswaController panggilmhs = new MahasiswaController();
                    panggilmhs.mahasiswa_page();
                    break;

                case 2:
                    MajorController panggiljur = new MajorController();
                    panggiljur.major_page();
                    break;
                default:
                    break;
            }
        }
    }

    

}
