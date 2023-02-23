using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KahveOTO
{

    // Kasadan sipariş alan ve siparişi üretip teslim eden insan.


    public class Barista:AktifÇalışan
    {
        //Properties(Özellikler)
        public bool isBoşta { get; set; } = true;



        //Methods(İşlemler)

        public void SiparişiÜret(Sipariş sipariş)
        {
            isBoşta = false;

            //siparişi üret

            isBoşta = true;
        }



        //Events(İlanları-Cevapları)




        //Constructor(Yaratım)

        public Barista()
        {
            isBoşta = true;
        }



    }
}
