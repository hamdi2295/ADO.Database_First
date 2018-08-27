using crud_console.Koneksi;
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

    public class MahasiswaController
    {
        Koneksi.universityEntities4 _context = new Koneksi.universityEntities4();


        public void mahasiswa_page()
        {
            int pilih;
            Console.Clear();
            Console.WriteLine("SELAMAT DATANG DI HALAMAN MAHASISWA");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Save (Insert)");
            Console.WriteLine("2. Update Data");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. View All Data");
            Console.WriteLine("\n");
            Console.Write("Pilih Nomor : "); pilih = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            switch (pilih)
            {
                case 1:
                    Save();
                    System.Console.Read();
                    break;
                case 2:
                    Console.WriteLine("Masukkan ID Mahasiswa yang akan di update : "); int input = Convert.ToInt32(Console.ReadLine());
                    Update(input);
                    System.Console.Read();
                    break;
                case 3:
                    System.Console.Write("Masukkan Id yang ingin di hapus : "); input = Convert.ToInt32(System.Console.ReadLine());
                    Delete(input);
                    System.Console.Read();
                    break;
                case 4:
                    GetAll();
                    break;
            } 
        }
        public void Save()
        {
            System.Console.WriteLine("          Insert Data Mahasiswa          ");
            System.Console.WriteLine("-----------------------------------------");
            System.Console.Write("ID Mahasiswa       : "); int ID_Mahasiswa = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Nama Mahasiswa     : "); string Nama_Mahasiswa = System.Console.ReadLine();
            System.Console.Write("Alamat Mahasiswa   : "); string Alamat_Mahasiswa = System.Console.ReadLine();
            System.Console.Write("Jenis Kelamin      : "); string jekel = System.Console.ReadLine();
            System.Console.Write("Jurusan            : "); string jurusan = System.Console.ReadLine();

            Koneksi.student call = new Koneksi.student();
            {
                call.student_id = ID_Mahasiswa;
                call.name = Nama_Mahasiswa;
                call.address = Alamat_Mahasiswa;
                call.gender = jekel;
                call.major_id = jurusan;
                
            };
            try
            {
                _context.students.Add(call);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public List<Koneksi.student> GetAll()
        {
            var getall = _context.students.ToList();
            foreach (Koneksi.student mahasiswa in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Id Mahasiswa        : " + mahasiswa.student_id);
                System.Console.WriteLine("Nama Mahasiswa      : " + mahasiswa.name);
                System.Console.WriteLine("Alamat Mahasiswa    : " + mahasiswa.address);
                System.Console.WriteLine("Jenis Kelamin       : " + mahasiswa.gender);
                System.Console.WriteLine("Jurusan             : " + mahasiswa.major_id);
                System.Console.WriteLine("================");
            }
            Console.ReadKey(true);
            return getall;
            
        }

        public int Update(int input)
        {
            
            System.Console.Write("Nama Mahasiswa     : "); string Nama_Mahasiswa = System.Console.ReadLine();
            System.Console.Write("Alamat Mahasiswa   : "); string Alamat_Mahasiswa = System.Console.ReadLine();
            System.Console.Write("Jenis Kelamin      : "); string jekel = System.Console.ReadLine();
            System.Console.Write("Jurusan            : "); string jurusan = System.Console.ReadLine();
            Koneksi.student mahasiswa = GetById(input);
            mahasiswa.name = Nama_Mahasiswa;
            mahasiswa.address = Alamat_Mahasiswa;
            mahasiswa.gender = jekel;
            mahasiswa.major_id = jurusan;

            _context.Entry(mahasiswa).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public int Delete(int input)
        {
            student mahasiswa = GetById(input);
            _context.SaveChanges();
            _context.SaveChanges();
            return input;
        }

        public Koneksi.student GetById(int input)
        {
            var mahasiswa = _context.students.Find(input);
            if (mahasiswa == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            return mahasiswa;
        }

    }


    public class Major
    {
     
    }

}
