using System;

namespace recursive_extension_metotlar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rekürsif - Öz yinelemeli fonk(kendi kendini çağıran)
            //3^4 üsttünü alma işlemi = 3*3*3*3
            int result = 1; //result burada çarpan elemanlarını tutacak
            for(int i =1; i<5; i++)
            result = result *3;
            Console.WriteLine(result);
            //unutmayalım altta oluşturduğumuz claasın instance almayı
            Islemler instance = new();
            Console.WriteLine(instance.Expo(3,4));

            //Extension Metotlar
            string ifade = "Osman Batuhan Kalkan";
            bool sonuc = ifade.CheckSpaces();
            Console.WriteLine(sonuc);
            if(sonuc)
                Console.WriteLine(ifade.RemoveWhiteSpaces());
            
            Console.WriteLine(ifade.MakeLowerCase());
            Console.WriteLine(ifade.MakeUpperCase());

            int[] dizi ={9,3,6,2,1,5,0};
            dizi.SortArray();
            dizi.EkranaYazdir();
        }
    }
    public class Islemler{

        public int Expo(int sayi, int üs)
        {   
            if(üs<2)
            return sayi;
            return Expo(sayi,üs-1)*sayi;
        }
        //Expo(3,4)
        //Expo(3,3)*3;
        //Expo(3,2)*3*3;
        //Expo(3,1)*3*3*3;
        //3*3*3*3=3^4; çıktı

        //Extension
        //burada bilmemiz gereken extension classlar ve metotlar static olmalı !!!
        //static olmazsa erişemeyiz, nesenesi olmadan erişebilmemiz lazım
        //hadi boşluk kontorolu yapan bir metod oluşturalım
    }
    public static class Extension{
        public static bool CheckSpaces(this string param)
        {
            return param.Contains(" ");
        }
        public static string RemoveWhiteSpaces(this string param)
        {
            string[] dizi = param.Split(" "); //bu diziyi boşluklara ayır ve bir dizi yaz dedim
            return string.Join("*",dizi); // burada joinle birleştir dedim
        }
        //Büyük harfe çeviren başka bir extension yazalım
        public static string MakeUpperCase(this string param)
        {
            return param.ToUpper();

        }
        //küçük harfe çevir
         public static string MakeLowerCase(this string param)
        {
            return param.ToLower();

        }
        //Sıralayan bir extensiona ihtiyaç var hemen yaratalım
        public static int [] SortArray(this int[] param)
        {
            //diziler array sınıfından türemiştir
            Array.Sort(param);
            return param;
        }
        //integer diziyi erkana yazdıran bir ex aşşağıda void kullanma nedemimiz erkana tekrar dönmeyeceği için
        public static void EkranaYazdir(this int[] param)
        {
            foreach (int item in param)
            Console.WriteLine(item);
        }
    }
}