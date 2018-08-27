using crud_console.Koneksi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_console
{
    class MajorController
    {
        Koneksi.universityEntities4 _context = new Koneksi.universityEntities4();

        public void major_page()
        {
            int pil;
            Console.Clear();
            Console.WriteLine("SELAMAT DATANG DI HALAMAN JURUSAN  ");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Save (Insert)");
            Console.WriteLine("2. Update Data");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. View All Data");
            Console.WriteLine("\n");
            Console.Write("Pilih Nomor : "); pil = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            switch (pil)
            {
                case 1:
                    Save();
                    Console.Read();
                    break;
                case 2:
                    Console.WriteLine("Masukkan ID Jurusan yang akan di update : "); int input = Convert.ToInt32(Console.ReadLine());
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
                default:
                    
                    break;
            }
        }

        public void Save()
        {
            System.Console.WriteLine("          Insert Data Jurusan            ");
            System.Console.WriteLine("-----------------------------------------");
            System.Console.Write("ID jurusan       : "); int ID_Jurusan = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Nama Jurusan     : "); string Nama_Jurusan = System.Console.ReadLine();
            
            Koneksi.major call = new Koneksi.major();
            {
                call.major_id = ID_Jurusan;
                call.major_name = Nama_Jurusan;
                
            };
            try
            {
                _context.majors.Add(call);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public int Update(int input)
        {

            System.Console.Write("Nama Jurusan     : "); string Nama_Jurusan = System.Console.ReadLine();

            Koneksi.major jurusan = GetById(input);
            jurusan.major_name = Nama_Jurusan;
            
            _context.Entry(jurusan).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public List<Koneksi.major> GetAll()
        {
            var getall = _context.majors.ToList();
            foreach (Koneksi.major jurusan in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Id Jurusan        : " + jurusan.major_id);
                System.Console.WriteLine("Nama Jurusan      : " + jurusan.major_name);
            }
            Console.ReadKey(true);
            return getall;

        }


        public Koneksi.major GetById(int input)
        {
            var jurusan = _context.majors.Find(input);
            if (jurusan == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            return jurusan;
        }

        public int Delete(int input)
        {
            Major jurusan = GetById(input);
            _context.SaveChanges();
            _context.SaveChanges();
            return input;
        }
    }
}
