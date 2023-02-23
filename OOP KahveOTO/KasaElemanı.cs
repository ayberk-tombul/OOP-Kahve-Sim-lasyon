namespace OOP_KahveOTO
{

    // Kasada sipariş alan , ödeme alabilen ve siparişi baristaya aktaran insan


    public class KasaElemanı:AktifÇalışan
    {
        //Properties(Özellikler)
        public Sipariş AktifSiparis { get; set; }
        public List<Ödeme> Ödemeler { get; set; }



        //Methods(İşlemler)
        public void SiparişAl( Müşteri müşteri )
        {
            try
            {
                AktifSiparis = müşteri.SiparişVer();
                ÖdemeAl(müşteri);
                BaristayaSiparişiİlet(AktifÇalışanlar.Instance.BoştaolanBarista());
            }
            catch (ExceptionBoştaOlanBaristaYok ex)
            {

            }
            catch (Exception)
            {

                throw;
            }
            

        }
        public void ÖdemeAl(Müşteri müşteri)
        {

           Ödeme ödeme = müşteri.ÖdemeYap(AktifSiparis.TotalCost);
           Ödemeler.Add(ödeme);

        }

        public void BaristayaSiparişiİlet(Barista barista)
        {
            barista.SiparişiÜret(AktifSiparis);
            AktifSiparis = null;
            //Tekrar sipariş almaya başlayabilirim.
            if (Kasaboş != null)
            {
                Kasaboş(this, null);
            }

        }

        //Events(İlanları-Cevapları)


        //delagate
        public delegate void onKasaboş(object sender,EventArgs args);
        public event onKasaboş Kasaboş;



        //Constructor(Yaratım)

        public KasaElemanı()
        {
            Ödemeler = new List<Ödeme>();
        }



    }
}